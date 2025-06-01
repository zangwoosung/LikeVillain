using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_HitTrap;



    private void Start()
    {
        Player.OnHitTrapEvent += Player_OnHitTrapEvent;
    }

    private void Player_OnHitTrapEvent(Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(m_HitTrap, pos);
    }

    private void PlayHitTrap(Vector3 pos)
    {
        
           
       

    }

}
