using UnityEngine;

public class ControladorBeisbol : MonoBehaviour
{
    // Evento que se llama para iniciar el minijuego
    public void IniciarJuego()
    {
        Debug.Log("Minijuego de b�isbol iniciado");
        // Inicializar otros componentes necesarios para el juego aqu�
    }

    // M�todo que se llama cuando el jugador batea correctamente
    public void BatearCoco()
    {
        // Puedes elegir a�adir cocos al contador si esto representa puntos ganados
        DinamicaJuego.Instance.AddCocos(1);
        // O tambi�n puedes evitar la p�rdida de cocos si esto representa una defensa exitosa
    }

    // M�todo que se llama para verificar la victoria o la derrota basada en el contador de cocos
    public void VerificarEstadoJuego()
    {
        if (DinamicaJuego.Instance.GetCocosCount() <= 0)
        {
            PerderJuego();
        }
    }

    // M�todo que se llama cuando el tiempo se acaba para determinar el resultado del juego
    public void FinalizarJuego()
    {
        if (DinamicaJuego.Instance.GetCocosCount() > 0)
        {
            GanarJuego();
        }
        else
        {
            PerderJuego();
        }
    }

    private void GanarJuego()
    {
        Debug.Log("�Has ganado el minijuego de b�isbol!");
        // Implementa la l�gica para cuando el jugador gana el juego
    }

    private void PerderJuego()
    {
        Debug.Log("Has perdido el minijuego de b�isbol.");
        // Implementa la l�gica para cuando el jugador pierde el juego
    }
}
