using UnityEngine;

public class InstantEnd : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] PlayerData playerData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerData.HP = 0;
            playerData.Life = 0;
            playerData.CalculateHP();

        }
    }
}
