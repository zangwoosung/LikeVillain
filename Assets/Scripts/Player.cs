using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Transform m_PlayerContainer;
    [SerializeField] Transform m_Player;
    public PlayerData playerData;
    public Animator anim;

    public float bounceForce = 10f;

    private Rigidbody rb;
    private bool isGrounded;
    Quaternion originalRotation;
    Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();
    }

    public void Restore()
    {
        transform.position= originalPosition;
        transform.rotation= originalRotation;

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
        if (Input.GetKey(KeyCode.Z))
        {
            m_Player.transform.eulerAngles = new Vector3(0, -90, 0);
            
        }
        if (Input.GetKey(KeyCode.Y))
        {
            m_Player.transform.eulerAngles = new Vector3(0, 90, 0);

        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
          
            m_PlayerContainer.Translate(Vector3.left * playerData.MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //m_Player.transform.eulerAngles = new Vector3(0, 180, 0);
            //Quaternion q = m_Player.rotation;
            //q.y = -90;
            //m_Player.rotation = q;
            m_PlayerContainer.Translate(Vector3.right * playerData.MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_PlayerContainer.Translate(Vector3.forward * playerData.MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_PlayerContainer.Translate(Vector3.back * playerData.MoveSpeed * Time.deltaTime);
        }


    }
}
