using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyunkayit: MonoBehaviour
{

    public static Oyunkayit Instance;
    public static int yuksekskor;
    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;


        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("Scoree");
        Debug.Log(PlayerPrefs.GetInt("Scoree")+"Sorun buu");
        yuksekskor = PlayerPrefs.GetInt("Scoree");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
