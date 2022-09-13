using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyector : MonoBehaviour
{
    private bool proyectando;
    [SerializeField] private GameObject proyector_image;
    [SerializeField] private GameObject jugador;
    private bool jugando;

    void Start()
    {
        proyector_image.SetActive(false);
    }

    void Update()
    {
        jugando = jugador.GetComponent<BuscarElCable>().jugando;
        if (jugando)
        {
            if (proyectando)
            {
                proyector_image.SetActive(true);
            }
            else
            {
                proyector_image.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (jugando)
        {
            proyectando = !proyectando;
        }
    }
}
