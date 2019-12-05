using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class MessageServer : MonoBehaviour
{   
    private TcpListener tcpListener;    
    private Thread tcpListenerThread;
    private TcpClient connectedTcpClient;
    public int port = 8000;
    private GenericPacket incomingPacket;
    private bool hasNewPacket = false;

    // Use this for initialization
    void Start () {
        // Start TcpServer background thread
        tcpListenerThread = new Thread (new ThreadStart(ListenForIncommingRequests));
        tcpListenerThread.IsBackground = true;
        tcpListenerThread.Start();
    }
    
    // Update is called once per frame
    void Update () {
        if (hasNewPacket) {
            Debug.Log(incomingPacket.data);
            switch (incomingPacket.type) {
                case "PlayerTransform":
                    // Pull transform data out
                    PlayerTransform newTransform = JsonUtility.FromJson<PlayerTransform>(incomingPacket.data);
                    transform.position = newTransform.position;
                    break;
                default:
                    // catch all messages
                    break;
            }
        }
    }

    private void SendJSON(string msg) {
        if (connectedTcpClient == null) {
            return;
        }

        try {
            // Get a stream object for writing.
            NetworkStream stream = connectedTcpClient.GetStream();
            if (stream.CanWrite) {
                // Convert string message to byte array.
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(msg + "\r\n");
                // Write byte array to socketConnection stream.
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
            }
        }
        catch (SocketException socketException) {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void ListenForIncommingRequests () {
        try {           
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();    
            Debug.Log("Server is listening");
            
            while (true) {
                // ISSUE: I BELIEVE THIS ONLY CREATES ONE THREAD FOR ALL LISTENERS :?
                using (connectedTcpClient = tcpListener.AcceptTcpClient()) {
                Debug.Log("client connected");
                    // Get a stream object for reading
                    using (NetworkStream stream = connectedTcpClient.GetStream()) {
                        StreamReader reader = new StreamReader(stream, Encoding.ASCII);
                        while(true) {
                            string json = reader.ReadLine();
                            // This is where you read in data
                            
                            incomingPacket = JsonUtility.FromJson<GenericPacket>(json);
                            hasNewPacket = true;
                        }               
                    }               
                }           
            }       
        }       
        catch (SocketException socketException) {           
            Debug.Log("SocketException " + socketException.ToString());       
        }     
    }
}