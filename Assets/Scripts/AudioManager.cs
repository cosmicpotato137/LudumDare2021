using UnityEngine.Audio;
using System;
using UnityEngine;

// Holds list of sounds that can be easily added or removed
    // Each audio clip, volume and pitch, loop, volume & pitch randomness, spatial settings
    // play() method
    
public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static GameObject instance;

    // Start is called before the first frame update
    void Awake()
    {
        
        if (instance == null)
            instance = gameObject;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    void Start ()
    {
        Play("BkgndMusic");
    }

    public void Play(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
