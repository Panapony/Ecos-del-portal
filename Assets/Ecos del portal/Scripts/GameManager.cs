using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameoverText;
    public GameObject victoryPanel;
    public TextMeshProUGUI statusText;

    public Button restartButton;
    public Button menuButton;
     public Button menuButtonVictory;
    public Button nextLevelButton;
    private bool gameOverActive=false;

private bool isGamePaused=false;


void Awake()
{
    if(Instance== null)
    {
        Instance= this;
    }
    else{
        Destroy(gameObject);
    }
}

    void Start()
    {
        if(gameOverPanel != null) gameOverPanel.SetActive(false);
       if(victoryPanel != null) victoryPanel.SetActive(false);


        if(restartButton!=null)
        restartButton.onClick.AddListener(ReiniciarEscena);


/// dos botones para volver al menú de inicio
        if(menuButton != null)
        menuButton.onClick.AddListener(IrAlMenu);
if(menuButtonVictory != null)
        menuButtonVictory.onClick.AddListener(IrAlMenu);
/////////


        if(nextLevelButton != null)
        nextLevelButton.onClick.AddListener(SiguienteNivel);

    }

public void GameOver()
{
    if(gameOverActive) return;
    gameOverActive=true;
    if(gameOverPanel != null)
    {
        gameOverPanel.SetActive(true);
    }

    if(gameoverText != null)
    {
        gameoverText.text = "Game Over"; 
    }
}
public void Victory()
{

    if(isGamePaused) return;
    ActivarMenu(victoryPanel, "Nivel Completado");
}

private void ActivarMenu(GameObject panel, string mensaje)
{
isGamePaused=true;
Time.timeScale = 0f;
if(panel != null) panel.SetActive(true);
if(statusText != null) statusText.text = mensaje;

}


public void SiguienteNivel()
{

    Debug.Log("Cargando siguiente nivel");
    Time.timeScale =1f;
    int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
    if(nextIndex < SceneManager.sceneCountInBuildSettings)
    {
        SceneManager.LoadScene(nextIndex);
    }
    else{
        Debug.Log("No hay más niveles. volviendo al menu");
        IrAlMenu();
    }
}

public void ReiniciarEscena()
{
   Debug.Log("Reiniciando escena");
    Time.timeScale=1f;
   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

/*int escenaActual= UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
UnityEngine.SceneManagement.SceneManager.LoadScene(escenaActual);
*/
}



public void IrAlMenu()
{
    Time.timeScale=1f;
    SceneManager.LoadScene("Menú inicio");
}
   
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.R))
    {
        Debug.Log("Reiniciando con tecla");
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
    }
}
