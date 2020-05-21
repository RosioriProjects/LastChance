using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginData : MonoBehaviour
{

    public TMP_InputField username;
    public TMP_InputField password;
    string user;
    string pass;

    Dictionary<string, string> parameters = new Dictionary<string, string>();
    public void doPost()
    {
        user = username.text;
        pass = password.text;
        string json = @"{
        'username': 'usernamePlaceholder', 
        'password':'passwordPlaceholder'
        }";
        string URL = "http://localhost:8080/user/login";

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        //Auth token for http request
        string accessToken;
        //Our custom Headers
        Dictionary<string, string> headers = new Dictionary<string, string>();
        //Encode the access and secret keys
        //Add the custom headers

        parameters.Add("Content-Type", "application/json");
        //parameters.Add("Content-Length", json.Length.ToString());
        //Replace single ' for double " 
        //This is usefull if we have a big json object, is more easy to replace in another editor the double quote by singles one
        
        json = json.Replace("usernamePlaceholder", user);
        json = json.Replace("passwordPlaceholder", pass);
        json = json.Replace("'", "\"");
        //Encode the JSON string into a bytes
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        //Now we call a new WWW request
        WWW www = new WWW(URL, postData, parameters);
        //And we start a new co routine in Unity and wait for the response.
        StartCoroutine(WaitForRequest(www));
    }
    
    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            //Print server response
            Debug.Log(www.text);
            SceneManager.LoadScene("Game");
        }
        else
        {
            //Something goes wrong, print the error response
            Debug.Log(www.error);
        }
    }


}
