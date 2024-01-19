using UnityEngine;

public class Bolo : MonoBehaviour
{
    public bool derribado = false;
    public Vector3 posicionInicial;
    public Quaternion rotacionInicial;
    private ControladorBolos controladorBolos;

    private void Start()
    {
        controladorBolos = FindObjectOfType<ControladorBolos>();
        // Guarda la posici�n y rotaci�n iniciales para poder resetear los bolos despu�s
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!derribado && collision.gameObject.CompareTag("Coco"))
        {
            derribado = true;
            // Notifica al controlador de bolos que este bolo ha sido derribado
            controladorBolos.DerribarBolo();
            // En lugar de desactivar el bolo, inicia un temporizador para resetearlo
            Invoke("ResetearBolo", 2f); // Espera 2 segundos antes de resetear
        }
    }

    private void ResetearBolo()
    {
        // Resetear la posici�n y rotaci�n a su estado inicial
        transform.position = posicionInicial;
        transform.rotation = rotacionInicial;
        derribado = false;
        // Reactivar f�sicas o cualquier otro componente necesario
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
