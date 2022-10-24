using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    public Transform target;
    public float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x + 5.5f, 0.1f, transform.position.z),cameraSpeed);
        
    }
}
