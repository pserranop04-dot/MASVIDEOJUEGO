using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
        Instance = this;

        // Opcional: mantener entre escenas
        DontDestroyOnLoad(gameObject);
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
        Debug.Log("Puntos" + puntos);
    }

    public void ActualizaMarcador(int valor)
    {
        puntos += valor;
        MonedasText.GetComponent<TextMeshProUGUI>().text = puntos.ToString();
    }
}
