using System;
using Unity.VisualScripting;
using UnityEngine;


public class BaseItem : MonoBehaviour
{
    //test change
    public static event Action<AudioType> OnHitEvent;
    public AudioType myType;
    int damage = 10;
    public PlayerData playerData;
    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("tyep " +myType.ToString());
        OnHitEvent?.Invoke(myType);
    }


}
public class InstantEnd : BaseItem
{   
    public new void OnTriggerEnter(Collider other) 
    {
        base.OnTriggerEnter(other);
        
        if (other.CompareTag("Player"))
        {
            playerData.HP = 0;
            playerData.Life = 0;
            playerData.CalculateHP();

        }
    }
}
