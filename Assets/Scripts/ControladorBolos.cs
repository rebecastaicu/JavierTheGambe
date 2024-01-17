using UnityEngine;

public class ControladorBolos : MonoBehaviour
{
    private int bolosDerribadosTotal = 0;
    public GameObject[] bolos; // Asigna los objetos de los bolos aquí
    public GameObject cocoPrefab; // Asigna tu prefab de coco aquí
    public Transform puntoDeLanzamiento; // Asigna el punto desde donde se lanzarán los cocos

    private void Start()
    {
        // Inicializa los bolos para la primera partida
        ResetearBolos();
    }

    public void DerribarBolo()
    {
        bolosDerribadosTotal++;
        // Aquí puedes agregar cualquier lógica adicional necesaria cuando un bolo es derribado
    }

    public void LanzamientoRealizado()
    {
        // Esta función podría ser útil si se necesita realizar alguna acción después de cada lanzamiento
    }

    private void ResetearBolos()
    {
        foreach (GameObject bolo in bolos)
        {
            bolo.SetActive(true); // Reactiva los bolos
            // Se asume que Bolo es un script adjunto a cada bolo con su posición y rotación inicial
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
