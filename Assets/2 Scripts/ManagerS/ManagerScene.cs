using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
   public void Tutorial()
   {
      SceneManager.LoadScene("1Tutorial");
   }

   public void Menu()
   {
      SceneManager.LoadScene("Menu");
   }

   public void Creditos()
   {
      SceneManager.LoadScene("Creditos");
   }

   public void Nivel1()
   {
      SceneManager.LoadScene("2Nivel1");
   }

   public void Opciones()
   {
      SceneManager.LoadScene("Opciones");
   }
}
