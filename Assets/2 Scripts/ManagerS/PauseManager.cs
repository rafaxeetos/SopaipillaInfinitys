using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject opcionesPag;
    public GameObject pausaPag;

    public void Opciones()
    {
        opcionesPag.SetActive(true);
    }

    public void CerrarOpciones()
    {
        opcionesPag.SetActive(false);
    }

    public void CerrarPausa()
    {
        pausaPag.SetActive(false);
        Time.timeScale = 1;
    }

    public void SalirMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
