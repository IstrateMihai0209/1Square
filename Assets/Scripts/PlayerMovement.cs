using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float jumpForce = 3f;
    private float movSpeed = 100f;

    private float coyoteTime = 1f;
    private float timeLeftGrounded;

    private float jumpBuffer = 0.3f;
    private float lastJumpPressed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool left = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        //Try this, but with two last jump pressed variables (for left and right)
        if ((left || lastJumpPressed + jumpBuffer > Time.time) && Mathf.Abs(rb.velocity.y) < 0.001f && timeLeftGrounded + coyoteTime > Time.time)
        {
            transform.position += new Vector3(-1, 0, 0) * Time.fixedDeltaTime * movSpeed;
            rb.AddForce(new Vector2(0.00f, jumpForce), ForceMode2D.Impulse);
        }

        if ((right || lastJumpPressed + jumpBuffer > Time.time) && Mathf.Abs(rb.velocity.y) < 0.001f && timeLeftGrounded + coyoteTime > Time.time)
        {
            transform.position += new Vector3(1, 0, 0) * Time.fixedDeltaTime * movSpeed;
            rb.AddForce(new Vector2(0.00f, jumpForce), ForceMode2D.Impulse);
        }

        if ((left || right) && !(Mathf.Abs(rb.velocity.y) < 0.001f))
            lastJumpPressed = Time.time;

        if (rb.velocity.y == 0f)
        {
            timeLeftGrounded = Time.time;
        }

        print(lastJumpPressed + jumpBuffer);
        print("Time.time = " + Time.time);
    }
}

/*public float movSpeed = 1.41f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool left = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        if(left && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            //transform.position += new Vector3(-1, 0, 0) * Time.fixedDeltaTime * movSpeed;
            //rb.AddForce(new Vector2(-1.00f, jumpForce), ForceMode2D.Impulse);

            rb.velocity = new Vector2(-movSpeed, jumpForce * rb.gravityScale);
        }

        if (right && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            //transform.position += new Vector3(1, 0, 0) * Time.fixedDeltaTime * movSpeed;
            //rb.AddForce(new Vector2(1.00f, jumpForce), ForceMode2D.Impulse);

            rb.velocity = new Vector2(movSpeed, jumpForce * rb.gravityScale);
        }

        if (rb.velocity.y == 0)
            transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y);

        /*transform.position =
                Vector2.Lerp(transform.position, new Vector2(transform.position.x + dir, transform.position.y)
                , movSpeed * Time.deltaTime);*/
//}