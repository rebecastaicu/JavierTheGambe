using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public int score = 0; // Puntuación inicial
    public Transform spawnPoint; // Punto de spawn de la pelota
    public Text scoreText; // Objeto de texto para mostrar la puntuación

    void Start()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("Spawn point not assigned to the Basket script!");
        }

        if (scoreText == null)
        {
            Debug.LogError("Score text not assigned to the Basket script!");
        }
        else
        {
            UpdateScoreText();
        }
    }

    void Update()
    {
        // Verificar la entrada del jugador (por ejemplo, tocar la pantalla o presionar un botón)
        if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" según la configuración de entrada de tu proyecto
        {
            // Lanzar la pelota desde el punto de spawn
            ThrowBall();
        }
    }

    // Método llamado cuando algo entra en el área de colisión del objeto
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota")) // Asegúrate de que el objeto que entra es la pelota
        {
            // Incrementar la puntuación
            score++;
            UpdateScoreText(); // Actualizar el marcador de puntuación

            // Puedes agregar aquí cualquier otra acción que quieras realizar al anotar, como reproducir un sonido o mostrar un efecto visual.

            // Reubicar la pelota
            RespawnBall();
        }
    }

    // Método para reubicar la pelota después de anotar
    void RespawnBall()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Pelota");

        // Reubicar la pelota en el punto de spawn
        ball.transform.position = spawnPoint.position;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero; // Detener cualquier movimiento residual
    }

    // Método para lanzar la pelota desde el punto de spawn
    void ThrowBall()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Pelota");

        // Aplicar una fuerza hacia adelante para simular el lanzamiento
        ball.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 500f); // Ajusta la fuerza según sea necesario
    }

    // Método para actualizar el objeto de texto de puntuación
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntuación: " + score;
        }
    }
}
