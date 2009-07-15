using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebSystem
{
	
	public partial class Altas : System.Web.UI.Page
	{
		// Tomando configuracion de BD en web.config
		public string credentials = ConfigurationManager.AppSettings["ConnectionString"];
			
          public void Page_Load(Object sender, EventArgs e)
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

			// Cargar el nuevo textbox
        	
			int cantreng=tabla.Tables["mitabla"].Rows.Count;
			
			int nvaclave=Int32.Parse(tabla.Tables["mitabla"].Rows[cantreng-1][0].ToString())+1;
            
			CLAVE.Text=nvaclave.ToString();
			
           }
    
          public void INSERTAR(Object sender, EventArgs e)
		{
			// Instanciando conexion MySql
			MySqlConnection conexion3 = new MySqlConnection();
			
			// Cargando datos de la BD a la conexion
			conexion3.ConnectionString = credentials;
			
			// Usando sql
            string query="INSERT INTO mitabla(clave,nombre,edad) values(?CLAVE, ?NOMBRE, ?EDAD)";
			
			// Instanciando DataAdapter que ejecuta el query			
			MySqlDataAdapter canal = new MySqlDataAdapter();
			
			// Creando tabla en memoria (DataSet)
			DataSet tabla = new DataSet();
            
			// Usando objeto command
			MySqlCommand orden = new MySqlCommand(query,conexion3);
			
			orden.Parameters.Add(new MySqlParameter("?CLAVE", MySqlDbType.Int32));
			
			orden.Parameters["?CLAVE"].Value = CLAVE.Text;
			
			orden.Parameters.Add(new MySqlParameter("?NOMBRE", MySqlDbType.VarChar,20));
			
			orden.Parameters["?NOMBRE"].Value = NOMBRE.Text;
			
			orden.Parameters.Add(new MySqlParameter("?EDAD", MySqlDbType.Int32));
			
			orden.Parameters["?EDAD"].Value = EDAD.Text;
			
			orden.Connection.Open();
            
			orden.ExecuteNonQuery();
            
			orden.Connection.Close();
    
			//refrescar dataset con nuevos datos
			canal = new MySqlDataAdapter("SELECT * FROM mitabla",conexion3);
			
			tabla = new DataSet();
			
			canal.Fill(tabla,"mitabla");
				
			//cargar el datagrid
            TABLAGRID.DataSource=tabla.Tables["mitabla"].DefaultView;
            
			TABLAGRID.DataBind();
    
            //cargando textbox clave y limpiando las otros textbox
            int cantreng=tabla.Tables["mitabla"].Rows.Count;
            
			int nvaclave=Int32.Parse(tabla.Tables["mitabla"].Rows[cantreng-1][0].ToString())+1;
            
			CLAVE.Text=nvaclave.ToString();
            
			NOMBRE.Text="";
            
			EDAD.Text="";
            
			//cerrando conexion
            
			conexion3.Close();
		}

	}
}
