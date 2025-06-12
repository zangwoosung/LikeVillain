using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public  event Action OnGameOverEvent;

    EventBinding<PlayerEvent> playerEventBinding;
    private int hp;

    private void OnEnable()
    {
        playerEventBinding = new EventBinding<PlayerEvent>(PlayerEventHandler);
        EventBus<PlayerEvent>.Register(playerEventBinding);
    }

    private void PlayerEventHandler(PlayerEvent @event)
    {
        Debug.Log("@event");  
        Debug.Log(@event);  
    }

    public int HP
    {
        get { return hp; }
        set { hp = value;
        

        }
    }   

    [field:SerializeField]
    private int life;
    public int Life
    {
        get { return life; }
        set { life = value;
            OnGameOverEvent?.Invoke();
            Debug.Log("in PlayerData");
            if (life == 0)
            {
                EventBus<PlayerEvent>.Raise(new PlayerEvent
                {
                    health = 100,
                    mana = 100
                });

                EventBus<TestEvent>.Raise(new TestEvent { });

                OnGameOverEvent?.Invoke();
            }
        }
    }

    public float JumpForce = 5f;
    public float MoveSpeed = 5; 
    public float bounceForce = 10f;

    public void CalculateHP()
    {
        if (HP <= 0 && Life > 0)
        {
            Life--;

            HP = 100;
        }
    }

}
