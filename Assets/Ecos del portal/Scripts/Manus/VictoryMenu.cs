using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuVictoria : MonoBehaviour
{
    public void ReiniciarNivel()
    {
        //  devolver el tiempo a la normalidad
        Time.timeScale = 1f; 
        
        // Recarga la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SiguienteNivel(string nombreNivel)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreNivel);
    }

    public void IrAlMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menú Inicio"); // Asegúrate de tener una escena con este nombre
    }
}