using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebSystem
{
	
	
	public partial class Busqueda : System.Web.UI.Page
	{
	
		
   public void BUSCAR (Object sender, EventArgs e)
    {
			// Tomando configuracion de BD en web.config
			string credentials = ConfigurationManager.AppSettings["ConnectionString"];
			
			// Instanciando conexion MySql
			MySqlConnection conexion = new MySqlConnection();

			// Cargando datos de la BD a la conexion
			conexion.ConnectionString = credentials;
			
			// Definimos el query
			string query="SELECT * FROM mitabla WHERE clave=?CLAVE";
			
			// Comando anterior utilizando OleDB
			// string query = "SELECT * FROM mitabla WHERE clave=@CLAVE"
			
			// Instanciando DataAdapter que ejecuta el query			
			MySqlDataAdapter canal = new MySqlDataAdapter(query, conexion);
							
			// Creando tabla en memoria (DataSet)
			DataSet tabla = new DataSet();
			
			// Abriendo conexion a BD
			conexion.Open();
			
			// Cargando valor del Textbox con la clave a buscar
			canal.SelectCommand.Parameters.Add("?CLAVE", MySqlDbType.Int32).Value=CLAVE.Text;
			
			// Comando anterior usando OleDB
			// canal.SelectCommand.Parameters.Add(new OleDbParameter("@CLAVE", OleDbType.Integer));
			// canal.SelectCommand.Parameters["@cLAVE"].Value=CLAVE.Text;
			
			canal.Fill(tabla,"mitabla");
			
			// Cargar DataGrid
			TABLAGRID.DataSource=tabla;
			TABLAGRID.DataMember="mitabla";
			TABLAGRID.DataBind();
      }
	}
}
