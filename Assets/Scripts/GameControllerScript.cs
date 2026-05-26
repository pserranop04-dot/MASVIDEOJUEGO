using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public float velocidad = 1;
    public float velocidadMaxima = 2;
    public int monedasTotales = 100;
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
    }
}
