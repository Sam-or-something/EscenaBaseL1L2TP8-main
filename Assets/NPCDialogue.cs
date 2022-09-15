using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    private string[] current_conversation;
    private int current_dialogue_nmbr;
    private string[] dialogo0 = new string[] {"Hola",
        "Los chicos de tercero van a llegar en medio minuto y no esta funcionando una de las computadoras de escritorio.",
        "Hable con Jero y me dijo que puso las instrucciones para arreglarlo en el proyector.",
        "Podes ayudarme y arreglarla antes de que lleguen los alumnos?" };
    private string[] dialogo1 = new string[] { "Todavia no terminaste?", "Cuidado que te queda poco tiempo." };
    private string[] dialogo2_win = new string[] { "Arreglaste la compu!", "Muchas gracias." };
    private string[] dialogo3_lose = new string[] {"Llegaron los chicos y todavia no esta funcionando la compu.",
        "Que pena :(" };
    private bool en_rango;
    private bool jugando;
    private bool juego_finalizado;
    [SerializeField] private GameObject jugador;
    public bool empezado;
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Text Txt_instrucciones;

    void Start()
    {
        en_rango = false;
        txt_Dialogue.text = " ";
        Txt_instrucciones.text = " ";
    }

    void Update()
    {
        jugando = jugador.GetComponent<BuscarElCable>().jugando;
        juego_finalizado = jugador.GetComponent<BuscarElCable>().juego_finalizado;

        if (!empezado)
        {
            current_conversation = dialogo0;
        }
        else if (jugando)
        {
            current_conversation = dialogo1;
        }
        else if(!jugando && juego_finalizado)
        {
            current_conversation = dialogo2_win;
        }
        else if(!jugando && !juego_finalizado)
        {
            current_conversation = dialogo3_lose;
        }

        if(en_rango && Input.GetKeyDown(KeyCode.E))
        {
            if(current_dialogue_nmbr < current_conversation.Length -1)
            {
                txt_Dialogue.text = current_conversation[current_dialogue_nmbr];
            }
            else
            {
                txt_Dialogue.text = current_conversation[current_dialogue_nmbr];
                current_dialogue_nmbr = 0;
                if (!empezado)
                {
                    empezado = true;
                    jugador.GetComponent<BuscarElCable>().jugando = true;
                    txt_Dialogue.text = " ";
                    jugador.GetComponent<BuscarElCable>().cable_pickup.SetActive(true);
                }
            }
            current_dialogue_nmbr++;
        }
        if (empezado && !jugando){
            jugador.transform.position = new Vector3(-0.48f, 0.8250002f, 8.85f);
            txt_Dialogue.text = current_conversation[0];
            current_dialogue_nmbr = 1;
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.name == "FPSController")
        {
            en_rango = true;
            Txt_instrucciones.text = "Apreta E para hablar con el mep";
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.name == "FPSController")
        {
            en_rango = false;
            current_dialogue_nmbr = 0;
            txt_Dialogue.text = " ";
            Txt_instrucciones.text = " ";
        }
    }
}
