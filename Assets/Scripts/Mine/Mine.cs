using System;
using UnityEngine;


public class BaseMine:MonoBehaviour
{
    public static event Action<AudioType> OnHitEvent;
    public  PlayerData playerData;
    public AudioType myType;
    public int damate;
    public virtual void OnTriggerEnter(Collider other)
    {
        OnHitEvent?.Invoke(myType);
    }
}



public class Mine : BaseMine
{
    public override  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            base.OnTriggerEnter(other);
            playerData.HP -= damate;
        }
    }
}
