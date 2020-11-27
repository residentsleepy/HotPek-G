using UnityEngine.Audio;
using UnityEngine;

//ESTE CÓDIGO SE USA COMO CLASE, NO VA EN NINGUN OBJETO O PERSONAJE

//El código nos permite definir diferentes atributos de los sonidos que podrán ser usados durante el juego

[System.Serializable]
public class Sound
{
    public string name; //Nombre del clip de audio
    public AudioClip clip; //El AudioClip que será usado
    [Range(0f, 1f)]
    public float volume; //Slider para controlar el volumen del audio
    [Range(.1f,3)]
    public float pitch; //Slider para controlar el pitch del audio
    public bool loop; //Este booleano determina si el audio se reproducirá de manera consistente o no
    [HideInInspector]
    public AudioSource source; //El AudioSource determina de donde viene el audio y su intensidad segun que tan cerca a lejos está del AudioListener
    
}
