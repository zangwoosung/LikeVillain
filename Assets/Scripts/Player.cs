using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Transform m_PlayerTransform;
    public PlayerData playerData;
    public Animator anim;

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
        transform.rotation = originalRotation;
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
            Invoke("StandUp", 2);
            isGrounded = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("AirSpine");
            playerData.HP -= 10;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * playerData.JumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

      
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_PlayerTransform.Translate(Vector3.left * playerData.MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_PlayerTransform.Translate(Vector3.right * playerData.MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_PlayerTransform.Translate(Vector3.forward * playerData.MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_PlayerTransform.Translate(Vector3.back * playerData.MoveSpeed * Time.deltaTime);
        }


    }
}
