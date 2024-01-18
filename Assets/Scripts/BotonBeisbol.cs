using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections; // Necesario para usar coroutines

public class BotonBaseball : MonoBehaviour
{
    public XRBaseInteractable interactableButton; // Referencia al bot�n interactuable
    public ControladorBeisbol controladorBeisbol; // Referencia al controlador de b�isbol

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
        // Obtener el n�mero actual de cocos
        int cocosCount = DinamicaJuego.Instance.GetCocosCount();

        if (cocosCount >= 25) // Verificar si hay suficientes cocos para iniciar el juego de b�isbol
        {
            // Si hay suficientes cocos, iniciar el minijuego de b�isbol
            StartCoroutine(IniciarJuegoConRetraso());
        }
        else
        {
            // Si no hay suficientes cocos, mostrar un mensaje de error o alguna indicaci�n al jugador
            Debug.Log("Debes recoger al menos 25 cocos para jugar al b�isbol.");
        }
    }

    // Coroutine para iniciar el juego despu�s de un retraso de 5 segundos
    private IEnumerator IniciarJuegoConRetraso()
    {
        yield return new WaitForSeconds(5); // Esperar 5 segundos
        controladorBeisbol.IniciarJuego(); // Luego iniciar el juego
    }
}
