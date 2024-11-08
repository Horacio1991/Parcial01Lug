namespace UI
{
    partial class Form1
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
            cmbDeporte = new ComboBox();
            label3 = new Label();
            txtEquipoLocal = new TextBox();
            txtEquipoVisitante = new TextBox();
            label4 = new Label();
            label5 = new Label();
            dtpFechaPartido = new DateTimePicker();
            btnGuardar = new Button();
            label6 = new Label();
            dgvTodosLosPartidos = new DataGridView();
            txtEliminarPartido = new TextBox();
            label7 = new Label();
            btnEliminarPartido = new Button();
            txtActualizarMarcador = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtMarcadorLocal = new TextBox();
            txtMarcadorVisitante = new TextBox();
            btnModificarMarcador = new Button();
            btnGuardarEnMemoria = new Button();
            btnCargaMasiva = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTodosLosPartidos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 11);
            label1.Name = "label1";
            label1.Size = new Size(122, 21);
            label1.TabIndex = 0;
            label1.Text = "Nuevo Partido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 49);
            label2.Name = "label2";
            label2.Size = new Size(58, 17);
            label2.TabIndex = 1;
            label2.Text = "Deporte";
            // 
            // cmbDeporte
            // 
            cmbDeporte.FormattingEnabled = true;
            cmbDeporte.Location = new Point(28, 75);
            cmbDeporte.Name = "cmbDeporte";
            cmbDeporte.Size = new Size(200, 23);
            cmbDeporte.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 121);
            label3.Name = "label3";
            label3.Size = new Size(84, 17);
            label3.TabIndex = 3;
            label3.Text = "Equipo Local";
            // 
            // txtEquipoLocal
            // 
            txtEquipoLocal.Location = new Point(28, 152);
            txtEquipoLocal.Name = "txtEquipoLocal";
            txtEquipoLocal.Size = new Size(200, 23);
            txtEquipoLocal.TabIndex = 4;
            // 
            // txtEquipoVisitante
            // 
            txtEquipoVisitante.Location = new Point(28, 228);
            txtEquipoVisitante.Name = "txtEquipoVisitante";
            txtEquipoVisitante.Size = new Size(200, 23);
            txtEquipoVisitante.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(28, 197);
            label4.Name = "label4";
            label4.Size = new Size(104, 17);
            label4.TabIndex = 5;
            label4.Text = "Equipo Visitante";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(28, 280);
            label5.Name = "label5";
            label5.Size = new Size(114, 17);
            label5.TabIndex = 7;
            label5.Text = "Fecha Del Partido";
            // 
            // dtpFechaPartido
            // 
            dtpFechaPartido.Location = new Point(28, 309);
            dtpFechaPartido.Name = "dtpFechaPartido";
            dtpFechaPartido.Size = new Size(200, 23);
            dtpFechaPartido.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(34, 361);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(194, 39);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(288, 11);
            label6.Name = "label6";
            label6.Size = new Size(148, 21);
            label6.TabIndex = 10;
            label6.Text = "Todos Los Partidos";
            // 
            // dgvTodosLosPartidos
            // 
            dgvTodosLosPartidos.BackgroundColor = SystemColors.Control;
            dgvTodosLosPartidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTodosLosPartidos.GridColor = SystemColors.ActiveCaptionText;
            dgvTodosLosPartidos.Location = new Point(288, 49);
            dgvTodosLosPartidos.Name = "dgvTodosLosPartidos";
            dgvTodosLosPartidos.Size = new Size(500, 202);
            dgvTodosLosPartidos.TabIndex = 11;
            dgvTodosLosPartidos.CellClick += dgvTodosLosPartidos_CellClick;
            // 
            // txtEliminarPartido
            // 
            txtEliminarPartido.Location = new Point(288, 295);
            txtEliminarPartido.Name = "txtEliminarPartido";
            txtEliminarPartido.Size = new Size(200, 23);
            txtEliminarPartido.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(288, 264);
            label7.Name = "label7";
            label7.Size = new Size(180, 17);
            label7.TabIndex = 12;
            label7.Text = "Eliminar Partido, Ingrese el ID:";
            // 
            // btnEliminarPartido
            // 
            btnEliminarPartido.Location = new Point(380, 338);
            btnEliminarPartido.Name = "btnEliminarPartido";
            btnEliminarPartido.Size = new Size(108, 39);
            btnEliminarPartido.TabIndex = 14;
            btnEliminarPartido.Text = "ELIMINAR";
            btnEliminarPartido.UseVisualStyleBackColor = true;
            btnEliminarPartido.Click += btnEliminarPartido_Click;
            // 
            // txtActualizarMarcador
            // 
            txtActualizarMarcador.Location = new Point(531, 295);
            txtActualizarMarcador.Name = "txtActualizarMarcador";
            txtActualizarMarcador.Size = new Size(257, 23);
            txtActualizarMarcador.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(531, 264);
            label8.Name = "label8";
            label8.Size = new Size(257, 17);
            label8.TabIndex = 15;
            label8.Text = "Actualizar Marcador Partido, Ingrese el ID:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(531, 338);
            label9.Name = "label9";
            label9.Size = new Size(102, 17);
            label9.TabIndex = 17;
            label9.Text = "Marcado Local:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(531, 372);
            label10.Name = "label10";
            label10.Size = new Size(122, 17);
            label10.TabIndex = 18;
            label10.Text = "Marcado Visitante:";
            // 
            // txtMarcadorLocal
            // 
            txtMarcadorLocal.Location = new Point(639, 332);
            txtMarcadorLocal.Name = "txtMarcadorLocal";
            txtMarcadorLocal.Size = new Size(76, 23);
            txtMarcadorLocal.TabIndex = 19;
            // 
            // txtMarcadorVisitante
            // 
            txtMarcadorVisitante.Location = new Point(659, 366);
            txtMarcadorVisitante.Name = "txtMarcadorVisitante";
            txtMarcadorVisitante.Size = new Size(76, 23);
            txtMarcadorVisitante.TabIndex = 20;
            // 
            // btnModificarMarcador
            // 
            btnModificarMarcador.Location = new Point(680, 406);
            btnModificarMarcador.Name = "btnModificarMarcador";
            btnModificarMarcador.Size = new Size(108, 39);
            btnModificarMarcador.TabIndex = 21;
            btnModificarMarcador.Text = "MODIFICAR";
            btnModificarMarcador.UseVisualStyleBackColor = true;
            btnModificarMarcador.Click += btnModificarMarcador_Click;
            // 
            // btnGuardarEnMemoria
            // 
            btnGuardarEnMemoria.Location = new Point(34, 406);
            btnGuardarEnMemoria.Name = "btnGuardarEnMemoria";
            btnGuardarEnMemoria.Size = new Size(194, 39);
            btnGuardarEnMemoria.TabIndex = 22;
            btnGuardarEnMemoria.Text = "GUARDAR EN MEMORIA";
            btnGuardarEnMemoria.UseVisualStyleBackColor = true;
            btnGuardarEnMemoria.Click += btnGuardarEnMemoria_Click;
            // 
            // btnCargaMasiva
            // 
            btnCargaMasiva.Location = new Point(34, 451);
            btnCargaMasiva.Name = "btnCargaMasiva";
            btnCargaMasiva.Size = new Size(194, 39);
            btnCargaMasiva.TabIndex = 23;
            btnCargaMasiva.Text = "CARGA MASIVA";
            btnCargaMasiva.UseVisualStyleBackColor = true;
            btnCargaMasiva.Click += btnCargaMasiva_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 521);
            Controls.Add(btnCargaMasiva);
            Controls.Add(btnGuardarEnMemoria);
            Controls.Add(btnModificarMarcador);
            Controls.Add(txtMarcadorVisitante);
            Controls.Add(txtMarcadorLocal);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(txtActualizarMarcador);
            Controls.Add(label8);
            Controls.Add(btnEliminarPartido);
            Controls.Add(txtEliminarPartido);
            Controls.Add(label7);
            Controls.Add(dgvTodosLosPartidos);
            Controls.Add(label6);
            Controls.Add(btnGuardar);
            Controls.Add(dtpFechaPartido);
            Controls.Add(label5);
            Controls.Add(txtEquipoVisitante);
            Controls.Add(label4);
            Controls.Add(txtEquipoLocal);
            Controls.Add(label3);
            Controls.Add(cmbDeporte);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvTodosLosPartidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbDeporte;
        private Label label3;
        private TextBox txtEquipoLocal;
        private TextBox txtEquipoVisitante;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpFechaPartido;
        private Button btnGuardar;
        private Label label6;
        private DataGridView dgvTodosLosPartidos;
        private TextBox txtEliminarPartido;
        private Label label7;
        private Button btnEliminarPartido;
        private TextBox txtActualizarMarcador;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtMarcadorLocal;
        private TextBox txtMarcadorVisitante;
        private Button btnModificarMarcador;
        private Button btnGuardarEnMemoria;
        private Button btnCargaMasiva;
    }
}
