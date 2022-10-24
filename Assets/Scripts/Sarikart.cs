using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarikart : MonoBehaviour
{
    public GameObject show_y;
    public Transform sarıkart;
    public float LifeTime=1f;
    bool colliderBusy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player" && !colliderBusy)
        {
            
            colliderBusy = true;
            MenuControllerInGame.health -= 1;
            GameObject yeni_show_y = Instantiate(show_y);
            yeni_show_y.transform.position = new Vector3(sarıkart.position.x, 2f, 0f);
            Destroy(yeni_show_y, LifeTime);
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
