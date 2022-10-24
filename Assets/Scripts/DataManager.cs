using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;


public class DataManager : MonoBehaviour
{

    public static DataManager Instance;
    public int score;
    
    public int highscore;
    public int olum;
    EasyFileSave myFile;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            

        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

 

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            


        }
    }
    
    public int Olum
    {
        get
        {
            return olum;
        }
        set
        {
            olum = value;



        }


    }
  
}