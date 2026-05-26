using UnityEngine;

public class MonedaScript : MonoBehaviour
{
    public int valor = 10;

    Animator miAnimadorController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        miAnimadorController = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(col.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //MONEDA
        if (col.gameObject.name == "Personaje")
        {
            GameManager.Instance.ActualizaMarcador(valor);

            gameObject.GetComponent<Animator>().SetBool("monedaDestruir", true);

            GetComponent<Collider2D>().enabled = false;

            Destroy(this.gameObject, 1.0f);

            //Reproducir sonido de moneda
            AudioManager.instancia.ReproducirEfecto(AudioManager.instancia.SonidoMonedas);
        }
    }
}
