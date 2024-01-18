using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections; // Necesario para usar coroutines

public class BotonBaseball : MonoBehaviour
{
    public XRBaseInteractable interactableButton; // Referencia al botón interactuable
    public ControladorBeisbol controladorBeisbol; // Referencia al controlador de béisbol

    private void OnEnable()
    {
        interactableButton.selectEntered.AddListener(HandleButtonPress);
    }

    private void OnDisable()
    {
        interactableButton.selectEntered.RemoveListener(HandleButtonPress);
    }

    private void HandleButtonPress(SelectEnterEventArgs args)
    {
        // Obtener el número actual de cocos
        int cocosCount = DinamicaJuego.Instance.GetCocosCount();

        if (cocosCount >= 25) // Verificar si hay suficientes cocos para iniciar el juego de béisbol
        {
            // Si hay suficientes cocos, iniciar el minijuego de béisbol
            StartCoroutine(IniciarJuegoConRetraso());
        }
        else
        {
            // Si no hay suficientes cocos, mostrar un mensaje de error o alguna indicación al jugador
            Debug.Log("Debes recoger al menos 25 cocos para jugar al béisbol.");
        }
    }

    // Coroutine para iniciar el juego después de un retraso de 5 segundos
    private IEnumerator IniciarJuegoConRetraso()
    {
        yield return new WaitForSeconds(5); // Esperar 5 segundos
        controladorBeisbol.IniciarJuego(); // Luego iniciar el juego
    }
}
