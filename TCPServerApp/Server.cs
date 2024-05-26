using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Server
{
    private const int PORT = 9999;

    static void Main(string[] args)
    {
        Start();
    }

    public static void Start()
    {
        TcpListener server = null;
        try
        {
            server = new TcpListener(IPAddress.Any, PORT);
            server.Start();
            Console.WriteLine("Server is running...");
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            server.Stop();
        }
    }

    static void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] data = new byte[256];
        StringBuilder responseData = new StringBuilder();
        int bytes = stream.Read(data, 0, data.Length);
        responseData.Append(Encoding.UTF8.GetString(data, 0, bytes));
        string request = responseData.ToString().Trim(); 

        if (request.StartsWith("POST"))
        {
            string[] parts = request.Split(' ', 2);
            if (parts.Length >= 2)
            {
                string postContent = parts[1];
                
            }
        }
        else if (request.StartsWith("DELETE"))
        {
            string[] parts = request.Split(' ', 2);
            if (parts.Length >= 2)
            {
                int postIdToDelete = int.Parse(parts[1]);
               
            }
        }
        else if (request.StartsWith("COMMENT"))
        {
            string[] parts = request.Split(' ', 3);
            if (parts.Length >= 3)
            {
                int postId = int.Parse(parts[1]);
                string commentContent = parts[2];
                
            }
        }
        else if (request.StartsWith("LIKE"))
        {
            string[] parts = request.Split(' ', 2);
            if (parts.Length >= 2)
            {
                int postId = int.Parse(parts[1]);
                
            }
        }
        else if (request == "EXIT")
        {
           
            client.Close();
        }
    }


}
