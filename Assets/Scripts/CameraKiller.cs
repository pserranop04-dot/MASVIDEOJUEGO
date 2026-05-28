using UnityEngine;

public class CameraKiller : MonoBehaviour
{
    private GameObject personaje;
    private MovPersonaje movPersonaje;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MovPersonaje personaje = collision.GetComponent<MovPersonaje>();

            if (personaje != null)
            {
                personaje.Morir();
            }
        }
    }
}


