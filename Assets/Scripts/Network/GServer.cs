using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System;

namespace GrownEnd
{
    public class NetworkMessage256
    {
        public byte[] bytes;
        public int length = 0;
        public NetworkMessage256()
        {
            this.bytes = new byte[256];
        }
    }
    public class GTcpConnectedClient
    {
        private TcpClient client;
        private byte[] readbuffer;
        public GTcpConnectedClient(TcpClient clinet)
        {
            this.client = client;
            readbuffer = new byte[256];
        }
        public void ReadStreamAsync()
        {
            client.GetStream().BeginRead(readbuffer, 0, readbuffer.Length, OnReadEnd, null);
        }
        private void OnReadEnd(IAsyncResult ar)
        {
            client.GetStream().EndRead(ar);
            //TODO:Go to executor
        }

    }
    public class NetworkCryptor
    {
        private byte[] bytes;
        public NetworkCryptor()
        {

        }
        public void MoveToMessageEnCrypt(Vector3 position, ref NetworkMessage256 mesage)
        {
            
            mesage.bytes[0] = Convert.ToByte('m');
            int boffset = 1;
            var x = BitConverter.GetBytes(position.x);
            var y = BitConverter.GetBytes(position.y);
            var z = BitConverter.GetBytes(position.z);
            for(int i = 0; i < 3; i++)
            {
                mesage.bytes[boffset + i] = x[i];
                boffset++;
            }
            for (int i = 0; i < 3; i++)
            {
                mesage.bytes[boffset + i] = y[i];
                boffset++;
            }
            for (int i = 0; i < 3; i++)
            {
                mesage.bytes[boffset + i] = z[i];
                boffset++;
            }
            mesage.length = boffset;
        }
        public Vector3 MoveToMessageDeCrypt(ref NetworkMessage256 mesage)
        {

            int boffset = 1;
            Vector3 position = new Vector3();
            position.x = BitConverter.ToSingle(mesage.bytes, boffset);
            boffset += 4;
            position.y = BitConverter.ToSingle(mesage.bytes, boffset);
            boffset += 4;
            position.z = BitConverter.ToSingle(mesage.bytes, boffset);
            return position;
        }
    }

    public class GServer : MonoBehaviour
    {
        [SerializeField]
        private int _port;
        public int port
        {
            set { _port = value; }
            get { return _port; }
        }
        private TcpListener listener;
        private List<GTcpConnectedClient> clients;
        public void Initialize(IPAddress ip, int port)
        {
            clients = new List<GTcpConnectedClient>();
            listener = new TcpListener(ip, port);
            listener.Start();
            listener.BeginAcceptTcpClient(OnConnect, null);
            
        }
        private void OnConnect(IAsyncResult ar)
        {
            TcpClient client = listener.EndAcceptTcpClient(ar);
            clients.Add(new GTcpConnectedClient(client));
            listener.BeginAcceptTcpClient(OnConnect, null);
        }
        private void ReadClients()
        {
            for(int i = 0; i < clients.Count;i++)
            {
                clients[i].ReadStreamAsync();
            }
        }
        void Update()
        {

        }
    }
}