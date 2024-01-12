using UnityEngine;

public class Hoyo : MonoBehaviour
{
    public ControladorMinigolf controladorMinigolf;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coco"))
        {
            // Notifica al controlador del minijuego que un coco ha entrado
            controladorMinigolf.CocoEnHoyo();
        }
    }
}

