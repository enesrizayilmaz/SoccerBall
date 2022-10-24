using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yildizalma : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DataManager.Instance.Score += 25;
            Destroy(this.gameObject);
        }
       
    }

}
