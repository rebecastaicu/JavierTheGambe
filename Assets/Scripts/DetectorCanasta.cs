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
        // Verifica si el objeto que colisionó con el trigger tiene la etiqueta "Coco"
        if (other.CompareTag("Coco"))
        {
            // Si es un coco, llama al método EncestarCoco del controladorBaloncesto
            controladorBaloncesto.EncestarCoco();
        }
    }
}
