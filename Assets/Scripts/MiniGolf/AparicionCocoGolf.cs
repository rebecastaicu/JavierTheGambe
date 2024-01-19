using UnityEngine;

public class AparicionCocoGolf : MonoBehaviour
{
    public GameObject cocoPrefab; // Asigna el prefab del coco aqu�
    private GameObject cocoActual; // Almacena la instancia actual del coco

    void Start()
    {
        VerificarYAparicionCoco();
    }

    public void VerificarYAparicionCoco()
    {
        // Verificar si ya existe un coco
        if (cocoActual == null)
        {
            // Si no hay coco, instanciar uno en la posici�n de PuntoGolpeoMinigolf
            cocoActual = Instantiate(cocoPrefab, transform.position, Quaternion.identity, transform);
        }
    }
}
