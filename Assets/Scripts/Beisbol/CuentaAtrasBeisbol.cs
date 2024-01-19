using System.Collections;
using UnityEngine;
using TMPro;

public class CuentaAtrasBeisbol : MonoBehaviour
{
    public TextMeshProUGUI textoDeTiempo; // Texto en pantalla para mostrar el tiempo restante
    private float tiempoRestante = 180f; // Tiempo total del juego en segundos (180 segundos = 3 minutos)
    public ControladorBeisbol controladorBeisbol; // Conecta este script con el ControladorBeisbol

    void Start()
    {
        // Verifica si el componente de texto está asignado
        if (textoDeTiempo != null)
        {
            // Inicia la cuenta regresiva
            StartCoroutine(Temporizador());
        }
        else
        {
            // Muestra un error si no se asignó el componente de texto
            Debug.LogError("No se ha asignado el componente TextMeshProUGUI al script CuentaAtrasBeisbol.");
        }
    }

    // Método para activar el temporizador
    public void ActivarTemporizador()
    {
        StartCoroutine(Temporizador());
    }

    IEnumerator Temporizador()
    {
        while (tiempoRestante > 0)
        {
            // Disminuir el tiempo restante cada segundo
            tiempoRestante -= Time.deltaTime;

            // Convertir el tiempo en minutos y segundos
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);

            // Mostrar el tiempo en el texto de la interfaz de usuario
            textoDeTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);

            // Esperar hasta el próximo frame
            yield return null;
        }

        // Cuando el temporizador llegue a cero
        textoDeTiempo.text = "¡Tiempo finalizado!";
        controladorBeisbol.FinalizarJuego(); // Llamar al método para finalizar el juego
    }
}
