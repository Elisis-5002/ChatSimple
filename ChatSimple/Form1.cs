using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Diagnostics.Eventing.Reader;

namespace ChatSimple
{
    public partial class Form1 : Form
    {
        private TcpClient cliente;
        private StreamReader reader;
        private StreamWriter writer;
        public Form1()
        {
            InitializeComponent();
        }

        private string getIP()
        {
            string hostName = Dns.GetHostName();
            string localIP = "No se pudo determinar la IP local.";
            IPHostEntry host = Dns.GetHostEntry(hostName);
            
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
                return localIP;
                       
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta aplicacion " +
                "es el Servidor?", "Sistema", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question); 
            //Necesitamos saber si el usuario es el servidor o el cliente,
            //para eso usamos un MessageBox con botones de Sí y No.
            //Si el usuario responde Sí, entonces la aplicación se comportará como un servidor,
            //de lo contrario, se comportará como un cliente.
            string ip = getIP();
            try
            {
                if (respuesta == DialogResult.Yes)
                {

                    int port = int.Parse(txtPuerto.Text);
                    TcpListener server = new TcpListener(IPAddress.Any, port);
                    server.Start();
                    
                    rtbHistorial.AppendText("Servidor iniciado en la ip y puerto " + ip + ":" + port + "\n");

                    // Esperar a que un cliente se conecte DE MANERA ASÍNCRONA 
                    cliente = await server.AcceptTcpClientAsync();
                    rtbHistorial.AppendText("Cliente conectado!\n");

                    ConfigurarStreams();
                    _ = RecibirMensajes();
                }
                else
                {
                    // string ip = txtIP.Text;
                    int port = int.Parse(txtPuerto.Text);

                    cliente = new TcpClient();
                    rtbHistorial.AppendText("Conectando al servidor...\n");

                    await cliente.ConnectAsync(ip, port);
                    rtbHistorial.AppendText("Conectado!\n");

                    ConfigurarStreams();
                    _ = RecibirMensajes();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }



        }
        private void ConfigurarStreams()
        {
            NetworkStream stream = cliente.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
        }

        private async Task RecibirMensajes()
        {
            try
            {
                while (cliente != null && cliente.Connected)
                {
                    string mensajeRecibido = await reader.ReadLineAsync();
                    if (mensajeRecibido != null)
                    {
                        rtbHistorial.Invoke((MethodInvoker)delegate
                        {
                            rtbHistorial.AppendText("Extraño: " + mensajeRecibido + "\n");
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                rtbHistorial.Invoke((MethodInvoker)delegate
                {
                    rtbHistorial.AppendText("Cliente desconectado.\n");
                });

            }

            //La tecnica delegado se utiliza para actualizar el control RichTextBox desde un hilo diferente
            //al hilo de la interfaz de usuario, lo que es necesario para evitar problemas de concurrencia.
        }

      

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            if (cliente !=
                null && cliente.Connected &&
                !string.IsNullOrWhiteSpace(txtMensaje.Text))
            {
                try
                {
                    string mensaje = txtMensaje.Text;
                    await writer.WriteLineAsync(mensaje);

                    rtbHistorial.AppendText("Yo: " + mensaje + "\n");
                    txtMensaje.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" +
                    ex.ToString());
                }
            }
            else
                MessageBox.Show("No hay clientes conectados", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
