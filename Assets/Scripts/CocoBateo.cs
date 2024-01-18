using UnityEngine;

public class CocoBateo : MonoBehaviour
{
    // Variable que determina si el coco ha sido bateado exitosamente.
    public bool bateadoExitosamente = false;

    void OnCollisionEnter(Collision collision)
    {
        // Si el objeto con el que el coco colisiona es el bate.
        if (collision.gameObject.CompareTag("Bate"))
        {
            bateadoExitosamente = true;
            // Aquí llamar a un método en el ControladorBeisbol para sumar un coco.
            ControladorBeisbol.Instance.BatearCoco();
        }
    }

    void OnDestroy()
    {
        // Si el coco se destruye y no ha sido bateado, se resta un coco.
        if (!bateadoExitosamente)
        {
            ControladorBeisbol.Instance.FallarBateo();
        }
    }
}
