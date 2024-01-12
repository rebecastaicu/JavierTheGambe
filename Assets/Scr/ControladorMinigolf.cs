using UnityEngine;
using System.Collections;

public class ControladorMinigolf : MonoBehaviour
{
    private int cocosEnHoyos = 0;
    private float tiempoRestante = 180f; // 3 minutos
    private bool minijuegoActivo = false;

    public DInamicaJuego dinamicaJuego; // Referencia al script principal

    void Start()
    {
        // Inicializa el minijuego aqu� si es necesario
        minijuegoActivo = true;
    }

    void Update()
    {
        if (minijuegoActivo)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                FinalizarMinijuego();
            }
        }
    }

    public void CocoEnHoyo()
    {
        cocosEnHoyos++;
        dinamicaJuego.AddCocos(1); // Suma un coco al marcador principal

        if (cocosEnHoyos >= 10)
        {
            // El jugador gan� el minijuego
            FinalizarMinijuego();
        }
    }

    private void FinalizarMinijuego()
    {
        minijuegoActivo = false;
        // Aqu� puedes a�adir lo que sucede cuando termina el minijuego
    }
}
