using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject PanelJugar; //panel menu
    public GameObject PanelConfig; 
    public GameObject PanelNivel1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MostrarInicio();
    }

//MOSTRAR PANELES
    public void MostrarInicio()
    {
        PanelJugar.SetActive(true);
        PanelConfig.SetActive(false);
        PanelNivel1.SetActive(false);
        AudioManager.instancia.ReproducirMusica(AudioManager.instancia.MusicaMenu);
    }

    public void MostrarSettings()
    {
        PanelJugar.SetActive(false);
        PanelConfig.SetActive(true);
        PanelNivel1.SetActive(false);
    }

    public void MostrarNivel1()
    {
        PanelJugar.SetActive(false);
        PanelConfig.SetActive(false);
        PanelNivel1.SetActive(true);
    }

    // Update is called once per frame
    void Update() { }
}
