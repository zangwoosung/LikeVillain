using System;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : MonoBehaviour
{
    EventBinding<TestEvent> testEventBinding;
    EventBinding<PlayerEvent> playerEventBinding;

    private void OnEnable()
    {
        testEventBinding = new EventBinding<TestEvent>(HandleTestEvent);
        EventBus<TestEvent>.Register(testEventBinding);

        playerEventBinding = new EventBinding<PlayerEvent>(HandlePlayerEvent);
        EventBus<PlayerEvent>.Register(playerEventBinding);

    }
    private void OnDisable()
    {        
        EventBus<TestEvent>.Deregister(testEventBinding);        
        EventBus<PlayerEvent>.Deregister(playerEventBinding);

    }

    private void Awake()
    {
        
    }

    

    private void HandleTestEvent( )
    {
        Debug.Log("Hero HandleTestEvent ");
    }    
    private void HandlePlayerEvent(PlayerEvent playerEvent)
    {
        Debug.Log("Hero ");
        Debug.Log(playerEvent.health);
        Debug.Log(playerEvent.mana);
        playerEvent.myAction();
        Debug.Log(playerEvent.myFunc(5));
    }
    
   



}
