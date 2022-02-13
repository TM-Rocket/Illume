using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float _jumpHeight = 1f;
    [SerializeField] private float zPosition = 0f;
    private CharacterController _controller;
    private PlayerInput _playerInput;
    private InputAction _movementAction;
    private InputAction _jumpAction;
    private Vector3 _move;
    private Vector3 _playerVelocity;
    private Vector3 _movementOffset;
    private bool _groundedPlayer;
    private Animator _animator;
    private int _isRunningHash;
    private int _isJumpingHash;

    // Start is called before the first frame update
    void Start() {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        _movementAction = _playerInput.actions["Movement"];
        _jumpAction = _playerInput.actions["Jump"];

        // Animation bool values
        _isRunningHash = Animator.StringToHash("isRunning");
        _isJumpingHash = Animator.StringToHash("isJumping");
    } 

    // Update is called once per frame
    void Update() {

        // Checks if player is grounded, if so changes Jumping animation value.
        if (_groundedPlayer && _playerVelocity.y < 0) {
            _animator.SetBool(_isJumpingHash, false);
            _playerVelocity.y = 0f;
        }

        if(transform.position.z != zPosition) {
            _movementOffset.z = (zPosition - transform.position.z) * 0.05f;
        }
        _controller.Move(_movementOffset); // Apply force to pull player back to desired Z-axis value

        //Player Movement and animation read from input
        Vector2 input = _movementAction.ReadValue<Vector2>();
        _move = new Vector3(input.x, 0, 0);
        _controller.Move(_move * Time.deltaTime * 5); // Move player using _move vector from player input
        if (_move.x == 0) {
            _animator.SetBool(_isRunningHash, false);
        } else {
            _animator.SetBool(_isRunningHash, true);
            transform.rotation = Quaternion.LookRotation(_move); // Makes sure Player is facing the correct direction
        }

        // Player jump input and animation
        if (_jumpAction.triggered && _groundedPlayer) {
            _animator.SetBool(_isJumpingHash, true);
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -7.0f * -9.81f); // Jump + gravity
        }

        _playerVelocity.y += -40f * Time.deltaTime; // Brings player back down to ground
        _controller.Move(_playerVelocity * Time.deltaTime); // Move player after calculating Y vector

        _groundedPlayer = _controller.isGrounded; // Character controller grounded check
    }
}
