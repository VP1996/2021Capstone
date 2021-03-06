using UnityEngine.Audio;
using System;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        { Destroy(gameObject); };

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
    
    
    void Start()
    {
        //Play("Background");
        //Play("BAckground"+Random.Range(1, 4));
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MainScreen")
        {
            
            Play("Background");
        }
        else if (scene.name == "Tutorial")
        {
            Play("Background");
        }
        else if (scene.name == "Level1")
        {
            Play("Background");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
    public void ChangePitch(string name, float speed)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.pitch = speed / 10;
    }
    public void ChangeVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = volume;
    }
}