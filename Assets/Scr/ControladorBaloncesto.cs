using UnityEngine;

public class ControladorBaloncesto : MonoBehaviour
{
    private int puntos = 0;
    private int puntosParaGanar = 10; // Puntos necesarios para ganar el minijuego
    public DInamicaJuego dinamicaJuego; // Referencia al script principal para los cocos

    // Llamar este método cuando un coco entre en la canasta
    public void EncestarCoco()
    {
        puntos++;
        dinamicaJuego.AddCocos(1); // Suma un coco al marcador principal

        // Verifica si se alcanzó el número de puntos para ganar
        if (puntos >= puntosParaGanar)
        {
            GanarMinijuego();
        }
    }

    private void GanarMinijuego()
    {
        // Que sucede cuando el jugador gana el minijuego

        Debug.Log("¡Minijuego ganado!");

        // Llamar a una función en DInamicaJuego para indicar que el minijuego ha sido completado.
        dinamicaJuego.CompleteMinigame(2); // Este es el tercer minijuego
    }
}