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
        // Guarda la posición y rotación iniciales para poder resetear los bolos después
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!derribado && collision.gameObject.CompareTag("Coco"))
        {
            derribado = true;
            gameObject.SetActive(false); // Desactiva el bolo derribado
            controladorBolos.DerribarBolo();
        }
    }
}
