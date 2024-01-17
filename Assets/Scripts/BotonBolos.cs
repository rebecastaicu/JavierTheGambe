using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BotonBolos : MonoBehaviour
{
    public XRBaseInteractable interactableButton; // Referencia al botón interactuable
    public ControladorBolos controladorBolos; // Referencia al controlador de bolos

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

        int cocosCount = DinamicaJuego.Instance.GetCocosCount();

        if (cocosCount >= 10)
        {
            // Ejecutar el minijuego de los bolos, generando un coco
            controladorBolos.GenerarCoco();
        }
        else
        {
            // Aquí puedes manejar la lógica si no se han recogido suficientes cocos
            Debug.Log("Debes recoger más cocos para jugar a los bolos.");
        }
    }
}
