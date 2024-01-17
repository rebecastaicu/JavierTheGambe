using UnityEngine;
using UnityEngine.Events;

public class Temporizador : MonoBehaviour
{
    public float tiempoRestante { get; private set; }
    public bool temporizadorActivo = false;
    public UnityEvent onTiempoAgotado;

    public void IniciarTemporizador(float duracion)
    {
        tiempoRestante = duracion;
        temporizadorActivo = true;
    }

    void Update()
    {
        if (temporizadorActivo)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                temporizadorActivo = false;
                onTiempoAgotado.Invoke();
            }
        }
    }

    public void DetenerTemporizador()
    {
        temporizadorActivo = false;
    }
}
