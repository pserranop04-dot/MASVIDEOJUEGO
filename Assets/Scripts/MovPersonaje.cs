using UnityEngine;
using UnityEngine.InputSystem;

public class MovPersonaje : MonoBehaviour
{

    public float multiplicador = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hola");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movTeclas = InputSystem.actions["Move"].ReadValue<Vector2>();
       //float movTeclas = Input.GetAxis ("Horizontal"); 
      
      float miDeltaTime = Time.deltaTime;

        transform.Translate(
            movTeclas*(Time.deltaTime*multiplicador),
            0
            
        );
    }
}
