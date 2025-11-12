using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindFormsApp
{
    public partial class frmAltaArticulo : Form
    {
        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo article = new Articulo();
            ArticuloNegocio negocio= new ArticuloNegocio();

            try
            {
                article.Codigo = txtCodigo.Text;
                article.Nombre = txtNombre.Text;
                article.Descripcion = txtDescripcion.Text;
                article.marca = (Marca)cbxMarca.SelectedItem;
                article.categoria = (Categoria)cbxCategoria.SelectedItem;
                article.ImagenUrl= txtImagenUrl.Text;
                article.Precio =float.Parse(txtPrecio.Text);

                negocio.agregar(article);
                MessageBox.Show("Agregado exitosamente");
                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio=new MarcaNegocio();
            CategoriaNegocio categoriaNegocio= new CategoriaNegocio();

            try
            {
                cbxMarca.DataSource = marcaNegocio.listar();
                cbxCategoria.DataSource = categoriaNegocio.listar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagenUrl.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
                
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");

            }
        }

        
    }
}
