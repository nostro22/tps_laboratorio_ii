using IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TP3ClassLibrary;


namespace TP3Prototipo
{
    /// <summary>
    /// Esta es la FrmPrincipal funciona, aqui se realiza la logica del manejo de archivos y serializacion y sirve como hud principal
    /// </summary>
    public partial class EstoNoEsCompraGamer : Form
    {
  
        //Archivos
        private string ultimoArchivo;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private PuntoJson<List<Producto>> puntoJsonProductos;        
        private PuntoXml<List<Producto>> puntoXmlProductos;        
        private PuntoXml<List<Persona>> puntoXmlPersonas;
        private PuntoXml<List<Factura>> puntoXmlFacturas;        
        private FrmClienteAlta AltaCliente;
        
        //Listas
        private List<Producto> listaCarrito;
        private List<Persona> listaPersonas;
        private List<Producto> listaProductos;
        private List<Factura> listaFacturas;
        
        //Ayudas para navegacion y muestra de productos
        private List<Label> listaLabelsPrecio;
        private List<Label> listaLabelsRareza;
        private List<Label> listaLabelsCantidad;
        private List<GroupBox> listaGroupBoxProductos;

        /// <summary>
        /// Rutas a la base de datos default, es como una especie de salvavida que se va actualizando sola, si le da a guardar como puede actualizar su archivo original de trabajo
        /// pero normalmente se trabajara en default si no se sube ninguna base, no hay verificacion al subir bases de datos propias en los atributos asi que pueden mostrar inconsistencias 
        /// </summary>
        
        private string actualDataPersonas = $"{AppDomain.CurrentDomain.BaseDirectory}//DefaultPersonasData.xml";
        private string defaultDataPersonas = $"{AppDomain.CurrentDomain.BaseDirectory}//DefaultPersonasData.xml";
        private string defaultDataFacturas = $"{AppDomain.CurrentDomain.BaseDirectory}//DefaultFacturasData.xml";
        public EstoNoEsCompraGamer()
        {
            InitializeComponent();               
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
            InitDatabases();
            CargarProductosBD();
            cmbLCliente.DataSource = listaPersonas;
            cmbLCliente.DisplayMember = "NombreCompleto";
        }


        #region Archivos


        /// <summary>
        /// Seteo inicial de la base de datos por default y carga de personas y productos
        /// </summary>
        private void InitDatabases()
        {
           openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;          
       
            try
            {                
                listaPersonas = new(puntoXmlPersonas.Leer(actualDataPersonas));
                listaFacturas = new(puntoXmlFacturas.Leer(defaultDataFacturas));
            }
            catch (ExcepcionArchivos ex)
            {
                MostrarMensajeError(ex, "Error en Iniciacion de Archivos");
            }
            try
            {
                 ProductoDAO.OnFalloConexionBaseDatos += BackUpData_EventHandler;
                 listaProductos = ProductoDAO.Leer();                  
            }
            catch (ExcepcionArchivos ex)
            {
                MostrarMensajeError(ex, "Error se necesita estar conectado al servidor principal para operar se cerrara la aplicacion");
                Close();

            }
        }

        /// <summary>
        /// Guarda los cambios luego de facturar en el archivo de facturas que solo puede ser el default como para simular el control de la sede
        /// </summary>
        private void SaveFacturas()
        {
            puntoXmlFacturas.GuardarComo(defaultDataFacturas, listaFacturas);
        }

        /// <summary>
        /// Usado para que al momento de cargar una base de datos se use ese archivo al momento del guardado automatico
        /// </summary>
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

