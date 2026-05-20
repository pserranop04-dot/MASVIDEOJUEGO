using UnityEngine;
using UnityEngine.InputSystem;

public class MovPersonaje : MonoBehaviour
{

    public float multiplicador = 5f;
    public float potenciaSalto = 0.1f;

    bool puedoSaltar = false;
    //private bool tocaSuelo; //para que detecte que no toca suelo y aplicarlo para que contabilice el salto una vez deje de tocar el suelo.
    private int contarSalto = 0; // contabilizador de salto

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


    //Flip izquierda y derecha
        //this.transform.Translate(movTeclas.x * multiplicador, 0, 0);

        if (movTeclas.x < 0)
        {
           this.GetComponent<SpriteRenderer>().flipX = true;   
        }
        else if (movTeclas.x > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        };
        

    
    //Salto

        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        
        Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.magenta);


        if (hit == true) //(hit.collider == true)
        {
            puedoSaltar = true;
           // Debug.Log(hit.collider.name);
            //tocaSuelo = true;
            contarSalto = 0; //resetea el contabilizador del salto a 0
            
        }else
        {
            puedoSaltar = false;
        };
        Debug.Log(puedoSaltar);


        if (salto && (puedoSaltar || contarSalto < 1) )// añadido puedo saltar y contar salto
        {
           rb.AddForce( new Vector2 (0, potenciaSalto),ForceMode2D.Impulse);

            contarSalto++; //incrementará el salto a doble salto
        }

        

        
        
    }

}
