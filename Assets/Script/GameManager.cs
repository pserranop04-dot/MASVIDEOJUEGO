using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int vidas = 2;
    public int muertes = 0;
    public bool estoyMuerto = false;

    public int puntos = 0;
    public int puntosGlobales = 0;

    public Transform personaje;
    public Transform respawn;
    public TextMeshProUGUI monedasText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (monedasText == null)
        {
            GameObject obj = GameObject.Find("MonedasText");
            if (obj != null)
                monedasText = obj.GetComponent<TextMeshProUGUI>();
        }
    }

    public void ActualizaMarcador(int valor)
    {
        puntos += valor;

        if (monedasText != null)
            monedasText.text = puntos.ToString();
    }

    public void MuertePorCamara()
    {
        if (estoyMuerto)
            return;

        estoyMuerto = true;
        vidas--;
        muertes++;

        if (vidas > 0)
        {
            Respawn();
        }
        else
        {
            IrAlMenu();
        }
    }

    private void Respawn()
    {
        if (personaje == null)
        {
            Debug.LogError("ERROR: GameManager.personaje es NULL");
            return;
        }

        if (respawn == null)
        {
            Debug.LogError("ERROR: GameManager.respawn es NULL");
            return;
        }

        personaje.position = respawn.position;

        // Resetear cámara si existe
        Camera cam = Camera.main;
        if (cam != null)
        {
            CameraKiller ck = cam.GetComponent<CameraKiller>();
            if (ck != null)
                ck.ResetearCamara();
        }

        estoyMuerto = false;
    }

    private void IrAlMenu()
    {
        SceneManager.LoadScene("UInterfaz1");
    }
}
