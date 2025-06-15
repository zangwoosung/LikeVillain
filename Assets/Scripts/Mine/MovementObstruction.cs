using UnityEngine;

public class MovementObstruction : Mine
{
    public  override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            base.OnTriggerEnter(other);
            playerData.JumpForce -= 2.0f;
            playerData.MoveSpeed -= 2.0f; 

        }
    }

}

