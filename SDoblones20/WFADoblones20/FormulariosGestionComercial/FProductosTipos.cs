using System;
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
    public partial class FProductosTipos : Form
    {
        private ProductosTiposCLN ProductosTipos = new ProductosTiposCLN();
        private string TipoOperacion = "";
        private DataTable DTAuxiliar = new DataTable();
        private int CodigoTipoProductoseleccionado = 0;

        public int CodigoTipoProductoSeleccionado
        {
            get
            {
                return CodigoTipoProductoseleccionado;
            }
            set
            {
                CodigoTipoProductoseleccionado = value;
            }
        }

        public FProductosTipos()
        {
            InitializeComponent();
        }

        private void InhabilitarControles(bool Estado)
        {
            tBNombreTipoProducto.ReadOnly = Estado;
            tBNombreCortoTipoProducto.ReadOnly = Estado;
            tBDescripcionTipoProducto.ReadOnly = Estado;
            //tBNivel.ReadOnly = Estado;
        }

        private void InicializarControles()
        {
            tBNombreTipoProducto.Text = "";
            tBNombreCortoTipoProducto.Text = "";
            tBDescripcionTipoProducto.Text = "";
            tBNivel.Text = "";
        }


        private void FProductosTipos_Load(object sender, EventArgs e)
        {
            tVProductostipos.Nodes.Clear();
            CargarNodosHijos((TreeNode)null, null);
            
            InicializarControles();
            InhabilitarControles(true);

            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        void CargarNodosHijos(TreeNode NodoPadre, int? CodigoTipoProductoPadre)
        {
            DataTable DTTiposProductos = new DataTable();
            DTTiposProductos = ProductosTipos.ListarProductosTiposProductoTipoPadre(CodigoTipoProductoPadre);
            foreach(DataRow FilaTipoProducto in DTTiposProductos.Rows)
            {
                int? CotigoTipoProductoPadreAux = null;
                if (FilaTipoProducto["CodigoTipoProductoPadre"].ToString() != "")
                    CotigoTipoProductoPadreAux = int.Parse(FilaTipoProducto["CodigoTipoProductoPadre"].ToString());

                ProductoTipo pt = new ProductoTipo(
                int.Parse(FilaTipoProducto["CodigoTipoProducto"].ToString()),
                CotigoTipoProductoPadreAux,
                FilaTipoProducto["NombreTipoProducto"].ToString(),
                FilaTipoProducto["NombreCortoTipoProducto"].ToString(),
                FilaTipoProducto["DescripcionTipoProducto"].ToString(),
                byte.Parse(FilaTipoProducto["Nivel"].ToString()));

                if(NodoPadre == null)
                {
                    TreeNode NodoNuevo = tVProductostipos.Nodes.Add(FilaTipoProducto["NombreTipoProducto"].ToString());
                    NodoNuevo.Tag = pt;
                    NodoNuevo.ImageIndex = 2;
                    NodoNuevo.SelectedImageIndex = 2;
                    CargarNodosHijos(NodoNuevo, int.Parse(FilaTipoProducto["CodigoTipoProducto"].ToString()));
                }
                else
                {
                    TreeNode NodoNuevo = NodoPadre.Nodes.Add(FilaTipoProducto["NombreTipoProducto"].ToString());
                    NodoNuevo.Tag = pt;
                    if (NodoPadre.Level > 0)
                    {
                        NodoPadre.ImageIndex = 1;
                        NodoPadre.SelectedImageIndex = 1;
                    }
                    else
                    {
                        NodoPadre.ImageIndex = 0;
                        NodoPadre.SelectedImageIndex = 0;
                    }

                        NodoNuevo.ImageIndex = 2;
                        NodoNuevo.SelectedImageIndex = 2;

                    CargarNodosHijos(NodoNuevo, int.Parse(FilaTipoProducto["CodigoTipoProducto"].ToString()));
                }
                
            }
		}

        void EliminarNodosHijos(TreeNode NodoPadre)
        {
            if (NodoPadre.Nodes.Count > 0)
            {
                foreach (TreeNode NodoActual in NodoPadre.Nodes)
                {
                    EliminarNodosHijos(NodoActual);
                }
            }
            
            ProductosTipos.EliminarProductoTipo(((ProductoTipo)NodoPadre.Tag).Codigo);
            NodoPadre.Remove();
        }	


        private void CargarInformacionNodo(TreeNode NodoSeleccionado)
        {
            DataTable DTAux = new DataTable();
            int CodiTipoProd = 0;
            int? CodiTipoProdPadr = 0;
            string NombTipoProd = "";
            string NombCortTipoProd = "";
            string DescTipoProd = "";
            byte Nive;

            
            if (NodoSeleccionado != null)
            {
                CodiTipoProd = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).Codigo;
                CodiTipoProdPadr = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).CodigoPadre;
                NombTipoProd = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).Nombre;
                NombCortTipoProd = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).NombreCorto;
                DescTipoProd = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).Descripcion;
                Nive = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).Niv;
                tBCodigoTipoProducto.Text = CodiTipoProd.ToString();
                tBNombreTipoProducto.Text = NombTipoProd;
                tBNombreCortoTipoProducto.Text = NombCortTipoProd;
                tBDescripcionTipoProducto.Text = DescTipoProd;
                tBNivel.Text = Nive.ToString();
            }
            else
            {
                InicializarControles();
            }
        }


        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void tVProductostipos_MouseDown(object sender, MouseEventArgs e)
        {
            tSMIAgregarProductoTipo.Enabled = false;
            tSMIEditarElementoActual.Enabled = false;
            tSMIEliminarElementoActual.Enabled = false;
            
            tSMIAgregarProductoTipo1.Enabled = false;
            tSMIEditarElementoSeleccionado1.Enabled = false;
            tSMIEliminarElementoSeleccionado1.Enabled = false;
            
            TreeNode NodoActual = tVProductostipos.GetNodeAt(new Point(e.X, e.Y));
            if (NodoActual != null)
            {
                tVProductostipos.SelectedNode = NodoActual;

                CodigoTipoProductoseleccionado = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).Codigo;
                if (e.Button == MouseButtons.Right)
                {
                    tSMIAgregarProductoTipo.Enabled = true;
                    tSMIEditarElementoActual.Enabled = true;
                    tSMIEliminarElementoActual.Enabled = true;
                }
                if (e.Button == MouseButtons.Left)
                {
                   CargarInformacionNodo(tVProductostipos.GetNodeAt(new Point(e.X, e.Y)));

                   
                }
                tSMIAgregarProductoTipo1.Enabled = true;
                tSMIEditarElementoSeleccionado1.Enabled = true;
                tSMIEliminarElementoSeleccionado1.Enabled = true;
                 
            }
        }

        private void tSMIAgregarProductoTipo_Click(object sender, EventArgs e)
        {
            InicializarControles();
            InhabilitarControles(false);

            int NivelNodoNuevo = tVProductostipos.SelectedNode.Level + 1;
            tBNivel.Text = NivelNodoNuevo.ToString();

            TipoOperacion = "IH";

            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
            tBNombreTipoProducto.Focus();
        }

        private void tSMIAgregarProductoTipoPadre_Click(object sender, EventArgs e)
        {
            InicializarControles();
            InhabilitarControles(false);
            tBNivel.Text = "0";

            TipoOperacion = "IP";

            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
            tBNombreTipoProducto.Focus();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "IP")
            {
                ProductosTipos.InsertarProductoTipo(null, tBNombreTipoProducto.Text, tBNombreCortoTipoProducto.Text, tBDescripcionTipoProducto.Text, 0);
                DataTable DTAuxiliarPT = new DataTable();
                DTAuxiliarPT = ProductosTipos.ObtenerProductoTipoNombre(tBNombreTipoProducto.Text);
                ProductoTipo PTP = new ProductoTipo(int.Parse(DTAuxiliarPT.Rows[0][0].ToString()), null, DTAuxiliarPT.Rows[0][2].ToString(), DTAuxiliarPT.Rows[0][3].ToString(), DTAuxiliarPT.Rows[0][4].ToString(), byte.Parse(DTAuxiliarPT.Rows[0][5].ToString()));
                TreeNode NodoProductoTipoPadre = new TreeNode(tBNombreTipoProducto.Text);
                NodoProductoTipoPadre.Tag = PTP;
                NodoProductoTipoPadre.ImageIndex = 2;
                NodoProductoTipoPadre.SelectedImageIndex = 2;
                tVProductostipos.Nodes.Add(NodoProductoTipoPadre);
                tVProductostipos.SelectedNode.Expand();
            }

            if (TipoOperacion == "IH")
            {
                ProductosTipos.InsertarProductoTipo(((ProductoTipo)tVProductostipos.SelectedNode.Tag).Codigo, tBNombreTipoProducto.Text, tBNombreCortoTipoProducto.Text, tBDescripcionTipoProducto.Text, byte.Parse(tBNivel.Text));
                DataTable DTAuxiliarPT = new DataTable();
                DTAuxiliarPT = ProductosTipos.ObtenerProductoTipoNombre(tBNombreTipoProducto.Text);
                ProductoTipo PTP = new ProductoTipo(int.Parse(DTAuxiliarPT.Rows[0][0].ToString()), int.Parse(DTAuxiliarPT.Rows[0][1].ToString()), DTAuxiliarPT.Rows[0][2].ToString(), DTAuxiliarPT.Rows[0][3].ToString(), DTAuxiliarPT.Rows[0][4].ToString(), byte.Parse(DTAuxiliarPT.Rows[0][5].ToString()));

                TreeNode NodoProductoTipo = new TreeNode(tBNombreTipoProducto.Text);
                NodoProductoTipo.Tag = PTP;
                NodoProductoTipo.ImageIndex = 2;
                NodoProductoTipo.SelectedImageIndex = 2;
                if (tVProductostipos.SelectedNode.Level > 0)
                {
                    tVProductostipos.SelectedNode.ImageIndex = 1;
                    tVProductostipos.SelectedNode.SelectedImageIndex = 1;
                }
                else
                {
                    tVProductostipos.SelectedNode.ImageIndex = 0;
                    tVProductostipos.SelectedNode.SelectedImageIndex = 0;
                }

                tVProductostipos.SelectedNode.Nodes.Add(NodoProductoTipo);
                tVProductostipos.SelectedNode.Expand();
            }

            if (TipoOperacion == "E")
            {
                ProductosTipos.ActualizarProductoTipo(((ProductoTipo)tVProductostipos.SelectedNode.Tag).Codigo, ((ProductoTipo)tVProductostipos.SelectedNode.Tag).CodigoPadre, tBNombreTipoProducto.Text, tBNombreCortoTipoProducto.Text, tBDescripcionTipoProducto.Text, ((ProductoTipo)tVProductostipos.SelectedNode.Tag).Niv);
                DataTable DTAuxiliarPT = new DataTable();
                
                DTAuxiliarPT = ProductosTipos.ObtenerProductoTipoNombre(tBNombreTipoProducto.Text);
                int? CotigoTipoProductoPadreAux = null;
                if (DTAuxiliarPT.Rows[0]["CodigoTipoProductoPadre"].ToString() != "")
                    CotigoTipoProductoPadreAux = int.Parse(DTAuxiliarPT.Rows[0]["CodigoTipoProductoPadre"].ToString());

                ProductoTipo PTP = new ProductoTipo(int.Parse(DTAuxiliarPT.Rows[0][0].ToString()), CotigoTipoProductoPadreAux, DTAuxiliarPT.Rows[0][2].ToString(), DTAuxiliarPT.Rows[0][3].ToString(), DTAuxiliarPT.Rows[0][4].ToString(), byte.Parse(DTAuxiliarPT.Rows[0][5].ToString()));

                tVProductostipos.SelectedNode.Text = tBNombreTipoProducto.Text;
                TreeNode NodoProductoTipo = tVProductostipos.SelectedNode;
                NodoProductoTipo.Tag = PTP;
            }

            InhabilitarControles(true);
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;

        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            InicializarControles();
            InhabilitarControles(true);
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        

        private void tBNombreCortoTipoProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void bCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tSMIEditarElementoActual_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            CargarInformacionNodo(tVProductostipos.SelectedNode);
            InhabilitarControles(false);

            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
            tBNombreTipoProducto.Focus();
        }

        private void tSMIEliminarElementoActual_Click(object sender, EventArgs e)
        {
            string Mensaje = "Esta seguro que desea eliminar el elemento actual, recuerde que una vez aceptada la operacion es irreversible. Ademas para poder eliminar satisfactoriamente este elemento, el mismo no debe estar siendo utilizado en ningun registro o en su caso alguno de sus elementos hijos.";
            string Titulo = "Confimarción eliminación elemento";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {
                try
                {
                    EliminarNodosHijos(tVProductostipos.SelectedNode);
                    InhabilitarControles(true);
                    InicializarControles();
                    bAceptar.Enabled = false;
                    bCancelar.Enabled = false;
                }
                catch
                {
                    Mensaje = "No se pudo eliminar el elemento seleccionado, debido a que el mismo o uno de sus hijos forma parte de alguna transacción.";
                    Titulo = "Información eliminación elemento";
                    Botones = MessageBoxButtons.OK;
                    Icono = MessageBoxIcon.Information;
                    MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                }
            }
        }
    }

    public class ProductoTipo
    {
        private int CodigoProductoTipo;
        private int? CodigoProductoTipoPadre;
        private string NombreProductoTipo;
        private string NombreCortoProducto;
        private string DescripcionProductoTipo;
        private byte Nivel;

        public ProductoTipo(int Codigo, int? CodigoPadre, string Nombre, string NombreCorto, string Descripcion, byte Niv)
        {
            this.CodigoProductoTipo = Codigo;
            this.CodigoProductoTipoPadre = CodigoPadre;
            this.NombreProductoTipo = Nombre;
            this.NombreCortoProducto = NombreCorto;
            this.DescripcionProductoTipo = Descripcion;
            this.Nivel = Niv;
        }

        public int Codigo
        {
            get
            {
                return CodigoProductoTipo;
            }
        }

        public int? CodigoPadre
        {
            get
            {
                return CodigoProductoTipoPadre;
            }
        }

        public string Nombre
        {

            get
            {
                return NombreProductoTipo;
            }
        }

        public string NombreCorto
        {

            get
            {
                return NombreCortoProducto;
            }
        }

        public string Descripcion
        {

            get
            {
                return DescripcionProductoTipo;
            }
        }

        public byte Niv
        {

            get
            {
                return Nivel;
            }
        }

        /*
        public override string ToString()
        {
            return this.Codigo.ToString() + " - " + this.Nombre;
        }*/
    }
}
