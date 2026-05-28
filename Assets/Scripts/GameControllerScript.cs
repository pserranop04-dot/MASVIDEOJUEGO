using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public float velocidad = 1f;
    public float velocidadMaxima = 5f;   // Más margen para notar la aceleración
    public int monedasTotales = 100;
    public CanvasGroup oscurecedor;

    float aceleradorMonedas;

    void Start()
    {
        // Mucho más razonable: cada moneda aporta aceleración real
        aceleradorMonedas = velocidadMaxima / monedasTotales;
    }

    void Update()
    {
        float aceleracionTotal = aceleradorMonedas * GameManager.Instance.puntos;

        // Velocidad final limitada
        float velocidadFinal = Mathf.Clamp(velocidad + aceleracionTotal, velocidad, velocidadMaxima);

        Debug.Log("Velocidad final: " + velocidadFinal);

        // Movimiento real
        transform.Translate(velocidadFinal * Time.deltaTime, 0, 0);

        // Pitch suave (no lineal)
        float t = velocidadFinal / velocidadMaxima;
        AudioManager.instancia.musicaSource.pitch = Mathf.Lerp(1f, 1.3f, t);

        // OSCURECER A PARTIR DE 140 PUNTOS
        if (GameManager.Instance.puntos >= 140)
        {
            float puntosExtra = GameManager.Instance.puntos - 140;
            float alpha = Mathf.Clamp(puntosExtra * 0.01f, 0f, 1f);
            oscurecedor.alpha = alpha;
        }
    }
}

