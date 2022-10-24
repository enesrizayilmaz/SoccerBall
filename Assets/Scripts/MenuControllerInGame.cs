
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds;
using Firebase.Auth;

public class MenuControllerInGame : MonoBehaviour
{
    [SerializeField] Saveloadmanager slManager;

    private RewardedAd rewardedAd;
    [SerializeField] FirebaseAuth auth;
    public GameObject menuscreen;
    public GameObject gamescreen;
    public static Boolean reklamgos;
    public GameObject inGameScreen, pauseScreen, deathScreen;
    public GameObject odulluScreen;
    public GameObject heart1, heart2, heart3;
    private InterstitialAd inter;
    private InterstitialAd inter2;
    public static Boolean giris;
    public static Boolean anamenu = false;
    public static int health;
    public int skor;

    
    // Start is called before the first frame update
   

    void Start()
    {
        string id = "ca-app-pub-3058256649555601/2835768902";
        reklamgos = false;
        this.rewardedAd = new RewardedAd(id);
        AdRequest request = new AdRequest.Builder().Build();

        this.rewardedAd.LoadAd(request);

        this.Request();
        this.Request2();

        this.rewardedAd.OnUserEarnedReward += VideoRewarded;

        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;


        slManager = FindObjectOfType<Saveloadmanager>();
        health = 3;
        PlayerPrefs.SetInt("replay", 0);

        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);

    }
    private void Request()
    {

        string adUnitId = "ca-app-pub-3058256649555601/8777595417";
        this.inter = new InterstitialAd(adUnitId);
        this.inter.OnAdClosed += InterstitalClosed;
        AdRequest request = new AdRequest.Builder().Build();
        this.inter.LoadAd(request);

    }
    private void Request2()
    {

        string adUnitId2 = "ca-app-pub-3058256649555601/3497437865";
        this.inter2 = new InterstitialAd(adUnitId2);
        this.inter2.OnAdClosed += InterstitalClosed;
        AdRequest request2 = new AdRequest.Builder().Build();
        this.inter2.LoadAd(request2);

    }
    public void CreateAndLoadRewardedAd()
    {
        string id = "ca-app-pub-3058256649555601/2835768902";
        AdRequest odrequest = new AdRequest.Builder().Build();
        this.rewardedAd = new RewardedAd(id);
        this.rewardedAd.LoadAd(odrequest);
        this.rewardedAd.OnUserEarnedReward += VideoRewarded;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        reklamgos = true;
    }
   


    private void InterstitalClosed(object sender, EventArgs e)
    {
        this.Request();
        this.Request2();
    }

    private void VideoRewarded(object sender, EventArgs e)
    {
        Reward();

    }
    

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.CreateAndLoadRewardedAd();

        odulluScreen.SetActive(false);
        inGameScreen.SetActive(true);
        gamescreen.SetActive(true);

        Time.timeScale = 1;
    }
    
 

    // Update is called once per frame
    void Update()
    {
        
        if (health > 3)
        {
            health = 3;
            
        }
        if (health < 0)
        {
            health = 0;
        }

        switch (health)
        {
            case 3:

                
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;


            case 2:
              
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;


            case 1:
               
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;


            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                if (health == 0)
                {

                  
                    Time.timeScale = 0;
                    

                }

                if(reklamgos == false)
                {

                    inGameScreen.SetActive(false);
                    pauseScreen.SetActive(false);
                    odulluScreen.SetActive(true);



                }
                else
                {
                    inGameScreen.SetActive(false);
                    pauseScreen.SetActive(false);
                    deathScreen.SetActive(true);
                }






                break;




                






        }


    }
    
   

    public void PauseButton()
    {
        Time.timeScale = 0;
      
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);

    }

    public void PlayButton()
    {
        Time.timeScale = 1;
       
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
        
    }
   
    public void ReplayButton()
    {
       
        auth = FirebaseAuth.DefaultInstance;
        FirebaseUser user = auth.CurrentUser;
        PlayerPrefs.SetInt("replay", 1);
       
        PlayerPrefs.Save();
        string userid = user.UserId;
        int score = PlayerPrefs.GetInt("Scoree");
        slManager.SaveData(user.UserId, user.Email, score, PlayerPrefs.GetString("id"));
        
        health = 3;
    
        
      
            
        //Reklam açıldı.
        this.inter.Show();
           
     

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
        deathScreen.SetActive(false);
        menuscreen.SetActive(false);
        
        
        
        DataManager.Instance.Score = 0;
     
      
        PlayerPrefs.Save();
        
        



    }


   
    public void HomeButton()
    {
        auth = FirebaseAuth.DefaultInstance;
        FirebaseUser user = auth.CurrentUser;
        string userid = user.UserId;
        int score = PlayerPrefs.GetInt("Scoree");
        slManager.SaveData(user.UserId, user.Email, score, PlayerPrefs.GetString("id"));
        this.inter2.Show();
        PlayerPrefs.Save();
        giris = true;
        
        health = 3;
        
        PlayerPrefs.DeleteKey("Score");
        anamenu = true;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        

    }
    public void ShowAds()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }

    }
    private void Reward()
    {
        MenuControllerInGame.health = 3;
    }




}
