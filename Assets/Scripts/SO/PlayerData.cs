using UnityEditor.Rendering.Analytics;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int HP=100;   
    public int Life=5;   
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
