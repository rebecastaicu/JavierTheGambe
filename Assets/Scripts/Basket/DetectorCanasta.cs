using UnityEngine;

public class DetectorCanasta : MonoBehaviour
{
    public ControladorBaloncesto controladorBaloncesto; // Referencia al script ControladorBaloncesto

    void Start()
    {
        if (controladorBaloncesto == null)
        {
            controladorBaloncesto = FindObjectOfType<ControladorBaloncesto>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colision� con el trigger tiene la etiqueta "Coco"
        if (other.CompareTag("Coco"))
        {
            // Si es un coco, llama al m�todo EncestarCoco del controladorBaloncesto
            controladorBaloncesto.EncestarCoco();
        }
    }
}
