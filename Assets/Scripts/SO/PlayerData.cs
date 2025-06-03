using System;
using UnityEditor.Rendering.Analytics;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public  event Action OnGameOverEvent; 

    private int hp;

    public int HP
    {
        get { return hp; }
        set { hp = value;
        

        }
    }   

    private int life;

    public int Life
    {
        get { return life; }
        set { life = value;
            OnGameOverEvent?.Invoke();
            Debug.Log("in PlayerData");
            if (life==0)
            OnGameOverEvent?.Invoke();
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
