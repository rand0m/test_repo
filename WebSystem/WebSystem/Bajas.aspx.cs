
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebSystem
{
	
	
	public partial class Bajas : System.Web.UI.Page
	{
		// Tomando configuracion de BD en web.config
		string credentials = ConfigurationManager.AppSettings["ConnectionString"];

    public void Page_Load(Object sender, EventArgs e)
    {
			if (!IsPostBack)
				DespTabla();
     }

	public void DespTabla()
		{
			// Instanciando conexion MySql
			MySqlConnection conexion = new MySqlConnection();

			// Cargando datos de la BD a la conexion
			conexion.ConnectionString = credentials;
			
			// Definimos el query
			string query = "SELECT * FROM mitabla";
			
			// Instanciando DataAdapter que ejecuta el query			
			MySqlDataAdapter canal = new MySqlDataAdapter(query, conexion);
							
			// Creando tabla en memoria (DataSet)
			DataSet tabla = new DataSet();
			
			// Abriendo conexion a BD
			conexion.Open();
			
			// Llenando el DataAdapter
			canal.Fill(tabla, "mitabla");
			
			// Cargando DataGrid
			TABLAGRID.DataSource=tabla;
			TABLAGRID.DataMember="mitabla";
			TABLAGRID.DataBind();    
		}
		
		
     public void BORRAR (Object sender, EventArgs e)
     {
		// Instanciamos nuestro objeto MySqlConnection, para conectarnos a MySQL
		MySqlConnection conexion = new MySqlConnection();
			
		MySqlDataAdapter canal;			
    	// Se cargan los valores de	conexion al objeto conexion
		conexion.ConnectionString = credentials;
        //usando sql
        string query="DELETE FROM mitabla WHERE clave=?CLAVE";
		MySqlCommand orden=new MySqlCommand(query, conexion);
		orden.Parameters.Add(new MySqlParameter("?CLAVE", MySqlDbType.Int32));
		orden.Parameters["?CLAVE"].Value=CLAVE.Text;
		orden.Connection.Open();
		orden.ExecuteNonQuery();
		orden.Connection.Close();
			
		//refrescando dataset
		canal=new MySqlDataAdapter ("SELECT * FROM mitabla", conexion);
		DataSet tabla=new DataSet();
		canal.Fill(tabla,"mitabla");	
		TABLAGRID.DataSource=tabla.Tables["mitabla"].DefaultView;
		TABLAGRID.DataBind();	
		//limpiando textbox
		CLAVE.Text="";
		conexion.Close();
    
     }

	}
}
