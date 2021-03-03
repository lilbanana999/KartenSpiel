using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Öffnen : MonoBehaviour
{
    
    private string[] gezogeneKarten;
    private (string, int)[] kartenPack1;
    private (string, int)[] kartenPack2;
    private (string, int)[] kartenPack3;
    public int kartenanzahl;
    public int Münzenanzahl;
    public Text Münzen;
    private void Start() 
    {
        Münzenanzahl = 0;
        
        kartenPack1 = new (string, int)[5]
        {
            ("ozelot", 2),
            ("Hase", 7),
            ("Gürteltier", 1),
            ("Niete", 20),
            ("Bär", 6)
        };
        kartenPack2 = new (string, int)[6]
        {
            ("Hund", 2),
            ("Katze", 7),
            ("Gürteltier", 1),
            ("Niete", 20),
            ("Bär", 6),
            ("1000 Münzen", 10)
        };
        kartenPack3 = new (string, int)[5]
        {
            ("Gürtelgürtel", 2),
            ("Gürtelhase", 7),
            ("Gürteltier", 1),
            ("Gürtelhund", 20),
            ("Gürtelbär", 6)
        };
        
        
        kartenanzahl = 2;
        gezogeneKarten = new string[kartenanzahl];

    }

    public void OnKlick1()
    {
        KartenZiehen(kartenPack1);
    }
    public void OnKlick2()
    {
        KartenZiehen(kartenPack2);
    }
    public void OnKlick3()
    {
        KartenZiehen(kartenPack3);
    }

    private void KartenZiehen((string, int)[] kartenPack)
    {
        List<string> temp = new List<string>();

        for (int i = 0; i < kartenPack.Length; i++)
        {
            for (int j = 0; j < kartenPack[i].Item2; j++)
            {
                temp.Add(kartenPack[i].Item1);
            }
        }
        
        for (int i = 0; i < kartenanzahl; i++)
        {
            int RandomNumber = Random.Range(0, temp.Count);
            gezogeneKarten[i] = temp[RandomNumber];
            if (temp[RandomNumber] == "1000 Münzen")
            {
                Münzenanzahl += 1000;
                Münzen.text = Münzenanzahl.ToString(); 
            }
               

        }

        for (int i = 0; i < gezogeneKarten.Length; i++)
        {
            Debug.Log(gezogeneKarten[i]);
        }
    }

    public void BAckinbusiness()
    {
        SceneManager.LoadScene(0);
    }

    public void Geldmanager()
    {
        
    }
    
}
