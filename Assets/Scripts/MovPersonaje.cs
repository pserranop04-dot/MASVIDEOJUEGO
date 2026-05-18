using UnityEngine;
using UnityEngine.InputSystem;

public class MovPersonaje : MonoBehaviour
{

    public float multiplicador = 5f;
    public float salto = 0.1f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hola");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    // Andar/Moverse
        Vector2 movTeclas = InputSystem.actions["Move"].ReadValue<Vector2>();
       
      
      float miDeltaTime = Time.deltaTime;

        transform.Translate(
            movTeclas*(Time.deltaTime*multiplicador),
            0
        );

    //Movimiento personaje
        //rb.linearVelocity = new Vector2(miDeltaTime, rb.linearVelocityY);


    // Salto
        if (InputSystem.actions["Jump"].IsPressed())
        {
           rb.AddForce(
            new Vector2 (0,salto),
            ForceMode2D.Impulse
            );
        };
        
    }
}
