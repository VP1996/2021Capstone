using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userInsert : MonoBehaviour
{
    /**
    string URL = "http://localhost/mathaway/userInsert.php";
    //public string UserName, Difficulty, DiedOnL1, TimeLevel1, WrongALevel1, DiedOnL2, TimeLevel2, WrongALevel2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("space"))
        {
            AddResults(UserName, Difficulty, DiedOnL1,
           TimeLevel1, WrongALevel1, DiedOnL2,
            TimeLevel2, WrongALevel2);

        }
        
    }

    public void AddResults(string _UserName, string _Difficulty, string _DiedOnL1,
        string _TimeLevel1, string _WrongALevel1, string _DiedOnL2, string _TimeLevel2, string _WrongALevel2)
    {
        WWWForm form = new WWWForm();
        form.AddField("addUserID", "NULL");
        form.AddField("addUserName", _UserName);
        form.AddField("addDifficulty", _Difficulty);
        form.AddField("addDiedOnL1", _DiedOnL1);
        form.AddField("addTimeLevel1", _TimeLevel1);
        form.AddField("addWrongALevel1", _WrongALevel1);
        form.AddField("addDiedOnL2", _DiedOnL2);
        form.AddField("addTimeLevel2", _TimeLevel2);
        form.AddField("addWrongALevel2", _WrongALevel2);

        WWW www = new WWW(URL, form);


    }
   **/
}
