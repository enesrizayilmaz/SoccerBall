using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeniyol : MonoBehaviour
{

    public Transform yol;
    public Transform yol2;
   
 
 

    private void OnTriggerEnter2D(Collider2D other)
    {

        
        if(other.gameObject.name == "SON")
        {
            yol2.position = new Vector3(yol.position.x + 31.2f,yol.position.y,yol.position.z);

           
        }

        if(other.gameObject.name == "SON2")
        {
            yol.position = new Vector3(yol2.position.x + 31.2f , yol2.position.y, yol2.position.z);
            

        }
      
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
