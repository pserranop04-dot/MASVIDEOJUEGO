using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //SONIDOS EN PUBLICO PARA ARRASTRAR CLIPS
    public static AudioManager instancia;
    public AudioSource musicaSource;
    public AudioSource efectosSource;
    public AudioClip MusicaMenu;
    public AudioClip MusicaEscena1;
    public AudioClip MusicaEscena2;
    public AudioClip SonidoMonedas;
    public AudioClip SonidoBoton;
    public AudioClip SonidoBotonSalir;
    public AudioMixer mixer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }

    //SINGLETONE
    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //REPRODUCIR
    public void ReproducirMusica(AudioClip clip)
    {
        if (musicaSource.clip == clip)
            return;
        musicaSource.clip = clip;
        musicaSource.Play();
    }

    public void ReproducirEfecto(AudioClip clip)
    {
        efectosSource.PlayOneShot(clip);
    }

    public void SonarBoton()
    {
        ReproducirEfecto(SonidoBoton);
    }

    public void SonarBotonSalir()
    {
        ReproducirEfecto(SonidoBotonSalir);
    }

    public void CambiarVolumenMusica(float valor)
    {
        mixer.SetFloat("VolumenMusica", Mathf.Log10(valor) * 20);
    }

    public void CambiarVolumenEfectos(float valor)
    {
        mixer.SetFloat("VolumenEfectos", Mathf.Log10(valor) * 20);
    }
}
