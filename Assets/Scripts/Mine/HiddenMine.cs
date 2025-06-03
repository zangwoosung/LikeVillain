using UnityEngine;
public class HiddenMine : MonoBehaviour
{
    [SerializeField] Renderer outsideRenderer;
    [SerializeField] int damage = 10;
    [SerializeField] PlayerData playerData;
    private void Start()
    {
        outsideRenderer.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            outsideRenderer.enabled = true;
            playerData.HP -= damage;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            outsideRenderer.enabled = false;
            playerData.HP -= damage;
        }
    }
}

