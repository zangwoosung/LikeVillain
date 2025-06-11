using System;
using UnityEngine;

public class FinishLine : Mine
{
    public static event Action OnStageClearEvent;
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            base.OnTriggerEnter(other);
            OnStageClearEvent?.Invoke();
        }
    }
}
