namespace ChatSimple
{
    partial class frmChat
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtIP = new TextBox();
            txtPuerto = new TextBox();
            txtMensaje = new TextBox();
            rtbHistorial = new RichTextBox();
            btnIniciarServidor = new Button();
            btnEnviar = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 20);
            label1.Name = "label1";
            label1.Size = new Size(27, 25);
            label1.TabIndex = 0;
            label1.Text = "IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(342, 20);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 1;
            label2.Text = "Puerto";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(31, 48);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(242, 31);
            txtIP.TabIndex = 2;
            // 
            // txtPuerto
            // 
            txtPuerto.Location = new Point(342, 48);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(150, 31);
            txtPuerto.TabIndex = 3;
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(31, 392);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(530, 31);
            txtMensaje.TabIndex = 4;
            // 
            // rtbHistorial
            // 
            rtbHistorial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbHistorial.Location = new Point(31, 136);
            rtbHistorial.Name = "rtbHistorial";
            rtbHistorial.Size = new Size(677, 217);
            rtbHistorial.TabIndex = 5;
            rtbHistorial.Text = "";
            // 
            // btnIniciarServidor
            // 
            btnIniciarServidor.Location = new Point(596, 50);
            btnIniciarServidor.Name = "btnIniciarServidor";
            btnIniciarServidor.Size = new Size(112, 34);
            btnIniciarServidor.TabIndex = 6;
            btnIniciarServidor.Text = "Iniciar Server";
            btnIniciarServidor.UseVisualStyleBackColor = true;
            btnIniciarServidor.Click += btnIniciarServidor_Click;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(596, 389);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(112, 34);
            btnEnviar.TabIndex = 7;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 108);
            label3.Name = "label3";
            label3.Size = new Size(85, 25);
            label3.TabIndex = 8;
            label3.Text = "Mensajes";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 364);
            label4.Name = "label4";
            label4.Size = new Size(77, 25);
            label4.TabIndex = 9;
            label4.Text = "Mensaje";
            // 
            // frmChat
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 471);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnEnviar);
            Controls.Add(btnIniciarServidor);
            Controls.Add(rtbHistorial);
            Controls.Add(txtMensaje);
            Controls.Add(txtPuerto);
            Controls.Add(txtIP);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmChat";
            Text = "Chat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtIP;
        private TextBox txtPuerto;
        private TextBox txtMensaje;
        private RichTextBox rtbHistorial;
        private Button btnIniciarServidor;
        private Button btnEnviar;
        private Label label3;
        private Label label4;
    }
}
