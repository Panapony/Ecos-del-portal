using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
public GameObject Start;

public void PlayGame()
{
SceneManager.LoadScene("Ecos del portal_Andric");

}
public void QuitGame()
{
Application.Quit();

}

}
