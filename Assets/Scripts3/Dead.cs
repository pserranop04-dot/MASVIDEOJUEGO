using UnityEngine;

public class Dead : MonoBehaviour
{

    private GameObject personaje;
    private MovPersonaje movPersonaje;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personaje = GameObject.Find("Personaje");
        movPersonaje = personaje.GetComponent<MovPersonaje>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Personaje")
        {
            Debug.Log(col.name);
            movPersonaje.Respawnear();
        }
    }
}
