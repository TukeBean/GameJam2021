using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : MonoBehaviour
{

   
    public static AudioManager instance; //reference to the current audiomanager within scene
    //Audio manager will need to be added as a prefab to each scene aka. menu, level
    public AudioMixerGroup mixerGroup;
    public Sound[] sounds; //our array of sound clips

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        

        DontDestroyOnLoad(gameObject); // allows audiomanager to persist between scenes
       //currently commented out as we may want it to destroy as an easy way to stop title music playing

        foreach (Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            //controls for sound
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("boss_music");
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return; //dont try playing a sound that isnt there
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return; //dont try playing a sound that isnt there
        }
        s.source.Stop();
    }
}
