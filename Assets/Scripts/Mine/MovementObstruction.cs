using UnityEngine;

public class MovementObstruction : MonoBehaviour
{
    [SerializeField] int damage = 2;
    [SerializeField] PlayerData playerData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerData.JumpForce -= damage;
            playerData.MoveSpeed -= damage;
        }
    }

}

