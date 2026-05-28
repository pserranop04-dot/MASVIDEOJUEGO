using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MovPersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    public float potenciaSalto = 35f;

    public bool direccionDerecha = true;
    bool puedoSaltar = false;

    Animator controlAnimacion;
    Rigidbody2D rb;

    int contarSalto = 0;

    Transform respawn;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controlAnimacion = GetComponent<Animator>();

        // Respawn desde la escena
        GameObject r = GameObject.Find("Respawn");
        if (r != null)
            respawn = r.transform;

        // Registrar personaje en GameManager
        GameManager.Instance.personaje = this.transform;
        GameManager.Instance.respawn = respawn;
    }

    void Update()
    {
        // Si está muerto → no se mueve
        if (GameManager.Instance.estoyMuerto)
            return;

        // MOVIMIENTO
        Vector2 movTeclas = InputSystem.actions["Move"].ReadValue<Vector2>();
        transform.Translate(movTeclas * velocidad * Time.deltaTime);

        // FLIP
        if (movTeclas.x > 0 && !direccionDerecha) girar();
        else if (movTeclas.x < 0 && direccionDerecha) girar();

        // ANIMACIÓN CAMINAR
        controlAnimacion.SetBool("activaCamina", movTeclas.x != 0);

        // SALTO
        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);

        if (hit.collider != null)
        {
            puedoSaltar = true;
            contarSalto = 0;
        }
        else
        {
            puedoSaltar = false;
        }

        if (salto && (puedoSaltar || contarSalto < 1))
        {
            rb.AddForce(Vector2.up * potenciaSalto, ForceMode2D.Impulse);
            contarSalto++;
        }

        // CAER FUERA DE LA PANTALLA
        if (transform.position.y <= -7)
        {
            GameManager.Instance.MuertePorCamara();
        }
    }

    // GIRAR SPRITE
    private void girar()
    {
        direccionDerecha = !direccionDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    // TRIGGER CON LA CÁMARA
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            GameManager.Instance.MuertePorCamara();
        }
    }
}






