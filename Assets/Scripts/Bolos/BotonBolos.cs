using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BotonBolos : MonoBehaviour
{
    public XRBaseInteractable interactableButton; // Referencia al botón interactuable
    public ControladorBolos controladorBolos; // Referencia al controlador de bolos
    public AparicionObjetosBolos aparicionBolos; // Referencia al script de aparición de bolos

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
        int cocosCount = DinamicaJuego.Instance.GetCocosCount();

        if (cocosCount >= 10)
        {
            Debug.Log("Iniciando el minijuego de bolos.");
            IniciarMinijuegoBolos();
        }
        else
        {
            Debug.Log("Debes recoger más cocos para jugar a los bolos.");
        }
    }

    private void IniciarMinijuegoBolos()
    {
        if (aparicionBolos != null)
        {
            aparicionBolos.PosicionarBolos();
            aparicionBolos.VerificarYColocarCoco();
        }
    }

    public void FinalizarMinijuegoBolos()
    {
        // Aquí puedes implementar la lógica para finalizar el juego
        Debug.Log("Minijuego de bolos finalizado.");

        // Ejemplo: Desactivar los bolos y el coco
        if (aparicionBolos != null)
        {
            aparicionBolos.DesactivarBolosYCoco();
        }

        
    }
}


