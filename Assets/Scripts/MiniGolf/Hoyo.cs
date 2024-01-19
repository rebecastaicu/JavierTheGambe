using UnityEngine;
using System;

public class Hoyo : MonoBehaviour
{
    public static event Action OnBolaEntradaHoyo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coco"))
        {
            // Notifica al ControladorMinigolf que una bola ha entrado en el hoyo
            OnBolaEntradaHoyo?.Invoke();
        }
    }
}
