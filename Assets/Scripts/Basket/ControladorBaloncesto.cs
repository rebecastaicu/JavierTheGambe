using System.Collections;
using UnityEngine;

public class ControladorBaloncesto : MonoBehaviour
{
    private int puntos = 0;
    private int puntosParaGanar = 5; // Puntos necesarios para ganar el minijuego
    public DinamicaJuego dinamicaJuego; // Referencia al script principal para los cocos

    // Este m�todo se llama cuando un coco es encestado correctamente
    public void EncestarCoco()
    {
        puntos++;
        dinamicaJuego.AddCocos(1); // Suma un coco al marcador principal

        // Verifica si se alcanz� el n�mero de puntos para ganar
        if (puntos >= puntosParaGanar)
        {
            GanarMinijuego();
        }
    }

    // Este m�todo se llama cuando el jugador alcanza los puntos necesarios para ganar
    private void GanarMinijuego()
    {
        // Que sucede cuando el jugador gana el minijuego
        Debug.Log("�Minijuego ganado!");
        FinalizarJuego();
    }

    // Este m�todo inicializa el minijuego de baloncesto
    public void IniciarJuego()
    {
        puntos = 0; // Restablecer puntos
        Debug.Log("Minijuego de baloncesto iniciado");
    }

    // Este m�todo finaliza el minijuego de baloncesto, ahora es p�blico para que pueda ser llamado desde CuentaAtras
    public void FinalizarJuego()
    {
        Debug.Log("El minijuego de baloncesto ha finalizado");
        this.gameObject.SetActive(false); // Desactiva el objeto de juego, deteniendo toda la l�gica del minijuego
    }
}
