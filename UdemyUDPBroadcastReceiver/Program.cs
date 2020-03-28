/* 
 * Udemy :: UDP Socket Programming For Distributed Computing in C# .NET
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace UdemyUDPBroadcastReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sockBroadcastReceiver = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //

            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 23000); // ip address and port no which we will recive the data
            //1st parameter :: Receives data from all available IP adresses from this host 
            //2nd parameter :: Receives data from port 23000 (same port as the sender )

            //just as sending data we need a byte array to recieve the data too
            byte[] receiverBuffer = new byte[512];
            int countReceived = 0;

            try
            {
                sockBroadcastReceiver.Bind(ipEndPoint); // binds the endpoint to the reciving socket
                while (true)
                {
                    //receive methord
                    countReceived = sockBroadcastReceiver.Receive(receiverBuffer);
                    Console.WriteLine("Number of byted recieved : " + countReceived);
                    Array.Clear(receiverBuffer, 0 , receiverBuffer.Length); 
                    // cause using the same array to get the data again ans again needs to clear it before adding 
                }
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

        }
    }
}
