using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebSocketDemo : MonoBehaviour {
    
    #region Vars

    public  Text            websocketMessageText;
    public  Button          ReconnectButton;
    public  InputField      websocketAddress;
    private WebSocket       w;
    private bool            isConnFailed = false;

    #endregion Vars

    private void OnEnable()
    {
       // WebSocket.WSMessageReceviedEvent += NewMessageRecevied;
    }

    private void OnDisable()
    {
       // WebSocket.WSMessageReceviedEvent -= NewMessageRecevied;
    }

    // Use this for initialization
    void Start () {

        websocketAddress.text = "ws://localhost:8080";
        StartCoroutine(WebSocketCon());  

    }

    IEnumerator WebSocketCon()
    {
        //w = new WebSocket(new Uri("ws://localhost:8080"));
        w = new WebSocket(new Uri(websocketAddress.text));

        yield return StartCoroutine(w.Connect());

        Debug.Log("CONNECTED TO WEBSOCKETS");

        string lastMessage = "";

        while (true)
        {
            string message = w.RecvString();

            w.Recv();

            if (message != lastMessage)
            {
                NewMessageRecevied(message);//Now we are getting data from message send event.
                Debug.Log("Message :: " + message);
            }

            if (w.error != null) {
                isConnFailed = true;
                Debug.Log("Error occured in websocket");
                break;

            }

            lastMessage = message;
            yield return 0;
        }
    }

    void Update()
    {
        if (isConnFailed)
        {
            ReconnectButton.gameObject.SetActive(true);
        }
        else
        {
            ReconnectButton.gameObject.SetActive(false);
        }
    }

    private void OnGUI()
    {

        if(GUI.Button(new Rect(0, 0, 100, 100), "Send"))
        {
            w.SendString("Hi there from unity".ToString());
        }

       /* if (isConnFailed)
        {
            if (GUI.Button(new Rect(0, 100, 300, 100), "con failed! connect again"))
            {
                isConnFailed = false;
                StartCoroutine(WebSocketCon());

            }
        }*/
        

    }

    public void NewMessageRecevied(string message)
    {

        Debug.Log("New Message Recevied : " + message);
        if(message!="")
        websocketMessageText.text += "\n"+ message;

        FindObjectOfType<Rotator>().IsRotateCube(message);
    }

    public void Reconnect()
    {
        isConnFailed = false;
        StartCoroutine(WebSocketCon());
    }

    private void OnApplicationQuit()
    {
        if (w != null)
        {
            w.Close();
        }
    }



}
