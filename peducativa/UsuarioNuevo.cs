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
    
    public UsuarioNuevo()
    {
        InitializeComponent();
    }

    // 1. EL CONSTRUCTOR (Cuando la ventana nace)
	public UsuarioNuevo(string id, string nombre, string clave, string rol)
	{
	    InitializeComponent();
	    this.idUsuario = id; // Guardamos el ID para saber a quién vamos a editar
	    txtNombre.Text = nombre; // Ponemos el nombre en el cuadro de texto
	    txtClave.Text = clave;   // Ponemos la clave
	    
	    // Intentamos seleccionar el rol en el menú desplegable
	    try {
	        cmbRol.SelectedIndex = int.Parse(rol);
	    } catch {
	        cmbRol.SelectedIndex = 0; // Si falla, ponemos el primero por defecto
	    }
	    this.Text = "Modificar Usuario"; // Cambiamos el título de la ventana
	}
	
	void BtnGuardarClick(object sender, EventArgs e)
	{
	    // 2. VALIDACIÓN: ¿Dejó algo vacío?
	    if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
	    {
	        MessageBox.Show("Por favor, rellene todos los campos.");
	        return; // Si falta algo, nos detenemos aquí y no guardamos nada
	    }
	
	    try {
	        using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
	        {
	            conexion.Open();
	
	            // 3. SEGURIDAD: ¿El nombre ya está registrado?
	            // Solo revisamos esto si es un usuario NUEVO.
	            if (idUsuario == null) 
	            {
	                string consultaCheck = "SELECT COUNT(*) FROM usuario WHERE nombre = @nom";
	                using (MySqlCommand cmdCheck = new MySqlCommand(consultaCheck, conexion))
	                {
	                    cmdCheck.Parameters.AddWithValue("@nom", txtNombre.Text.Trim());
	                    int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
	
	                    if (existe > 0)
	                    {
	                        MessageBox.Show("El nombre de usuario ya existe. Elija otro.");
	                        return; // Si ya existe, no dejamos guardar
	                    }
	                }
	            }
	
	            // 4. DECISIÓN: ¿Insertamos o Actualizamos?
	            string consulta;
	            if (idUsuario == null) {
	                // Si no hay ID, es alguien nuevo (INSERT)
	                consulta = "INSERT INTO usuario (nombre, clave, rol) VALUES (@nombre, @clave, @rol)";
	            } else {
	                // Si hay ID, es alguien que ya existe (UPDATE)
	                consulta = "UPDATE usuario SET nombre=@nombre, clave=@clave, rol=@rol WHERE id=@id";
	            }
	
	            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
	            {
	                // Limpiamos los espacios extras con .Trim() y pasamos los datos
	                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
	                cmd.Parameters.AddWithValue("@clave", txtClave.Text.Trim());
	                cmd.Parameters.AddWithValue("@rol", cmbRol.SelectedIndex);
	                
	                if (idUsuario != null) {
	                    cmd.Parameters.AddWithValue("@id", idUsuario);
	                }
	
	                cmd.ExecuteNonQuery(); // Ejecutamos la orden en la base de datos
	            }
	        }
	        
	        // 5. FINALIZACIÓN
	        MessageBox.Show(idUsuario == null ? "Usuario agregado." : "Usuario actualizado.");
	        this.DialogResult = DialogResult.OK; // Enviamos la señal de "Éxito" a la ventana principal
	        this.Close(); // Cerramos la ventanita
	    } catch (Exception ex) {
	        MessageBox.Show("Error: " + ex.Message);
	    }
	}
	}
}
