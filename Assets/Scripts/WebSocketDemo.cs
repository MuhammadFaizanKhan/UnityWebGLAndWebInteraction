using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WebSocketDemo : MonoBehaviour {
    
    #region Vars

    public  Text            websocketMessageText;
    public  Button          ReconnectButton;
    public  InputField      websocketAddress;

    public TMP_Text connectionInfoText;

    private WebSocket       webSocket;
    
    Rotator rotator;
    public GameObject chatPanel;

    private bool isConnFailed = true;
    public bool IsConnFailed
    {
        get { return isConnFailed; }
        set { 
            isConnFailed = value;
            TogglePanles();
        }
    }
    #endregion Vars

    void Start () {
        rotator = FindAnyObjectByType<Rotator>();
        websocketAddress.text = "ws://localhost:8080";
    }

    IEnumerator WebSocketCon()
    {
        webSocket = new WebSocket(new Uri(websocketAddress.text));
        yield return StartCoroutine(webSocket.Connect());
        Debug.Log("CONNECTED TO WEBSOCKETS");
        string lastMessage = "";

        while (true)
        {
            string message = webSocket.RecvString();

            webSocket.Recv();
            
            if (message != lastMessage)
            {
                NewMessageRecevied(message);//Now we are getting data from message send event.
                Debug.Log("Message :: " + message);
            }

            if (webSocket.error != null) {
                IsConnFailed = true;
                connectionInfoText.text = "Error.."+ webSocket.error;
                Debug.Log("Error occured in websocket");
                break;

            }
            else
            {
                IsConnFailed = false;
            }

            lastMessage = message;
            yield return 0;
        }
    }

    void TogglePanles()
    {
        if (IsConnFailed)
        {
            ReconnectButton.gameObject.SetActive(true);
            chatPanel.SetActive(false);
            
        }
        else
        {
            ReconnectButton.gameObject.SetActive(false);
            chatPanel.SetActive(true);
            connectionInfoText.text = "Connected..";
        }
    }

    public void SendString(TMP_InputField text)
    {
        
        webSocket.SendString(text.text);
    }

    public void NewMessageRecevied(string message)
    {
        Debug.Log("New Message Recevied : " + message);
        if (message != "")
        {
            websocketMessageText.text += "\n" + message;
            rotator.IsRotateCube(message?.ToLower());
        }

       
    }

    public void Reconnect()
    {
        StartCoroutine(WebSocketCon());
    }

    private void OnApplicationQuit()
    {
        if (webSocket != null)
        {
            webSocket.Close();
        }
    }



}
