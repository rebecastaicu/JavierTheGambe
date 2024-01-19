using UnityEngine;

public class ControladorHoyo : MonoBehaviour
{

    // Evento para notificar al ControladorMinigolf
    public static event System.Action OnBolaEntradaHoyo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GolfBall"))
        {
            // Notifica al ControladorMinigolf que una bola ha entrado en el hoyo
            OnBolaEntradaHoyo?.Invoke();
        }
    }
}
