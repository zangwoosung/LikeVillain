using System;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public static event Action OnStageClearEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnStageClearEvent?.Invoke();
        }
    }
}
