using UnityEngine;

public class ControladorBolos : MonoBehaviour
{
    private int bolosDerribadosTotal = 0;
    private int tiradasRestantes = 3;
    private int partidasJugadas = 0;
    private const int MaxPartidas = 3;
    public DInamicaJuego dinamicaJuego; // Referencia al script principal para los cocos
    public GameObject[] bolos; // Asigna los objetos de los bolos aqu�
    public GameObject cocoPrefab; // Asigna tu prefab de coco aqu�
    public Transform puntoDeLanzamiento; // Asigna el punto desde donde se lanzar�n los cocos

    private void Start()
    {
        // Inicializa los bolos para la primera partida
        ResetearBolos();
    }

    public void DerribarBolo()
    {
        bolosDerribadosTotal++;
        if (bolosDerribadosTotal >= 20)
        {
            dinamicaJuego.AddCocos(10); // Suma 10 cocos al marcador principal
            dinamicaJuego.CompleteMinigame(1); // Indica que el minijuego ha sido completado
        }
    }

    public void LanzamientoRealizado()
    {
        tiradasRestantes--;
        if (tiradasRestantes <= 0)
        {
            partidasJugadas++;
            if (partidasJugadas < MaxPartidas)
            {
                // Reinicia la ronda si a�n quedan partidas
                ResetearBolos();
                tiradasRestantes = 3;
            }
            else
            {
                // El minijuego termina despu�s de tres partidas
                // L�gica para hacer algo al finalizar las tres partidas
            }
        }
    }

    private void ResetearBolos()
    {
        foreach (GameObject bolo in bolos)
        {
            bolo.SetActive(true); // Reactiva los bolos
            bolo.transform.position = bolo.GetComponent<Bolo>().posicionInicial;
            bolo.transform.rotation = bolo.GetComponent<Bolo>().rotacionInicial;
            bolo.GetComponent<Bolo>().derribado = false;
        }
    }

    public void GenerarCoco()
    {
        Instantiate(cocoPrefab, puntoDeLanzamiento.position, puntoDeLanzamiento.rotation);
    }
}
