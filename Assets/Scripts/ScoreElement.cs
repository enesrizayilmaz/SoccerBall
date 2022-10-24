using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{

    public TMP_Text usernameText;
  
    public TMP_Text xpText;

    public void NewScoreElement(string _username,string _xp)
    {
        usernameText.text = _username;
        
        xpText.text = _xp.ToString();
    }

}