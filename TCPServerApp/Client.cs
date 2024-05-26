using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    private const string SERVER_IP = "127.0.0.1";
    private const int SERVER_PORT = 9999;

    public static void Start()
    {
        try
        {
            TcpClient client = new TcpClient(SERVER_IP, SERVER_PORT);
            NetworkStream stream = client.GetStream();
            byte[] data;
            string command;

            while (true)
            {
                Console.WriteLine("Introduceți comanda (POST, DELETE, COMMENT, LIKE sau EXIT):");
                command = Console.ReadLine();
                if (command.ToUpper() == "EXIT")
                {
                    break;
                }

                
                data = Encoding.UTF8.GetBytes(command);
                stream.Write(data, 0, data.Length);

                
                data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length);
                string response = Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine("Răspuns de la server: " + response);
            }

            
            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

}
