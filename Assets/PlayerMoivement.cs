using UnityEngine;

public class PlayerMoivement : MonoBehaviour
{
    public GameManager gm;
    public Rigidbody rb;

    public float strafeSpeed = 100f;
    public float runSpeed = 100f;
    public float jumpForce = 15f;

    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool doJump = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            Debug.Log("Вы проиграли");
            gm.EndGame();
        }
    }

    void Update()
    {
        if (Input.GetKey("d"))
        {
            strafeRight = true;
        } else
        {
            strafeRight = false;
        }

        if (Input.GetKey("a"))
        {
            strafeLeft = true;
        } else
        {
            strafeLeft = false;
        }

        if (Input.GetKeyDown("space"))
        {
            doJump = true;
        }

        if(transform.position.y < -5f)
        {
            Debug.Log("Вы проиграли");
            gm.EndGame();
        }
    }

    void FixedUpdate()
    {
        // rb.AddForce(0, 0, runSpeed * Time.deltaTime);
        rb.MovePosition(transform.position + Vector3.forward * runSpeed * Time.deltaTime);

        if (strafeLeft)
        {
            // rb.MovePosition(transform.position + Vector3.left * strafeSpeed * Time.deltaTime);
            rb.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (strafeRight)
        {
            // rb.MovePosition(transform.position + Vector3.right * strafeSpeed * Time.deltaTime);
            rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (doJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doJump = false;
        }
    }
}
