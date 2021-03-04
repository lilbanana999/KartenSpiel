using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Öffnen : MonoBehaviour
{
    [Serializable]
    public struct Karte
    {
        public GameObject Prefab;
        public string id;
    }
    
    private string[] gezogeneKarten;
    private (string, int)[] kartenPack1;
    private (string, int)[] kartenPack2;
    private (string, int)[] kartenPack3;
    public int kartenanzahl;
    public int Münzenanzahl;
    public int addcash1k;
    public int addcash5k;
    public Text Münzen;
    public Button silberPack;
    public Button goldPack;
    public Button gürtelPack;
    public GameObject layoutGroup;
    public Karte[] Karten;
    private List<GameObject> angezeigteKarten;
    public List<GameObject> Inventar;
    
    private void Start()
    {
        angezeigteKarten = new List<GameObject>();
        Münzenanzahl = 5000;
        addcash1k = 1000;
        addcash5k = 5000;
        
        Münzen.text = Münzenanzahl.ToString() + "$";
        
        kartenPack1 = new (string, int)[6]
        {
            ("hyäne", 2),
            ("drache", 7),
            ("gürteltier", 1),
            ("Niete", 20),
            ("dino", 6),
            ("Münzen", 5)
        };
        kartenPack2 = new (string, int)[6]
        {
            ("Hund", 2),
            ("Katze", 7),
            ("Gürteltier", 1),
            ("Niete", 20),
            ("Bär", 6),
            ("Münzen", 10)
        };
        kartenPack3 = new (string, int)[6]
        {
            ("Gürtelgürtel", 1),
            ("Gürtelhase", 14),
            ("Gürteltier", 2),
            ("Gürtelhund", 20),
            ("Gürtelbär", 12),
            ("Münzen", 6)
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
        Münzenanzahl -= 1000;
        Münzen.text = Münzenanzahl.ToString() + "$";
        CheckPrices();
    }
    public void OnKlick3()
    {
        KartenZiehen(kartenPack3);
        Münzenanzahl -= 1000;
        Münzen.text = Münzenanzahl.ToString() + "$";
        CheckPrices();
    }

    private void KartenZiehen((string, int)[] kartenPack)
    {
        for (int i = 0; i < angezeigteKarten.Count; i++)
        {
            Destroy(angezeigteKarten[i]);
        }

        
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
            if (temp[RandomNumber] == "Münzen")
            {
                int amount = Random.Range(100, 500);
                Münzenanzahl += amount;
                Münzen.text = Münzenanzahl.ToString() + "$";
                gezogeneKarten[i] = $"{amount} Münzen";
                CheckPrices();
            }
               

        }

        for (int i = 0; i < gezogeneKarten.Length; i++)
        {
            Debug.Log(gezogeneKarten[i]);

            for (int j = 0; j < Karten.Length; j++)
            {
                if (gezogeneKarten[i] == Karten[j].id)
                {
                    GameObject karte = Instantiate(Karten[j].Prefab);
                    karte.transform.SetParent(layoutGroup.transform);
                    angezeigteKarten.Add(karte);
                    Inventar.Add(karte);
                }
            }
        }
    }

    public void BAckinbusiness()
    {
        SceneManager.LoadScene(0);
    }

    public void CheckPrices()
    {
        if (Münzenanzahl < 1000)
        {
            gürtelPack.interactable = false;
            goldPack.interactable = false;
        }
        else
        {
            gürtelPack.interactable = true;
            goldPack.interactable = true;
        }

    }
    
}
