/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 14/5/2026
 * Time: 6:58 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace peducativa
{
	partial class UsuarioNuevo
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.TextBox txtClave;
		private System.Windows.Forms.ComboBox cmbRol;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnGuardar;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.txtClave = new System.Windows.Forms.TextBox();
			this.cmbRol = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(288, 138);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(251, 22);
			this.txtNombre.TabIndex = 0;
			// 
			// txtClave
			// 
			this.txtClave.Location = new System.Drawing.Point(288, 212);
			this.txtClave.Name = "txtClave";
			this.txtClave.Size = new System.Drawing.Size(251, 22);
			this.txtClave.TabIndex = 1;
			// 
			// cmbRol
			// 
			this.cmbRol.FormattingEnabled = true;
			this.cmbRol.Items.AddRange(new object[] {
			"Jugador",
			"Administrador"});
			this.cmbRol.Location = new System.Drawing.Point(288, 291);
			this.cmbRol.Name = "cmbRol";
			this.cmbRol.Size = new System.Drawing.Size(251, 24);
			this.cmbRol.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoEllipsis = true;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(288, 118);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Nombre de usuario";
			// 
			// label2
			// 
			this.label2.AutoEllipsis = true;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(288, 192);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Contraseña";
			// 
			// label3
			// 
			this.label3.AutoEllipsis = true;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(288, 271);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "Rol";
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(404, 398);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(126, 51);
			this.btnGuardar.TabIndex = 6;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.BtnGuardarClick);
			// 
			// UsuarioNuevo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(937, 485);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbRol);
			this.Controls.Add(this.txtClave);
			this.Controls.Add(this.txtNombre);
			this.Name = "UsuarioNuevo";
			this.Text = "UsuarioNuevo";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
