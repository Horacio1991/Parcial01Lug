using BLL;
using Entity;


namespace UI
{
    public partial class Form1 : Form
    {
        private readonly PartidoBLL _partidoBLL;
        private List<Partido> _partidosEnMemoria;

        public Form1()
        {
            InitializeComponent();
            _partidoBLL = new PartidoBLL();
            _partidosEnMemoria = new List<Partido>();
            CargarDeportes();
            CargarPartidosEnGrilla();
        }

        // Cargar deportes en el combo box
        private void CargarDeportes()
        {
            List<Deporte> deportes = _partidoBLL.ObtenerDeportes();
            cmbDeporte.DataSource = deportes;
            cmbDeporte.DisplayMember = "Descripcion"; // Mostrar el nombre del deporte
            cmbDeporte.ValueMember = "IdDeporte";     // Obtener el ID del deporte seleccionado
        }

        // Cargar los partidos en el DataGridView
        private void CargarPartidosEnGrilla()
        {
            List<Partido> partidos = _partidoBLL.ObtenerTodosLosPartidos();
            dgvTodosLosPartidos.DataSource = partidos;

            // Modificación estética de las columnas
            dgvTodosLosPartidos.Columns["FechaRegistro"].HeaderText = "Fecha de Registro";
            dgvTodosLosPartidos.Columns["EquipoLocal"].HeaderText = "Equipo Local";
            dgvTodosLosPartidos.Columns["EquipoVisitante"].HeaderText = "Equipo Visitante";
            dgvTodosLosPartidos.Columns["FechaPartido"].HeaderText = "Fecha del Partido";
            dgvTodosLosPartidos.Columns["MarcadorLocal"].HeaderText = "Marcador Local";
            dgvTodosLosPartidos.Columns["MarcadorVisitante"].HeaderText = "Marcador Visitante";
            dgvTodosLosPartidos.Columns["Deporte"].Visible = false; // Ocultar la columna de objeto Deporte

            // Agreg columna para la descripción del deporte
            if (!dgvTodosLosPartidos.Columns.Contains("DescripcionDeporte"))
            {
                DataGridViewTextBoxColumn descripcionDeporteColumn = new DataGridViewTextBoxColumn
                {
                    Name = "DescripcionDeporte",
                    HeaderText = "Deporte",
                    ReadOnly = true
                };
                dgvTodosLosPartidos.Columns.Add(descripcionDeporteColumn);
            }

            // Rellenar la columna con la descripción del deporte
            foreach (DataGridViewRow row in dgvTodosLosPartidos.Rows)
            {
                Partido partido = row.DataBoundItem as Partido;
                if (partido != null)
                {
                    row.Cells["DescripcionDeporte"].Value = partido.Deporte.Descripcion;
                }
            }
        }

        // Limpiar campos de texto
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
                Deporte deporteSeleccionado = (Deporte)cmbDeporte.SelectedItem;
                string equipoLocal = txtEquipoLocal.Text;
                string equipoVisitante = txtEquipoVisitante.Text;
                DateTime fechaPartido = dtpFechaPartido.Value;

                Partido nuevoPartido = new Partido
                {
                    Deporte = deporteSeleccionado,
                    EquipoLocal = equipoLocal,
                    EquipoVisitante = equipoVisitante,
                    FechaPartido = fechaPartido
                };

                _partidoBLL.AgregarPartido(nuevoPartido);

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

        // Autocompletar campos al hacer clic en una fila de la tabla
        private void dgvTodosLosPartidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvTodosLosPartidos.Rows[e.RowIndex];
                Partido partidoSeleccionado = filaSeleccionada.DataBoundItem as Partido;

                if (partidoSeleccionado != null)
                {
                    // Autocompletar TextBox para eliminar partido
                    txtEliminarPartido.Text = partidoSeleccionado.IdPartido.ToString();

                    // Autocompletar TextBox para modificar marcador
                    txtActualizarMarcador.Text = partidoSeleccionado.IdPartido.ToString();
                    txtMarcadorLocal.Text = partidoSeleccionado.MarcadorLocal.ToString();
                    txtMarcadorVisitante.Text = partidoSeleccionado.MarcadorVisitante.ToString();
                }
            }
        }

        private void btnGuardarEnMemoria_Click(object sender, EventArgs e)
        {
            try
            {
                Deporte deporteSeleccionado = (Deporte)cmbDeporte.SelectedItem;
                string equipoLocal = txtEquipoLocal.Text;
                string equipoVisitante = txtEquipoVisitante.Text;
                DateTime fechaPartido = dtpFechaPartido.Value;

                Partido nuevoPartido = new Partido
                {
                    Deporte = deporteSeleccionado,
                    EquipoLocal = equipoLocal,
                    EquipoVisitante = equipoVisitante,
                    FechaPartido = fechaPartido
                };

                _partidosEnMemoria.Add(nuevoPartido);
                MessageBox.Show("Partido guardado en memoria.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            try
            {
                _partidoBLL.CargarPartidosMasivos(_partidosEnMemoria);
                MessageBox.Show("Carga masiva realizada con éxito.");
                _partidosEnMemoria.Clear(); // Limpiar lista en memoria despues de la carga
                CargarPartidosEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en carga masiva: " + ex.Message);
            }
        }
    }
}
