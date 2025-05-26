using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public float jumpForce = 5f;
    public float moveSpeed = 5;
    public float speed = 5f;
    public float bounceForce = 10f;

    private Rigidbody rb;
    private bool isGrounded;
    Quaternion originalRotation;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    } 
  
    
    void StandUp()
    {
        transform.rotation= originalRotation;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector3 collisionNormal = collision.contacts[0].normal;
            rb.AddForce(collisionNormal * bounceForce, ForceMode.Impulse);
            Invoke("StandUp", 2);           
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("AirSpine");
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Get input for horizontal movement
        float horizontalInput = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput += 1;
        }

        // Get input for vertical movement
        float verticalInput = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput -= 1;
        }

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // Normalize the vector to ensure consistent movement speed
        movement.Normalize();

        // Move the object
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
