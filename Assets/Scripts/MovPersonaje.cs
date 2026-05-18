using UnityEngine;
using UnityEngine.InputSystem;

public class MovPersonaje : MonoBehaviour
{

    public float multiplicador = 5f;
    public float salto = 0.1f;

    private bool puedoSaltar = true;
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
    
    
    //Salto
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);

        if (hit)
        {
            puedoSaltar = true;
            Debug.Log(hit.collider.name);
        }else
        {
            puedoSaltar = false;
        }

    // Salto
        if (InputSystem.actions["Jump"].IsPressed() )//&& puedoSaltar)
        {
           rb.AddForce(
            new Vector2 (0,salto),
            ForceMode2D.Impulse
            );
        };
        
    }

}
