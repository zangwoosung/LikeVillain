using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
