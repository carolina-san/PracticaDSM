
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
 * Clase Codigo_promocional:
 *
 */

namespace DsmGen.Infraestructure.Repository.Dominio_dsm
{
public partial class Codigo_promocionalRepository : BasicRepository, ICodigo_promocionalRepository
{
public Codigo_promocionalRepository() : base ()
{
}


public Codigo_promocionalRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public Codigo_promocionalEN ReadOIDDefault (string id
                                            )
{
        Codigo_promocionalEN codigo_promocionalEN = null;

        try
        {
                SessionInitializeTransaction ();
                codigo_promocionalEN = (Codigo_promocionalEN)session.Get (typeof(Codigo_promocionalNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return codigo_promocionalEN;
}

public System.Collections.Generic.IList<Codigo_promocionalEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<Codigo_promocionalEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(Codigo_promocionalNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<Codigo_promocionalEN>();
                        else
                                result = session.CreateCriteria (typeof(Codigo_promocionalNH)).List<Codigo_promocionalEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in Codigo_promocionalRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (Codigo_promocionalEN codigo_promocional)
{
        try
        {
                SessionInitializeTransaction ();
                Codigo_promocionalNH codigo_promocionalNH = (Codigo_promocionalNH)session.Load (typeof(Codigo_promocionalNH), codigo_promocional.Id);

                codigo_promocionalNH.Descuento = codigo_promocional.Descuento;


                session.Update (codigo_promocionalNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in Codigo_promocionalRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string Nuevo (Codigo_promocionalEN codigo_promocional)
{
        Codigo_promocionalNH codigo_promocionalNH = new Codigo_promocionalNH (codigo_promocional);

        try
        {
                SessionInitializeTransaction ();

                session.Save (codigo_promocionalNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in Codigo_promocionalRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return codigo_promocionalNH.Id;
}

public void Eliminar (string id
                      )
{
        try
        {
                SessionInitializeTransaction ();
                Codigo_promocionalNH codigo_promocionalNH = (Codigo_promocionalNH)session.Load (typeof(Codigo_promocionalNH), id);
                session.Delete (codigo_promocionalNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in Codigo_promocionalRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modificar (Codigo_promocionalEN codigo_promocional)
{
        try
        {
                SessionInitializeTransaction ();
                Codigo_promocionalNH codigo_promocionalNH = (Codigo_promocionalNH)session.Load (typeof(Codigo_promocionalNH), codigo_promocional.Id);

                codigo_promocionalNH.Descuento = codigo_promocional.Descuento;

                session.Update (codigo_promocionalNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in Codigo_promocionalRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
