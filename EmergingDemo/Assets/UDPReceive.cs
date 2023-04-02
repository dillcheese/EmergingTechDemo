using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class UDPReceive : MonoBehaviour
{
    private Thread receiveThread;
    private UdpClient client;
    public int port = 5052;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public string data;
    private byte[] dataByte;

    public void Start()
    {
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    // receive thread
    private void ReceiveData()
    {
        client = new UdpClient(port);

        while (startRecieving)
        {
            try
            {
                //var timer = new System.Timers.Timer(1000);
                //timer.Elapsed += (sender, e) => dataByte = null;
                //timer.AutoReset = true;
                //timer.Enabled = true;

                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);
                if (printToConsole) { print(data); }
            }
            catch (Exception err)
            {
                print(err.ToString());
            }


        }
    }
}