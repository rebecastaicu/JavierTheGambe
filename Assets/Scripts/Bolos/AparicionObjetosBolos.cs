using UnityEngine;

public class AparicionObjetosBolos : MonoBehaviour
{
    public GameObject boloPrefab; // Prefab del bolo
    public GameObject cocoPrefab; // Prefab del coco
    public int filas = 4; // N�mero de filas en la formaci�n
    public float distanciaEntreBolos = 0.3f; // Distancia entre bolos
    public Transform zonaDeLanzamiento; // Punto de lanzamiento del coco

    void Start()
    {
        PosicionarBolos();
        VerificarYColocarCoco();
    }

    public void PosicionarBolos()
    {
        Vector3 startPosition = transform.position; // Punto de inicio
        Vector3 currentPosition = startPosition;

        for (int fila = 0; fila < filas; fila++)
        {
            for (int i = 0; i <= fila; i++)
            {
                GameObject bolo = Instantiate(boloPrefab, currentPosition, Quaternion.identity);
                bolo.transform.SetParent(transform); // Opcional: establecer como hijo del manager
                currentPosition.x += distanciaEntreBolos;
            }

            // Actualizar la posici�n para la siguiente fila
            startPosition.z += distanciaEntreBolos;
            startPosition.x -= distanciaEntreBolos / 2;
            currentPosition = startPosition;
        }
    }

    public void VerificarYColocarCoco()
    {
        // Verificar si ya existe un coco en la zona de lanzamiento
        if (ZonaDeLanzamientoEstaVacia())
        {
            // Si no hay coco, instanciar uno nuevo
            Instantiate(cocoPrefab, zonaDeLanzamiento.position, Quaternion.identity);
        }
    }

    bool ZonaDeLanzamientoEstaVacia()
    {
        // Definir un peque�o radio alrededor de la zona de lanzamiento
        float radioDeDeteccion = 0.5f; // Ajustar seg�n sea necesario
        Collider[] hitColliders = Physics.OverlapSphere(zonaDeLanzamiento.position, radioDeDeteccion);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Coco"))
            {
                return false; // Encontr� un coco, la zona no est� vac�a
            }
        }
        return true; // No encontr� ning�n coco, la zona est� vac�a
    }
    public void DesactivarBolosYCoco()
    {
        // Desactivar todos los bolos en la escena
        foreach (Transform bolo in transform)
        {
            bolo.gameObject.SetActive(false);
        }

        // Desactivar el coco si est� presente en la zona de lanzamiento
        if (ZonaDeLanzamientoEstaVacia() == false)
        {
            // Asumiendo que solo hay un coco en la zona de lanzamiento
            Collider[] hitColliders = Physics.OverlapSphere(zonaDeLanzamiento.position, 0.5f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Coco"))
                {
                    hitCollider.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
}
