using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuscarElCable : MonoBehaviour
{
    private bool tiene_cable;
    public bool juego_finalizado;
    private bool en_rango_cable_pickup;
    public GameObject cable_pickup;
    [SerializeField] private GameObject cable_place;
    private bool en_rango_cable_place;
    public bool jugando;
    [SerializeField] private Text txt_instrucciones;

    private void Start()
    {
        tiene_cable = false;
        juego_finalizado = false;
        en_rango_cable_pickup = false;
        en_rango_cable_place = false;
        cable_place.SetActive(false);
        cable_pickup.SetActive(false);
        jugando = false;
    }

    private void Update()
    {
        if (jugando)
        {
            if (en_rango_cable_pickup && Input.GetKeyDown(KeyCode.E))
            {
                tiene_cable = true;
                cable_pickup.SetActive(false);
                txt_instrucciones.text = " ";
            }

            if (en_rango_cable_place && tiene_cable)
            {
                txt_instrucciones.text = "Apretar E para poner el cable.";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    cable_place.SetActive(true);
                    juego_finalizado = true;
                    jugando = false;
                    txt_instrucciones.text = " ";
                }
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.name == "[CABLEPICKUP]")
        {
            en_rango_cable_pickup = true;
            txt_instrucciones.text = "Apreta E para levantar el cable.";

        }

        if(col.name == "Monitor")
        {
            en_rango_cable_place = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.name == "[CABLEPICKUP]")
        {
            en_rango_cable_pickup = false;
            txt_instrucciones.text = " ";
        }

        if (col.name == "Monitor")
        {
            en_rango_cable_place = false;
            txt_instrucciones.text = " ";
        }
    }
}
