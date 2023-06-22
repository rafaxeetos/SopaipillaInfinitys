using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopManager : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player1"))
      {
         SceneManager.LoadScene("Start");
      }

      if (other.CompareTag("Player2"))
      {
         SceneManager.LoadScene("Start");
      }
   }
}
