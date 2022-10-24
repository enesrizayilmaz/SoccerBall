using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dikendegdi : MonoBehaviour
{
    bool colliderBusy = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !colliderBusy)
        {

            colliderBusy = true;
            MenuControllerInGame.health -= 2;
            
            
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
