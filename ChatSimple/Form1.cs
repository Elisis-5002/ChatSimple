using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Drawing.Text;

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

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta aplicación es el servidor?","Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Necesitamos saber si el usuario es el servidor o el cliente,
            //para eso usamos un MessageBox con botones de Sí y No.
            //Si el usuario responde Sí, entonces la aplicación se comportará como un servidor,
            //de lo contrario, se comportará como un cliente.
            try
            {
                int port = int.Parse(txtPuerto.Text);
                TcpListener server = new TcpListener(IPAddress.Any, port);
                server.Start();

                // Esperar a que un cliente se conecte DE MANERA ASÍNCRONA 
                cliente = await server.AcceptTcpClientAsync();
                rtbHistorial.AppendText("Cliente conectado!\n"); 
            }
            catch (Exception ex)
            {
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
                while(cliente !=null && cliente.Connected)
                {
                    string mensajeRecibido = await reader.ReadLineAsync();
                    if(mensajeRecibido != null)
                    {
                        rtbHistorial.Invoke((MethodInvoker)delegate
                        {
                            rtbHistorial.AppendText("Extraño: " + mensajeRecibido + "\n"); 
                        });
                    }
                }

            }catch (Exception ex)
            {
                rtbHistorial.Invoke((MethodInvoker)delegate {
                    rtbHistorial.AppendText("Cliente desconectado.\n");
                });

            }

            //La tecnica delegada se utiliza para actualizar el control RichTextBox desde un hilo diferente
            //al hilo de la interfaz de usuario, lo que es necesario para evitar problemas de concurrencia.
        }
    }
