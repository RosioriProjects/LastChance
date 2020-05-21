using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoginData : MonoBehaviour
{

    public TMP_InputField username;
    public TMP_InputField password;
    string user;
    string pass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Upload()
    {
        user = username.text;
        pass = password.text;
        WWWForm form = new WWWForm();
        form.AddField("username", user);
        form.AddField("password", pass);
        Debug.Log(user + pass);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/user/login", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
    public void Login()
    {

        
        //StartCoroutine(Upload());
        Debug.Log(StartCoroutine(Upload()));
        

    }


}
