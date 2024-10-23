
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
 * Clase Busqueda:
 *
 */

namespace DsmGen.Infraestructure.Repository.Dominio_dsm
{
public partial class BusquedaRepository : BasicRepository, IBusquedaRepository
{
public BusquedaRepository() : base ()
{
}


public BusquedaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public BusquedaEN ReadOIDDefault (int id
                                  )
{
        BusquedaEN busquedaEN = null;

        try
        {
                SessionInitializeTransaction ();
                busquedaEN = (BusquedaEN)session.Get (typeof(BusquedaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return busquedaEN;
}

public System.Collections.Generic.IList<BusquedaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<BusquedaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(BusquedaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<BusquedaEN>();
                        else
                                result = session.CreateCriteria (typeof(BusquedaNH)).List<BusquedaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in BusquedaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (BusquedaEN busqueda)
{
        try
        {
                SessionInitializeTransaction ();
                BusquedaNH busquedaNH = (BusquedaNH)session.Load (typeof(BusquedaNH), busqueda.Id);

                busquedaNH.Marca = busqueda.Marca;


                busquedaNH.Talla = busqueda.Talla;


                busquedaNH.Precio = busqueda.Precio;


                session.Update (busquedaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in BusquedaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nueva (BusquedaEN busqueda)
{
        BusquedaNH busquedaNH = new BusquedaNH (busqueda);

        try
        {
                SessionInitializeTransaction ();

                session.Save (busquedaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in BusquedaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return busquedaNH.Id;
}
}
}
