using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textoMonedas;

    public void ActualizarMonedas()
    {
        textoMonedas.text = GameManager.Instance.puntosGlobales.ToString();
    }
}
