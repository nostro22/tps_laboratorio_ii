using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP3ClassLibrary;
using IO;




namespace TP3Prototipo
{
    public partial class EstoNoEsCompraGamer : Form
    {

        private List<Producto> listaCarrito;

        #region Archivos

        private string ultimoArchivo;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private puntoJson<List<Producto>> puntoJsonProductos;        
        private PuntoXml<List<Producto>> puntoXmlProductos;        
        private PuntoXml<List<Persona>> puntoXmlPersonas;
        private PuntoXml<List<Factura>> puntoXmlFacturas;        
        private FrmClienteAlta AltaCliente;

        //Databases       
        private string defaultDataProductos = $"{AppDomain.CurrentDomain.BaseDirectory}//DefaultProductosData.json";
        private string actualDataProductos = $"{AppDomain.CurrentDomain.BaseDirectory}//DefaultProductosData.json";
        private string actualDataPersonas = $"{AppDomain.CurrentDomain.BaseDirectory}//DefaultPersonasData.xml";
        private string defaultDataPersonas = $"{AppDomain.CurrentDomain.BaseDirectory}//DefaultPersonasData.xml";
        private string defaultDataFacturas = $"{AppDomain.CurrentDomain.BaseDirectory}//DefaultFacturasData.xml";
       
        private void initDatabases()
        {
           openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
           actualDataProductos = defaultDataProductos;         
           actualDataPersonas =  defaultDataPersonas;
       
            try
            {
                switch (Path.GetExtension(actualDataProductos))
                {
                    case ".json":
                        listaProductos = new(puntoJsonProductos.Leer(defaultDataProductos));
                        
                        break;
                 
                    case ".xml":
                        listaProductos = new(puntoXmlProductos.Leer(defaultDataPersonas));
                        break;

                    default:
                        MessageBox.Show("Los datos productos solo pueden ser cargados como .xml o .json", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                listaPersonas = new(puntoXmlPersonas.Leer(actualDataPersonas));
                listaFacturas = new(puntoXmlFacturas.Leer(defaultDataFacturas));

            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void SaveFacturas()
        {
            puntoXmlFacturas.GuardarComo(defaultDataFacturas, listaFacturas);
        }

        private string UltimoArchivo
        {
            get
            {
                return ultimoArchivo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    ultimoArchivo = value;
                }
            }
        }

     
        public void ArchiveSetUp()
        {
            puntoJsonProductos = new puntoJson<List<Producto>>();
            puntoXmlProductos = new PuntoXml<List<Producto>>();          
            puntoXmlPersonas = new PuntoXml<List<Persona>>();
            puntoXmlFacturas = new PuntoXml<List<Factura>>();         

            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            openFileDialog.Filter = "Archivo de texto|*.txt|Archivo JSON|*.json|Archivo XML|*.xml";
            saveFileDialog.Filter = "Archivo de texto|*.txt|Archivo JSON|*.json|Archivo XML|*.xml";
        }

      

         private void GuardarComoPersona()
        {
           
            saveFileDialog.Filter = "Archivo XML|*.xml";
            saveFileDialog.DefaultExt =".xml";
           
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                UltimoArchivo = saveFileDialog.FileName;
         
                try
                {
                    if (Path.GetExtension(UltimoArchivo) == ".xml")
                    {
                        puntoXmlPersonas.GuardarComo(UltimoArchivo, listaPersonas);
                        puntoXmlPersonas.GuardarComo(defaultDataPersonas, listaPersonas);
                    }
                    else
                    {
                        MessageBox.Show("Los base de datos personas solo pueden ser guardados como .xml para no comprometer la integridad", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex);
                }
            
            }
        }

        private void GuardarComoProducto()
        {
            saveFileDialog.Filter = "Archivo XML|*.xml|Archivo JSON|*.json";
            saveFileDialog.DefaultExt = ".json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                UltimoArchivo = saveFileDialog.FileName;

                try
                {

                    switch (Path.GetExtension(UltimoArchivo))
                    {
                        case ".json":
                            puntoJsonProductos.GuardarComo(UltimoArchivo, listaProductos);
                            puntoJsonProductos.GuardarComo(defaultDataPersonas, listaProductos);
                            break;

                        case ".xml":
                            puntoXmlProductos.GuardarComo(UltimoArchivo, listaProductos);
                            puntoJsonProductos.GuardarComo(defaultDataPersonas, listaProductos);
                            break;
                        default:
                            throw new Exception("La base de datos debe ser guardada en .xml o .json para conservar la integridad de la misma");
                            break;
                    }

                }
                catch (Exception ex)
                {

                    MostrarMensajeError(ex);
                }
            }
            
           
        }

        private void GuardarDatosActualPersonas()
        {

            try
            {
                puntoXmlPersonas.GuardarComo(actualDataPersonas, listaPersonas);
            }

            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void GuardarDatosActualProductos()
        {
            try
            {
                switch (Path.GetExtension(actualDataProductos))
                {
                    case ".json":
                        puntoJsonProductos.GuardarComo(actualDataProductos, listaProductos);
                        break;
                    case ".xml":
                        puntoXmlProductos.GuardarComo(actualDataProductos, listaProductos);                 
                        break;
                }
                        
            }

            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        #region LoadDataFunctions

        private void LoadProductos()
        {
                openFileDialog.Filter = "Archivo XML|*.xml|Archivo JSON|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UltimoArchivo = openFileDialog.FileName;

                try
                {
                    switch (Path.GetExtension(UltimoArchivo))
                    {
                        case ".json":
                            listaProductos = new(puntoJsonProductos.Leer(ultimoArchivo));
                            GuardarDatosActualProductos();
                            break;
                        case ".xml":
                            listaProductos = new(puntoXmlProductos.Leer(ultimoArchivo));
                            GuardarDatosActualProductos();
                            break;
                        default:
                            MessageBox.Show("Los datos productos solo pueden ser cargados como .xml o .json", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex);
                }
            }
        }


        private void LoadPersonas()
        {

            openFileDialog.Filter = "Archivo XML|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UltimoArchivo = openFileDialog.FileName;
                try
                {
                    switch (Path.GetExtension(UltimoArchivo))
                    {
                        case ".xml":
                            listaPersonas = new(puntoXmlPersonas.Leer(ultimoArchivo));
                            GuardarDatosActualPersonas();
                            break;
                        default:
                            MessageBox.Show("Los datos productos solo pueden ser cargados como .xml", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex);
                }
            }
        }

        private void LoadFacturas()
        {
            try
            {
                listaFacturas = new(puntoXmlFacturas.Leer(defaultDataFacturas));
            }
            catch 
            {
                MessageBox.Show("Fallo en carga Facturas base Datos Facturas");
            }
        }

        #endregion

        private void MostrarMensajeError(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Error: {ex.Message}");
            sb.AppendLine(ex.StackTrace);

            MessageBox.Show(sb.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
        public EstoNoEsCompraGamer()
        {
            InitializeComponent();               
        }
        
        private string resorcesPath =Path.Combine(Directory.GetCurrentDirectory(),"");


        #region Productos
        private List<Persona> listaPersonas;
        private List<Producto> listaProductos;
        private List<Factura> listaFacturas;
        private List<Label> listaLabelsPrecio;
        private List<Label> listaLabelsRareza;
        private List<Label> listaLabelsCantidad;
        private List<GroupBox> listaGroupBoxProductos;
        private void SetOneProducto(Producto unProducto, int posicion)
        {
            if (posicion < 6 && posicion > -1 &&  unProducto!=null)
            {
            
            unProducto = listaProductos[posicion];
            listaGroupBoxProductos[posicion].Text = unProducto.Nombre;
            listaLabelsRareza[posicion].Text = unProducto.Rareza.ToString();
            listaLabelsPrecio[posicion].Text = "$" + unProducto.Price.ToString();
            listaLabelsCantidad[posicion].Text = "Cant: " + unProducto.Cantidad.ToString();
            }

        }
       
        private void ActualizarListadoProductos()
        {
            int index = 0;
            foreach (Producto item in listaProductos)
            {
                if (!(item is null))
                {
                    SetOneProducto(item, index);
                }
                index++;
            }
        }

        #endregion
        private void LabelsProductosSetUp()
        {
            listaLabelsPrecio = new List<Label>();
            listaLabelsRareza = new List<Label>();
            listaLabelsCantidad = new List<Label>();
            listaGroupBoxProductos = new List<GroupBox>();

            listaLabelsCantidad.Add(lblCantidad);
            listaLabelsCantidad.Add(lblCantidad2);
            listaLabelsCantidad.Add(lblCantidad3);
            listaLabelsCantidad.Add(lblCantidad4);
            listaLabelsCantidad.Add(lblCantidad5);
            listaLabelsCantidad.Add(lblCantidad6);

            listaLabelsPrecio.Add(lblPrice);
            listaLabelsPrecio.Add(lblPrice2);
            listaLabelsPrecio.Add(lblPrice3);
            listaLabelsPrecio.Add(lblPrice4);
            listaLabelsPrecio.Add(lblPrice5);
            listaLabelsPrecio.Add(lblPrice6);

            listaLabelsRareza.Add(lblRareza);
            listaLabelsRareza.Add(lblRareza2);
            listaLabelsRareza.Add(lblRareza3);
            listaLabelsRareza.Add(lblRareza4);
            listaLabelsRareza.Add(lblRareza5);
            listaLabelsRareza.Add(lblRareza6);

            listaGroupBoxProductos.Add(grbProducto);
            listaGroupBoxProductos.Add(grbProducto2);
            listaGroupBoxProductos.Add(grbProducto3);
            listaGroupBoxProductos.Add(grbProducto4);
            listaGroupBoxProductos.Add(grbProducto5);
            listaGroupBoxProductos.Add(grbProducto6);         


        }






        private void ActualizarCtbSeller()
        {
            Console.WriteLine(listaPersonas.ToString());
            List<string> listaClientesActivos = Persona.GetNamesDni(Persona.ListaActivos(listaPersonas));
            cmbClientes.DataSource = listaClientesActivos;
           
        }

        private void FeedBackCar()
        {
            int cantidadCarrito = Carrito.CantidadProductoCarrito;
            lblCar.Text = cantidadCarrito.ToString();
            if (cantidadCarrito == 0)
            {
                lblCar.ForeColor = Color.Red;
            }
            else
            {
                lblCar.ForeColor = Color.Cyan;
            }
        }



        private void EstoNoEsCompraGamer_Load(object sender, EventArgs e)
        {
            listaPersonas = new List<Persona>();
            listaProductos = new List<Producto>();
            listaFacturas = new List<Factura>();
            listaCarrito = Carrito.ListaCarrito;
            LabelsProductosSetUp();    
            FeedBackCar();
            ArchiveSetUp();
            LoadFacturas();
            initDatabases();
            ActualizarCtbSeller();            
            ActualizarListadoProductos();        
        }
      


     
        private void btnClearCar_Click(object sender, EventArgs e)
        {
            Carrito.VaciaCarrito(listaProductos);
            FeedBackCar();
            ActualizarListadoProductos();

        }

        private void btnFacturacion(object sender, EventArgs e)
        {
            if (Carrito.CantidadProductoCarrito == 0)
            {
                FrmNotificacion advertencia = new FrmNotificacion("Carrito Vacio", 4);
                advertencia.StartPosition = FormStartPosition.CenterScreen;
                advertencia.Show();
            }
            else
            {

                FrmFacturacion facturacion = new FrmFacturacion(listaFacturas, listaPersonas, listaCarrito, listaProductos, cmbClientes.Text);                
                facturacion.ShowDialog();
                SaveFacturas();
                GuardarDatosActualProductos();
                ActualizarListadoProductos();
                FeedBackCar();

            }

            ////Facturacion
            ///

        }

        private void btnDownloadPersonas_Click(object sender, EventArgs e)
        {
            GuardarComoPersona();
        }

        private void btnDownloadProductos_Click(object sender, EventArgs e)
        {
            GuardarComoProducto();
        }

        private void btnUploadProductos_Click(object sender, EventArgs e)
        {
            LoadProductos();
            ActualizarListadoProductos();
        }

        private void btnUploadPersonas_Click(object sender, EventArgs e)
        {
            LoadPersonas();
            
        }

        #region EvetosBotonesProductos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[0],1);            
            ActualizarListadoProductos();
            FeedBackCar();
            
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[1], 1);            
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void btnAgregar3_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[2], 1);           
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void btnAgregar4_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[3], 1);         
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void btnAgregar5_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[4], 1);           
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void btnAgregar6_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[5], 1);         
            FeedBackCar();
            ActualizarListadoProductos();
        }
        private void btnDevolver(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[0], 1);     
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void btnDevolver2(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[1], 1);        
            FeedBackCar();
            ActualizarListadoProductos();
        }
       
        private void btnDevolver3(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[2], 1);
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void btnDevolver4(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[3], 1);
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void btnDevolver5(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[4], 1);
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void btnDevolver6(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[5], 1);
            FeedBackCar();
            ActualizarListadoProductos();
        }

        #endregion
        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            AltaCliente = new FrmClienteAlta( listaPersonas);
            AltaCliente.ShowDialog();
            ActualizarCtbSeller();
            GuardarDatosActualPersonas();

        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            FrmSolicitudDni frmModificacion = new FrmSolicitudDni(listaPersonas,eAccion.MODIFICAR);
            frmModificacion.ShowDialog();
            ActualizarCtbSeller();
            GuardarDatosActualPersonas();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            FrmSolicitudDni frmBaja = new FrmSolicitudDni(listaPersonas, eAccion.BAJA);
            frmBaja.ShowDialog();
            ActualizarCtbSeller();
            GuardarDatosActualPersonas();
        }

        private void btnInformsSales_Click(object sender, EventArgs e)
        {
            FrmImformes frmImformes = new FrmImformes(listaFacturas,listaPersonas);
            frmImformes.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string message = "Seguro que desea salir";
            string title = "Confirme";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
           
            
        }
    }
}
