
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
 * Clase Marca:
 *
 */

namespace DsmGen.Infraestructure.Repository.Dominio_dsm
{
public partial class MarcaRepository : BasicRepository, IMarcaRepository
{
public MarcaRepository() : base ()
{
}


public MarcaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}
        public MarcaEN BuscarPorNombre(string nombre)
        {
            MarcaEN marcaEN = null;

            try
            {
                SessionInitializeTransaction();
                marcaEN = session.CreateCriteria<MarcaNH>()
                                 .Add(Restrictions.Eq("Nombre", nombre))
                                 .UniqueResult<MarcaNH>();
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw new DsmGen.ApplicationCore.Exceptions.DataLayerException("Error en BuscarPorNombre.", ex);
            }
            finally
            {
                SessionClose();
            }

            return marcaEN;
        }
        public MarcaEN ReadOIDDefault (string nombre
                               )
{
        MarcaEN marcaEN = null;

        try
        {
                SessionInitializeTransaction ();
                marcaEN = (MarcaEN)session.Get (typeof(MarcaNH), nombre);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return marcaEN;
}

public System.Collections.Generic.IList<MarcaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MarcaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MarcaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MarcaEN>();
                        else
                                result = session.CreateCriteria (typeof(MarcaNH)).List<MarcaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MarcaEN marca)
{
        try
        {
                SessionInitializeTransaction ();
                MarcaNH marcaNH = (MarcaNH)session.Load (typeof(MarcaNH), marca.Nombre);


                session.Update (marcaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string Nuevo (MarcaEN marca)
{
        MarcaNH marcaNH = new MarcaNH (marca);

        try
        {
                SessionInitializeTransaction ();

                session.Save (marcaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return marcaNH.Nombre;
}

public void Modificar (MarcaEN marca)
{
        try
        {
                SessionInitializeTransaction ();
                MarcaNH marcaNH = (MarcaNH)session.Load (typeof(MarcaNH), marca.Nombre);
                session.Update (marcaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (string nombre
                      )
{
        try
        {
                SessionInitializeTransaction ();
                MarcaNH marcaNH = (MarcaNH)session.Load (typeof(MarcaNH), nombre);
                session.Delete (marcaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<MarcaEN> DameALL (int first, int size)
{
        System.Collections.Generic.IList<MarcaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MarcaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MarcaEN>();
                else
                        result = session.CreateCriteria (typeof(MarcaNH)).List<MarcaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Seguir (string p_Marca_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN marcaEN = null;
        try
        {
                SessionInitializeTransaction ();
                marcaEN = (MarcaEN)session.Load (typeof(MarcaNH), p_Marca_OID);
                DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuarioENAux = null;
                if (marcaEN.Usuario == null) {
                        marcaEN.Usuario = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN>();
                }

                foreach (string item in p_usuario_OIDs) {
                        usuarioENAux = new DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN ();
                        usuarioENAux = (DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN)session.Load (typeof(DsmGen.Infraestructure.EN.Dominio_dsm.UsuarioNH), item);
                        usuarioENAux.Marca.Add (marcaEN);

                        marcaEN.Usuario.Add (usuarioENAux);
                }


                session.Update (marcaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void NoSeguir (string p_Marca_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN marcaEN = null;
                marcaEN = (MarcaEN)session.Load (typeof(MarcaNH), p_Marca_OID);

                DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuarioENAux = null;
                if (marcaEN.Usuario != null) {
                        foreach (string item in p_usuario_OIDs) {
                                usuarioENAux = (DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN)session.Load (typeof(DsmGen.Infraestructure.EN.Dominio_dsm.UsuarioNH), item);
                                if (marcaEN.Usuario.Contains (usuarioENAux) == true) {
                                        marcaEN.Usuario.Remove (usuarioENAux);
                                        usuarioENAux.Marca.Remove (marcaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario_OIDs you are trying to unrelationer, doesn't exist in MarcaEN");
                        }
                }

                session.Update (marcaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
