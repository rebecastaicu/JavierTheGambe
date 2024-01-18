using UnityEngine;

public class ControladorBeisbol : MonoBehaviour
{
    public static ControladorBeisbol Instance { get; private set; }
    public CuentaAtrasBeisbol temporizador; // Referencia al script del temporizador

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // M�todo para iniciar el juego y activar el temporizador
    public void IniciarJuego()
    {
        Debug.Log("Juego de b�isbol iniciado. El tiempo comienza a contar.");
        temporizador.ActivarTemporizador(); // Activa el temporizador
    }

    // M�todo para finalizar el juego
    public void FinalizarJuego()
    {
        Debug.Log("Juego de b�isbol finalizado.");
        // Aqu� puedes agregar la l�gica para manejar el final del juego
    }

    // M�todo que se llama cuando el coco es bateado.
    public void BatearCoco()
    {
        DinamicaJuego.Instance.AddCocos(1);
        Debug.Log("Bateo exitoso! Se a�ade un coco.");
    }

    // M�todo que se llama cuando se falla el bateo.
    public void FallarBateo()
    {
        DinamicaJuego.Instance.SubtractCocos(1);
        Debug.Log("Bateo fallido. Se resta un coco.");
    }
}
