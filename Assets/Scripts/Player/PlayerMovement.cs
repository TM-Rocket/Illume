using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float _jumpHeight = 1f;
    [SerializeField] private float _pushPower = 2f;
    [SerializeField] private float zPosition = 0f;
    [SerializeField] private ParticleSystem _waterFlow;
    private CharacterController _controller;
    private PlayerInput _playerInput;
    private InputAction _movementAction;
    private InputAction _jumpAction;
    private InputAction _interactAction;
    private InputAction _waterAction;
    private Vector3 _move;
    private Vector3 _playerVelocity;
    private Vector3 _movementOffset;
    private bool _groundedPlayer;
    private Animator _animator;
    private int _isRunningHash;
    private int _isJumpingHash;

    private void Start() {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        _movementAction = _playerInput.actions["Movement"];
        _jumpAction = _playerInput.actions["Jump"];
        _waterAction = _playerInput.actions["WaterAction"];

        // Animation bool values
        _isRunningHash = Animator.StringToHash("isRunning");
        _isJumpingHash = Animator.StringToHash("isJumping");
    } 

    private void Update() {

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


        if (_waterAction.triggered) {
            _waterFlow.Play();
        }

        _groundedPlayer = GroundedCheck(); // Character controller grounded check
    }

    private bool GroundedCheck() //check if the player is touching the ground or very close to touching the ground
    {
        if (_controller.isGrounded) //built-in controller is grounded check
        {
            return true;
        }

        RaycastHit hit; //creates raycast "hit"

        //if the bottom of the player is within 0.2m of the ground and the player is not currently moving up
        if (Physics.Raycast(_controller.transform.position, new Vector3(0, -1, 0), out hit, 0.2f) && _playerVelocity.y <= 0)
        {
            //move the player down the distance of the raycast hit
            _controller.Move(new Vector3(0, -hit.distance, 0));
            return true;
        }

        return false;

    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;    

        // No pushable Rigidbody exists
        if (body == null || body.isKinematic) {
            return;
        }

        // Don't push objects below the character
        if (hit.moveDirection.y < -0.3) {
            return;
        }

        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDirection * _pushPower;
    }
}