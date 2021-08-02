using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagers : MonoBehaviour
{
    public static AudioManagers Ins;
    public AudioSource MusicPlayer;
    public AudioSource SoundPlayer;
    // Start is called before the first frame update
    void Start()
    {
        MusicPlayer.volume = 0.6f;
        SoundPlayer.volume = 0.6f;
        Ins = this;
    }
    //播放音乐
    public void PlayMusic(string name)
    {
        if (MusicPlayer.isPlaying == false)
        {
            AudioClip clip = Resources.Load<AudioClip>(name);
            MusicPlayer.clip = clip;
            MusicPlayer.Play();
        }
    }

    public void StopMusic()
    {
        MusicPlayer.Stop();
    }

    //播放音效
    public void PlaySound(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        SoundPlayer.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
