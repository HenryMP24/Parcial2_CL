using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Npgsql;
using NpgsqlTypes;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hola a todos";
    }
    [WebMethod]
    public DataSet HelloWorld2()
    {
        NpgsqlConnection con = new NpgsqlConnection();
        con.ConnectionString = "Server=localhost;Port=5432; User Id=postgres; Password=123456; Database= academico;";
        NpgsqlDataAdapter ada = new NpgsqlDataAdapter();
        ada.SelectCommand = new NpgsqlCommand();
        ada.SelectCommand.Connection = con;
        ada.SelectCommand.CommandText = "select * from alumno";
        ada.SelectCommand.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        ada.Fill(ds);
        return ds;
    }


}
