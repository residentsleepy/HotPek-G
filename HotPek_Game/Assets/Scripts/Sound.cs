using UnityEngine.Audio;
using UnityEngine;

//THIS CODE ISN'T NEEDED IN A CHARACTER OR OBJECT

//This code is used to have serializable fields that will help us manage the sounds in all the scenes

[System.Serializable]
public class Sound
{

    public string name; //The name the audio will use

    public AudioClip clip; //The AudioClip itself that will be played

    [Range(0f, 1f)]
    public float volume; //Slider to control the volume of each sound
    [Range(.1f,3)]
    public float pitch; //Slider to control the pitch of each sound

    public bool loop; //This boolean allow us to repeat the audio when it ends

    [HideInInspector] //This defines where will the audio come from in the scene
    public AudioSource source; //This also allow us to manage the AudioSource(s) we create in the AudioManager script
    
}