     /// <summary>
     /// Inicializacion del sistema de serializacion de archivos
     /// </summary>
        public void ArchiveSetUp()
        {
            puntoJsonProductos = new PuntoJson<List<Producto>>();
            puntoXmlProductos = new PuntoXml<List<Producto>>();          
            puntoXmlPersonas = new PuntoXml<List<Persona>>();
            puntoXmlFacturas = new PuntoXml<List<Factura>>();         

            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            openFileDialog.Filter = "Archivo de texto|*.txt|Archivo JSON|*.json|Archivo XML|*.xml";
            saveFileDialog.Filter = "Archivo de texto|*.txt|Archivo JSON|*.json|Archivo XML|*.xml";
        }

      
        /// <summary>
        /// Guardado sin verificacion de preExistencia del archivo para Personas
        /// </summary>
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
                catch (ExcepcionArchivos ex)
                {
                    MostrarMensajeError(ex,"Error Guardado de archivos de personas");
                }
            
            }
        }

        /// <summary>
        /// Guardado sin verificacion de preExistencia del archivo para Producto
        /// </summary>
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
                catch (ExcepcionArchivos ex)
                {
                    MostrarMensajeError(ex,"Error Guardado de productos en el archivo");
                }
            }
            
           
        }

        /// <summary>
        /// Actualiza el archivo de guardado Personas
        /// </summary>
        private void GuardarDatosActualPersonas()
        {

            try
            {
                puntoXmlPersonas.GuardarComo(actualDataPersonas, listaPersonas);
            }

            catch (ExcepcionArchivos ex)
            {
                MostrarMensajeError(ex,"Error Guardado de seguridad datos Personas");
            }
        }

        /// <summary>
        /// Actualiza el archivo de guardado Productos
        /// </summary>
        private void GuardarDatosActualProductos()
        {
            try
            {
                ProductoDAO.ActualizarProductos(listaProductos);
            }
            catch (ExcepcionArchivos ex)
            {
                MostrarMensajeError(ex,"Error en guardado de seguridad de productos");
            }
        }

        #region LoadDataFunctions

        /// <summary>
        /// Cargado de productos desde la base de datos
        /// </summary>
        //private void LoadProductos()
        //{
           
        //        try
        //        {
        //            listaProductos = ProductoDAO.Leer();
        //        }
        //        catch (ExcepcionArchivos ex)
        //        {
        //            MostrarMensajeError(ex,"Error en carga de productos desde la base de datos ");
        //        }
            
        //}


        /// <summary>
        /// Cargado de Personas desde un archivo custom. Como  posee herencia puede ser de tipo .xml 
        /// </summary>
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
                            MessageBox.Show("Los datos personas solo pueden ser cargados como .xml", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                }
                catch (ExcepcionArchivos ex)
                {
                    MostrarMensajeError(ex,"Error en carga de personas desde el archivo");
                }
            }
        }

        /// <summary>
        /// Carga del archivo facturas 
        /// </summary>
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


        /// <summary>
        /// Excepcion basica para notificar de errores archivos
        /// </summary>
        /// <param name="ex"></param>
        private void MostrarMensajeError(ExcepcionArchivos ex , string mensaje)
        {
            MessageBox.Show(mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
                


        #region Productos
    
        /// <summary>
        /// Inicia el setup de un producto a uno de los 6 slots correspondiente para display del mismo
        /// </summary>
        /// <param name="unProducto"></param>
        /// <param name="posicion"></param>
        private void SetOneProducto(Producto unProducto, int posicion)
        {
            if (this.InvokeRequired)
            {
                Action d = new Action(()=>SetOneProducto(unProducto,posicion));               
                this.Invoke(d);
            }
            else
            {                
                if (posicion < listaProductos.Count && posicion > -1 &&  unProducto!=null)
                {
                    unProducto = listaProductos[posicion];
                    listaGroupBoxProductos[posicion].Text = unProducto.Nombre;
                    listaLabelsRareza[posicion].Text = unProducto.Rareza.ToString();
                    listaLabelsPrecio[posicion].Text = "$" + unProducto.Precio.ToString();
                    listaLabelsCantidad[posicion].Text = "Cant: " + unProducto.Cantidad.ToString();
                    listaGroupBoxProductos[posicion].Visible = true;
                }
            }

        }

        /// <summary>
        /// Recorre los slots disponibles de display y si hay espacios sobrantes los apaga
        /// </summary>
        /// 

        private void ActualizarListadoProductos()
        {

            int index = 0;
            int productoValido = 0;
            foreach (Producto item in listaProductos)
            {
                if (item.ProductoDisponible())
                {
                    SetOneProducto(item, index);
                    productoValido++;
                }
                else if(!item.ProductoDisponible())
                {
                    listaGroupBoxProductos[index].Visible = false;
                }
                    index++;
            }
           

        }
        /// <summary>
        /// Simula la carga inicial de los productos traidos desde la BD una vez completa
        /// </summary>
        private void CargarProductosBD()
        {
            FrmApertura frmLoading = new FrmApertura();
            frmLoading.Show();
            Action action = new Action (()=> frmLoading.Refresh());
            action.Invoke();

            int index = 0;
            int productoValido = 0;
            foreach (Producto item in listaProductos)
            {
                if (item.ProductoDisponible())
                {
                    Thread hiloActualizacion = new Thread(()=>SetOneProducto(item, index));                    
                    hiloActualizacion.Start();
                    Thread.Sleep(500);
                    productoValido++;
                }
                index++;
            }

            frmLoading.Close();
        }

        /// <summary>
        /// Seteo inicial de container para poder ser apagados si no hay productos que mostrar
        /// </summary>
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
        #endregion



        /// <summary>
        /// Cambia el color de los numero del carrito si esta vacio
        /// </summary>
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


        /// <summary>
        /// Vacia el carrito y devuelve el stock a los display de producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
     
        private void BtnClearCar_Click(object sender, EventArgs e)
        {
            Carrito.VaciaCarrito(listaProductos);
            FeedBackCar();
            ActualizarListadoProductos();
        }

        /// <summary>
        /// Invoca al FrmFacturacion y luego guarda los cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFacturacion(object sender, EventArgs e)
        {
            if (Carrito.CantidadProductoCarrito == 0)
            {
                FrmNotificacion advertencia = new FrmNotificacion("Carrito Vacio", 4);
                advertencia.StartPosition = FormStartPosition.CenterScreen;
                advertencia.Show();
            }
            else
            {

                FrmFacturacion facturacion = new FrmFacturacion(listaFacturas, listaPersonas, listaCarrito, cmbLCliente.SelectedIndex);
                DialogResult dialogResult = facturacion.ShowDialog();
              if(dialogResult == DialogResult.OK)
                {
                    SaveFacturas();
                    GuardarDatosActualProductos();                    
                    ActualizarListadoProductos();
                    listaCarrito.Clear();
                    FeedBackCar();     

                }
            }
          

        }

        /// <summary>
        /// Permite descargar la base de datos actual de persona en un archivo .xlm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDownloadPersonas_Click(object sender, EventArgs e)
        {
            GuardarComoPersona();
        }

        /// <summary>
        /// Permite descargar la base de datos actual de Productos en formato .json o .xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDownloadProductos_Click(object sender, EventArgs e)
        {
            GuardarComoProducto();
        }

      
        /// <summary>
        /// Llama a la carga de una base de datos externa para personas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUploadPersonas_Click(object sender, EventArgs e)
        {
            LoadPersonas();           
        }
        /// <summary>
        /// Eventos generico de sumar o restar productos al carrito dependiendo del boton que le des sumas un producto u otro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region EvetosBotonesProductos
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[0],1);            
            ActualizarListadoProductos();
            FeedBackCar();
            
        }

        private void BtnAgregar2_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[1], 1);            
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void BtnAgregar3_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[2], 1);           
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void BtnAgregar4_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[3], 1);         
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void BtnAgregar5_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[4], 1);           
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void BtnAgregar6_Click(object sender, EventArgs e)
        {
            Producto.VenderProducto(listaCarrito, listaProductos[5], 1);         
            FeedBackCar();
            ActualizarListadoProductos();
        }
        private void BtnDevolver(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[0], 1);     
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void BtnDevolver2(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[1], 1);        
            FeedBackCar();
            ActualizarListadoProductos();
        }
       
        private void BtnDevolver3(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[2], 1);
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void BtnDevolver4(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[3], 1);
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void BtnDevolver5(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[4], 1);
            FeedBackCar();
            ActualizarListadoProductos();
        }

        private void BtnDevolver6(object sender, EventArgs e)
        {
            Producto.DevolverProducto(listaProductos, listaProductos[5], 1);
            FeedBackCar();
            ActualizarListadoProductos();
        }

        #endregion

        /// <summary>
        /// Llama a la alta del cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            AltaCliente = new FrmClienteAlta( listaPersonas);
            AltaCliente.ShowDialog();
            GuardarDatosActualPersonas();

        }

        /// <summary>
        /// Llama a la modificacion del cliente se usa la misma frmModificacion para la baja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificacion_Click(object sender, EventArgs e)
        {
            FrmSolicitudDni frmModificacion = new FrmSolicitudDni(listaPersonas,eAccion.MODIFICAR);
            frmModificacion.ShowDialog();
            GuardarDatosActualPersonas();
        }

        /// <summary>
        /// Llama a la baja del cliente se usa la misma frmModificacion para la modificacion
        /// En la baja se realiza una baja logica activo = false o una baja y resubida si hay cambio de clase entre cliente y afiliado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBaja_Click(object sender, EventArgs e)
        {
            FrmSolicitudDni frmBaja = new FrmSolicitudDni(listaPersonas, eAccion.BAJA);
            frmBaja.ShowDialog();
            GuardarDatosActualPersonas();
        }

        /// <summary>
        /// Se llama a los informes donde se podra ver en detalle las factiras e imprimirlas 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInformsSales_Click(object sender, EventArgs e)
        {
            FrmImformes frmImformes = new FrmImformes(listaFacturas,listaPersonas);
            frmImformes.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Captura el evento cuando falla la carga de la base de datos por conexion
        /// </summary>
        private void BackUpData_EventHandler()
        {
            string message = "Error conecion. \n\n Se Desactivaran las opciones de venta pero podra usar las funciones locales";
            string title = "MODO LOCAL";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons);
            btnClearCar.Hide();
            grbCart.Hide();
            btnVentasCarrito.Hide();
            btnModificarProductos.Hide();
            btnDownloadProductos.Hide();
        }

        private void BtnModificarProductos_Click(object sender, EventArgs e)
        {
            if(listaProductos.Count>0)
            {
                Carrito.VaciaCarrito(listaProductos);
                FrmModificarProductos frmModificarProductos = new FrmModificarProductos(listaProductos);
                frmModificarProductos.ShowDialog();
                listaProductos = ProductoDAO.Leer();
                ActualizarListadoProductos();
            }
            else
            {
                MessageBox.Show("Asegurece de estar conectado al servidor", "Error Lista de productos Vacia", MessageBoxButtons.YesNo);
            }
        }
    }
}
