using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BotonGolf : MonoBehaviour
{
    public XRBaseInteractable interactableButton; // Referencia al botón interactuable
    public ControladorMinigolf controladorMinigolf; // Referencia al controlador de minigolf
    public AparicionCocoGolf aparicionCocoGolf; // Referencia al script de aparición de cocos

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
        Debug.Log("Iniciando el minijuego de golf.");
        IniciarMinijuegoGolf();
    }

    private void IniciarMinijuegoGolf()
    {
        controladorMinigolf.enabled = true; // Activar el ControladorMinigolf

        // Llamar a la función para instanciar el coco
        if (aparicionCocoGolf != null)
        {
            aparicionCocoGolf.VerificarYAparicionCoco();
        }
    }

    public void FinalizarMinijuegoGolf()
    {
        // lógica para finalizar el juego de golf
        Debug.Log("Minijuego de golf finalizado.");

        // Desactivar los elementos del minijuego 
        controladorMinigolf.enabled = false; // Desactivar el ControladorMinigolf
    }
}

