using UnityEngine;

public class ControladorBaloncesto : MonoBehaviour
{
    private int puntos = 0;
    private int puntosParaGanar = 5; // Puntos necesarios para ganar el minijuego
    public DinamicaJuego dinamicaJuego; // Referencia al script principal para los cocos

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
    }
}