
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
 * Clase Usuario_admin:
 *
 */

namespace DsmGen.Infraestructure.Repository.Dominio_dsm
{
public partial class Usuario_adminRepository : BasicRepository, IUsuario_adminRepository
{
public Usuario_adminRepository() : base ()
{
}


public Usuario_adminRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public Usuario_adminEN ReadOIDDefault (string email
                                       )
{
        Usuario_adminEN usuario_adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuario_adminEN = (Usuario_adminEN)session.Get (typeof(Usuario_adminNH), email);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuario_adminEN;
}

public System.Collections.Generic.IList<Usuario_adminEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<Usuario_adminEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(Usuario_adminNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<Usuario_adminEN>();
                        else
                                result = session.CreateCriteria (typeof(Usuario_adminNH)).List<Usuario_adminEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in Usuario_adminRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (Usuario_adminEN usuario_admin)
{
        try
        {
                SessionInitializeTransaction ();
                Usuario_adminNH usuario_adminNH = (Usuario_adminNH)session.Load (typeof(Usuario_adminNH), usuario_admin.Email);

                usuario_adminNH.NombreSocio = usuario_admin.NombreSocio;

                session.Update (usuario_adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in Usuario_adminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string Nuevo (Usuario_adminEN usuario_admin)
{
        Usuario_adminNH usuario_adminNH = new Usuario_adminNH (usuario_admin);

        try
        {
                SessionInitializeTransaction ();

                session.Save (usuario_adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in Usuario_adminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario_adminNH.Email;
}

public void Modificar (Usuario_adminEN usuario_admin)
{
        try
        {
                SessionInitializeTransaction ();
                Usuario_adminNH usuario_adminNH = (Usuario_adminNH)session.Load (typeof(Usuario_adminNH), usuario_admin.Email);

                usuario_adminNH.Nombre = usuario_admin.Nombre;


                usuario_adminNH.FechaNac = usuario_admin.FechaNac;


                usuario_adminNH.Pass = usuario_admin.Pass;


                usuario_adminNH.NombreSocio = usuario_admin.NombreSocio;

                session.Update (usuario_adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in Usuario_adminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (string email
                      )
{
        try
        {
                SessionInitializeTransaction ();
                Usuario_adminNH usuario_adminNH = (Usuario_adminNH)session.Load (typeof(Usuario_adminNH), email);
                session.Delete (usuario_adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in Usuario_adminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
