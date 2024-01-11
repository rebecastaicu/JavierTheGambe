using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego Instance;

    [SerializeField] private int cocosRecolectados = 0;
    [SerializeField] private int minijuegosCompletados = 0;
    [SerializeField] private Temporizador temporizador;
    [SerializeField] private LanzadorCoco lanzadorCoco;
    public int Vida { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (minijuegosCompletados < 3 || cocosRecolectados < 250)
        {
            Debug.Log("No tienes suficientes cocos o no has completado los minijuegos requeridos.");
            // Aquí podrías cargar una escena diferente o mostrar un mensaje.
            return;
        }

        Vida = 250; // Comienza con 250 cocos/vida
        temporizador.IniciarTemporizador(60); // Comienza el temporizador de 1 minuto
        lanzadorCoco.IniciarLanzamiento(); // Comienza a lanzar cocos
    }

    public void PerderVida()
    {
        Vida--;
        if (Vida <= 0)
        {
            FinDelJuego();
        }
    }

    private void FinDelJuego()
    {
        lanzadorCoco.DetenerLanzamiento();
        temporizador.DetenerTemporizador();
        Debug.Log("El juego ha terminado. Puntuación final: " + Vida);
        // Implementa lo que sucede cuando el juego termina, por ejemplo, reiniciar o salir al menú principal.
    }
}
