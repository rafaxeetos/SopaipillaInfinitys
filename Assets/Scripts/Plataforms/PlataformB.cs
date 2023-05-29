using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformB : MonoBehaviour
{

    public GameObject Bb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(Bb);
        }

    }

}
