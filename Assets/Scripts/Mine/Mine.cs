using UnityEngine;

public class Mine : MonoBehaviour
{
   [SerializeField] int damage = 10;
   [SerializeField] PlayerData playerData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerData.HP -= damage;
        }
    }
}
