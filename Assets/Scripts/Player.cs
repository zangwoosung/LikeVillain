using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    } 
    public float speed = 5f;
    void OnCollisionEnter(Collision collision)
    {
        // Set isGrounded true when touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {


        float moveInput = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow by default
        transform.Translate(Vector3.forward * moveInput * speed * Time.deltaTime);
       
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");

            anim.SetTrigger("Forward");

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("V");

            anim.SetTrigger("Backward");

        }
      
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");

            anim.SetTrigger("Run");

        }

    }
}
