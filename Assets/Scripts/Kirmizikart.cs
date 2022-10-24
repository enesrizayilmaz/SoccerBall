using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kirmizikart : MonoBehaviour
{
    public GameObject show_r;
    public Transform kırmızıkart;
    public float LifeTime = 1f;
    bool colliderBusy = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            MenuControllerInGame.health -= 2;
            GameObject yeni_show_r = Instantiate(show_r);
            yeni_show_r.transform.position = new Vector3(kırmızıkart.position.x, 2f, 0f);
            Destroy(yeni_show_r, LifeTime);
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
