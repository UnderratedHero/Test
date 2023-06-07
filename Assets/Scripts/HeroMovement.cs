using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float jumpForce = 0.2f;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Move();
        }

        if (isGrounded && Input.GetButton("Jump"))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Crouch();
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {
            StopCrouch();
        }
    }
    private void Move()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void GroundCheck()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);

        isGrounded = collider.Length > 2;
    }
    private void Crouch()
    {
        moveSpeed = 3.0f;
        sprite.color = new Color(0f, 0f, 0f, 1.0f);
    }

    private void StopCrouch()
    {
        moveSpeed = 10.0f;
        sprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
