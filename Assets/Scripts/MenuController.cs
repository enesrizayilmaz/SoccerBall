using Firebase.Auth;
using Firebase.Database;
using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject kayitekrani;
    public GameObject oyunekrani;
    private InterstitialAd inter3;
    private InterstitialAd inter4;
    public GameObject scoreboardekranı;
    public GameObject menuekranı;
   
    private Saveloadmanager slManager;
    // Start is called before the first frame update
    public static MenuController Instance;
    private void Request3()
    {

        string adUnitId3 = "ca-app-pub-3058256649555601/1738988279";
        this.inter3 = new InterstitialAd(adUnitId3);
        this.inter3.OnAdClosed += InterstitalClosed;
        AdRequest request3 = new AdRequest.Builder().Build();
        this.inter3.LoadAd(request3);

    }
    private void Request4()
    {

        string adUnitId4 = "ca-app-pub-3058256649555601/3982008238";
        this.inter4 = new InterstitialAd(adUnitId4);
        this.inter4.OnAdClosed += InterstitalClosed;
        AdRequest request4 = new AdRequest.Builder().Build();
        this.inter4.LoadAd(request4);

    }
    private void InterstitalClosed(object sender, EventArgs e)
    {
        this.Request3();
        this.Request4();

    }
    private void Start()
    {
        this.Request3();
        this.Request4();
    }



    public void Sıralama()
    {
        
    }
    public void  TimeButton()
    {

        this.inter4.Show();



    }
    public void SkinButton()
    {

        SceneManager.LoadScene(1);
    }
    public void LeaderBoard()
    {
        this.inter3.Show();
        scoreboardekranı.SetActive(true);
        oyunekrani.SetActive(false);
        menuekranı.SetActive(false);
        kayitekrani.SetActive(false);

       
    }
    






    
    
    public void Exitt()
    {

        FirebaseAuth.DefaultInstance.SignOut();
        
        scoreboardekranı.SetActive(false);
        oyunekrani.SetActive(false);
        menuekranı.SetActive(false);
        kayitekrani.SetActive(true);

    }
    


}
