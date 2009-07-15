using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebSystem
{
	
	
	public partial class Modificaciones : System.Web.UI.Page
	{
		// Tomando configuracion de BD en web.config
		public string credentials = ConfigurationManager.AppSettings["ConnectionString"];
		
		// Instanciamos nuestro objeto MySqlConnection, para conectarnos a MySQL
		MySqlConnection conexion = new MySqlConnection();
		
		// OleDbConnection conexion= new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\\mibase.mdb");
		
		// Metodo que despliega datos en la carga de pagina
		public void Page_Load(Object sender, EventArgs e)
			{
				if(!IsPostBack)
					DespTabla();
			}
		
		// Metodo que despliega la tabla
		public void DespTabla()
			{
				// Se cargan los valores de	conexion al objeto conexion
				conexion.ConnectionString = credentials;
			
				// Se abre conexion con BD
				conexion.Open();
			
				// Se instancia un DataAdapter y se realiza un query
				MySqlDataAdapter canal = new MySqlDataAdapter("SELECT * FROM mitabla", conexion);
				
				// Equivalente en ODBC
				//OleDbDataAdapter canal=new OleDbDataAdapter("select * from mitabla", conexion);
				
				// Creamos un DataSet
				DataSet tabla=new DataSet();
			
				// Llenamos de datos al DataAdapter
				canal.Fill(tabla,"mitabla");
			
				// Cargamos los datos del Dataset al DataSource
				TABLAGRID.DataSource=tabla;
			
				// Se carga la tabla mitabla
				TABLAGRID.DataMember="mitabla";
			
				// Anexamos los datos actuales al DataSource
				TABLAGRID.DataBind();
				
			}

    
			// Metodo para Editar los items
			public void DataGrid_Edit(Object sender, DataGridCommandEventArgs e)
			{
				// Propiedad del DataSource para Editar items en el elemento seleccionado
				TABLAGRID.EditItemIndex = (int) e.Item.ItemIndex;
				
				// Ejectuar el metodo para Desplegar la tabla
                DespTabla();
             }
		
			
			// Metodo para Cancelar cambios
			public void DataGrid_Cancel(Object sender, DataGridCommandEventArgs e)
			{
				TABLAGRID.EditItemIndex=-1;
                DespTabla();
			}
		
			// Metodo para Actualizar datos
			public void DataGrid_Update(Object sender, DataGridCommandEventArgs e)
			{
				
			MySqlConnection conexion2 = new MySqlConnection();
			// Se cargan los valores de	conexion al objeto conexion
				conexion2.ConnectionString = credentials;
			
				// Declaramos un query para actualizar la tabla
				string query="UPDATE mitabla SET nombre=?NOMBRE, edad=?EDAD where clave=?CLAVE";
			
				// Instanciamos un objeto MySqlCommand
				MySqlCommand orden = new MySqlCommand (query, conexion2);
				
				// Agregamos parametros
				orden.Parameters.Add(new MySqlParameter ("?CLAVE", MySqlDbType.Int32));
                orden.Parameters.Add(new MySqlParameter ("?NOMBRE", MySqlDbType.VarChar,20));
				orden.Parameters.Add(new MySqlParameter ("?EDAD", MySqlDbType.Int32));
				
				orden.Parameters["?CLAVE"].Value=TABLAGRID.DataKeys[(int)e.Item.ItemIndex];
			
				//Console.WriteLine(orden.Parameters["?CLAVE"].Value);
			                 
				String[] nombrecajas = {"?CLAVE", "?NOMBRE","?EDAD"};
				
				for (int i=2; i<=3; i++)
					{
						String datocajas= ((TextBox)e.Item.Cells[i].Controls[0]).Text;
						orden.Parameters[nombrecajas[i-1]].Value=Server.HtmlEncode(datocajas);
						//Console.WriteLine("DatoCajas:" + datocajas);
					}
			
			try
				{
					orden.Connection.Open();
								
               		orden.ExecuteNonQuery();
    	
					TABLAGRID.EditItemIndex=-1;
    	
					orden.Connection.Close();
    	
					DespTabla();
				}
			
			catch (System.ArgumentNullException exc)
				{Response.Write(exc.Message);}
			
			}
	}
}
