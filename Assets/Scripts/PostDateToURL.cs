﻿using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PostDateToURL : MonoBehaviour {

    string postURL = "http://192.9.210.67/Web1/Server/ServerApi.php";
    public InputField dataPostUrl;

    private void OnMouseDown()
    {
        //postURL += "?objName"+this.name + "&Objposition"+this.transform.position.ToString();
        //StartCoroutine(PostDateRequest());
        StartCoroutine(PostDateRequestWithPost());

    }

    IEnumerator PostDateRequest()
    {
        UnityWebRequest www = new UnityWebRequest(postURL);
        yield return www;
        if (www.isDone)
        {
            Debug.Log(postURL +" sent get request with data");
        }
        else
        {
            Debug.Log("data sent failed");
        }

        Debug.Log(www.error);        
    }

    public void UpdateDataPostURL()
    {
        postURL = dataPostUrl.text;
    }

    IEnumerator PostDateRequestWithPost()
    {
        WWWForm www = new WWWForm();
        www.AddField("objName", this.name);
        www.AddField("Objposition", this.transform.position.ToString());
        UnityWebRequest req = UnityWebRequest.Post(postURL, www);
        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
              Debug.Log("data sent failed");
        }
        else
        {
            Debug.Log(postURL + " sent get request with data");
        }

    }
}
