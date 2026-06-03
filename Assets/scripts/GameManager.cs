using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    int objetosRecolectados = 0;

    public TMP_Text textScore;
    public TMP_Text textTimer;

    public GameObject panelWin;
    public GameObject panelGameOver;

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

        int segundos = Mathf.CeilToInt(tiempoRestante);
        textTimer.text = "00:" + segundos.ToString("D2");
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
    }

    public void MostrarWin()
    {
        corriendo = false;
        panelWin.SetActive(true);
    }

    public void MostrarGameOver()
    {
        panelGameOver.SetActive(true);
    }
}