using UnityEngine;
using UnityEngine.InputSystem;

public class Trepar : MonoBehaviour
{
    public float velocidadHorizontal = 8f;
    public float velocidadTrepar = 5f;
    public LayerMask capaEsclable;
    public Transform comprobadorCuerda; // Un objeto vacío en el centro del jugador
    public float radioComprobacion = 0.2f;

    private Rigidbody2D rb;
    private float entradaHorizontal;
    private float entradaVertical;
    private bool estaTocandoCuerda;
    private bool trepando;
    private float gravedadInicial;
  
    Animator treparAnimacion;

    InputAction moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravedadInicial = rb.gravityScale;
        treparAnimacion = this.GetComponent<Animator>();
        moveAction = InputSystem.actions.FindAction("Move");

    }

    // Update is called once per frame
    void Update()
    {
        //para leer las entradas del teclado 
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        entradaHorizontal = moveAction.ReadValue<Vector2>().x;
        entradaVertical = moveAction.ReadValue<Vector2>().y;

        //comprobación de si el jugador está superponiendo la capa "Escalable"
        estaTocandoCuerda = Physics2D.OverlapCircle(comprobadorCuerda.position, radioComprobacion, capaEsclable);

        //si tocamos la cuerda y se presiona arriba o abajo, empezamos a trepar
        if (estaTocandoCuerda && Mathf.Abs(entradaVertical)> 0.1f)
        {
            //Debug.DrawLine(transform.position, transform.position*3, Color.aliceBlue);
            treparAnimacion.SetBool("activaTrepar", true);
            trepando = true;
        }

        // si salimos de la cuerda, o el jugador no se mueve verticalmente, se deja de trepar
        if (!estaTocandoCuerda || (trepando && Mathf.Abs(entradaVertical)< 0.1f && entradaVertical == 0))
        {
            treparAnimacion.SetBool("activaTrepar", false);
            trepando = false;
        }

        // se ajusta la gravedad dependiendo de si estamos escalando o no
        if (trepando)
        {
            rb.gravityScale = 0f;
        } else
        {
            rb.gravityScale = gravedadInicial;
        }
      
    }

    void FixedUpdate()
    {
        if (trepando)
        {  // se mueve el personaje donde diga el jugador
            rb.linearVelocity = new Vector2 (entradaHorizontal * velocidadHorizontal, entradaVertical * velocidadTrepar);
        }
        else
        {  // movimiento normal por el suelo
            rb.linearVelocity = new Vector2 (entradaHorizontal * velocidadHorizontal, rb.linearVelocityY);
        }
    }

    private void OnDrawGizmosSelected() //Dibuja el cículo en la escena para que se pueda posicionar
    {
        if (comprobadorCuerda != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(comprobadorCuerda.position, radioComprobacion);
        }
    }
    
}

