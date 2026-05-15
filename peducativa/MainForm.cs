/*
CREATE DATABASE IF NOT EXISTS `peducativa`;
USE `peducativa`;

CREATE TABLE IF NOT EXISTS `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `clave` varchar(50) NOT NULL,
  `rol` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB;
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace peducativa
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			CargarUsuarios();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void CargarUsuarios()
		{
		    try {
		        using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) 
		        {
		            string consulta = "SELECT id, nombre, clave, rol FROM usuario";
		            conexion.Open();
		            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
		            DataTable tabla = new DataTable(); 
		            adaptador.Fill(tabla);
		            
		            // Asignación al control visual
		            dgvUsuarios.DataSource = tabla;
		            lblEstado.Text = string.Format("Cargados {0} usuarios.", tabla.Rows.Count);
		        }
		    } catch (Exception ex) {
		        MessageBox.Show("Error de conexión: " + ex.Message);
		    }
		}
		void BtnAgregarClick(object sender, EventArgs e)
		{
			UsuarioNuevo frmnuevo  = new UsuarioNuevo();
		
			if (frmnuevo.ShowDialog() == DialogResult.OK) // para mantener estructura
            {
				CargarUsuarios();
			}
		}
		void BtnModificarClick(object sender, EventArgs e)
		{
			if (dgvUsuarios.SelectedRows.Count > 0)
		    {
		        // 1. Obtener los datos de la fila seleccionada
		        string id = dgvUsuarios.CurrentRow.Cells["id"].Value.ToString();
		        string nombre = dgvUsuarios.CurrentRow.Cells["nombre"].Value.ToString();
		        string clave = dgvUsuarios.CurrentRow.Cells["clave"].Value.ToString();
		        string rol = dgvUsuarios.CurrentRow.Cells["rol"].Value.ToString();
		
		        // 2. Abrir el formulario y pasarle los datos (necesitaremos un constructor nuevo)
		        UsuarioNuevo frmModificar = new UsuarioNuevo(id, nombre, clave, rol);
		        
		        if (frmModificar.ShowDialog() == DialogResult.OK)
		        {
		            CargarUsuarios(); // Recargar la tabla tras modificar
		        }
		    }
		    else
		    {
		        MessageBox.Show("Por favor, seleccione una fila de la tabla para modificar.");
		    }
		}
		void BtnEliminarClick(object sender, EventArgs e)
		{
			if (dgvUsuarios.SelectedRows.Count > 0)
		    {
		        // 2. OBTENER EL ID de la fila seleccionada (Esto es lo que te faltaba)
		        string idParaEliminar = dgvUsuarios.CurrentRow.Cells["id"].Value.ToString();
		
		        // 3. Confirmación (Opcional pero recomendado)
		        if (MessageBox.Show("¿Desea eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
		        {
		            string consulta = "DELETE FROM usuario WHERE id = @id";
		            try {
		                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
		                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
		                {
		                    // AQUÍ USAMOS LA VARIABLE QUE CREAMOS ARRIBA
		                    cmd.Parameters.AddWithValue("@id", idParaEliminar);
		
		                    conexion.Open();
		                    cmd.ExecuteNonQuery();
		                }
		                MessageBox.Show("Usuario eliminado correctamente.");
		                CargarUsuarios(); // Recargar la tabla
		            } catch (Exception ex) {
		                MessageBox.Show("Error al eliminar: " + ex.Message);
		            }
		        }
		    }
		    else
		    {
		        MessageBox.Show("Por favor, seleccione una fila de la tabla.");
		    }
		}
		public void ConsultarUsuarios(string nombreBusqueda)
		{
		    try {
		        using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) 
		        {
		            // La consulta usa LIKE para buscar nombres que EMPIECEN o CONTENGAN ese texto
		            string consulta = "SELECT id, nombre, clave, rol FROM usuario WHERE nombre LIKE @nombre";
		            
		            conexion.Open();
		            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
		            
		            // El '%' indica que puede haber cualquier texto después de lo que escribas
		            adaptador.SelectCommand.Parameters.AddWithValue("@nombre", nombreBusqueda + "%");
		            
		            DataTable tabla = new DataTable(); 
		            adaptador.Fill(tabla);
		            
		            dgvUsuarios.DataSource = tabla;
		            lblEstado.Text = string.Format("Encontrados {0} usuarios.", tabla.Rows.Count);
		        }
		    } catch (Exception ex) {
		        MessageBox.Show("Error al consultar: " + ex.Message);
		    }
		}
		void BtnConsultarClick(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(txtConsultar.Text)) 
		    {
		        ConsultarUsuarios(txtConsultar.Text);
		    } 
		    else 
		    {
		        MessageBox.Show("Por favor, escribe un nombre en el cuadro de búsqueda.");
		        CargarUsuarios();
		    }
		}
	}
}
