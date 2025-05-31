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
            isGrounded = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("AirSpine");
            playerData.HP = 10;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * playerData.JumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        float moveSpeed = 5;// playerData.MoveSpeed;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_PlayerTransform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_PlayerTransform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_PlayerTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_PlayerTransform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }


    }
}
