using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Firebase.Auth;
using Firebase.Database;

public class Olustur : MonoBehaviour
{
    public GameObject sari;
    public GameObject arkaplan1;
    
    public GameObject yer1;
    public Text kullaniciadi_IF;
    public GameObject yer2;
   

    public Sprite skoryer200;
    public Sprite skoryer500;
    public Sprite skoryer1000;
    public Sprite skoryer1500;
    public Sprite skoryer2000;

    public Sprite skor100;
    public Sprite skor200;
    public Sprite skor500;
    public Sprite skor1000;
    public Sprite skor1500;
    public Sprite skor2000;


    public GameObject kirmizi;
    public GameObject yildiz;
  

    public GameObject diken;
    public static GameObject top;
    [SerializeField] Saveloadmanager slmanager;
    public static bool top1degis = false;
    public GameObject can;
    [SerializeField] FirebaseAuth auth;
    public Text Scoree;
    public Text HigScoree;

  
    public Transform oyuncu;
    float silinme_zamani = 7.5f;

    void Start()
    {
       


       


        PlayerPrefs.SetInt("Score",0);
        HigScoree.text = "HIGH SCORE:" + PlayerPrefs.GetInt("Scoree").ToString();
        
        Scoree.text = PlayerPrefs.GetInt("Score",0).ToString();
        if(DataManager.Instance.Score != 0)
        {
            DataManager.Instance.Score = 0;
        }
        
        InvokeRepeating("Skor_arttır",0,0.4f);
       
        
        InvokeRepeating("Nesne_klonla", 0,3.56f);


     

        

    }

    


    void Skor_arttır()
    {
        DataManager.Instance.Score++;
   
        
    
      

    }
    private void Update()
    {


        Scoree.text ="SCORE:" + DataManager.Instance.Score.ToString();

       
       
        if (DataManager.Instance.Score > PlayerPrefs.GetInt("Scoree")) 
        {
            
          HigScoree.text = "HIGH SCORE:" + DataManager.Instance.Score.ToString();
          PlayerPrefs.SetInt("Scoree", DataManager.Instance.Score);

           
            

          
           
            PlayerPrefs.Save();
            

        }
        

        if (DataManager.Instance.Score > 100 && DataManager.Instance.Score < 200)
        {

            arkaplan1.GetComponent<SpriteRenderer>().sprite = skor100;
            

        }
        if (DataManager.Instance.Score > 200 && DataManager.Instance.Score < 400)
        {
            arkaplan1.GetComponent<SpriteRenderer>().sprite = skor200;
            
            yer1.GetComponent<SpriteRenderer>().sprite = skoryer200;
            yer2.GetComponent<SpriteRenderer>().sprite = skoryer200;

        }
        if (DataManager.Instance.Score > 500 && DataManager.Instance.Score < 1000)
        {
            arkaplan1.GetComponent<SpriteRenderer>().sprite = skor500;
            
            yer1.GetComponent<SpriteRenderer>().sprite = skoryer500;
            yer2.GetComponent<SpriteRenderer>().sprite = skoryer500;

        }
        if (DataManager.Instance.Score > 1000 && DataManager.Instance.Score < 1500)
        {
            arkaplan1.GetComponent<SpriteRenderer>().sprite = skor1000;
            
            yer1.GetComponent<SpriteRenderer>().sprite = skoryer1000;
            yer2.GetComponent<SpriteRenderer>().sprite = skoryer1000;
            yer1.GetComponent<SpriteRenderer>().material.color = new Color32(116, 116, 116, 255);
            yer2.GetComponent<SpriteRenderer>().material.color = new Color32(116, 116, 116, 255);
            

        }
        if(DataManager.Instance.Score > 1500 && DataManager.Instance.Score < 2000)
        {
            arkaplan1.GetComponent<SpriteRenderer>().sprite = skor1500;

            yer1.GetComponent<SpriteRenderer>().sprite = skoryer1500;
            yer2.GetComponent<SpriteRenderer>().sprite = skoryer1500;

        }
        if(DataManager.Instance.Score > 2000)
        {
            arkaplan1.GetComponent<SpriteRenderer>().sprite = skor2000;

            yer1.GetComponent<SpriteRenderer>().sprite = skoryer2000;
            yer2.GetComponent<SpriteRenderer>().sprite = skoryer2000;
        }

        
    }
    

    void Nesne_klonla()

    {

        
       
       

       
        
        int rastsayi = Random.Range(0, 100);
      
        if(rastsayi > 0 && rastsayi <= 17 )
        {
            Klonla(sari,kirmizi,-3.27f);
        }
       
        if(rastsayi > 17 && rastsayi <= 35)
        {
       
           Klonla(yildiz,diken,-3.48f);
        }
        if(rastsayi > 35 && rastsayi <= 50)
        {

            Klonla(yildiz,yildiz,-1f);
        }
        if (rastsayi > 50 && rastsayi <= 70)
        {
            Klonla(sari,sari, -3.27f);
        }
        if(rastsayi > 70 && rastsayi < 73 && MenuControllerInGame.health < 3 )
        {
            Klonla(can,kirmizi, -3.4f);
        }
        if (rastsayi >= 73 && rastsayi < 83 && MenuControllerInGame.health < 3)
        {
            Klonla(can,yildiz, -1f);
        }
        if (rastsayi >= 83 && rastsayi < 100)
        {
            Klonla(diken,kirmizi, -3.401628f);
        }


   
        


    }
   
