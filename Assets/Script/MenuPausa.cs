
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    private bool pausa = false;
    //public MovimientoJugador jugador; para pausar el personaje al abrir menu pausa//
    //private bool pausa = false;

    void Start()
    {
        ObjetoMenuPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Detectar tecla Escape
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!pausa)
            {
                Pausar();
            }
            else
            {
                Resumir();
            }
        }
    }

    void Pausar()
    {
        ObjetoMenuPausa.SetActive(true);
        pausa = true;
        Time.timeScale = 0f;

        AudioListener.pause = true;

        //jugador.enabled = false; pausar mov//
    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        pausa = false;
        Time.timeScale = 1f;

        AudioListener.pause = false;

        //jugador.enabled = true; reactivar mov//
    }

    public void IrAlMenu(string nombreMenu)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreMenu);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
