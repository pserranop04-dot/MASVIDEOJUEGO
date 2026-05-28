using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int vidas = 2;
    public static bool estoyMuerto = false;
    public static int muertes = 0;
    public int puntos = 0;
    public int puntosGlobales = 0;

    private void Awake()
    {
        // Si ya existe otro singleton, destruye este
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        // Asignar instancia
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    
    }

    GameObject MonedasText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MonedasText = GameObject.Find("MonedasText");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Puntos" + puntos);
        //Debug.Log("Vidas: " + vidas);
    }

    public void ActualizaMarcador(int valor)
    {
        puntos += valor;
        MonedasText.GetComponent<TextMeshProUGUI>().text = puntos.ToString();
    }
}
