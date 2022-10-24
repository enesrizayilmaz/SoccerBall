using System;

public class Datasave 
{
    public string _UserId, _usermail,_id;
    public int _score;

    public Datasave() { }
    public Datasave(string userId,string userMail,int score,string id)
    {
        _UserId = userId;
        _usermail = userMail;
        _id = id;
        
        _score = score;
    }



}
