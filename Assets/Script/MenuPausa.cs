using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    private bool pausa = false;

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
    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        pausa = false;
        Time.timeScale = 1f;

        AudioListener.pause = false;
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
