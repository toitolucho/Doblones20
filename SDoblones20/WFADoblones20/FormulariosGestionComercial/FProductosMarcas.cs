﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FProductosMarcas : Form
    {
        private ProductosMarcasCLN ProductosMarcas = new ProductosMarcasCLN();
        private string TipoOperacion = "";
        private DataTable DTAuxiliar = new DataTable();

        public FProductosMarcas()
        {
            InitializeComponent();
        }

        private void FProductosMarcas_Load(object sender, EventArgs e)
        {
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            
            InhabilitarControles(true);

            DTAuxiliar = ProductosMarcas.ListarProductosMarcas();
            bSOrigen.DataSource = DTAuxiliar;
            
            //dGVGrilla.DataSource = DTAuxiliar;
            dGVGrilla.AutoGenerateColumns = false;
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InhabilitarControles(bool Estado)
        {
            //tBCodigo.ReadOnly = Estado;
            tBNombre.ReadOnly = Estado;
        }

        private void InicializarControles()
        {
            tBCodigo.Text = "";
            tBNombre.Text = "";
        }
  
        private void bNuevo_Click(object sender, EventArgs e)
        {
            TipoOperacion = "I";

            InhabilitarControles(false);
            InicializarControles();
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;

            tBNombre.Focus();
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
                TipoOperacion = "E";
                InhabilitarControles(false);
                bNuevo.Enabled = false;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = true;
                bCancelar.Enabled = true;
            
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = "Esta seguro que desea eliminar el registro actual, recuerde que una vez aceptada la operacion es irreversible.";
            string Titulo = "Confimarción eliminación registro";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {
                if (tBCodigo.Text == "")
                {
                    MessageBox.Show("No se ha seleccionado ninguna elemento para eliminarlo");

                }
                else
                {
                    ProductosMarcas.EliminarProductoMarca(int.Parse(tBCodigo.Text));
                    DTAuxiliar = ProductosMarcas.ListarProductosMarcas();
                    bSOrigen.DataSource = DTAuxiliar;
                }
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = true;
                bEliminar.Enabled = true;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
            {
                ProductosMarcas.InsertarProductoMarca(tBNombre.Text);
                
            }

            if (TipoOperacion == "E")
            {
                
               if (tBCodigo.Text == "")
                {
                    MessageBox.Show("No se ha seleccionado ningún elemento para editarlo");

                }
                else
                {
                    ProductosMarcas.ActualizarProductoMarca(int.Parse(tBCodigo.Text), tBNombre.Text);
                }
            }
            DTAuxiliar = ProductosMarcas.ListarProductosMarcas();
            bSOrigen.DataSource = DTAuxiliar;
            InhabilitarControles(true);
            InicializarControles();
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
                InicializarControles();
            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        private void dGVGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = 0;
            fila = dGVGrilla.CurrentCell.RowIndex;
            if (fila >= 0)
            {
                tBCodigo.Text = DTAuxiliar.Rows[fila][0].ToString();
                tBNombre.Text = DTAuxiliar.Rows[fila][1].ToString();
                /*FMonedasCotizacionesIA fmonedascotizacionesia = new FMonedasCotizacionesIA("E", byte.Parse(RBMonedasCotizaciones.Rows[fila][0].ToString()), byte.Parse(RBMonedasCotizaciones.Rows[fila][2].ToString()), DateTime.Parse(RBMonedasCotizaciones.Rows[fila][1].ToString()), decimal.Parse(RBMonedasCotizaciones.Rows[fila][4].ToString()), decimal.Parse(RBMonedasCotizaciones.Rows[fila][5].ToString()));
                fmonedascotizacionesia.ShowDialog();*/
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna elemento para editarlo");
            }
        }

    }
}
