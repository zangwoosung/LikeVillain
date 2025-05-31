using UnityEngine;

public class Mine : MonoBehaviour
{

   [SerializeField] int damage = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().playerData.HP -= damage;
        }
    }
}
