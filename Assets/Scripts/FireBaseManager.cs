using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Database;
using System;
using System.Linq;
using TMPro;
public class FireBaseManager : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public static FireBaseManager Instance;
    public DatabaseReference DBreference;
    public Text email, id, message;
    public GameObject kayitekrani;
    public GameObject scoreElement;
    public Transform scoreboardContent;
    public GameObject scoreboardekranı;
    public GameObject menuekranı;
    public GameObject oyunekrani;
    [SerializeField] FirebaseAuth auth;
    private Saveloadmanager slmanager;
    public DatabaseReference reference;
 

    private void Start()

    {

        slmanager = FindObjectOfType<Saveloadmanager>();

        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
       

       
        StartCoroutine(LoadData());
     

    }

    public IEnumerator LoadData()
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


              
                string usermail = childSnapshot.Child("_usermail").Value.ToString();
                string useridd = childSnapshot.Child("_UserId").Value.ToString();
                string username = childSnapshot.Child("_id").Value.ToString();
                string score = childSnapshot.Child("_score").Value.ToString();
             
                    slmanager.SaveData(useridd, usermail, Convert.ToInt32(score), username);


                
                GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(username, score);

            }

            
        }
    }


    void Update()
    {
       

        
        
        
        message.SetAllDirty();
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        
      
    }
    
    

    public void Login()
    {
        
        if (email.text == "" || id.text == "")
        {
            message.text = "Please enter e-mail and password";
        }
      

        PlayerPrefs.SetString("id", id.text);

        auth.SignInWithEmailAndPasswordAsync(email.text, id.text).ContinueWith(
            task =>
            {
                

                if (task.IsCanceled)
                {
                    print("Login canceled");
                    message.text = "Login canceled";
                    return;
                    
                }
                if (task.IsFaulted)
                {
                    FirebaseUser User = task.Result;
                    print(task.Exception);
                    message.text = "Wrong Id or E-mail/Hatalı giriş";
                  
                    slmanager.LoadData(User.UserId);
                    return;

                }
                if (task.IsCompleted)
                {
                    FirebaseUser User = task.Result;
                    
                    
                    print("User Logged In Successfully");
                    message.text = "Logged in as Email";
                   
                    slmanager.LoadData(User.UserId);
                    

                    return;
                    
                }
               

            });

        
        
    }
    

    public void Register()
    {

        

        if ( email.text == "" || id.text == "" )
        {
            message.text = "Please enter e-mail and password";
        }
        FirebaseUser user = auth.CurrentUser;
      
        string idd = id.text;
        PlayerPrefs.SetString("id", id.text);
        auth.CreateUserWithEmailAndPasswordAsync(email.text, id.text).ContinueWith(
            task =>
            {
            if (task.IsCanceled)
            {
            print("Registeration canceled");
            message.text = "Registeration canceled";
            return;
            }
            if (task.IsFaulted)
            {
            print(task.Exception);
                    message.text = "Wrong Id or E-mail/Hatalı kayıt,id 6 dan büyük olmalıdır";
            return;
  
            }
            if (task.IsCompleted)
            {
                    
                    FirebaseUser newUser = task.Result;
                  int score = 0;
          slmanager.SaveData(newUser.UserId, newUser.Email, score,idd);
                    slmanager.LoadData(newUser.UserId);

                    print("User Created Successfully");
            message.text = "User Created Successfully Email:" + newUser.Email + "UserId:" + newUser.UserId;
            return;
            }
            }
            );
            
                
        

    }
    
    public void Logout()
    {
        
            kayitekrani.SetActive(true);
            scoreboardekranı.SetActive(false);
            menuekranı.SetActive(false);
            auth.SignOut();
            FirebaseAuth.DefaultInstance.SignOut();

     

    }
  

}
