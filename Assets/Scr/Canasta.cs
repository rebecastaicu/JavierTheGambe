using UnityEngine;

public class Canasta : MonoBehaviour
{
    public ControladorBaloncesto controladorBaloncesto;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coco")) // Asegúrate de que los cocos tengan el tag "Coco"
        {
            // Notifica al controlador del juego de baloncesto que un coco ha sido encestado
            controladorBaloncesto.EncestarCoco();
        }
    }
}
