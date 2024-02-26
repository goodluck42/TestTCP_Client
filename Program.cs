using System.Net;
using System.Net.Sockets;
using System.Text;

var clientToServerSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
var serverEndpoint = IPEndPoint.Parse("10.0.0.101:13374");

clientToServerSocket.Connect(serverEndpoint);

try
{
    //var buffer = new byte[2048];
    while (true)
    {
        string message = Console.ReadLine()!;

        if (message == "0")
        {
            break;
        }
        var bytes = Encoding.UTF8.GetBytes(message);

        clientToServerSocket.Send(bytes);
    }
}
finally
{
    clientToServerSocket.Dispose();
}