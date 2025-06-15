using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Transform m_PlayerContainer;
    [SerializeField] Transform m_Player;
    public PlayerData playerData;
    public Animator anim;

    public float bounceForce = 10f;

    [SerializeField] Rigidbody rb;
    private bool isGrounded;
    Quaternion originalRotation;
    Vector3 originalPosition;

    void Start()
    {
        this.enabled = true;
        playerData.OnGameOverEvent += PlayerData_OnGameOverEvent;
        MainUI.OnGameAgainEvent += OnGameAgain;
        originalPosition = m_Player.transform.position;
        originalRotation = m_Player.transform.rotation;

        rb = m_Player.GetComponent<Rigidbody>();
    }

    private void PlayerData_OnGameOverEvent()
    {
        Debug.Log("game over in player");
        this.enabled = false;
    }

    public void OnGameAgain()
    {
        m_Player.transform.position = originalPosition;
        m_Player.transform.rotation = originalRotation;
        this.enabled = true;

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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * playerData.JumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            m_PlayerContainer.Translate(Vector3.left * playerData.MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
         
            m_PlayerContainer.Translate(Vector3.right * playerData.MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            m_PlayerContainer.Translate(Vector3.forward * playerData.MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            m_PlayerContainer.Translate(Vector3.back * playerData.MoveSpeed * Time.deltaTime);
        }


    }
}
