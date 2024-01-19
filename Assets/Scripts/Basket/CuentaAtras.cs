using System.Collections;
using UnityEngine;
using TMPro; // Usando TextMeshPro

public class CuentaAtras : MonoBehaviour
{
    public TextMeshProUGUI textoDeTiempo; // Referencia al Text que mostrará el tiempo
    private float tiempoRestante = 180f; // 3 minutos en segundos
    public ControladorBaloncesto controladorBaloncesto;

    void Start()
    {
        if (textoDeTiempo != null) // Corregir el nombre de la variable
        {
            StartCoroutine(Temporizador());
        }
        else
        {
            Debug.LogError("No se ha asignado el componente TextMeshProUGUI al script CuentaAtras.");
        }
    }

    IEnumerator Temporizador()
    {
        while (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;

            // Convierte el tiempo restante en minutos y segundos
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);

            // Actualiza el texto del UI
            textoDeTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos); 

            yield return null; // Espera un frame antes de continuar el bucle
        }

        // Cuando el temporizador llega a cero
        textoDeTiempo.text = "Tiempo finalizado"; // Agrega esta línea para mostrar el mensaje final
        controladorBaloncesto.FinalizarJuego(); // Llama a FinalizarJuego si el minijuego no ha sido ganado y el tiempo se acaba
    }
}
