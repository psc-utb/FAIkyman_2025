using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class KnightController : MonoBehaviour
{
    Animator _animator;

    [SerializeField]
    [Range(1, 10)]
    float speed = 1;

    InputAction inputActionMove;
    InputAction inputActionJump;

    GroundDetection groundDetection;
    Rigidbody2D rigidbody2D;

    [SerializeField]
    float jumpForce = 50000;

    // Awake is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _animator = GetComponent<Animator>();
        inputActionMove = InputSystem.actions.FindAction("Move");
        //inputAction = new InputSystem_Actions().Player.Move;
        inputActionJump = InputSystem.actions.FindAction("Jump");

        groundDetection = GetComponent<GroundDetection>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float vx = Input.GetAxisRaw("Horizontal");
        Vector2 moveXY = inputActionMove.ReadValue<Vector2>();
        float vx = moveXY.x;

        if (vx != 0)
        {
            _animator.SetBool("IsMoving", true);
            gameObject.transform.Translate(speed * vx * Time.deltaTime, 0, 0);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        if (Input.GetButton("Fire1"))
        {
            _animator.SetTrigger("Attacking");
        }

        if (groundDetection.IsGrounded)
        {
            if (inputActionJump.WasPressedThisFrame())
            {
                rigidbody2D.AddForceY(jumpForce, ForceMode2D.Force);
                //rigidbody2D.linearVelocityY = 10;
            }
        }

        //_animator.SetTrigger("Death");
    }

    void LateUpdate()
    {

    }
}
