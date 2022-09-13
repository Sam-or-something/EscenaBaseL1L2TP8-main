using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscarElCable : MonoBehaviour
{
    private bool tiene_cable;
    private bool juego_finalizado;
    private bool en_rango_cable_pickup;
    [SerializeField] private GameObject cable_pickup;
    [SerializeField] private GameObject cable_place;
    private bool en_rango_cable_place;
    public bool jugando;

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
            cable_pickup.SetActive(true);
            if (en_rango_cable_pickup && Input.GetKeyDown(KeyCode.L))
            {
                tiene_cable = true;
                cable_pickup.SetActive(false);
            }

            if (en_rango_cable_place && tiene_cable && Input.GetKeyDown(KeyCode.L))
            {
                cable_place.SetActive(true);
                juego_finalizado = true;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.name == "[CABLEPICKUP]")
        {
            en_rango_cable_pickup = true;
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
        }

        if (col.name == "Monitor")
        {
            en_rango_cable_place = false;
        }
    }
}
