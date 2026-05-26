using TMPro;
using UnityEngine;

public class CompararMonedas : MonoBehaviour
{
    public TextMeshProUGUI comparadorMonedas;
    public int monedasNecesarias = 1000;

    void Awake()
    {
        comparadorMonedas = GetComponent<TextMeshProUGUI>();
    }

    public void ActualizarComparacion()
    {
        int actuales = GameManager.Instance.puntosGlobales;
        comparadorMonedas.text = actuales + " / " + monedasNecesarias;
    }
}
