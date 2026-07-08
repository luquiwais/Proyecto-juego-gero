using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    int objetosRecolectados = 0;
    public int totalObjetos = 1;

    public TMP_Text textScore;
    public TMP_Text textTimer;

    public GameObject panelWin;
    public GameObject panelGameOver;

    public StarBar starBarWin;
    public StarBar starBarGameOver;

    public TMP_Text textScoreWin;
    public TMP_Text textTimerWin;

    public TMP_Text textScoreGameOver;
    public TMP_Text textTimerGameOver;

    [Header("Referencias al Player")]
    public MonoBehaviour scriptPlayer; // arrastrá acá tu único script de movimiento/cámara

    [Header("HUD esquinas")]
    public GameObject hudEsquinas; // objeto padre que agrupa Score y Timer de arriba

    float tiempoTotal = 60f;
    float tiempoRestante = 60f;
    bool corriendo = true;

    void Awake()
    {
        instancia = this;
    }

    void Update()
    {
        if (textTimer == null)
        {
            Debug.LogError("textTimer es null");
            return;
        }

        if (corriendo)
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                corriendo = false;
                MostrarGameOver();
            }

            textTimer.text = FormatearTiempo(tiempoRestante);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RecolectarObjeto()
    {
        objetosRecolectados++;
        textScore.text = "Score: " + objetosRecolectados;
        Debug.Log("Objetos recolectados: " + objetosRecolectados);

        if (objetosRecolectados >= totalObjetos)
        {
            MostrarWin();
        }
    }

    public void MostrarWin()
    {
        corriendo = false;
        starBarWin.LlenarEstrellas();

        textScoreWin.text = "Score: " + objetosRecolectados;
        textTimerWin.text = FormatearTiempo(tiempoTotal - tiempoRestante);

        panelWin.SetActive(true);
        BloquearPlayer();
    }

    public void MostrarGameOver()
    {
        starBarGameOver.VaciarEstrellas();

        textScoreGameOver.text = "Score: " + objetosRecolectados;
        textTimerGameOver.text = FormatearTiempo(tiempoTotal);

        panelGameOver.SetActive(true);
        BloquearPlayer();
    }

    void BloquearPlayer()
    {
        if (scriptPlayer != null) scriptPlayer.enabled = false;

        if (hudEsquinas != null) hudEsquinas.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    string FormatearTiempo(float segundos)
    {
        int mins = Mathf.FloorToInt(segundos / 60f);
        int segs = Mathf.FloorToInt(segundos % 60f);
        return string.Format("{0:00}:{1:00}", mins, segs);
    }
}