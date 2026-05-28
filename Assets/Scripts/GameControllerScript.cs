using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public float velocidad = 1f;
    public float velocidadMaxima = 5f;
    public int monedasTotales = 100;
    public CanvasGroup oscurecedor;

    float aceleradorMonedas;

    void Start()
    {
        // Cada moneda aporta aceleración real
        aceleradorMonedas = velocidadMaxima / monedasTotales;
    }

    void Update()
    {
        float aceleracionTotal = aceleradorMonedas * GameManager.Instance.puntos;

        // Velocidad final limitada
        float velocidadFinal = Mathf.Clamp(
            velocidad + aceleracionTotal,
            velocidad,
            velocidadMaxima
        );

        //Debug.Log("Velocidad final: " + velocidadFinal);

        // Movimiento real
        transform.Translate(velocidadFinal * Time.deltaTime, 0, 0);

        //   PITCH

        float t = velocidadFinal / velocidadMaxima;

        // Pitch objetivo según velocidad
        float pitchObjetivo = Mathf.Lerp(1f, 1.25f, t);

        // Amortiguación suave (no cambia de golpe)
        AudioManager.instancia.musicaSource.pitch = Mathf.Lerp(
            AudioManager.instancia.musicaSource.pitch,
            pitchObjetivo,
            0.05f
        );

        // -----------------------------
        //   OSCURECER A PARTIR DE 20
        // -----------------------------
        if (GameManager.Instance.puntos >= 20)
        {
            float puntosExtra = GameManager.Instance.puntos - 20;
            float alpha = Mathf.Clamp(puntosExtra * 0.01f, 0f, 1f);

            Debug.Log("Alpha actual: " + alpha);

            oscurecedor.alpha = alpha;
        }
    }




}
