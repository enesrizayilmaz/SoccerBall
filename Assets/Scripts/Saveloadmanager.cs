using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Firebase.Auth;

public class Saveloadmanager : MonoBehaviour
{
    Datasave data;
    public DatabaseReference DBreference;
    [SerializeField] FirebaseAuth auth;
    DatabaseReference reference;

    private void Start()
    {
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
        FirebaseUser user = auth.CurrentUser;
        string userid = user.UserId;

        
    }

   
    
    public void SaveData(string userid,string useremail,int score,string id)
    {

     
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        
        data = new Datasave(userid, useremail, score,id);
       
        string jsonData = JsonUtility.ToJson(data);
        reference.Child("Player" + userid).SetRawJsonValueAsync(jsonData);
       
    }
    public void LoadData(string userid)
    {

        reference = FirebaseDatabase.DefaultInstance.RootReference;
        
            reference.GetValueAsync().ContinueWith(
            task =>
            {
                if (task.IsCanceled)
                {
                    Debug.Log("Loading data canceled");
                    return;
                }
                if(task.IsFaulted)
                {
                    Debug.Log("Wrong account");
                }
                if(task.IsCompleted)
                {
                    DataSnapshot data = task.Result;
                    
                    string playerData = data.Child("Player"+ userid).GetRawJsonValue();
                   
                   
                    Datasave pd = JsonUtility.FromJson<Datasave>(playerData);

                    PlayerPrefs.SetInt("Scoree", pd._score);
                    PlayerPrefs.SetString("id", pd._id);
                   








                }
                
            });
      
    }

    
    
}
