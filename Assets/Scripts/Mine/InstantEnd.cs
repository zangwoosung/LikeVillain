using UnityEngine;

public class InstantEnd : Mine
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerData.HP = 0;
            playerData.Life = 0;
            playerData.CalculateHP();
            base.OnTriggerEnter(other);

        }
    }
}
