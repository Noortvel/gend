using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;


namespace GrownEnd
{
    public class GClient : MonoBehaviour
    {
        private TcpClient tcpClient;
        private byte[] readBuffer;
        private byte[] writeBuffer;
        private const int buffersSize = 256;

        public void Initialize(IPAddress ip, int port)
        {
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(ip, port);
                readBuffer = new byte[buffersSize];
                writeBuffer = new byte[buffersSize];
                tcpClient.GetStream().BeginRead(readBuffer, 0, buffersSize, EndAsyncBufferRead, null);
            }
            catch (SocketException e)
            {
                Debug.Log("TCPClient connect error: " + e);
                return;
            }
        }

        private void EndAsyncBufferRead(IAsyncResult ar)
        {

        }
        private void ClearBuffer()
        {
            for (int i = 0; i < readBuffer.Length; i++)
            {
                readBuffer[i] = 0;
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}