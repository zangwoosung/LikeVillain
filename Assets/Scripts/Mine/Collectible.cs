using System;
using UnityEngine;

public class Collectible: MonoBehaviour
{
    public static event Action<AudioType, Vector3> OnHitVFXEvent;
    public PlayerData playerData;
    public int JumpForce=0;
    public AudioType myType;
    public  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            playerData.JumpForce =JumpForce;
        }
    }
}
