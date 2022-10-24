using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sesackapa : MonoBehaviour
{
    public GameObject sarıkart;
    public GameObject gameover;
    public GameObject zıplama;
    public GameObject button;
    public GameObject kirmizikart;
    public Sprite seskapali;
    public Sprite sesacik;
    public bool seskapandı;


     void Update()
    {

        if (PlayerPrefs.GetInt("Ses") == 1)
        {
            button.GetComponent<Image>().sprite = sesacik;
            seskapandı = false;
            sarıkart.GetComponent<AudioSource>().mute = false;
            kirmizikart.GetComponent<AudioSource>().mute = false;
            gameover.GetComponent<AudioSource>().mute = false;
            zıplama.GetComponent<AudioSource>().mute = false;

            
        }
        else
        {
            button.GetComponent<Image>().sprite = seskapali;
            seskapandı = true;
            sarıkart.GetComponent<AudioSource>().mute = true;
            kirmizikart.GetComponent<AudioSource>().mute = true;
            gameover.GetComponent<AudioSource>().mute = true;
            zıplama.GetComponent<AudioSource>().mute = true;


        }
    }
   
   

    public void Sesikapat()
    {
        

        

        if (seskapandı == false)
        {
            sarıkart.GetComponent<AudioSource>().mute = true;
            kirmizikart.GetComponent<AudioSource>().mute = true;
            gameover.GetComponent<AudioSource>().mute = true;
            zıplama.GetComponent<AudioSource>().mute = true;

            PlayerPrefs.SetInt("Ses", 0);

            
            
        
        }
        if(seskapandı == true)
        {
            sarıkart.GetComponent<AudioSource>().mute = false;
            kirmizikart.GetComponent<AudioSource>().mute = false;
            zıplama.GetComponent<AudioSource>().mute = false;
            gameover.GetComponent<AudioSource>().mute = false;

            PlayerPrefs.SetInt("Ses", 1);

        }
        
      
        PlayerPrefs.Save();

    }
    
    
    

    }


