using UnityEngine;

public class CameraKiller : MonoBehaviour
{
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    public void ResetearCamara()
    {
        transform.position = posicionInicial;
    }
/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo reaccionar si el objeto que entra es el jugador
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Jugador tocó la cámara → muerte");

            // Llamar al GameManager para gestionar la muerte
            GameManager.Instance.MuertePorCamara();
        }
    }*/
}
