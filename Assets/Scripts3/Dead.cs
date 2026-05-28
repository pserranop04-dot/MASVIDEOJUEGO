using UnityEngine;


public class Dead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Solo reaccionar si el objeto que entra es el jugador
        if (col.CompareTag("Player"))
        {
            Debug.Log("Jugador tocó zona de muerte");

            // Llamar al GameManager para gestionar la muerte
            GameManager.Instance.MuertePorCamara();
        }
    }
}
