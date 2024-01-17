using UnityEngine;

public class ControladorBolos : MonoBehaviour
{
    private int bolosDerribadosTotal = 0;
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
        // Aqu� puedes agregar cualquier l�gica adicional necesaria cuando un bolo es derribado
    }

    public void LanzamientoRealizado()
    {
        // Esta funci�n podr�a ser �til si se necesita realizar alguna acci�n despu�s de cada lanzamiento
    }

    private void ResetearBolos()
    {
        foreach (GameObject bolo in bolos)
        {
            bolo.SetActive(true); // Reactiva los bolos
            // Se asume que Bolo es un script adjunto a cada bolo con su posici�n y rotaci�n inicial
            Bolo datosBolo = bolo.GetComponent<Bolo>();
            if (datosBolo != null)
            {
                bolo.transform.position = datosBolo.posicionInicial;
                bolo.transform.rotation = datosBolo.rotacionInicial;
                datosBolo.derribado = false;
            }
        }
    }

    public void GenerarCoco()
    {
        Instantiate(cocoPrefab, puntoDeLanzamiento.position, puntoDeLanzamiento.rotation);
    }
}
