using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Authsceneingame : MonoBehaviour
{

    public TextMeshProUGUI scoretext;
    public DatabaseReference DBreference;
    public GameObject kayitekrani;
    public GameObject scoreboardekranı;
    private Text email, id;
    public GameObject inGameScreen, pauseScreen, deathScreen;
    public GameObject menuekranı;
    public GameObject oyunekrani;
    public GameObject timekrani;
    public GameObject system1;
    public GameObject system2;
    public GameObject system3;
    public GameObject system4;
    [SerializeField] Saveloadmanager slManager;
    
    private string userId = "";
    [SerializeField] FirebaseAuth auth;

    
    private void Start()

    {
        
        
        if (MenuControllerInGame.anamenu == true || Skinscipt.skin == true )
        {
            oyunekrani.SetActive(false);
            menuekranı.SetActive(true);
            kayitekrani.SetActive(false);
            pauseScreen.SetActive(false);
            inGameScreen.SetActive(false);
            deathScreen.SetActive(false);
        }


        if (PlayerPrefs.GetInt("replay") == 1)
        {
            oyunekrani.SetActive(true);
            menuekranı.SetActive(false);
            kayitekrani.SetActive(false);
            pauseScreen.SetActive(false);
            inGameScreen.SetActive(true);
            deathScreen.SetActive(false);
            system1.SetActive(false);
            system2.SetActive(false);
            system3.SetActive(false);
            system4.SetActive(false);

        }

        

        slManager = FindObjectOfType<Saveloadmanager>();
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseAuth.DefaultInstance.StateChanged += HandleAuthStateChanged;
        CheckUser();

    }
 
    private void OnDestroy()
    {
       
        FirebaseAuth.DefaultInstance.StateChanged -= HandleAuthStateChanged;
        
    }


    private void HandleAuthStateChanged(object sender, EventArgs e)
    {
        CheckUser();


    }
    public void girisoyun()
    {
        if (PlayerPrefs.GetInt("replay") == 1)
        {
            oyunekrani.SetActive(true);
            menuekranı.SetActive(false);
            pauseScreen.SetActive(false);
            inGameScreen.SetActive(true);
            kayitekrani.SetActive(false);
            deathScreen.SetActive(false);
            system1.SetActive(false);
            system2.SetActive(false);
            system3.SetActive(false);
            system4.SetActive(false);

        }
        else
        inGameScreen.SetActive(true);
        kayitekrani.SetActive(false);
        scoreboardekranı.SetActive(false);
        menuekranı.SetActive(false);
        oyunekrani.SetActive(true);
        system1.SetActive(false);
        system2.SetActive(false);
        system3.SetActive(false);
        system4.SetActive(false);
    }
    public void girisscore()
    {
        if (PlayerPrefs.GetInt("replay") == 1)
        {
            oyunekrani.SetActive(true);
            menuekranı.SetActive(false);
            kayitekrani.SetActive(false);
            pauseScreen.SetActive(false);
            inGameScreen.SetActive(true);
            deathScreen.SetActive(false);
        }
        else
        kayitekrani.SetActive(false);
        scoreboardekranı.SetActive(true);
        menuekranı.SetActive(false);
        oyunekrani.SetActive(false);
    }
    public void girismenu()
    {
        if (PlayerPrefs.GetInt("replay") == 1)
        {
            oyunekrani.SetActive(true);
            menuekranı.SetActive(false);
            kayitekrani.SetActive(false);
            pauseScreen.SetActive(false);
            inGameScreen.SetActive(true);
            deathScreen.SetActive(false);
        }
        else
          kayitekrani.SetActive(false);
        scoreboardekranı.SetActive(false);
        menuekranı.SetActive(true);
        oyunekrani.SetActive(false);
    }
    public void giristime()
    {
        if (PlayerPrefs.GetInt("replay") == 1)
        {
            oyunekrani.SetActive(true);
            menuekranı.SetActive(false);
            kayitekrani.SetActive(false);
            pauseScreen.SetActive(false);
            inGameScreen.SetActive(true);
            deathScreen.SetActive(false);
        }
        else
        kayitekrani.SetActive(false);
        scoreboardekranı.SetActive(false);
        menuekranı.SetActive(false);
        oyunekrani.SetActive(false);
        timekrani.SetActive(true);
    }

    public void Geridon()
    {
        kayitekrani.SetActive(false);
        scoreboardekranı.SetActive(false);
        menuekranı.SetActive(true);
        oyunekrani.SetActive(false);
        timekrani.SetActive(false);
    }


    private void CheckUser()
    {
        if (FirebaseAuth.DefaultInstance.CurrentUser != null)
        {
           
            userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
            if (PlayerPrefs.GetInt("replay") == 1)
            {

                oyunekrani.SetActive(true);
                menuekranı.SetActive(false);
                kayitekrani.SetActive(false);
                pauseScreen.SetActive(false);
                inGameScreen.SetActive(true);
                deathScreen.SetActive(false);
            }
            else
            {
                StartCoroutine(LoadPlayer());
            }
              


        }
        else
        {
           
            kayitekrani.SetActive(true);
            scoreboardekranı.SetActive(false);
            menuekranı.SetActive(false);
            oyunekrani.SetActive(false);
        }
    }

    IEnumerator LoadPlayer()
    {

        var DBTask = DBreference.OrderByChild("_score").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            //Destroy any existing scoreboard elements



            //Loop through every users UID
            DBreference = FirebaseDatabase.DefaultInstance.RootReference;
            auth = FirebaseAuth.DefaultInstance;
            FirebaseUser user = auth.CurrentUser;
            string userid = user.UserId;

            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {




                string useridd = childSnapshot.Child("_UserId").Value.ToString();
                string username = childSnapshot.Child("_id").Value.ToString();
                string score = childSnapshot.Child("_score").Value.ToString();
                if (useridd == userid)
                {
                   
                    PlayerPrefs.SetInt("Scoree", Convert.ToInt32(score));
                    PlayerPrefs.SetString("id", username);
                    
                    scoretext.text = username + ":" + score;


                }


            }


        }
       
            scoreboardekranı.SetActive(false);
            oyunekrani.SetActive(false);
            menuekranı.SetActive(true);
            kayitekrani.SetActive(false);
        

        
        yield return new WaitForSeconds(3f);
    }
}
