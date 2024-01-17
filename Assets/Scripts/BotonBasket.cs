using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BotonBasket : MonoBehaviour
{
    public XRBaseInteractable interactableButton; // Referencia al botón interactuable
    public ControladorBaloncesto controladorBaloncesto; // Referencia al controlador de baloncesto

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
        // Obtener el objeto interactor desde los argumentos
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;

        // Obtener el número actual de cocos
        int cocosCount = DinamicaJuego.Instance.GetCocosCount();

        if (cocosCount >= 20) // Verificar si hay suficientes cocos para iniciar el juego
        {
            // Si hay suficientes cocos, iniciar el minijuego de baloncesto
            controladorBaloncesto.IniciarJuego();
        }
        else
        {
            // Si no hay suficientes cocos, mostrar un mensaje de error o alguna indicación al jugador
            Debug.Log("Debes recoger al menos 20 cocos para jugar al baloncesto.");
        }
    }
}
