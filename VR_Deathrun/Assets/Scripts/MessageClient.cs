using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class MessageClient : MonoBehaviour
{
    private TcpClient socketConnection;     
    private Thread clientReceiveThread;
    public int port;
    public string ip;

    // Use this for initialization
    void Start () {
        ConnectToTcpServer();
    }

    // Update is called once per frame
    void Update () {
        string packetData = JsonUtility.ToJson(new PlayerTransform(transform.position));
        SendJSON(JsonUtility.ToJson(new GenericPacket("PlayerTransform", packetData)));
    }

    private void ConnectToTcpServer () {
        try {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }       
        catch (Exception e) {
            Debug.Log("On client connect exception " + e);
        }
    }   

    private void ListenForData() {
        try {
            socketConnection = new TcpClient(ip, port);

            while (true) {
                // Get a stream object for reading
                using (NetworkStream stream = socketConnection.GetStream()) {
                    StreamReader reader = new StreamReader(stream, Encoding.ASCII);
                    while(true) {
                        string json = reader.ReadLine();
                        // THIS IS YOUR MESSAGE
                    }               
                }
			}
        }
        catch (SocketException socketException) {
            Debug.Log("Socket exception: " + socketException);
        }
    }
 
    private void SendJSON(string msg) {
        if (socketConnection == null) {
            return;
        }

        try {
            // Get a stream object for writing.
            NetworkStream stream = socketConnection.GetStream();
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
}