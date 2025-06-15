using System;
using UnityEngine;


public class BaseMine:MonoBehaviour
{
    public static event Action<AudioType> OnHitEvent;
    public static event Action<AudioType, Vector3> OnHitVFXEvent;
    public  PlayerData playerData;
    public AudioType myType;
    public int damate;
    public virtual void OnTriggerEnter(Collider other)
    {
        OnHitEvent?.Invoke(myType);
        OnHitVFXEvent.Invoke(myType, transform.position);
            
    }
}



public class Mine : BaseMine
{
    public override  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            base.OnTriggerEnter(other);
            playerData.Life -= 1;
        }
    }
}
