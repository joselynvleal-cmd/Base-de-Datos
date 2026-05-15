/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 14/5/2026
 * Time: 6:58 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;


namespace peducativa
{
	/// <summary>
	/// Description of UsuarioNuevo.
	/// </summary>
	public partial class UsuarioNuevo : Form
	{
		private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
    private string idUsuario = null;

    // CONSTRUCTOR 1: Para agregar (Sin parámetros)
    // Este es el que te falta y por eso da error en la línea 57 de MainForm
    public UsuarioNuevo()
    {
        InitializeComponent();
    }

    // CONSTRUCTOR 2: Para modificar (Con parámetros)
    public UsuarioNuevo(string id, string nombre, string clave, string rol)
    {
        InitializeComponent();
        this.idUsuario = id;
        txtNombre.Text = nombre;
        txtClave.Text = clave;
        
        // Intentar asignar el rol si el combo tiene items
        try {
            cmbRol.SelectedIndex = int.Parse(rol);
        } catch {
            cmbRol.SelectedIndex = 0;
        }
        
        this.Text = "Modificar Usuario";
    }
		void BtnGuardarClick(object sender, EventArgs e)
		{
			// 1. Validaciones de campos vacíos (ya las tienes)
		    if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
		    {
		        MessageBox.Show("Por favor, rellene todos los campos.");
		        return;
		    }
		
		    int idrol = cmbRol.SelectedIndex; 
		    if (idrol < 0) idrol = 0;
		
		    try {
		        using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
		        {
		            conexion.Open();
		
		            // --- NUEVA VALIDACIÓN: Verificar si el nombre ya existe ---
		            // Solo validamos si estamos creando un usuario NUEVO (idUsuario == null)
		            if (idUsuario == null) 
		            {
		                string consultaCheck = "SELECT COUNT(*) FROM usuario WHERE nombre = @nom";
		                using (MySqlCommand cmdCheck = new MySqlCommand(consultaCheck, conexion))
		                {
		                    cmdCheck.Parameters.AddWithValue("@nom", txtNombre.Text.Trim());
		                    int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
		
		                    if (existe > 0)
		                    {
		                        MessageBox.Show("El nombre de usuario ya existe. Por favor, elija otro.");
		                        return; // Detiene la ejecución y no guarda
		                    }
		                }
		            }
		            // ---------------------------------------------------------
		
		            // Si llegamos aquí, el nombre es válido o estamos editando
		            string consulta;
		            if (idUsuario == null) {
		                consulta = "INSERT INTO usuario (nombre, clave, rol) VALUES (@nombre, @clave, @rol)";
		            } else {
		                consulta = "UPDATE usuario SET nombre=@nombre, clave=@clave, rol=@rol WHERE id=@id";
		            }
		
		            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
		            {
		                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
		                cmd.Parameters.AddWithValue("@clave", txtClave.Text.Trim());
		                cmd.Parameters.AddWithValue("@rol", idrol);
		                
		                if (idUsuario != null) {
		                    cmd.Parameters.AddWithValue("@id", idUsuario);
		                }
		
		                cmd.ExecuteNonQuery();
		            }
		        }
		        
		        MessageBox.Show(idUsuario == null ? "Usuario agregado." : "Usuario actualizado.");
		        this.DialogResult = DialogResult.OK;
		        this.Close();
		    } catch (Exception ex) {
		        MessageBox.Show("Error: " + ex.Message);
		    }
		}
	}
}
