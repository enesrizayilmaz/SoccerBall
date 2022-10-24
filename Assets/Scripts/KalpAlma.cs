using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalpAlma : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            MenuControllerInGame.health += 1;
            Destroy(this.gameObject);
        }
       
    }
}
