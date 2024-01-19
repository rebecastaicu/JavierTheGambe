using UnityEngine;

public class Canasta : MonoBehaviour
{
    public ControladorBaloncesto controladorBaloncesto;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coco")) 
        {
            // Notifica al controlador del juego de baloncesto que un coco ha sido encestado
            controladorBaloncesto.EncestarCoco();
        }
    }
}
