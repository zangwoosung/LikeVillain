using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    Hit,
    Over,
    Clear,
    Item,
    Jump,
    Run
}
public class SoundManager : MonoBehaviour
{
    public Dictionary<AudioType, AudioClip> playList;
    [SerializeField] AudioSource myAudio;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip over;
    [SerializeField] AudioClip clear;
    [SerializeField] AudioClip item;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip run;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BaseItem.OnHitEvent += BaseItem_OnHitEvent;
        playList = new Dictionary<AudioType, AudioClip>();
        playList.Add(AudioType.Hit, hit);
        playList.Add(AudioType.Over, over);
        playList.Add(AudioType.Clear, clear);
        playList.Add(AudioType.Item, item);
        playList.Add(AudioType.Jump, jump);
        playList.Add(AudioType.Run, run);
    }

    private void BaseItem_OnHitEvent(AudioType obj)
    {
        AudioClip clip = playList[obj];
        myAudio.clip = clip;
        myAudio.Play();

        AudioSource.PlayClipAtPoint(clip, transform.position);

        
        
    }

    public void PlayOneList(AudioType myType)
    {
        AudioClip clip = playList[myType];
        myAudio.clip = clip; 
        myAudio.Play();

        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayOneList(AudioType.Hit);
        }
    }

}
