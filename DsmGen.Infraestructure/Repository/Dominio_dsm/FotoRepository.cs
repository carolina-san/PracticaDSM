
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
 * Clase Foto:
 *
 */

namespace DsmGen.Infraestructure.Repository.Dominio_dsm
{
public partial class FotoRepository : BasicRepository, IFotoRepository
{
public FotoRepository() : base ()
{
}


public FotoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FotoEN ReadOIDDefault (int id
                              )
{
        FotoEN fotoEN = null;

        try
        {
                SessionInitializeTransaction ();
                fotoEN = (FotoEN)session.Get (typeof(FotoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return fotoEN;
}

public System.Collections.Generic.IList<FotoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FotoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FotoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FotoEN>();
                        else
                                result = session.CreateCriteria (typeof(FotoNH)).List<FotoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in FotoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FotoEN foto)
{
        try
        {
                SessionInitializeTransaction ();
                FotoNH fotoNH = (FotoNH)session.Load (typeof(FotoNH), foto.Id);


                fotoNH.Archivo = foto.Archivo;


                fotoNH.Alt = foto.Alt;

                session.Update (fotoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in FotoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (FotoEN foto)
{
        FotoNH fotoNH = new FotoNH (foto);

        try
        {
                SessionInitializeTransaction ();
                if (foto.Articulo != null) {
                        // Argumento OID y no colección.
                        fotoNH
                        .Articulo = (DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN)session.Load (typeof(DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN), foto.Articulo.Id);

                        fotoNH.Articulo.Foto
                        .Add (fotoNH);
                }

                session.Save (fotoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in FotoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return fotoNH.Id;
}

public void Modificar (FotoEN foto)
{
        try
        {
                SessionInitializeTransaction ();
                FotoNH fotoNH = (FotoNH)session.Load (typeof(FotoNH), foto.Id);

                fotoNH.Archivo = foto.Archivo;


                fotoNH.Alt = foto.Alt;

                session.Update (fotoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in FotoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (int id
                      )
{
        try
        {
                SessionInitializeTransaction ();
                FotoNH fotoNH = (FotoNH)session.Load (typeof(FotoNH), id);
                session.Delete (fotoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in FotoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameOID
//Con e: FotoEN
public FotoEN DameOID (int id
                       )
{
        FotoEN fotoEN = null;

        try
        {
                SessionInitializeTransaction ();
                fotoEN = (FotoEN)session.Get (typeof(FotoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return fotoEN;
}

public System.Collections.Generic.IList<FotoEN> DameALL (int first, int size)
{
        System.Collections.Generic.IList<FotoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FotoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<FotoEN>();
                else
                        result = session.CreateCriteria (typeof(FotoNH)).List<FotoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in FotoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
