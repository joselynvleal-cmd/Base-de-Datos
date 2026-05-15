/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 14/5/2026
 * Time: 2:36 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace peducativa
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView dgvUsuarios;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Button btnModificar;
		private System.Windows.Forms.Button btnConsultar;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.Label lblEstado;
		private System.Windows.Forms.Label lblConsultar;
		private System.Windows.Forms.TextBox txtConsultar;
		
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
			this.dgvUsuarios = new System.Windows.Forms.DataGridView();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnModificar = new System.Windows.Forms.Button();
			this.btnConsultar = new System.Windows.Forms.Button();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.lblEstado = new System.Windows.Forms.Label();
			this.lblConsultar = new System.Windows.Forms.Label();
			this.txtConsultar = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvUsuarios
			// 
			this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUsuarios.Location = new System.Drawing.Point(12, 12);
			this.dgvUsuarios.Name = "dgvUsuarios";
			this.dgvUsuarios.RowTemplate.Height = 24;
			this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvUsuarios.Size = new System.Drawing.Size(639, 254);
			this.dgvUsuarios.TabIndex = 0;
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(712, 32);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(149, 50);
			this.btnAgregar.TabIndex = 1;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.BtnAgregarClick);
			// 
			// btnModificar
			// 
			this.btnModificar.Location = new System.Drawing.Point(712, 118);
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.Size = new System.Drawing.Size(149, 50);
			this.btnModificar.TabIndex = 2;
			this.btnModificar.Text = "Modificar";
			this.btnModificar.UseVisualStyleBackColor = true;
			this.btnModificar.Click += new System.EventHandler(this.BtnModificarClick);
			// 
			// btnConsultar
			// 
			this.btnConsultar.Location = new System.Drawing.Point(400, 368);
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.Size = new System.Drawing.Size(149, 50);
			this.btnConsultar.TabIndex = 3;
			this.btnConsultar.Text = "Consultar";
			this.btnConsultar.UseVisualStyleBackColor = true;
			this.btnConsultar.Click += new System.EventHandler(this.BtnConsultarClick);
			// 
			// btnEliminar
			// 
			this.btnEliminar.Location = new System.Drawing.Point(712, 204);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(149, 50);
			this.btnEliminar.TabIndex = 4;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			this.btnEliminar.Click += new System.EventHandler(this.BtnEliminarClick);
			// 
			// lblEstado
			// 
			this.lblEstado.Location = new System.Drawing.Point(313, 441);
			this.lblEstado.Name = "lblEstado";
			this.lblEstado.Size = new System.Drawing.Size(325, 23);
			this.lblEstado.TabIndex = 5;
			this.lblEstado.Text = "Listo";
			this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblConsultar
			// 
			this.lblConsultar.AutoSize = true;
			this.lblConsultar.Location = new System.Drawing.Point(400, 291);
			this.lblConsultar.Name = "lblConsultar";
			this.lblConsultar.Size = new System.Drawing.Size(129, 17);
			this.lblConsultar.TabIndex = 6;
			this.lblConsultar.Text = " Consultar Usuario:";
			// 
			// txtConsultar
			// 
			this.txtConsultar.Location = new System.Drawing.Point(367, 329);
			this.txtConsultar.Name = "txtConsultar";
			this.txtConsultar.Size = new System.Drawing.Size(209, 22);
			this.txtConsultar.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(937, 485);
			this.Controls.Add(this.txtConsultar);
			this.Controls.Add(this.lblConsultar);
			this.Controls.Add(this.lblEstado);
			this.Controls.Add(this.btnEliminar);
			this.Controls.Add(this.btnConsultar);
			this.Controls.Add(this.btnModificar);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.dgvUsuarios);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "peducativa";
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
