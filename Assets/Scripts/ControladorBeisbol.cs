using UnityEngine;

public class ControladorBeisbol : MonoBehaviour
{
    // Evento que se llama para iniciar el minijuego
    public void IniciarJuego()
    {
        Debug.Log("Minijuego de béisbol iniciado");
        // Inicializar otros componentes necesarios para el juego aquí
    }

    // Método que se llama cuando el jugador batea correctamente
    public void BatearCoco()
    {
        // Puedes elegir añadir cocos al contador si esto representa puntos ganados
        DinamicaJuego.Instance.AddCocos(1);
        // O también puedes evitar la pérdida de cocos si esto representa una defensa exitosa
    }

    // Método que se llama para verificar la victoria o la derrota basada en el contador de cocos
    public void VerificarEstadoJuego()
    {
        if (DinamicaJuego.Instance.GetCocosCount() <= 0)
        {
            PerderJuego();
        }
    }

    // Método que se llama cuando el tiempo se acaba para determinar el resultado del juego
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
        Debug.Log("¡Has ganado el minijuego de béisbol!");
        // Implementa la lógica para cuando el jugador gana el juego
    }

    private void PerderJuego()
    {
        Debug.Log("Has perdido el minijuego de béisbol.");
        // Implementa la lógica para cuando el jugador pierde el juego
    }
}
