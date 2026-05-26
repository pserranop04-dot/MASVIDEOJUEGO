using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptCargarNivel1 : MonoBehaviour
{
    public string Escenajuego1;

    public void CargarEscena()
    {
        SceneManager.LoadScene(Escenajuego1);
        AudioManager.instancia.ReproducirMusica(AudioManager.instancia.MusicaEscena1);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
