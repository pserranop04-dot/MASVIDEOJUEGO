using UnityEngine;

public class Trepar : MonoBehaviour
{

   /* public float velocidadTrepar = 5f;
    private bool detectaCuerda;

    private bool estaTrepando;

    BoxCollider2D bx;

    private Rigidbody2D rb;

    private float conGravedad;
    Animator treparAnimacion;*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*rb = GetComponent<Rigidbody2D>();
        treparAnimacion = this.GetComponent<Animator>();
        conGravedad = rb.gravityScale;*/

    }

    // Update is called once per frame
    void Update()
    {
       /* //Vector2 movTrepar = InputSystem.actions["Up"].ReadValue<Vector2>();
        //float verticalInput = Input.GetAxisRaw ("Vertical");

        //if (detectaCuerda && Mathf.Abs(verticalInput) > 0f) // si toca la cuerda y presiona los botones, realiza la acción
        {
            estaTrepando = true;
        }
        if (estaTrepando) //desactivar gravedad
        {
            rb.gravityScale = 0f;
            //rb.linearVelocityY = new Vector2( rb.linearVelocity.y, verticalInput * velocidadTrepar );
        }


        if (movTrepar.y != 0)
        {
            treparAnimacion.SetBool("activaTrepar", false);
        }
        else
        {
            treparAnimacion.SetBool("activaTrepar", true);
        }*/

    }


        /*  private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.CompareTag("Cuerda"))
        {
            detectaCuerda = true;
        }
        }
        private void OnTriggerExit2D(Collider2D collision) // restaurar gravedad al soltar
        {
        
        if (collision.CompareTag("Cuerda"))
        {
            detectaCuerda = false;
            estaTrepando = false;
            rb.gravityScale = conGravedad; 
        }*/
}

