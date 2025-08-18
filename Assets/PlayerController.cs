using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpForce = 10f;
    public LayerMask GroundLayer;
    public Transform GroundCheck;

    private bool isGrounded;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * MoveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    bool IsGrounded() //Ground Check Code
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.1f, GroundLayer);
    }

}
