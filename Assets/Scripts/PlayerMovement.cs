using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float jumpForce = 3f;
    private float movSpeed = 100f;

    private float coyoteTime = 1f;
    private float timeLeftGrounded;

    private float jumpBuffer = 0.3f;
    private float leftJumpPressed;
    private float rightJumpPressed;

    private float yMovL;
    private float yMovR;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool left = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 1.5f, LayerMask.GetMask("Squares"));
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 1.5f, LayerMask.GetMask("Squares"));

        if (hitLeft.collider != null) yMovL = 1f;
        else yMovL = 0f;

        if (hitRight.collider != null) yMovR = 1f;
        else yMovR = 0f;

        if ((left || leftJumpPressed + jumpBuffer > Time.time) && Mathf.Abs(rb.velocity.y) < 0.001f && timeLeftGrounded + coyoteTime > Time.time)
        {
            transform.position += new Vector3(-1, yMovL, 0) * Time.fixedDeltaTime * movSpeed;
            rb.AddForce(new Vector2(0.00f, jumpForce), ForceMode2D.Impulse);
        }

        if ((right || rightJumpPressed + jumpBuffer > Time.time) && Mathf.Abs(rb.velocity.y) < 0.001f && timeLeftGrounded + coyoteTime > Time.time)
        {
            transform.position += new Vector3(1, yMovR, 0) * Time.fixedDeltaTime * movSpeed;
            rb.AddForce(new Vector2(0.00f, jumpForce), ForceMode2D.Impulse);
        }

        if (left && !(Mathf.Abs(rb.velocity.y) < 0.001f))
            leftJumpPressed = Time.time;

        if (right && !(Mathf.Abs(rb.velocity.y) < 0.001f))
            rightJumpPressed = Time.time;

        if (rb.velocity.y == 0f)
        {
            timeLeftGrounded = Time.time;
        }
    }
}
