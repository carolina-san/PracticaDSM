
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
 * Clase Resenya:
 *
 */

namespace DsmGen.Infraestructure.Repository.Dominio_dsm
{
public partial class ResenyaRepository : BasicRepository, IResenyaRepository
{
public ResenyaRepository() : base ()
{
}


public ResenyaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ResenyaEN ReadOIDDefault (int id
                                 )
{
        ResenyaEN resenyaEN = null;

        try
        {
                SessionInitializeTransaction ();
                resenyaEN = (ResenyaEN)session.Get (typeof(ResenyaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return resenyaEN;
}

public System.Collections.Generic.IList<ResenyaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ResenyaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ResenyaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ResenyaEN>();
                        else
                                result = session.CreateCriteria (typeof(ResenyaNH)).List<ResenyaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ResenyaEN resenya)
{
        try
        {
                SessionInitializeTransaction ();
                ResenyaNH resenyaNH = (ResenyaNH)session.Load (typeof(ResenyaNH), resenya.Id);

                resenyaNH.Estrellas = resenya.Estrellas;


                resenyaNH.Comentario = resenya.Comentario;


                resenyaNH.Fecha = resenya.Fecha;



                session.Update (resenyaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nueva (ResenyaEN resenya)
{
        ResenyaNH resenyaNH = new ResenyaNH (resenya);

        try
        {
                SessionInitializeTransaction ();
                if (resenya.Usuario != null) {
                        // Argumento OID y no colección.
                        resenyaNH
                        .Usuario = (DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN)session.Load (typeof(DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN), resenya.Usuario.Email);

                        resenyaNH.Usuario.Resenya
                        .Add (resenyaNH);
                }
                if (resenya.Articulo != null) {
                        // Argumento OID y no colección.
                        resenyaNH
                        .Articulo = (DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN)session.Load (typeof(DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN), resenya.Articulo.Id);

                        resenyaNH.Articulo.Resenya
                        .Add (resenyaNH);
                }

                session.Save (resenyaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return resenyaNH.Id;
}

public void Eliminar (int id
                      )
{
        try
        {
                SessionInitializeTransaction ();
                ResenyaNH resenyaNH = (ResenyaNH)session.Load (typeof(ResenyaNH), id);
                session.Delete (resenyaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameOID
//Con e: ResenyaEN
public ResenyaEN DameOID (int id
                          )
{
        ResenyaEN resenyaEN = null;

        try
        {
                SessionInitializeTransaction ();
                resenyaEN = (ResenyaEN)session.Get (typeof(ResenyaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return resenyaEN;
}

public System.Collections.Generic.IList<ResenyaEN> DameAll (int first, int size)
{
        System.Collections.Generic.IList<ResenyaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ResenyaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ResenyaEN>();
                else
                        result = session.CreateCriteria (typeof(ResenyaNH)).List<ResenyaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
