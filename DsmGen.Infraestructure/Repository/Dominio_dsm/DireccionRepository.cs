
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
 * Clase Direccion:
 *
 */

namespace DsmGen.Infraestructure.Repository.Dominio_dsm
{
public partial class DireccionRepository : BasicRepository, IDireccionRepository
{
public DireccionRepository() : base ()
{
}


public DireccionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public DireccionEN ReadOIDDefault (int id
                                   )
{
        DireccionEN direccionEN = null;

        try
        {
                SessionInitializeTransaction ();
                direccionEN = (DireccionEN)session.Get (typeof(DireccionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return direccionEN;
}

public System.Collections.Generic.IList<DireccionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DireccionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DireccionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<DireccionEN>();
                        else
                                result = session.CreateCriteria (typeof(DireccionNH)).List<DireccionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DireccionEN direccion)
{
        try
        {
                SessionInitializeTransaction ();
                DireccionNH direccionNH = (DireccionNH)session.Load (typeof(DireccionNH), direccion.Id);

                direccionNH.Calle = direccion.Calle;


                direccionNH.Provincia = direccion.Provincia;


                direccionNH.CodPost = direccion.CodPost;


                direccionNH.Telf = direccion.Telf;


                direccionNH.NombreCompleto = direccion.NombreCompleto;



                session.Update (direccionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (DireccionEN direccion)
{
        DireccionNH direccionNH = new DireccionNH (direccion);

        try
        {
                SessionInitializeTransaction ();
                if (direccion.Usuario != null) {
                        // Argumento OID y no colección.
                        direccionNH
                        .Usuario = (DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN)session.Load (typeof(DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN), direccion.Usuario.Email);

                        direccionNH.Usuario.Direccion
                        .Add (direccionNH);
                }

                session.Save (direccionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return direccionNH.Id;
}

public void Modificar (DireccionEN direccion)
{
        try
        {
                SessionInitializeTransaction ();
                DireccionNH direccionNH = (DireccionNH)session.Load (typeof(DireccionNH), direccion.Id);

                direccionNH.Calle = direccion.Calle;


                direccionNH.Provincia = direccion.Provincia;


                direccionNH.CodPost = direccion.CodPost;


                direccionNH.Telf = direccion.Telf;


                direccionNH.NombreCompleto = direccion.NombreCompleto;

                session.Update (direccionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionRepository.", ex);
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
                DireccionNH direccionNH = (DireccionNH)session.Load (typeof(DireccionNH), id);
                session.Delete (direccionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameOID
//Con e: DireccionEN
public DireccionEN DameOID (int id
                            )
{
        DireccionEN direccionEN = null;

        try
        {
                SessionInitializeTransaction ();
                direccionEN = (DireccionEN)session.Get (typeof(DireccionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return direccionEN;
}

public System.Collections.Generic.IList<DireccionEN> DameAll (int first, int size)
{
        System.Collections.Generic.IList<DireccionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(DireccionNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<DireccionEN>();
                else
                        result = session.CreateCriteria (typeof(DireccionNH)).List<DireccionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
