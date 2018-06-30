using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpcionesPausa : MonoBehaviour{
    public void Cerrar()
    {
        Debug.Log("Quit!!!");
        Application.Quit();
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}
