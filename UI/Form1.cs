using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly PartidoBLL _partidoBLL;  
        public Form1()
        {
            InitializeComponent();

            _partidoBLL = new PartidoBLL();  
            CargarDeportes();
            CargarPartidosEnGrilla();

        }

        // Cargar deportes en el combo box
        private void CargarDeportes()
        {
            List<Deporte> deportes = _partidoBLL.ObtenerDeportes();
            cmbDeporte.DataSource = deportes;
            cmbDeporte.DisplayMember = "Descripcion";  // Nombre del deporte
            cmbDeporte.ValueMember = "IdDeporte";      // El valor será el ID del deporte
        }

        // cargar los partidos en la DataGridView
        private void CargarPartidosEnGrilla()
        {
            List<Partido> partidos = _partidoBLL.ObtenerTodosLosPartidos();
            dgvTodosLosPartidos.DataSource = partidos;

            // Modificacion estetica para las columnas
            dgvTodosLosPartidos.Columns["FechaRegistro"].HeaderText = "Fecha de Registro";
            dgvTodosLosPartidos.Columns["EquipoLocal"].HeaderText = "Equipo Local";
            dgvTodosLosPartidos.Columns["EquipoVisitante"].HeaderText = "Equipo Visitante";
            dgvTodosLosPartidos.Columns["FechaPartido"].HeaderText = "Fecha De Partido";
            dgvTodosLosPartidos.Columns["MarcadorLocal"].HeaderText = "Marcador Local";
            dgvTodosLosPartidos.Columns["MarcadorVisitante"].HeaderText = "Marcador Visitante";





        }

        // LimpiarTextBox
        private void LimpiarCampos()
        {
            txtEquipoLocal.Clear();
            txtEquipoVisitante.Clear();
            txtEliminarPartido.Clear();
            txtActualizarMarcador.Clear();
            txtMarcadorLocal.Clear();
            txtMarcadorVisitante.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idDeporte = (int)cmbDeporte.SelectedValue; 
                string equipoLocal = txtEquipoLocal.Text;
                string equipoVisitante = txtEquipoVisitante.Text;
                DateTime fechaPartido = dtpFechaPartido.Value;

                _partidoBLL.AgregarPartido(idDeporte, equipoLocal, equipoVisitante, fechaPartido);

                MessageBox.Show("Partido guardado exitosamente.");

                LimpiarCampos();
                CargarPartidosEnGrilla(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminarPartido_Click(object sender, EventArgs e)
        {
            try
            {
                int idPartido = int.Parse(txtEliminarPartido.Text);  

                _partidoBLL.EliminarPartido(idPartido);

                MessageBox.Show("Partido eliminado exitosamente.");

                LimpiarCampos();

                CargarPartidosEnGrilla();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnModificarMarcador_Click(object sender, EventArgs e)
        {
            try
            {
                int idPartido = int.Parse(txtActualizarMarcador.Text);  
                int marcadorLocal = int.Parse(txtMarcadorLocal.Text);
                int marcadorVisitante = int.Parse(txtMarcadorVisitante.Text);

                _partidoBLL.ActualizarMarcador(idPartido, marcadorLocal, marcadorVisitante);

                MessageBox.Show("Marcador actualizado exitosamente.");

                LimpiarCampos();

                CargarPartidosEnGrilla();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvTodosLosPartidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse de que se hizo click en una fila válida
            {
                DataGridViewRow filaSeleccionada = dgvTodosLosPartidos.Rows[e.RowIndex];

                // Autocompletar TextBox para eliminar partido (con el ID del partido)
                txtEliminarPartido.Text = filaSeleccionada.Cells["IdPartido"].Value.ToString();

                // Autocompletar TextBox para modificar marcador
                txtActualizarMarcador.Text = filaSeleccionada.Cells["IdPartido"].Value.ToString();
                txtMarcadorLocal.Text = filaSeleccionada.Cells["MarcadorLocal"].Value.ToString();
                txtMarcadorVisitante.Text = filaSeleccionada.Cells["MarcadorVisitante"].Value.ToString();
            }
        }
    }
}
