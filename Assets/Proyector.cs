using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyector : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("proyectando");
    }
}
