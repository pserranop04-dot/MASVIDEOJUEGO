using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public Transform camara;
    public float velocidad = 1f;
    public float velocidadMaxima = 5f;
    public int monedasTotales = 100;
    public CanvasGroup oscurecedor;
    public float limiteX = 39.5f; // posición donde la cámara debe parar
    public bool detenerScroll = false;

    float aceleradorMonedas;

    void Start()
    {
        aceleradorMonedas = velocidadMaxima / monedasTotales;
    }

    void Update()
    {
        if (detenerScroll)
            return; // la cámara ya no se mueve

        int puntos = GameManager.Instance.puntos;

        // -----------------------------
        //   VELOCIDAD
        // -----------------------------
        float aceleracionTotal = aceleradorMonedas * puntos;

        float velocidadFinal = Mathf.Clamp(
            velocidad + aceleracionTotal,
            velocidad,
            velocidadMaxima
        );

        // Mover la cámara
        camara.Translate(velocidadFinal * Time.deltaTime, 0, 0);

        // -----------------------------
        //   OSCURECER A PARTIR DE 20
        // -----------------------------
        if (puntos >= 50)
        {
            float puntosExtra = puntos - 50;

            // Oscurecimiento lento
            float alpha = puntosExtra * 0.005f;

            // Límite máximo (no llega a opaco)
            float alphaMax = 0.98f;

            // Clamp final
            alpha = Mathf.Clamp(alpha, 0f, alphaMax);

            oscurecedor.alpha = alpha;
        }
        else
        {
            oscurecedor.alpha = 0f;
        }
        if (transform.position.x >= limiteX)

        //que no se pase la camara de ejelimiteX
        {
            transform.position = new Vector3(limiteX, transform.position.y, transform.position.z);
            detenerScroll = true;
        }
    }
}
