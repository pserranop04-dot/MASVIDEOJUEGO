using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public float velocidad = 1;
    public float velocidadMaxima = 2;
    public int monedasTotales = 100;
    public CanvasGroup oscurecedor;
    float aceleradorMonedas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aceleradorMonedas = (velocidadMaxima / monedasTotales) / 20;
    }

    // Update is called once per frame
    void Update()
    {
        float aceleracionTotal = aceleradorMonedas * GameManager.Instance.puntos;
        float debugAcelera = velocidad + aceleracionTotal;
        Debug.Log(debugAcelera);

        transform.Translate((velocidad + aceleracionTotal) * Time.deltaTime, 0, 0);
        AudioManager.instancia.musicaSource.pitch = Mathf.Clamp(1f + aceleracionTotal, 1f, 2f);

        // OSCURECER A PARTIR DE 140 PUNTOS
        if (GameManager.Instance.puntos >= 140)
        {
            // Cuántos puntos llevas por encima de 140
            float puntosExtra = GameManager.Instance.puntos - 140;

            // Cada punto oscurece un poco más
            float alpha = Mathf.Clamp(puntosExtra * 0.01f, 0f, 1f);

            // Aplicar oscuridad
            oscurecedor.alpha = alpha;
        }
    }
}
