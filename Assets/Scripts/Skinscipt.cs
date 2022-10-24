using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Skinscipt : MonoBehaviour

    
{
    public static Skinscipt Instance;
    public Button button1;
    public Button button2;
    public GameObject tik;
    public Button button3;
    public Button button4;
    public static Boolean skin = false;
    public Button button5;
    public Boolean skinana;
    public Button button6;
   

    
    void Start()
    {

        skin = true;
        
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;
        button4.interactable = false;
        button5.interactable = false;
        button6.interactable = false;
        kilit_sistemi();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void geridon()
    {
        SceneManager.LoadScene(0);
    }
    public void kilit_sistemi()
    {
        int scores = PlayerPrefs.GetInt("Scoree");
        if(scores > 100)
        {
           

            button1.interactable = true;
            button2.interactable = false;
            button3.interactable = false;
            button4.interactable = false;
            button5.interactable = false;
            button6.interactable = false;



        }
        if (scores > 200)
        {
            button1.interactable = true;
            button2.interactable = true;
            button3.interactable = false;
            button4.interactable = false;
            button5.interactable = false;
            button6.interactable = false;
        }
        if (scores > 500)
        {
            button1.interactable = true;
            button2.interactable = true;
            button3.interactable = true;
            button4.interactable = false;
            button5.interactable = false;
            button6.interactable = false;
        }
        if (scores > 700)
        {
            button1.interactable = true;
            button2.interactable = true;
            button3.interactable = true;
            button4.interactable = true;
            button5.interactable = false;
            button6.interactable = false;
        }
        if (scores > 1000)
        {
            button1.interactable = true;
            button2.interactable = true;
            button3.interactable = true;
            button4.interactable = true;
            button5.interactable = true;
            button6.interactable = false;
        }
        if (scores > 2000)
        {
            button1.interactable = true;
            button2.interactable = true;
            button3.interactable = true;
            button4.interactable = true;
            button5.interactable = true;
            button6.interactable = true;
        }



    }

    public void Top1sec()
    {
        GameObject yeniklon =Instantiate(tik);
        yeniklon.transform.position = new Vector3(-4.41f, 1.16f, 0);
        Destroy(yeniklon, 0.7f);
        
        topdegis.topdegiss1 = true;
        topdegis.topdegiss2 = false;
        topdegis.topdegiss6 = false;
        topdegis.topdegiss3 = false;
        topdegis.topdegiss4 = false;
        topdegis.topdegiss5 = false;
    }
    public void Top2sec()
    {
        GameObject yeniklon2 = Instantiate(tik);
        yeniklon2.transform.position = new Vector3(1.8f, 0.9547794f, 0);
        
        Destroy(yeniklon2, 0.7f);
        topdegis.topdegiss1 = false;
        topdegis.topdegiss2 = true;
        topdegis.topdegiss6 = false;
        topdegis.topdegiss3 = false;
        topdegis.topdegiss4 = false;
        topdegis.topdegiss5 = false;
    }


    public void Top3sec()
    {
        GameObject yeniklon3 = Instantiate(tik);
        yeniklon3.transform.position = new Vector3(7.5f, 0.8f, 0);
        Destroy(yeniklon3, 0.7f);
        topdegis.topdegiss4 = false;
        topdegis.topdegiss5 = false;
        topdegis.topdegiss6 = false;
        topdegis.topdegiss2 = false;
        topdegis.topdegiss3 = true;
        topdegis.topdegiss1 = false;
    }
    public void Top4sec()
    {
        GameObject yeniklon4 = Instantiate(tik);
        yeniklon4.transform.position = new Vector3(-4.2f, -3.1f, 0);
        Destroy(yeniklon4, 0.7f);
        topdegis.topdegiss2 = false;
        topdegis.topdegiss3 = false;
        topdegis.topdegiss1 = false;
        topdegis.topdegiss5 = false;
        topdegis.topdegiss6 = false;
        topdegis.topdegiss4 = true;
    }
    public void Top5sec()
    {
        GameObject yeniklon5 = Instantiate(tik);
        yeniklon5.transform.position = new Vector3(1.8f, -2.7f, 0);
        Destroy(yeniklon5, 0.7f);
        topdegis.topdegiss2 = false;
        topdegis.topdegiss6 = false;
        topdegis.topdegiss3 = false;
        topdegis.topdegiss1 = false;
        topdegis.topdegiss4 = false;
        topdegis.topdegiss5 = true;
    }
    public void Top6sec()
    {
        GameObject yeniklon6 = Instantiate(tik);
        yeniklon6.transform.position = new Vector3(7.1f, -3.4f, 0);
        Destroy(yeniklon6, 0.7f);
        topdegis.topdegiss2 = false;
        topdegis.topdegiss3 = false;
        topdegis.topdegiss4 = false;
        topdegis.topdegiss1 = false;
        topdegis.topdegiss5 = false;
        topdegis.topdegiss6 = true;
    }
}
