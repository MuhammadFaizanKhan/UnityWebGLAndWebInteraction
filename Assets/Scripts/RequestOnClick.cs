using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestOnClick : MonoBehaviour {

    public string url = "http://localhost/Web1/frontend-large.jpg";

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        StartCoroutine(LoadImageFromWeb());
         
    }

    IEnumerator LoadImageFromWeb()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            Renderer rend = GetComponent<Renderer>();
            rend.material.mainTexture = www.texture;
        }
    }
}
