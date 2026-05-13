using UnityEngine;

public class PanelManager : MonoBehaviour
{

    public GameObject PanelJugar;
    public GameObject PanelConfig;
    public GameObject PanelNivel1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MostrarInicio();
    }
     public void MostrarInicio()
    {
        PanelJugar.SetActive(true);
        PanelConfig.SetActive(false);
        PanelNivel1.SetActive(false);
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
    void Update()
    {
        
    }
}
