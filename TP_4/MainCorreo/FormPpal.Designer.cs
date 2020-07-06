namespace MainCorreo
{
    partial class FormPpal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbEstadoPaquetes = new System.Windows.Forms.GroupBox();
            this.lblEntragado = new System.Windows.Forms.Label();
            this.lblEnViaje = new System.Windows.Forms.Label();
            this.lblIngresado = new System.Windows.Forms.Label();
            this.lstEstadoEntregado = new System.Windows.Forms.ListBox();
            this.cmsListas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstEstadoEnViaje = new System.Windows.Forms.ListBox();
            this.lstEstadoIngreasado = new System.Windows.Forms.ListBox();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.gbGrupo = new System.Windows.Forms.GroupBox();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.mtxtTrackingID = new System.Windows.Forms.MaskedTextBox();
            this.gbEstadoPaquetes.SuspendLayout();
            this.cmsListas.SuspendLayout();
            this.gbGrupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEstadoPaquetes
            // 
            this.gbEstadoPaquetes.Controls.Add(this.lblEntragado);
            this.gbEstadoPaquetes.Controls.Add(this.lblEnViaje);
            this.gbEstadoPaquetes.Controls.Add(this.lblIngresado);
            this.gbEstadoPaquetes.Controls.Add(this.lstEstadoEntregado);
            this.gbEstadoPaquetes.Controls.Add(this.lstEstadoEnViaje);
            this.gbEstadoPaquetes.Controls.Add(this.lstEstadoIngreasado);
            this.gbEstadoPaquetes.Location = new System.Drawing.Point(12, 25);
            this.gbEstadoPaquetes.Name = "gbEstadoPaquetes";
            this.gbEstadoPaquetes.Size = new System.Drawing.Size(776, 253);
            this.gbEstadoPaquetes.TabIndex = 0;
            this.gbEstadoPaquetes.TabStop = false;
            this.gbEstadoPaquetes.Text = "Estado Paquetes";
            // 
            // lblEntragado
            // 
            this.lblEntragado.AutoSize = true;
            this.lblEntragado.Location = new System.Drawing.Point(549, 32);
            this.lblEntragado.Name = "lblEntragado";
            this.lblEntragado.Size = new System.Drawing.Size(56, 13);
            this.lblEntragado.TabIndex = 5;
            this.lblEntragado.Text = "Entregado";
            // 
            // lblEnViaje
            // 
            this.lblEnViaje.AutoSize = true;
            this.lblEnViaje.Location = new System.Drawing.Point(275, 32);
            this.lblEnViaje.Name = "lblEnViaje";
            this.lblEnViaje.Size = new System.Drawing.Size(46, 13);
            this.lblEnViaje.TabIndex = 4;
            this.lblEnViaje.Text = "En Viaje";
            // 
            // lblIngresado
            // 
            this.lblIngresado.AutoSize = true;
            this.lblIngresado.Location = new System.Drawing.Point(7, 32);
            this.lblIngresado.Name = "lblIngresado";
            this.lblIngresado.Size = new System.Drawing.Size(53, 13);
            this.lblIngresado.TabIndex = 3;
            this.lblIngresado.Text = "lngresado";
            // 
            // lstEstadoEntregado
            // 
            this.lstEstadoEntregado.ContextMenuStrip = this.cmsListas;
            this.lstEstadoEntregado.FormattingEnabled = true;
            this.lstEstadoEntregado.Location = new System.Drawing.Point(552, 51);
            this.lstEstadoEntregado.Name = "lstEstadoEntregado";
            this.lstEstadoEntregado.Size = new System.Drawing.Size(207, 186);
            this.lstEstadoEntregado.TabIndex = 2;
            this.lstEstadoEntregado.ContextMenuStripChanged += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // cmsListas
            // 
            this.cmsListas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem});
            this.cmsListas.Name = "cmsInfo";
            this.cmsListas.Size = new System.Drawing.Size(116, 26);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // lstEstadoEnViaje
            // 
            this.lstEstadoEnViaje.FormattingEnabled = true;
            this.lstEstadoEnViaje.Location = new System.Drawing.Point(278, 51);
            this.lstEstadoEnViaje.Name = "lstEstadoEnViaje";
            this.lstEstadoEnViaje.Size = new System.Drawing.Size(207, 186);
            this.lstEstadoEnViaje.TabIndex = 1;
            // 
            // lstEstadoIngreasado
            // 
            this.lstEstadoIngreasado.FormattingEnabled = true;
            this.lstEstadoIngreasado.Location = new System.Drawing.Point(6, 51);
            this.lstEstadoIngreasado.Name = "lstEstadoIngreasado";
            this.lstEstadoIngreasado.Size = new System.Drawing.Size(207, 186);
            this.lstEstadoIngreasado.TabIndex = 0;
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.Location = new System.Drawing.Point(12, 300);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.ReadOnly = true;
            this.rtbMostrar.Size = new System.Drawing.Size(439, 138);
            this.rtbMostrar.TabIndex = 1;
            this.rtbMostrar.Text = "";
            // 
            // gbGrupo
            // 
            this.gbGrupo.Controls.Add(this.btnMostrarTodos);
            this.gbGrupo.Controls.Add(this.btnAgregar);
            this.gbGrupo.Controls.Add(this.txtDireccion);
            this.gbGrupo.Controls.Add(this.lblDireccion);
            this.gbGrupo.Controls.Add(this.lblTrackingID);
            this.gbGrupo.Controls.Add(this.mtxtTrackingID);
            this.gbGrupo.Location = new System.Drawing.Point(471, 300);
            this.gbGrupo.Name = "gbGrupo";
            this.gbGrupo.Size = new System.Drawing.Size(317, 146);
            this.gbGrupo.TabIndex = 2;
            this.gbGrupo.TabStop = false;
            this.gbGrupo.Text = "Paquete";
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(172, 82);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(139, 46);
            this.btnMostrarTodos.TabIndex = 7;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(172, 17);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(139, 47);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(6, 108);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(160, 20);
            this.txtDireccion.TabIndex = 5;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(6, 92);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.Location = new System.Drawing.Point(6, 28);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(63, 13);
            this.lblTrackingID.TabIndex = 3;
            this.lblTrackingID.Text = "Tracking ID";
            // 
            // mtxtTrackingID
            // 
            this.mtxtTrackingID.Location = new System.Drawing.Point(6, 44);
            this.mtxtTrackingID.Mask = "000-000-0000";
            this.mtxtTrackingID.Name = "mtxtTrackingID";
            this.mtxtTrackingID.Size = new System.Drawing.Size(160, 20);
            this.mtxtTrackingID.TabIndex = 2;
            // 
            // FormPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbGrupo);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.gbEstadoPaquetes);
            this.Name = "FormPpal";
            this.Text = "Correo UTN por Victoria.Pereyra.2C";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPpal_FormClosing);
            this.gbEstadoPaquetes.ResumeLayout(false);
            this.gbEstadoPaquetes.PerformLayout();
            this.cmsListas.ResumeLayout(false);
            this.gbGrupo.ResumeLayout(false);
            this.gbGrupo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEstadoPaquetes;
        private System.Windows.Forms.Label lblIngresado;
        private System.Windows.Forms.ListBox lstEstadoEntregado;
        private System.Windows.Forms.ListBox lstEstadoEnViaje;
        private System.Windows.Forms.ListBox lstEstadoIngreasado;
        private System.Windows.Forms.Label lblEnViaje;
        private System.Windows.Forms.Label lblEntragado;
        private System.Windows.Forms.RichTextBox rtbMostrar;
        private System.Windows.Forms.GroupBox gbGrupo;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.MaskedTextBox mtxtTrackingID;
        private System.Windows.Forms.ContextMenuStrip cmsListas;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
    }
}

