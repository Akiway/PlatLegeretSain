using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;

namespace PlatLegeretSain.Model
{
    sealed partial class SocketServer
    {
        // Singleton
        private static SocketServer ss = null;
        public static SocketServer Instance()
        {
            if (ss == null)
                ss = new SocketServer();
            return ss;
        }

        private Socket serverSocket;
        private Socket clientSocket; // We will only accept one socket.
        private byte[] buffer;

        public SocketServer()
        {
            StartServer();
        }

        private static void ShowErrorDialog(string message)
        {
            View.Game1.Print("Server error > " + message);
        }

        /// <summary>
        /// Construct server socket and bind socket to all local network interfaces, then listen for connections
        /// with a backlog of 10. Which means there can only be 10 pending connections lined up in the TCP stack
        /// at a time. This does not mean the server can handle only 10 connections. The we begin accepting connections.
        /// Meaning if there are connections queued, then we should process them.
        /// </summary>
        private void StartServer()
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = (Dns.Resolve("10.162.129.15")).AddressList[0];
                serverSocket.Bind(new IPEndPoint(ip, 3333));
                serverSocket.Listen(10);
                serverSocket.BeginAccept(AcceptCallback, null);
                View.Game1.Print("Server > IP : " + serverSocket.LocalEndPoint.ToString());
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void AcceptCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket = serverSocket.EndAccept(AR);
                buffer = new byte[clientSocket.ReceiveBufferSize];

                // Send a message to the newly connected client.
                var sendData = Encoding.ASCII.GetBytes("Connecté au Restaurant");
                clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);
                // Listen for client data.
                //clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
                // Continue listening for clients.
                serverSocket.BeginAccept(AcceptCallback, null);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void SendCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndSend(AR);
                BinaryFormatter formatter = new BinaryFormatter();
                // Send data
                while (clientSocket.Connected)
                {
                    // Serialize object into data
                    formatter.Serialize(new NetworkStream(clientSocket), Controller.Program.stats);
                }
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }
        /*
        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                // Socket exception will raise here when client closes, as this sample does not
                // demonstrate graceful disconnects for the sake of simplicity.
                int received = clientSocket.EndReceive(AR);

                if (received == 0)
                {
                    return;
                }

                // The received data is deserialized in the PersonPackage ctor.
                PersonPackage person = new PersonPackage(buffer);
                SubmitPersonToDataGrid(person);

                // Start receiving data again.
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }*/

        public void sendStats()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                //SoapFormatter formatter = new SoapFormatter();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(new NetworkStream(clientSocket), Controller.Program.stats);
                //formatter.Serialize(new NetworkStream(clientSocket), Statistique.Instance().Exchange());
                //clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);
            }
        }
    }
}