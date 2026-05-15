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
		
		// Esta es la dirección para encontrar y entrar a nuestra base de datos
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
		        using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) // 1. Preparamos el túnel (conexión) usando nuestra "dirección" (cadenaConexion).
		        {
		            string consulta = "SELECT id, nombre, clave, rol FROM usuario"; // 2. Escribimos la nota de lo que queremos pedir (seleccionar datos de la tabla usuario).
		            conexion.Open(); // 3. Abrimos la puerta de la base de datos.
		            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion); // 4. El 'adaptador' es como un mensajero: lleva la pregunta y trae los resultados.
		            DataTable tabla = new DataTable(); // 5. Creamos una tabla vacía en la memoria de la computadora para guardar lo que llegue.
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
	
			if (frmnuevo.ShowDialog() == DialogResult.OK)
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
		
		        // 2. Abrir el formulario y pasarle los datos 
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
		        // 2. OBTENER EL ID de la fila seleccionada
		        string idParaEliminar = dgvUsuarios.CurrentRow.Cells["id"].Value.ToString();
		
		        // 3. Confirmación (Opcional pero recomendado)
		        if (MessageBox.Show("¿Desea eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
		        {
		            string consulta = "DELETE FROM usuario WHERE id = @id"; // 1. Escribimos la orden para la base de datos: "BORRAR DE la tabla usuario DONDE el id coincida".
		            try {
		            	// 2. Preparamos la conexión y el comando (el sobre y la carta que vamos a enviar).
		                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
		                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
		                {
		                    // 3. ¡Seguridad primero! Le decimos que "@id" es el número del usuario que atrapamos de la tabla.
        					// Esto evita que borremos a alguien por accidente.
		                    cmd.Parameters.AddWithValue("@id", idParaEliminar);
							// 4. Abrimos la base de datos y ejecutamos la orden (hacemos el borrado).
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
		            
		            // 2. El símbolo '%' es la clave. 
            		// Si escribes "J", el '%' busca todo lo que empiece por J (Jose, Joselyn, Juan).
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
