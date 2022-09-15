using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject jugador;
    [SerializeField] private Text timer_UI;
    private bool jugando;
    private float timer;

    void Start()
    {
        timer_UI.text = "0s";
    }

    // Update is called once per frame
    void Update()
    {
        jugando = jugador.GetComponent<BuscarElCable>().jugando;

        if (jugando)
        {
            timer += Time.deltaTime;
            timer_UI.text = Mathf.FloorToInt(timer) + "s";
            if(timer > 30)
            {
                jugador.GetComponent<BuscarElCable>().jugando = false;
            }
        }
    }
}
