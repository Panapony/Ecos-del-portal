using UnityEngine;
using UnityEngine.Video;

public class ControladorVideo : MonoBehaviour
{
    public VideoPlayer miVideoPlayer;
    public GameObject fondoMenu; // Arrastra aquí tu Background o el Canvas

    public void Reproducir()
    {
        if (miVideoPlayer != null)
        {
            // Ocultamos el fondo para ver el video
            if (fondoMenu != null) fondoMenu.SetActive(false);

            miVideoPlayer.Play();

            // Suscribirse al evento para que el menú vuelva al terminar
            miVideoPlayer.loopPointReached += AlTerminarVideo;
        }
    }

    void AlTerminarVideo(VideoPlayer vp)
    {
        // El video terminó, volvemos a mostrar el menú
        if (fondoMenu != null) fondoMenu.SetActive(true);
    }
}