using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class Menu : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void play ()
    {
        SceneManager.LoadScene(1);
    }

    public void schließen()
    {
        Application.Quit();
    }

    public void Inventory()
    {
        SceneManager.LoadScene(2);
    }
        
}
