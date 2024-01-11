using UnityEngine;

public class Jugador : MonoBehaviour
{
    public static Jugador Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coco"))
        {
            ControladorJuego.Instance.PerderVida();
            Destroy(collision.gameObject); // Destruye el coco
        }
    }
}

