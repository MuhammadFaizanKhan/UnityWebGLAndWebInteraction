using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class WebSocketImplementation : MonoBehaviour {

    WebSocketSharp.WebSocket wssharp;

    // Use this for initialization
    void Start () {
        wssharp = new WebSocketSharp.WebSocket("ws://localhost:8080");
        wssharp.Connect();
        wssharp.OnMessage += Wssharp_OnMessage;
        wssharp.OnOpen += Wssharp_OnOpen;
        wssharp.OnError += Wssharp_OnError;
    }

    private void Wssharp_OnError(object sender, ErrorEventArgs e)
    {
        Debug.Log("Wssharp_OnError " + e.ToString());

    }

    private void Wssharp_OnOpen(object sender, EventArgs e)
    {
        Debug.Log("Wssharp_OnOpen " + e.ToString());
    }

    private void Wssharp_OnMessage(object sender, MessageEventArgs e)
    {
        Debug.Log(e.Data);
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(wssharp.IsAlive);

    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "Send"))
        {
            //   w.Send("Hi there from unity");
            wssharp.Send("Hi there from unity".ToString());
            //w.Send(new byte[] { u, 'n', 'i', 't', 'y' });
        }
    }
}
