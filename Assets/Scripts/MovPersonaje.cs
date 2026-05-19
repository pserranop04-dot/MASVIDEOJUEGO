using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovPersonaje : MonoBehaviour
{

    public float multiplicador = 5f;
    public float salto = 0.1f;

    bool puedoSaltar = false;
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


    //Flip izquierda y derecha
        //this.transform.Translate(movTeclas.x * multiplicador, 0, 0);

        if (movTeclas.x < 0)
        {
         this.GetComponent<SpriteRenderer>().flipX = true;   
        }
        else if (movTeclas.x > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        

    
    //Salto

        bool salto = InputSystem.actions["Jump"].WasCompletedThisFrame();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);

        if (hit == true) //(hit.collider == true)
        {
            puedoSaltar = true;
            Debug.Log(hit.collider.name);
        }else
        {
            puedoSaltar = false;
        }

        if (InputSystem.actions["Jump"].IsPressed() )// (salto && puedoSaltar)
        {
           rb.AddForce(
            new Vector2 (0, 1f),
            ForceMode2D.Impulse
            );
        };
        
    }

}
