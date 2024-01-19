using UnityEngine;

public class ControladorBolos : MonoBehaviour
{
    public AparicionObjetosBolos aparicionBolos; // Referencia al script AparicionObjetosBolos
    private int bolosDerribadosTotal = 0;
    private int totalBolos = 10; // Total de bolos en la partida

    // Referencia al script DinamicaJuego
    private DinamicaJuego dinamicaJuego;

    private void Start()
    {
        if (aparicionBolos != null)
        {
            aparicionBolos.PosicionarBolos();
            aparicionBolos.VerificarYColocarCoco();
        }

        // Encuentra el script DinamicaJuego en la escena
        dinamicaJuego = FindObjectOfType<DinamicaJuego>();
    }

    public void DerribarBolo()
    {
        bolosDerribadosTotal++;
        // Verifica si todos los bolos han sido derribados
        if (bolosDerribadosTotal == totalBolos)
        {
            // Añadir 10 cocos al contador general en DinamicaJuego
            dinamicaJuego.AddCocos(10);
            // Finalizar el minijuego de bolos
            FinalizarJuego();
        }
    }

    public void FinalizarJuego()
    {
        // Aquí puedes implementar la lógica para finalizar el juego
        // Por ejemplo, mostrar un mensaje de victoria, detener el juego, etc.
        Debug.Log("¡Minijuego de bolos finalizado!");

        // Otras acciones para finalizar el juego...
    }

    // Agrega cualquier otra lógica específica del juego que necesites aquí
}

