using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Chat
{
    public partial class Form1 : Form
    {
        private Client client;
        private string lastReceivedMessage = string.Empty;



        private RichTextBox GetRichTextBox()
        {
            return richTextBox1;
        }


        public Form1()
        {

            InitializeComponent();
            client = new Client(this);

        }


        private async void connectButton_Click(object sender, EventArgs e)
        {
            client = new Client(this);

            string serverIP = ipAdressTextBox.Text;
            int port;
            if (!int.TryParse(portTextBox.Text, out port))
            {
                MessageBox.Show("Введіть коректний номер порту.");
                return;
            }

            try
            {
                await client.Connect(serverIP, port);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка підключення: " + ex.Message);
            }

        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = usernameTextBox.Text;
                string message = username + ": " + messageTextBox.Text;

               
                await client.SendMessage(message);

                // Перевірка, чи потрібно додавати повідомлення до RichTextBox
                string lastReceivedMessage = message;
                if (!string.Equals(message, lastReceivedMessage))
                {
                    
                    AddMessageToChat(message);
                }

                
                messageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка відправки: " + ex.Message);
            }
        }


        private void disconnectButton_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            MessageBox.Show("відключення від сервера");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client.MessageReceived += AddMessageToChat;
        }

        public void AddMessageToChat(string message)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>(AddMessageToChat), message);
            }
            else
            {
               
                richTextBox1.AppendText(message + Environment.NewLine);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            string configFilePath = "config.txt";
            string[] lines = { ipAdressTextBox.Text, portTextBox.Text, usernameTextBox.Text };
            File.WriteAllLines(configFilePath, lines);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            string configFilePath = "config.txt";

            if (File.Exists(configFilePath))
            {
                string[] lines = File.ReadAllLines(configFilePath);

                if (lines.Length >= 3)
                {
                    ipAdressTextBox.Text = lines[0];
                    portTextBox.Text = lines[1];
                    usernameTextBox.Text = lines[2];
                }
                else
                {
                    MessageBox.Show("Файл конфігурації має неправильний формат.");
                }
            }
            else
            {
                MessageBox.Show("Файл конфігурації не знайдено.");
            }
        }

        class Client
        {
            private Form1 form1;

            public Client(Form1 form1)
            {
                this.form1 = form1;
            }

            public event Action<string> MessageReceived;

            private TcpClient client;
            private NetworkStream stream;

            public async Task Connect(string serverIP, int port)
            {
                client = new TcpClient();
                await client.ConnectAsync(serverIP, port); // Підключення до сервера
                Console.WriteLine("Підключено до сервера.");

                stream = client.GetStream();
                StartReceiving();
                form1.AddMessageToChat("Підключено до сервера.");
            }

            public async Task SendMessage(string message)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(buffer, 0, buffer.Length); // Відправка повідомлення
            }

            public void Disconnect()
            {
                client.Close();
            }

            private async void StartReceiving()
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                try
                {
                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        // Перевірка, чи потрібно оновлювати інтерфейс у головному потоці
                        if (form1.InvokeRequired)
                        {
                            form1.BeginInvoke(new Action(() => form1.AddMessageToChat(receivedMessage)));
                        }
                        else
                        {
                            form1.AddMessageToChat(receivedMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка отримання повідомлення: " + ex.Message);
                }
            }

        }

        

    }
}