    void Klonla(GameObject nesne, GameObject nesne2,float Y_koordinat)
    {
        
       
        
        
        if(DataManager.Instance.Score >= 0 && DataManager.Instance.Score < 100  )
        {
            GameObject yeni_klon = Instantiate(nesne);
            GameObject yeni_klon2 = Instantiate(nesne2);
            int rastsayi = Random.Range(0, 100);
            


            if (rastsayi <= 50 )
            {

                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 23f, Y_koordinat, 0f);
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 38f, Y_koordinat, 0f);

              
                
               
            }

            if (rastsayi > 50 && rastsayi <= 100 )
            {
                
                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 25f, Y_koordinat, 0f);
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 36f, Y_koordinat, 0f);
               
            }

       
            


            Destroy(yeni_klon, silinme_zamani);
            Destroy(yeni_klon2, silinme_zamani);
        }

        if(DataManager.Instance.Score > 100 && DataManager.Instance.Score < 200)
        {

            GameObject yeni_klon = Instantiate(nesne);
            GameObject yeni_klon2 = Instantiate(nesne2);
            int rastsayi = Random.Range(0, 100);
            
            if (rastsayi <= 50 )
            {
                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 23f, Y_koordinat, 0f);
                
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 38f, Y_koordinat, 0f);
            }

            if (rastsayi > 50 && rastsayi <= 100)
            {
                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 24.7f, Y_koordinat, 0f);
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 34.7f, Y_koordinat, 0f);
                
            }





            Destroy(yeni_klon, silinme_zamani);
            Destroy(yeni_klon2, silinme_zamani);
        }

        if(DataManager.Instance.Score > 200 && DataManager.Instance.Score < 400 )
        {
            GameObject yeni_klon = Instantiate(nesne);
            GameObject yeni_klon2 = Instantiate(nesne2);

            int rastsayi = Random.Range(0, 100);
            if (rastsayi <= 40)
            {
                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 23f, Y_koordinat, 0f);
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 38f, Y_koordinat, 0f);
                
            }

            if (rastsayi > 40 && rastsayi <= 100)
            {
                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 24.6f, Y_koordinat, 0f);
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 35.5f, Y_koordinat, 0f);
               
            }





            Destroy(yeni_klon, silinme_zamani);
            Destroy(yeni_klon2, silinme_zamani);

        }
        if(DataManager.Instance.score > 400 && DataManager.Instance.Score < 1000)
        {
            GameObject yeni_klon = Instantiate(nesne);
            GameObject yeni_klon2 = Instantiate(nesne2);

            int rastsayi = Random.Range(0, 100);
            if (rastsayi <= 50 )
            {
                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 23f, Y_koordinat, 0f);
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 38f, Y_koordinat, 0f);
                
                
            }

            if (rastsayi > 50 && rastsayi <= 100 )
            {
                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 24.5f, Y_koordinat, 0f);
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 35.25f, Y_koordinat, 0f);
                
                
            }





            Destroy(yeni_klon2, silinme_zamani);
            Destroy(yeni_klon, silinme_zamani);
        }
        if (DataManager.Instance.Score >= 1000 && DataManager.Instance.Score < 2000) 
        {
            GameObject yeni_klon = Instantiate(nesne);
            GameObject yeni_klon2 = Instantiate(nesne2);

            int rastsayi = Random.Range(0, 100);
            if (rastsayi <= 50)
            {
                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 23f, Y_koordinat, 0f);
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 38f, Y_koordinat, 0f);
                

            }

            if (rastsayi > 50 && rastsayi <= 100)
            {
                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 23.2f, Y_koordinat, 0f);
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 35.40f, Y_koordinat, 0f);
                

            }




            Destroy(yeni_klon2, silinme_zamani);

            Destroy(yeni_klon, silinme_zamani);
        }
        if (DataManager.Instance.Score >= 2000 && DataManager.Instance.Score < 99999999)
        {
            GameObject yeni_klon = Instantiate(nesne);
            GameObject yeni_klon2 = Instantiate(nesne2);

            int rastsayi = Random.Range(0, 100);
            if (rastsayi <= 50)
            {
                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 23f, Y_koordinat, 0f);
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 38f, Y_koordinat, 0f);


            }

            if (rastsayi > 50 && rastsayi <= 100)
            {
                yeni_klon.transform.position = new Vector3(oyuncu.position.x + 23.2f, Y_koordinat, 0f);
                yeni_klon2.transform.position = new Vector3(oyuncu.position.x + 35.10f, Y_koordinat, 0f);


            }




            Destroy(yeni_klon2, silinme_zamani);

            Destroy(yeni_klon, silinme_zamani);
        }

    }
        
    
    }









