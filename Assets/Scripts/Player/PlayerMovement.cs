using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float _jumpHeight = 1f;
    [SerializeField] private float _pushPower = 2f;
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
    private int _soundState;

    public bool IsFrozen = false;

    private void Start() {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();

        _movementAction = _playerInput.actions["Movement"];
        _jumpAction = _playerInput.actions["Jump"];

        // Animation bool values
        _isRunningHash = Animator.StringToHash("isRunning");
        _isJumpingHash = Animator.StringToHash("isJumping");
    } 

    private void Update() {
        if (!IsFrozen && _controller.enabled)
            {
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

            if (_move.x == 0 || !_groundedPlayer) {
                _animator.SetBool(_isRunningHash, false);
                StopFootStep();
                _soundState = 0;
            } else if (_move.x != 0) {
                PlayFootStep();
                _animator.SetBool(_isRunningHash, true);
                transform.rotation = Quaternion.LookRotation(_move); // Makes sure Player is facing the correct direction
            }

            // Player jump input and animation
            if (_jumpAction.triggered && _groundedPlayer) {
                AudioManager.Instance.Play("jump");
                _animator.SetBool(_isJumpingHash, true);
                _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -8.0f * -9.81f); // Jump + gravity
            }

            _playerVelocity.y += -35f * Time.deltaTime; // Brings player back down to ground
            _controller.Move(_playerVelocity * Time.deltaTime); // Move player after calculating Y vector

            _groundedPlayer = GroundedCheck(); // Character controller grounded check
        } else
        {
            StopFootStep();
            _soundState = 0;
        }
    }

    private bool GroundedCheck() //check if the player is touching the ground or very close to touching the ground
    {
        if (_controller.isGrounded) //built-in controller is grounded check
        {
            return true;
        }

        RaycastHit hit; //creates raycast "hit"

        //if the bottom of the player is within 0.16m of the ground and the player is not currently moving up
        if (Physics.Raycast(_controller.transform.position, new Vector3(0, -1, 0), out hit, 0.16f) && _playerVelocity.y <= 0)
        {
            //move the player down the distance of the raycast hit
            _controller.Move(new Vector3(0, -hit.distance, 0));
            return true;
        }

        return false;

    }

    private void PlayFootStep() // Sound
    {
        RaycastHit hit;
        Ray footstepRay = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(footstepRay, out hit)) {

            GameObject myObj = hit.collider.gameObject;

            // Check if object has a Renderer component on it
            if (myObj.GetComponent<Renderer>()) { 
                Renderer rend = myObj.GetComponent<Renderer>();
                Material standingOnMaterial = rend.material;
                string ground = standingOnMaterial.ToString();

                int tempstate = _soundState;

                if (hit.collider.tag == "Wood") {
                    _soundState = 1;
                    if (_soundState != tempstate) {
                        AudioManager.Instance.Play("walkingWood");
                        AudioManager.Instance.Stop("walkingGrass");
                        AudioManager.Instance.Stop("walkingRock");
                        AudioManager.Instance.Stop("walkingCave");
                    }
                } else if (ground == "ZLPC_Cave (Instance) (UnityEngine.Material)") {
                    _soundState = 2;
                    if (_soundState != tempstate) {
                        AudioManager.Instance.Play("walkingCave");
                        AudioManager.Instance.Stop("walkingWood");
                        AudioManager.Instance.Stop("walkingGrass");
                        AudioManager.Instance.Stop("walkingRock");
                    }
                } else if (ground == "ZLPC_Cave_2 (Instance) (UnityEngine.Material)" ||
                      ground == "ZLPC_Prop (Instance) (UnityEngine.Material)") {
                    _soundState = 3;
                    if (_soundState != tempstate) {
                        AudioManager.Instance.Play("walkingRock");
                        AudioManager.Instance.Stop("walkingWood");
                        AudioManager.Instance.Stop("walkingGrass");
                        AudioManager.Instance.Stop("walkingCave");
                    }
                } else {
                    _soundState = 4;
                    if (_soundState != tempstate) {
                        AudioManager.Instance.Play("walkingGrass");
                        AudioManager.Instance.Stop("walkingWood");
                        AudioManager.Instance.Stop("walkingRock");
                        AudioManager.Instance.Stop("walkingCave");
                    }
                }
            }
        }

        return;
    }
    private void StopFootStep() // Sound
    {
        AudioManager.Instance.Stop("walkingGrass");
        AudioManager.Instance.Stop("walkingWood");
        AudioManager.Instance.Stop("walkingRock");
        AudioManager.Instance.Stop("walkingCave");

        return;
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

    public void OnEnable() => IsFrozen = false;

    public void OnDisable() => IsFrozen = true;
}