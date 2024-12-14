
using System;
using System.Text;
using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.Exceptions;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;
using DsmGen.ApplicationCore.CP.Dominio_dsm;
using DsmGen.Infraestructure.EN.Dominio_dsm;


/*
 * Clase Carrito:
 *
 */

namespace DsmGen.Infraestructure.Repository.Dominio_dsm
{
public partial class CarritoRepository : BasicRepository, ICarritoRepository
{
public CarritoRepository() : base ()
{
}


public CarritoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public CarritoEN ReadOIDDefault (int id
                                 )
{
        CarritoEN carritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Get (typeof(CarritoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return carritoEN;
}

public System.Collections.Generic.IList<CarritoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CarritoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CarritoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<CarritoEN>();
                        else
                                result = session.CreateCriteria (typeof(CarritoNH)).List<CarritoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                CarritoNH carritoNH = (CarritoNH)session.Load (typeof(CarritoNH), carrito.Id);



                carritoNH.Subtotal = carrito.Subtotal;

                session.Update (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


//Sin e: ReadOID
//Con e: CarritoEN
public CarritoEN ReadOID (int id
                          )
{
        CarritoEN carritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Get (typeof(CarritoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return carritoEN;
}

public int Nuevo (CarritoEN carrito)
{
        CarritoNH carritoNH = new CarritoNH (carrito);

        try
        {
                SessionInitializeTransaction ();
                if (carrito.Usuario != null) {
                        // Argumento OID y no colección.
                        carritoNH
                        .Usuario = (DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN)session.Load (typeof(DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN), carrito.Usuario.Email);

                        carritoNH.Usuario.Carrito
                                = carritoNH;
                }

                session.Save (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carritoNH.Id;
}

public void AddArticulo (int p_Carrito_OID, System.Collections.Generic.IList<int> p_articulo_OIDs)
{
        DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN carritoEN = null;
        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Load (typeof(CarritoNH), p_Carrito_OID);
                DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN articuloENAux = null;
                if (carritoEN.Articulo == null) {
                        carritoEN.Articulo = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN>();
                }

                foreach (int item in p_articulo_OIDs) {
                        articuloENAux = new DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN ();
                        articuloENAux = (DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN)session.Load (typeof(DsmGen.Infraestructure.EN.Dominio_dsm.ArticuloNH), item);
                        articuloENAux.Carrito.Add (carritoEN);

                        carritoEN.Articulo.Add (articuloENAux);
                        carritoEN.Subtotal += articuloENAux.Precio;
                        
                }


                session.Update (carritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
        public void EliminarArticulo(int p_Carrito_OID, System.Collections.Generic.IList<int> p_articulo_OIDs)
        {
            DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN carritoEN = null;
            try
            {
                SessionInitializeTransaction();
                carritoEN = (CarritoEN)session.Load(typeof(CarritoNH), p_Carrito_OID);
                DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN articuloENAux = null;
                if (carritoEN.Articulo == null)
                {
                    carritoEN.Articulo = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN>();
                }

                foreach (int item in p_articulo_OIDs)
                {
                    articuloENAux = new DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN();
                    articuloENAux = (DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN)session.Load(typeof(DsmGen.Infraestructure.EN.Dominio_dsm.ArticuloNH), item);
                    articuloENAux.Carrito.Remove(carritoEN);

                    carritoEN.Articulo.Remove(articuloENAux);
                    carritoEN.Subtotal -= articuloENAux.Precio;

                }


                session.Update(carritoEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException("Error in CarritoRepository.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
    }
}
