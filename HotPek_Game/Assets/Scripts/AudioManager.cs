using UnityEngine.Audio;
using System;
using UnityEngine;

//ESTE CODIGO VA JUNTO CON EL OBJETO DEL MISMO NOMBRE (AUDIOMANAGER)

//El código controla varios aspectos de los diferentes sonidos que necesitemos usar durante la ejecución del programa
//La ventaja del código es poder llamarlo desde otros scripts para reproducir sonidos en los momentos deseados

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds; //Esto servirá como nuestra colección de sonidos con toda la configuración que la clase Sound nos permite

    public static AudioManager instance; //Usamos este mismo AudioManager para la verificación de si existe o no en la escena

    void Awake()
    {
        //Aqui tenemos la comprobación de la existencia del AudioManager en caso de que usemos el mismo en varias escenas
        //Si no tenemos uno lo establecemos como este mismo
        if(instance == null)
            instance = this;
        else //Pero si ya tenemos uno lo borramos para evitar repeticiones de sonido innecesarias
        {
            Destroy(gameObject);
            return;
        }

        //LINEA DESHABILITADA //La usamos si queremos que el AudioManager no sea destruido al cambiar de escena
        //DontDestroyOnLoad(gameObject);

        //Aqui se crea un AudioSource por cada sonido que vayamos a usar durante el juego
        //Crear varios AudioSource nos permite reproducir multiples sonidos al mismo tiempo sin interrumpir otros
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    //Esta función es usada para reproducir los audios que tengamos guardados en nuestro AudioManager
    //El string que usa como parametro debe ser el nombre de alguno de los audios guardados
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //En esta línea hacemos una comparación entre nuestro parametro y los miembros de Sounds s
        if (s == null) //Si no hay ninguna coincidencia, un mensaje aparecerá en consola para notificarnos
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play(); //Si hay coincidencia el sonido se reproducirá siguiendo los parametros establecidos (AudioClip, Volume, Pitch)
    }
}
