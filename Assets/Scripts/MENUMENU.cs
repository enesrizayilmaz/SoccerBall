using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MENUMENU : MonoBehaviour
{
    public GameObject kayitekrani;
    public GameObject oyunekrani;

    public GameObject scoreboardekranı;
    public GameObject menuekranı;

    private Saveloadmanager slManager;
    // Start is called before the first frame update
    public static MenuController Instance;


    private void Start()
    {
        slManager = FindObjectOfType<Saveloadmanager>();

        kayitekrani.SetActive(false);
        scoreboardekranı.SetActive(false);
        menuekranı.SetActive(true);


    }
    // Update is called once per frame
    void Update()
    {


    }

    public void Gecis()
    {
        
    }
    public void Menubutton()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayButton()
    {
        kayitekrani.SetActive(false);
        scoreboardekranı.SetActive(false);
        menuekranı.SetActive(false);
        oyunekrani.SetActive(true);


    }
    public void SkinButton()
    {
        SceneManager.LoadScene(1);
    }
    public void LeaderBoard()
    {
        scoreboardekranı.SetActive(true);

        menuekranı.SetActive(false);
        kayitekrani.SetActive(false);
        oyunekrani.SetActive(false);

    }









    public void Exitt()
    {

        FirebaseAuth.DefaultInstance.SignOut();
        SceneManager.LoadScene(0);

    }



}
