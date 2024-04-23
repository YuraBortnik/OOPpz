using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Server
{
    private TcpListener listener;
    private List<TcpClient> clients = new List<TcpClient>();

    public Server()
    {
        listener = new TcpListener(IPAddress.Any, 6544);
    }

    public async Task Start()
    {
        listener.Start();
        Console.WriteLine("Сервер запущено. Очікування клієнтів...");

        while (true)
        {
            TcpClient client = await listener.AcceptTcpClientAsync(); // Очікування підключення клієнта
            clients.Add(client); // Додавання клієнта до списку підключених клієнтів
            Console.WriteLine("Клієнт підключений.");

            HandleClient(client); // Обробка клієнта в окремому методі
        }
    }

    private async void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        try
        {
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                // Отримання повідомлення від клієнта
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Повідомлення від клієнта: " + receivedMessage);

                // Відправка повідомлення клієнту про успішну операцію
                SendToAllClients(receivedMessage);

                // Очищення буфера
                Array.Clear(buffer, 0, buffer.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
        finally
        {
            clients.Remove(client); // Видалення клієнта зі списку при відключенні
            client.Close();
        }
    }

    private void SendToAllClients(string message)
    {
        byte[] messageBuffer = Encoding.UTF8.GetBytes(message);

        foreach (TcpClient client in clients)
        {
            NetworkStream stream = client.GetStream();
            stream.Write(messageBuffer, 0, messageBuffer.Length);
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        Server server = new Server();
        await server.Start(); // Запуск сервера
    }
}
