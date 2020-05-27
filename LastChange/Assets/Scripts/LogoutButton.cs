using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoutButton : MonoBehaviour
{

    Player player;

    Dictionary<string, string> parameters = new Dictionary<string, string>();

    public void doPost()
    {
        player = FindObjectOfType<Player>();
        string username = player.username;
        int longitude = (int)player.transform.position.x;
        int latitude= (int) player.transform.position.y;
        string json = @"{
        'username':'usernamePlaceholder',
        'longitude':'longitudePlaceholder', 
        'latitude':'latitudePlaceholder'
        }";
        string URL = "http://localhost:8080/user/logout";

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

        json = json.Replace("usernamePlaceholder", username);
        json = json.Replace("longitudePlaceholder", longitude.ToString());
        json = json.Replace("latitudePlaceholder", latitude.ToString());
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
            
            SceneManager.LoadScene("Login");

        }
        else
        {
            //Something goes wrong, print the error response
            Debug.Log(www.error);
            

        }
    }

    public void Logout()
    {
        doPost();


    }
}
