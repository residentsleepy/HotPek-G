using UnityEngine.Audio;
using System;
using UnityEngine;

//THIS CODE GOES ALONG THE AUDIO MANAGER OBJECT

//The code controls the sounds we use while we play the game controlling multiples aspects of the sound
//The advantage with this code is being able to call it from other scripts to play our chosen sounds

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds; //Our array of sounds we will be using through the game

    public static AudioManager instance;

    void Awake()
    {
        //This is used mainly if we able the use of one AudioManager in multiple scenes
        //This checks if we already have an Audio Manager
        //If we don't have one we create it
        if(instance == null)
            instance = this;
        else //But if we already have one in scene we destroy it to not have double AudioClips playing
        {
            Destroy(gameObject);
            return;
        }

        //THIS LINE IS DISABLED //Use it if we need the AudioManager in every scene with the music playing constantly
        //DontDestroyOnLoad(gameObject);

        //This creates an AudioSource for each of the sounds we are using
        //Ensuring everyone can be played at the same time (we could not if we only had one AudioSource)
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    //When this function is called we take the string given as a parameter to find the sound in our list that matches the parameter
    //This makes the sound play in the scene from our previously created AudioSource
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //In this first line what we do is to find a match making a comparisson between the parameter and our array
        if (s == null) //If there are no matches a message telling us the sound is non existent will show up in our Console
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play(); //If there is a sound it will play with the parameters we stablish in Inspector (AudioClip, Volume, Pitch)
    }
}
