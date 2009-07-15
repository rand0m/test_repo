using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebSystem
{	
	public partial class Desplegar : System.Web.UI.Page
	{
    
    public void Page_Load(object sender, EventArgs e) 
    {
			// Tomando configuracion de BD en web.config
			string credentials = ConfigurationManager.AppSettings["ConnectionString"];
			
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
    
    public void TABLAGRID_SelectedIndexChanged(Object sender, EventArgs e)
		{}
	}
}
