namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FProductosTipos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FProductosTipos));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tVProductostipos = new System.Windows.Forms.TreeView();
            this.cMSProductosTipos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMIAgregarProductoTipoPadre = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIAgregarProductoTipo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMIEditarElementoActual = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIEliminarElementoActual = new System.Windows.Forms.ToolStripMenuItem();
            this.iLProductosTipos32x32 = new System.Windows.Forms.ImageList(this.components);
            this.bCerrar = new System.Windows.Forms.Button();
            this.tBDescripcionTipoProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.tBNivel = new System.Windows.Forms.TextBox();
            this.tBNombreCortoTipoProducto = new System.Windows.Forms.TextBox();
            this.tBNombreTipoProducto = new System.Windows.Forms.TextBox();
            this.tBCodigoTipoProducto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSMIAgregarProductoTipoPadre1 = new System.Windows.Forms.ToolStripButton();
            this.tSMIAgregarProductoTipo1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMIEditarElementoSeleccionado1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMIEliminarElementoSeleccionado1 = new System.Windows.Forms.ToolStripButton();
            this.tSBCerrar = new System.Windows.Forms.ToolStripButton();
            this.iLProductosTiposSeleccionados = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cMSProductosTipos.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(807, 443);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(807, 482);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tVProductostipos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bCerrar);
            this.splitContainer1.Panel2.Controls.Add(this.tBDescripcionTipoProducto);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.bCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.bAceptar);
            this.splitContainer1.Panel2.Controls.Add(this.tBNivel);
            this.splitContainer1.Panel2.Controls.Add(this.tBNombreCortoTipoProducto);
            this.splitContainer1.Panel2.Controls.Add(this.tBNombreTipoProducto);
            this.splitContainer1.Panel2.Controls.Add(this.tBCodigoTipoProducto);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Size = new System.Drawing.Size(807, 443);
            this.splitContainer1.SplitterDistance = 382;
            this.splitContainer1.TabIndex = 1;
            // 
            // tVProductostipos
            // 
            this.tVProductostipos.ContextMenuStrip = this.cMSProductosTipos;
            this.tVProductostipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tVProductostipos.ImageIndex = 0;
            this.tVProductostipos.ImageList = this.iLProductosTipos32x32;
            this.tVProductostipos.Location = new System.Drawing.Point(0, 0);
            this.tVProductostipos.Name = "tVProductostipos";
            this.tVProductostipos.SelectedImageIndex = 0;
            this.tVProductostipos.Size = new System.Drawing.Size(382, 443);
            this.tVProductostipos.TabIndex = 0;
            this.tVProductostipos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tVProductostipos_MouseDown);
            // 
            // cMSProductosTipos
            // 
            this.cMSProductosTipos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIAgregarProductoTipoPadre,
            this.tSMIAgregarProductoTipo,
            this.toolStripSeparator1,
            this.tSMIEditarElementoActual,
            this.tSMIEliminarElementoActual});
            this.cMSProductosTipos.Name = "cMSProductosTipos";
            this.cMSProductosTipos.Size = new System.Drawing.Size(243, 98);
            // 
            // tSMIAgregarProductoTipoPadre
            // 
            this.tSMIAgregarProductoTipoPadre.Name = "tSMIAgregarProductoTipoPadre";
            this.tSMIAgregarProductoTipoPadre.Size = new System.Drawing.Size(242, 22);
            this.tSMIAgregarProductoTipoPadre.Text = "Agregar producto tipo padre";
            this.tSMIAgregarProductoTipoPadre.Click += new System.EventHandler(this.tSMIAgregarProductoTipoPadre_Click);
            // 
            // tSMIAgregarProductoTipo
            // 
            this.tSMIAgregarProductoTipo.Name = "tSMIAgregarProductoTipo";
            this.tSMIAgregarProductoTipo.Size = new System.Drawing.Size(242, 22);
            this.tSMIAgregarProductoTipo.Text = "Agregar producto tipo";
            this.tSMIAgregarProductoTipo.Click += new System.EventHandler(this.tSMIAgregarProductoTipo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
            // 
            // tSMIEditarElementoActual
            // 
            this.tSMIEditarElementoActual.Name = "tSMIEditarElementoActual";
            this.tSMIEditarElementoActual.Size = new System.Drawing.Size(242, 22);
            this.tSMIEditarElementoActual.Text = "Editar elemento seleccionado";
            this.tSMIEditarElementoActual.Click += new System.EventHandler(this.tSMIEditarElementoActual_Click);
            // 
            // tSMIEliminarElementoActual
            // 
            this.tSMIEliminarElementoActual.Name = "tSMIEliminarElementoActual";
            this.tSMIEliminarElementoActual.Size = new System.Drawing.Size(242, 22);
            this.tSMIEliminarElementoActual.Text = "Eliminar elemento seleccionado";
            this.tSMIEliminarElementoActual.Click += new System.EventHandler(this.tSMIEliminarElementoActual_Click);
            // 
            // iLProductosTipos32x32
            // 
            this.iLProductosTipos32x32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iLProductosTipos32x32.ImageStream")));
            this.iLProductosTipos32x32.TransparentColor = System.Drawing.Color.Transparent;
            this.iLProductosTipos32x32.Images.SetKeyName(0, "ProductoTipoGrupo.ico");
            this.iLProductosTipos32x32.Images.SetKeyName(1, "ProductoTipoPadre.ico");
            this.iLProductosTipos32x32.Images.SetKeyName(2, "ProductoTipo.ico");
            // 
            // bCerrar
            // 
            this.bCerrar.Location = new System.Drawing.Point(331, 192);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(75, 23);
            this.bCerrar.TabIndex = 12;
            this.bCerrar.Text = "Cerrar";
            this.bCerrar.UseVisualStyleBackColor = true;
            this.bCerrar.Click += new System.EventHandler(this.bCerrar_Click_1);
            // 
            // tBDescripcionTipoProducto
            // 
            this.tBDescripcionTipoProducto.Location = new System.Drawing.Point(156, 90);
            this.tBDescripcionTipoProducto.Multiline = true;
            this.tBDescripcionTipoProducto.Name = "tBDescripcionTipoProducto";
            this.tBDescripcionTipoProducto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBDescripcionTipoProducto.Size = new System.Drawing.Size(250, 48);
            this.tBDescripcionTipoProducto.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Descripción tipo producto";
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(249, 192);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 6;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(168, 192);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 23);
            this.bAceptar.TabIndex = 5;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // tBNivel
            // 
            this.tBNivel.Location = new System.Drawing.Point(156, 144);
            this.tBNivel.Name = "tBNivel";
            this.tBNivel.ReadOnly = true;
            this.tBNivel.Size = new System.Drawing.Size(50, 20);
            this.tBNivel.TabIndex = 4;
            // 
            // tBNombreCortoTipoProducto
            // 
            this.tBNombreCortoTipoProducto.Location = new System.Drawing.Point(156, 63);
            this.tBNombreCortoTipoProducto.Name = "tBNombreCortoTipoProducto";
            this.tBNombreCortoTipoProducto.Size = new System.Drawing.Size(150, 20);
            this.tBNombreCortoTipoProducto.TabIndex = 2;
            this.tBNombreCortoTipoProducto.TextChanged += new System.EventHandler(this.tBNombreCortoTipoProducto_TextChanged);
            // 
            // tBNombreTipoProducto
            // 
            this.tBNombreTipoProducto.Location = new System.Drawing.Point(156, 37);
            this.tBNombreTipoProducto.Name = "tBNombreTipoProducto";
            this.tBNombreTipoProducto.Size = new System.Drawing.Size(250, 20);
            this.tBNombreTipoProducto.TabIndex = 1;
            // 
            // tBCodigoTipoProducto
            // 
            this.tBCodigoTipoProducto.Location = new System.Drawing.Point(156, 11);
            this.tBCodigoTipoProducto.Name = "tBCodigoTipoProducto";
            this.tBCodigoTipoProducto.ReadOnly = true;
            this.tBCodigoTipoProducto.Size = new System.Drawing.Size(50, 20);
            this.tBCodigoTipoProducto.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(119, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Nivel";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Nombre corto tipo producto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Nombre tipo producto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Codigo tipo producto";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIAgregarProductoTipoPadre1,
            this.tSMIAgregarProductoTipo1,
            this.toolStripSeparator4,
            this.tSMIEditarElementoSeleccionado1,
            this.tSMIEliminarElementoSeleccionado1,
            this.toolStripSeparator2,
            this.tSBCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(204, 39);
            this.toolStrip1.TabIndex = 0;
            // 
            // tSMIAgregarProductoTipoPadre1
            // 
            this.tSMIAgregarProductoTipoPadre1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSMIAgregarProductoTipoPadre1.Image = ((System.Drawing.Image)(resources.GetObject("tSMIAgregarProductoTipoPadre1.Image")));
            this.tSMIAgregarProductoTipoPadre1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSMIAgregarProductoTipoPadre1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSMIAgregarProductoTipoPadre1.Name = "tSMIAgregarProductoTipoPadre1";
            this.tSMIAgregarProductoTipoPadre1.Size = new System.Drawing.Size(36, 36);
            this.tSMIAgregarProductoTipoPadre1.Text = "Nuevo producto tipo padre";
            this.tSMIAgregarProductoTipoPadre1.Click += new System.EventHandler(this.tSMIAgregarProductoTipoPadre_Click);
            // 
            // tSMIAgregarProductoTipo1
            // 
            this.tSMIAgregarProductoTipo1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSMIAgregarProductoTipo1.Enabled = false;
            this.tSMIAgregarProductoTipo1.Image = ((System.Drawing.Image)(resources.GetObject("tSMIAgregarProductoTipo1.Image")));
            this.tSMIAgregarProductoTipo1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSMIAgregarProductoTipo1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSMIAgregarProductoTipo1.Name = "tSMIAgregarProductoTipo1";
            this.tSMIAgregarProductoTipo1.Size = new System.Drawing.Size(36, 36);
            this.tSMIAgregarProductoTipo1.Text = "Nuevo producto tipo";
            this.tSMIAgregarProductoTipo1.Click += new System.EventHandler(this.tSMIAgregarProductoTipo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tSMIEditarElementoSeleccionado1
            // 
            this.tSMIEditarElementoSeleccionado1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSMIEditarElementoSeleccionado1.Enabled = false;
            this.tSMIEditarElementoSeleccionado1.Image = ((System.Drawing.Image)(resources.GetObject("tSMIEditarElementoSeleccionado1.Image")));
            this.tSMIEditarElementoSeleccionado1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSMIEditarElementoSeleccionado1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSMIEditarElementoSeleccionado1.Name = "tSMIEditarElementoSeleccionado1";
            this.tSMIEditarElementoSeleccionado1.Size = new System.Drawing.Size(36, 36);
            this.tSMIEditarElementoSeleccionado1.Text = "Editar elemento seleccionado";
            this.tSMIEditarElementoSeleccionado1.Click += new System.EventHandler(this.tSMIEditarElementoActual_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tSMIEliminarElementoSeleccionado1
            // 
            this.tSMIEliminarElementoSeleccionado1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSMIEliminarElementoSeleccionado1.Image = ((System.Drawing.Image)(resources.GetObject("tSMIEliminarElementoSeleccionado1.Image")));
            this.tSMIEliminarElementoSeleccionado1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSMIEliminarElementoSeleccionado1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSMIEliminarElementoSeleccionado1.Name = "tSMIEliminarElementoSeleccionado1";
            this.tSMIEliminarElementoSeleccionado1.Size = new System.Drawing.Size(36, 36);
            this.tSMIEliminarElementoSeleccionado1.Text = "Eliminar elemento seleccionado";
            this.tSMIEliminarElementoSeleccionado1.Click += new System.EventHandler(this.tSMIEliminarElementoActual_Click);
            // 
            // tSBCerrar
            // 
            this.tSBCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBCerrar.Image = ((System.Drawing.Image)(resources.GetObject("tSBCerrar.Image")));
            this.tSBCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSBCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBCerrar.Name = "tSBCerrar";
            this.tSBCerrar.Size = new System.Drawing.Size(36, 36);
            this.tSBCerrar.Text = "toolStripButton1";
            this.tSBCerrar.Click += new System.EventHandler(this.bCerrar_Click);
            // 
            // iLProductosTiposSeleccionados
            // 
            this.iLProductosTiposSeleccionados.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iLProductosTiposSeleccionados.ImageStream")));
            this.iLProductosTiposSeleccionados.TransparentColor = System.Drawing.Color.Transparent;
            this.iLProductosTiposSeleccionados.Images.SetKeyName(0, "ProductoTipoGrupo.ico");
            this.iLProductosTiposSeleccionados.Images.SetKeyName(1, "ProductoTipoPadre.ico");
            this.iLProductosTiposSeleccionados.Images.SetKeyName(2, "ProductoTipo.ico");
            // 
            // FProductosTipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 482);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FProductosTipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipos productos";
            this.Load += new System.EventHandler(this.FProductosTipos_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.cMSProductosTipos.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tVProductostipos;
        private System.Windows.Forms.TextBox tBNivel;
        private System.Windows.Forms.TextBox tBNombreCortoTipoProducto;
        private System.Windows.Forms.TextBox tBNombreTipoProducto;
        private System.Windows.Forms.TextBox tBCodigoTipoProducto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip cMSProductosTipos;
        private System.Windows.Forms.ToolStripMenuItem tSMIAgregarProductoTipoPadre;
        private System.Windows.Forms.ToolStripMenuItem tSMIAgregarProductoTipo;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.TextBox tBDescripcionTipoProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCerrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tSMIEditarElementoActual;
        private System.Windows.Forms.ToolStripMenuItem tSMIEliminarElementoActual;
        private System.Windows.Forms.ImageList iLProductosTipos32x32;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSMIAgregarProductoTipoPadre1;
        private System.Windows.Forms.ToolStripButton tSMIAgregarProductoTipo1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tSMIEditarElementoSeleccionado1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tSMIEliminarElementoSeleccionado1;
        private System.Windows.Forms.ToolStripButton tSBCerrar;
        private System.Windows.Forms.ImageList iLProductosTiposSeleccionados;
    }
}