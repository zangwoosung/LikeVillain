using UnityEngine;
public class HiddenMine : Mine
{
    [SerializeField] Renderer outsideRenderer;
    
    private void Start()
    {
        outsideRenderer.enabled = false;
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outsideRenderer.enabled = true;
            base.OnTriggerEnter(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outsideRenderer.enabled = false;            
        }
    }
}

