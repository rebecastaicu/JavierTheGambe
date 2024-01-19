using UnityEngine;

public class LanzadorCoco : MonoBehaviour
{
    [SerializeField] private GameObject cocoPrefab;
    [SerializeField] private Transform puntoDeLanzamiento;
    [SerializeField] private float fuerzaDeLanzamiento = 10f;
    [SerializeField] private float intervaloDeLanzamiento = 2f;

    private void Start()
    {
        InvokeRepeating("LanzarCoco", 0, intervaloDeLanzamiento);
    }

    private void LanzarCoco()
    {
        if (cocoPrefab != null && puntoDeLanzamiento != null)
        {
            GameObject coco = Instantiate(cocoPrefab, puntoDeLanzamiento.position, puntoDeLanzamiento.rotation);
            Rigidbody rb = coco.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(puntoDeLanzamiento.forward * fuerzaDeLanzamiento, ForceMode.Impulse);
            }
        }
    }
}
