using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public int score = 0; // Puntuaci�n inicial
    public Transform spawnPoint; // Punto de spawn de la pelota
    public Text scoreText; // Objeto de texto para mostrar la puntuaci�n

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
        // Verificar la entrada del jugador (por ejemplo, tocar la pantalla o presionar un bot�n)
        if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" seg�n la configuraci�n de entrada de tu proyecto
        {
            // Lanzar la pelota desde el punto de spawn
            ThrowBall();
        }
    }

    // M�todo llamado cuando algo entra en el �rea de colisi�n del objeto
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota")) // Aseg�rate de que el objeto que entra es la pelota
        {
            // Incrementar la puntuaci�n
            score++;
            UpdateScoreText(); // Actualizar el marcador de puntuaci�n

            // Puedes agregar aqu� cualquier otra acci�n que quieras realizar al anotar, como reproducir un sonido o mostrar un efecto visual.

            // Reubicar la pelota
            RespawnBall();
        }
    }

    // M�todo para reubicar la pelota despu�s de anotar
    void RespawnBall()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Pelota");

        // Reubicar la pelota en el punto de spawn
        ball.transform.position = spawnPoint.position;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero; // Detener cualquier movimiento residual
    }

    // M�todo para lanzar la pelota desde el punto de spawn
    void ThrowBall()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Pelota");

        // Aplicar una fuerza hacia adelante para simular el lanzamiento
        ball.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 500f); // Ajusta la fuerza seg�n sea necesario
    }

    // M�todo para actualizar el objeto de texto de puntuaci�n
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntuaci�n: " + score;
        }
    }
}
