using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public event Action OnGameOverEvent;
    public float JumpForce = 5f;
    public float MoveSpeed = 5;
    public float bounceForce = 10f;

    private int hp;        
    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;
        }
    }

    [field: SerializeField]
    private int life;
    public int Life
    {
        get { return life; }
        set
        {
            Debug.Log("Life " + life);
            life = value;
            if (life <= 0)
            {
                Debug.Log("game over ");
                OnGameOverEvent?.Invoke();
            }
        }
    }
    public void ResetData()
    {
        Debug.Log("reset data");
        Life = 5;
        JumpForce = 5f;
        MoveSpeed = 5;
        bounceForce = 10f;

    }
    public void CalculateHP()
    {
        if (HP <= 0 && Life > 0)
        {
            Life--;

            HP = 100;
        }
    }

}
