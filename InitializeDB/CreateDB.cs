
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using DsmGen.Infraestructure.Repository.Dominio_dsm;
using DsmGen.Infraestructure.CP;
using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.CP.Dominio_dsm;
using DsmGen.Infraestructure.Repository;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                PedidoRepository pedidorepository = new PedidoRepository ();
                PedidoCEN pedidocen = new PedidoCEN (pedidorepository);
                LineaPedidoRepository lineapedidorepository = new LineaPedidoRepository ();
                LineaPedidoCEN lineapedidocen = new LineaPedidoCEN (lineapedidorepository);
                Usuario_adminRepository usuario_adminrepository = new Usuario_adminRepository ();
                Usuario_adminCEN usuario_admincen = new Usuario_adminCEN (usuario_adminrepository);
                ArticuloRepository articulorepository = new ArticuloRepository ();
                ArticuloCEN articulocen = new ArticuloCEN (articulorepository);
                FotoRepository fotorepository = new FotoRepository ();
                FotoCEN fotocen = new FotoCEN (fotorepository);
                MarcaRepository marcarepository = new MarcaRepository ();
                MarcaCEN marcacen = new MarcaCEN (marcarepository);
                DireccionRepository direccionrepository = new DireccionRepository ();
                DireccionCEN direccioncen = new DireccionCEN (direccionrepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                usuariocen.Nuevo ("juan@gmail.com", "Juan", new DateTime (1990, 1, 1), "1234");
                Console.WriteLine ("Usuario Juan creado");

                if (usuariocen.Login ("juan@gmail.com", "1234") != null) {
                        Console.WriteLine ("Usuario Juan logueado");
                }
                else{
                        Console.WriteLine ("Usuario Juan no logueado");
                }



                string marca1 = marcacen.Nuevo ("nike");
                Console.WriteLine ("Marca creada correctamente");
                int art1 = articulocen.Nuevo ("Articulo1", 50, "Descripcion1", DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum.Talla_35, "No hay recomendaciones", true, "verificado", marca1, 100);
                Console.WriteLine ("Articulo creado correctamente");
                articulocen.Dec_stock (art1, 10);
                Console.WriteLine ("Stock decrementado correctamente");


                string usuario1 = usuario_admincen.Nuevo ("juan2@gmail.com", "Juan", new DateTime (1990, 1, 1), "1234");
                Console.WriteLine ("Usuario Admin Juan creado");

                articulocen.Mas_stock (art1, 10);
                Console.WriteLine ("Stock incrementado correctamente");
                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
