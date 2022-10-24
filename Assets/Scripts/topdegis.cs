using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topdegis : MonoBehaviour
{
    public Sprite top1;
    public Sprite top2;
    public Sprite top3;
    public Sprite top4;
    public Sprite top5;
    public Sprite top6;
    public static bool topdegiss1 = false;
    public static bool topdegiss2 = false;
    public static bool topdegiss3 = false;
    public static bool topdegiss4 = false;
    public static bool topdegiss5 = false;
    public static bool topdegiss6 = false;
    void Start()
     {

        if (topdegiss1 == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = top1;
            
        }
        if (topdegiss2 == true)
        {
            
            this.gameObject.GetComponent<SpriteRenderer>().sprite = top2;
            
        }
        if (topdegiss3 == true)
        {
            
            this.gameObject.GetComponent<SpriteRenderer>().sprite = top3;
            
        }
        if (topdegiss4 == true)
        {
         
            this.gameObject.GetComponent<SpriteRenderer>().sprite = top4;
            
        }
        if (topdegiss5 == true)
        {
            
            this.gameObject.GetComponent<SpriteRenderer>().sprite = top5;
           
        }
        if (topdegiss6 == true)
        {
            
            this.gameObject.GetComponent<SpriteRenderer>().sprite = top6;
            
        }



    }

}
