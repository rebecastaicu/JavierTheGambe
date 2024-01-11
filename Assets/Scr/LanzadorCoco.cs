using System.Collections;
using UnityEngine;

public class LanzadorCoco : MonoBehaviour
{
    [SerializeField] private GameObject cocoPrefab; // Asigna el prefab del coco en el inspector
    [SerializeField] private Transform puntoDeLanzamiento; // Asigna el punto de lanzamiento en el inspector
    [SerializeField] private float fuerzaDeLanzamiento = 10f; // Ajusta esta fuerza como sea necesario
    [SerializeField] private Vector3 direccionDeLanzamiento = Vector3.forward; // Ajusta según la orientación deseada
    [SerializeField] private float intervaloDeLanzamiento = 2f; // Lanzar un coco cada 2 segundos

    private bool juegoActivo = true; // Controla si el juego está activo

    // Método público para iniciar el lanzamiento de cocos
    public void IniciarLanzamiento()
    {
        juegoActivo = true;
        StartCoroutine(LanzarCocosConIntervalo());
    }

    // Método público para detener el lanzamiento de cocos
    public void DetenerLanzamiento()
    {
        juegoActivo = false;
        StopAllCoroutines(); // Detiene todas las coroutines en este MonoBehaviour
    }

    // Coroutine que lanza cocos a intervalos regulares
    private IEnumerator LanzarCocosConIntervalo()
    {
        while (juegoActivo)
        {
            LanzarCoco();
            yield return new WaitForSeconds(intervaloDeLanzamiento);
        }
    }

    // Método para lanzar un coco
    private void LanzarCoco()
    {
        Debug.Log("Intentando lanzar un coco...");
        if (cocoPrefab != null && puntoDeLanzamiento != null)
        {
            GameObject coco = Instantiate(cocoPrefab, puntoDeLanzamiento.position, puntoDeLanzamiento.rotation);
            Debug.Log("Coco instanciado en la posición: " + coco.transform.position);
            Rigidbody rb = coco.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(puntoDeLanzamiento.TransformDirection(direccionDeLanzamiento) * fuerzaDeLanzamiento, ForceMode.Impulse);
                Debug.Log("Fuerza aplicada al coco");
            }
            else
            {
                Debug.LogError("El coco no tiene un Rigidbody.");
            }
        }
        else
        {
            Debug.LogError("Prefab del coco o punto de lanzamiento no asignado.");
        }
    }
}
