using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformA : MonoBehaviour
{
    public GameObject Aa;

    private void Start()
    {
        Aa.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Aa.SetActive(true);
        }

    }
}
