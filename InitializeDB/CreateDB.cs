
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
using DsmGen.Infraestructure.EN.Dominio_dsm;
using System.Text.RegularExpressions;

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
                ResenyaRepository resenyarepository = new ResenyaRepository ();
                ResenyaCEN resenyacen = new ResenyaCEN (resenyarepository);
                Codigo_promocionalRepository codigo_promocionalrepository = new Codigo_promocionalRepository ();
                Codigo_promocionalCEN codigo_promocionalcen = new Codigo_promocionalCEN (codigo_promocionalrepository);
                NotificacionRepository notificacionrepository = new NotificacionRepository ();
                NotificacionCEN notificacioncen = new NotificacionCEN (notificacionrepository);
                CarritoRepository carritorepository = new CarritoRepository ();
                CarritoCEN carritocen = new CarritoCEN (carritorepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                string usu= usuariocen.Nuevo ("juan@gmail.com", "Juan", new DateTime (1990, 1, 1), "1234");
                Console.WriteLine ("Usuario Juan creado");
                string usu2 = usuariocen.Nuevo("pedro@gmail.com", "Pedro", new DateTime(2003, 10, 18), "1234");
                if (usuariocen.Login ("juan@gmail.com", "1234") != null) {
                        Console.WriteLine ("Usuario Juan logueado");
                }
                else{
                        Console.WriteLine ("Usuario Juan no logueado");
                }



                string marca1 = marcacen.Nuevo ("Nike");
                string marca2 = marcacen.Nuevo("Adidas");
                string marca3 = marcacen.Nuevo("New Balance");
                Console.WriteLine ("Marca creada correctamente");
                
                int art2= articulocen.Nuevo("Nike Dunk Low", (float)119.95,
                    "Nike Dunk Low Panda ", DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum.Talla_35,
                    "El artículo talla pequeño", true, "Verificado por la marca", marca1, 100, "Negro", "/Images/nike-dunk.jpg");
                int art3 = articulocen.Nuevo("Nike Deportivas", (float)59.95,
                    "Nike Deportivas Rosas", DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum.Talla_35,
                    "El artículo talla grande", true, "Verificado por la marca", marca1, 100, "Rosa", "/Images/zapatilla-deportivo.jpg");
                int art4 = articulocen.Nuevo("Nike Court", (float)99.95,
                    "Nike Court Blanco y negro ", DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum.Talla_35,
                    "El artículo talla normal", true, "Verificado por la marca", marca1, 100, "Blanco", "/Images/zapatillas-nike-court.jpg");
                int art5 = articulocen.Nuevo("New Balance 530", (float)114.95,
                    "New Balance del modelo 530", DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum.Talla_35,
                    "El artículo talla normal", true, "Verificado por la marca", marca1, 100, "Beige", "/Images/newbalance-530.png");
                int art6 = articulocen.Nuevo("New Balance 550", (float)129.95,
                    "New Balance del modelo 550 ", DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum.Talla_35,
                    "El artículo talla pequeño", true, "Verificado por la marca", marca1, 100, "Gris", "/Images/nb3.jpg");
                int art7 = articulocen.Nuevo("New Balance Deportivas", (float)99.95,
                    "New Balance modelo deportivo clásico ", DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum.Talla_35,
                    "El artículo talla normal", true, "Verificado por la marca", marca1, 100, "Blanco", "/Images/zapatillas-new-balance.jpg");
                int art8 = articulocen.Nuevo("Adidas Superstar", (float)99.95,
                    "Adidas modelo Superstar con rojo y negro", DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum.Talla_35,
                    "El artículo talla normal", true, "Verificado por la marca", marca1, 100, "Blanco", "/Images/zapatillas-adidas1.jpg");
                int art1 = articulocen.Nuevo("Adidas Deportivas", (float)79.95,
                    "Adidas modelo deportivo clásico ", DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum.Talla_35,
                    "El artículo talla grande", true, "Verificado por la marca", marca1, 100, "Negro", "/Images/adidas2.png");
               
                resenyacen.Nueva(5, "Muy buen producto", new DateTime(2022, 4, 6), usu, art1);
                resenyacen.Nueva(4, "El artículo cumple su función", new DateTime(2021, 5, 11), usu, art2);
                resenyacen.Nueva(4, "Decentes", new DateTime(2023, 11, 19), usu2, art2);
                resenyacen.Nueva(1, "No me gustan", new DateTime(2021, 10, 28), usu2, art5);
                resenyacen.Nueva(4, "Un poco caras", new DateTime(2024, 1, 16), usu, art5);

                Console.WriteLine ("Articulo creado correctamente");
                articulocen.Dec_stock (art1, 10);
                Console.WriteLine ("Stock decrementado correctamente");
                articulocen.Mas_stock (art1, 10);
                Console.WriteLine ("Stock incrementado correctamente");

                string usuario1 = usuario_admincen.Nuevo ("admin@admin.com", "Administrador", new DateTime (1990, 1, 1), "admin");
                Console.WriteLine ("Usuario Admin Juan creado");

                usuariocen.CambiarPass (usu, "1234", "12345");
                Console.WriteLine ("Password cambiada correctamente");
                int dir = direccioncen.Nuevo ("carrer nou", "Barcelona", 08001, 644216474, "Carolina", usuario1);
                Console.WriteLine ("Direccion creada correctamente");
                int pedido = pedidocen.Nuevo (usuario1, (float)10.85, dir);
                Console.WriteLine ("Pedido creado correctamente");

                LineaPedidoCP lineapedidocp = new LineaPedidoCP(new SessionCPNHibernate());
                lineapedidocp.Nuevo(pedido, 2, 10, art1);
                Console.WriteLine ("Linea de pedido 1 creada correctamente");
                lineapedidocp.Nuevo(pedido, 1, 30, art2);
                Console.WriteLine("Linea de pedido 2 creada correctamente");
                lineapedidocp.Nuevo(pedido, 3, 50, art3);
                Console.WriteLine("Linea de pedido 3 creada correctamente");

                PedidoEN pedidoEN = pedidocen.DameOID(pedido);
                Console.WriteLine("Total pedido: " + pedidoEN.Total);


                pedidocen.Modificar (pedido, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.EstadoPedidoEnum.enviado, new DateTime (2021, 6, 1));
                Console.WriteLine ("Pedido modificado correctamente");

                IList<ArticuloEN> articulos = articulocen.DamePorTalla (DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum.Talla_35);
                Console.WriteLine ("Articulos de la talla 35:");
                foreach (ArticuloEN articulo in articulos) {
                        Console.WriteLine (articulo.Nombre);
                }

                IList<ArticuloEN> articulos2 = articulocen.DamePorPrecio (10, 40);
                Console.WriteLine ("Articulos entre 10 y 40€ :");
                foreach (ArticuloEN articulo in articulos2) {
                        Console.WriteLine (articulo.Nombre);
                }
                IList<ArticuloEN> articulos3 = articulocen.DamePorColor ("verde");
                Console.WriteLine ("Articulos por color verde:");
                foreach (ArticuloEN articulo in articulos3) {
                        Console.WriteLine (articulo.Nombre);
                }
                IList<ArticuloEN> articulos4 = articulocen.DamePorTipo ("zapatilla");
                Console.WriteLine ("Articulos de tipo zapatilla:");
                foreach (ArticuloEN articulo in articulos4) {
                        Console.WriteLine (articulo.Nombre);
                }
                IList<ArticuloEN> articulos5 = articulocen.DamePorMarca("nike");
                Console.WriteLine("Articulos de marca nike:");
                foreach (ArticuloEN articulo in articulos5)
                {
                    Console.WriteLine(articulo.Nombre);
                }



                PedidoCP pedidoCP = new PedidoCP(new SessionCPNHibernate());
                pedidoCP.EnviarPedido(pedido);
                Console.WriteLine("Pedido enviado y artículos decrementados");

                IList<ArticuloEN> stocks = articulocen.DameALL(0, -1);
                Console.WriteLine("Stock de los articulos:");
                foreach (ArticuloEN articulo in stocks)
                {
                    Console.WriteLine(articulo.Nombre);
                    Console.WriteLine(articulo.Stock);
                }

                int carrito = carritocen.Nuevo(usuario1,0);
                Console.WriteLine("Carrito creado correctamente");
                IList<ArticuloEN> artsCesta= articulocen.DameALL(0, -1);
                IList<int> ids = new List<int>();
                foreach (var art in artsCesta)
                {   
                       ids.Add(art.Id);
                }
                carritocen.AddArticulo(carrito, ids);
                Console.WriteLine("Articulos añadidos al carrito correctamente");
                CarritoEN creado=carritocen.ReadOID(carrito);
                Console.WriteLine("Carrito recuperado correctamente" + creado.Id);
                Console.WriteLine("subtotal:"+ creado.Subtotal);
                carritocen.EliminarArticulo(carrito, ids);
                Console.WriteLine("Articulos eliminados del carrito correctamente");
                CarritoEN eliminado = carritocen.ReadOID(carrito);
                Console.WriteLine("Carrito recuperado correctamente" + eliminado.Id);
                Console.WriteLine("subtotal:" + eliminado.Subtotal);


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
