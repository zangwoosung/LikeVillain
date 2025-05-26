using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public float JumpForce = 5f;
    public float MoveSpeed = 5;
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
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Movement based on arrow keys
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);
        }
    }
}
