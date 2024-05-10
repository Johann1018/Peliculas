using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otroParcial
{
    public partial class Form1 : Form
    {

        Controladora controladora;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Capturar los datos del formulario
                int dni = int.Parse(txtDni.Text);
                string nombre = txtNombre.Text;   
                string sexo = cmbSexo.Text;
                string estado = cmbEstado.Text;
                int telefono = int.Parse(txtTelefono.Text);

                // Crear una instancia de Vehiculo con los datos capturados
                Director director = new Director
                {
                    DNI = dni,
                    NombreCompleto = nombre,
                    Sexo = sexo,
                    Estado = estado,
                    Telefono = telefono,
                };

                // Registrar el vehículo en el taller de mecánica
                Controladora.RegistrarDirector(director);

                // Actualizar el DataGridView
                dgDirectores.DataSource = null;
                dgDirectores.DataSource = Controladora.directores;

                // Mostrar un mensaje de éxito
                MessageBox.Show("Director registrado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar director: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgDirectores_SelectionChanged(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dgDirectores.SelectedRows.Count > 0)
            {
                // Obtener el vehículo seleccionado
                Director directorSeleccionado = (Director)dgDirectores.SelectedRows[0].DataBoundItem;

                // Habilitar el botón si se seleccionó un vehículo
                btnRegistrarPelicula.Enabled = true;
            }
            else
            {
                // Deshabilitar el botón si no se seleccionó ningún vehículo
                btnRegistrarPelicula.Enabled = false;
            }
        }

        private void btnRegistrarPelicula_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se seleccionó una fila en el DataGridView
                if (dgDirectores.SelectedRows.Count > 0)
                {
                    // Obtener el vehículo seleccionado
                    Director directorSeleccionado = (Director)dgDirectores.SelectedRows[0].DataBoundItem;

                    // Obtener los valores de los TextBox
                    string codigo = txtCodigo.Text;
                    string nombre = txtNombrePelicula.Text;
                    string genero = cmbGenero.Text;
                    string estado = txtEstado.Text;
                    string duracion = txtDuracion.Text;
                    double taquilla = double.Parse(txtTaquillaGenerada.Text);
                    string año = txtAñoEstreno.Text;

                    // Crear una instancia de OrdenServicio
                    Pelicula pelicula = new Pelicula
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Genero = genero,
                        Estado = estado,
                        Duracion = duracion,
                        TaquillaGenerada = taquilla,
                        AñoEstreno = año
                    };
               
                    // Agregar la orden de servicio al vehículo seleccionado
                    directorSeleccionado.Pelicula.Add(pelicula);

                    // Actualizar el DataGridView con las órdenes de servicio del vehículo
                    dgPeliculas.DataSource = null;
                    dgPeliculas.DataSource = directorSeleccionado.Pelicula;

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("Pelicula registrada correctamente.");
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un director.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar pelicula: {ex.Message}");
            }
        }

        private void ActualizarDataGridView(List<Director> directors)
        {
            // Limpiar el DataGridView
            //  dgFiltros.DataSource = null;

            // Mostrar los vehículos en el DataGridView
            dgFiltros.DataSource = directors;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los vehículos con el mayor número de órdenes de servicio
                var peliculasMasTaquilleras = Controladora.directores
                    .OrderByDescending(v => v.Pelicula.Count)
                    // .Take(1)
                    .ToList();

                // Actualizar el DataGridView con los resultados del filtro
                ActualizarDataGridView(peliculasMasTaquilleras);

                // Mostrar un mensaje si no se encontraron vehículos
                if (peliculasMasTaquilleras.Count == 0)
                {
                    MessageBox.Show("No se encontraron vehículos con órdenes de servicio.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar vehículos: {ex.Message}");
            }
        }
    }
}
