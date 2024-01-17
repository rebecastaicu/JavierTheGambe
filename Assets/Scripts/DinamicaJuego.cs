using UnityEngine;

public class DinamicaJuego : MonoBehaviour
{
    // Singleton instance
    public static DinamicaJuego Instance { get; private set; }

    private int cocosCounter; // Contador de cocos

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cocosCounter = 0;
    }

    // M�todo para a�adir cocos al contador
    public void AddCocos(int amount)
    {
        cocosCounter += amount;
    }
    // M�todo para restar cocos del contador
    public void SubtractCocos(int amount)
    {
        cocosCounter -= amount;
        if (cocosCounter < 0)
        {
            cocosCounter = 0; // Asegurarse de que el contador no sea negativo
        }
    }
    // M�todo para obtener el contador actual de cocos
    public int GetCocosCount()
    {
        return cocosCounter;
    }
}
