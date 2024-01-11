using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DInamicaJuego : MonoBehaviour
{
    private bool[] minigamesCompleted; // Estado de completitud de cada minijuego
    private int cocosCounter; // Contador de cocos

    // Start is called before the first frame update
    void Start()
    {
        minigamesCompleted = new bool[4]; // 4 minijuegos
        cocosCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Aquí puedes añadir la lógica para comprobar el input del usuario 
        // y activar los minijuegos si se cumplen las condiciones.
    }

    // Llamar este método cuando se complete un minijuego
    public void CompleteMinigame(int minigameIndex)
    {
        if (minigameIndex >= 0 && minigameIndex < minigamesCompleted.Length)
        {
            minigamesCompleted[minigameIndex] = true;
        }
    }

    // Método para añadir cocos al contador
    public void AddCocos(int amount)
    {
        cocosCounter += amount;
    }

    // Método para verificar si se puede iniciar un minijuego específico
    public bool CanStartMinigame(int minigameIndex)
    {
        switch (minigameIndex)
        {
            case 0: // Primer minijuego, siempre se puede iniciar
                return true;
            case 1: // Segundo minijuego, requiere haber completado el primero y tener 50 cocos
                return minigamesCompleted[0] && cocosCounter >= 10;
            case 2: // Tercer minijuego, requiere haber completado los dos primeros y tener 100 cocos
                return minigamesCompleted[0] && minigamesCompleted[1] && cocosCounter >= 20;
            case 3: // Cuarto minijuego, requiere haber completado los tres anteriores y tener 150 cocos
                return minigamesCompleted[0] && minigamesCompleted[1] && minigamesCompleted[2] && cocosCounter >= 30;
            default:
                return false;
        }
    }
}
