using UnityEngine;
using System.Collections;

public class ControladorMinigolf : MonoBehaviour
{
    private int puntaje = 0;
    private int bolasEnHoyo = 0;

    public int Puntaje
    {
        get { return puntaje; }
        private set { puntaje = value; }
    }

    public int BolasEnHoyo
    {
        get { return bolasEnHoyo; }
        private set { bolasEnHoyo = value; }
    }

    void OnEnable()
    {
        ControladorHoyo.OnBolaEntradaHoyo += BolaEntradaHoyo;
    }

    void OnDisable()
    {
        ControladorHoyo.OnBolaEntradaHoyo -= BolaEntradaHoyo;
    }

    public void BolaEntradaHoyo()
    {
        BolasEnHoyo++;
        if (BolasEnHoyo == 3)
        {
            Puntaje += 10;
            DinamicaJuego.Instance.AddCocos(10); // Añade 10 cocos al contador general
            FinalizarMinijuego(); // Finaliza el minijuego
        }
    }

    private void FinalizarMinijuego()
    {
        // Aquí puedes agregar la lógica para finalizar el minijuego
        // Por ejemplo, desactivar el juego, mostrar un mensaje, etc.
        Debug.Log("Minijuego finalizado");
    }
}

