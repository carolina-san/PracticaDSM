
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
 * Clase Articulo:
 *
 */

namespace DsmGen.Infraestructure.Repository.Dominio_dsm
{
public partial class ArticuloRepository : BasicRepository, IArticuloRepository
{
public ArticuloRepository() : base ()
{
}


public ArticuloRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ArticuloEN ReadOIDDefault (int id
                                  )
{
        ArticuloEN articuloEN = null;

        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Get (typeof(ArticuloNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ArticuloNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ArticuloEN>();
                        else
                                result = session.CreateCriteria (typeof(ArticuloNH)).List<ArticuloEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloNH articuloNH = (ArticuloNH)session.Load (typeof(ArticuloNH), articulo.Id);

                articuloNH.Nombre = articulo.Nombre;


                articuloNH.Precio = articulo.Precio;


                articuloNH.Descripcion = articulo.Descripcion;


                articuloNH.Talla = articulo.Talla;


                articuloNH.Recomendaciones = articulo.Recomendaciones;


                articuloNH.Check_verificado = articulo.Check_verificado;


                articuloNH.Desc_verificado = articulo.Desc_verificado;





                articuloNH.Stock = articulo.Stock;


                articuloNH.En_stock = articulo.En_stock;





                session.Update (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


//Sin e: DameOID
//Con e: ArticuloEN
public ArticuloEN DameOID (int id
                           )
{
        ArticuloEN articuloEN = null;

        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Get (typeof(ArticuloNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> DameALL (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ArticuloNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ArticuloEN>();
                else
                        result = session.CreateCriteria (typeof(ArticuloNH)).List<ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int Nuevo (ArticuloEN articulo)
{
        ArticuloNH articuloNH = new ArticuloNH (articulo);

        try
        {
                SessionInitializeTransaction ();
                if (articulo.Marca != null) {
                        // Argumento OID y no colección.
                        articuloNH
                        .Marca = (DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN)session.Load (typeof(DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN), articulo.Marca.Nombre);

                        articuloNH.Marca.Articulo
                        .Add (articuloNH);
                }

                session.Save (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return articuloNH.Id;
}

public void Modificar (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloNH articuloNH = (ArticuloNH)session.Load (typeof(ArticuloNH), articulo.Id);

                articuloNH.Nombre = articulo.Nombre;


                articuloNH.Precio = articulo.Precio;


                articuloNH.Descripcion = articulo.Descripcion;


                articuloNH.Talla = articulo.Talla;


                articuloNH.Recomendaciones = articulo.Recomendaciones;


                articuloNH.Check_verificado = articulo.Check_verificado;


                articuloNH.Desc_verificado = articulo.Desc_verificado;


                articuloNH.Stock = articulo.Stock;


                articuloNH.En_stock = articulo.En_stock;

                session.Update (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
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
                ArticuloNH articuloNH = (ArticuloNH)session.Load (typeof(ArticuloNH), id);
                session.Delete (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Favorito (int p_Articulo_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN articuloEN = null;
        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Load (typeof(ArticuloNH), p_Articulo_OID);
                DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuarioENAux = null;
                if (articuloEN.Usuario == null) {
                        articuloEN.Usuario = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN>();
                }

                foreach (string item in p_usuario_OIDs) {
                        usuarioENAux = new DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN ();
                        usuarioENAux = (DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN)session.Load (typeof(DsmGen.Infraestructure.EN.Dominio_dsm.UsuarioNH), item);
                        usuarioENAux.Articulo.Add (articuloEN);

                        articuloEN.Usuario.Add (usuarioENAux);
                }


                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void NotFavorito (int p_Articulo_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN articuloEN = null;
                articuloEN = (ArticuloEN)session.Load (typeof(ArticuloNH), p_Articulo_OID);

                DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuarioENAux = null;
                if (articuloEN.Usuario != null) {
                        foreach (string item in p_usuario_OIDs) {
                                usuarioENAux = (DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN)session.Load (typeof(DsmGen.Infraestructure.EN.Dominio_dsm.UsuarioNH), item);
                                if (articuloEN.Usuario.Contains (usuarioENAux) == true) {
                                        articuloEN.Usuario.Remove (usuarioENAux);
                                        usuarioENAux.Articulo.Remove (articuloEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario_OIDs you are trying to unrelationer, doesn't exist in ArticuloEN");
                        }
                }

                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void NotificacionActivada (int p_Articulo_OID, System.Collections.Generic.IList<string> p_usuario_0_OIDs)
{
        DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN articuloEN = null;
        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Load (typeof(ArticuloNH), p_Articulo_OID);
                DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario_0ENAux = null;
                if (articuloEN.Usuario_0 == null) {
                        articuloEN.Usuario_0 = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN>();
                }

                foreach (string item in p_usuario_0_OIDs) {
                        usuario_0ENAux = new DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN ();
                        usuario_0ENAux = (DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN)session.Load (typeof(DsmGen.Infraestructure.EN.Dominio_dsm.UsuarioNH), item);
                        usuario_0ENAux.Articulo_0.Add (articuloEN);

                        articuloEN.Usuario_0.Add (usuario_0ENAux);
                }


                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void NotificacionDesactivada (int p_Articulo_OID, System.Collections.Generic.IList<string> p_usuario_0_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN articuloEN = null;
                articuloEN = (ArticuloEN)session.Load (typeof(ArticuloNH), p_Articulo_OID);

                DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario_0ENAux = null;
                if (articuloEN.Usuario_0 != null) {
                        foreach (string item in p_usuario_0_OIDs) {
                                usuario_0ENAux = (DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN)session.Load (typeof(DsmGen.Infraestructure.EN.Dominio_dsm.UsuarioNH), item);
                                if (articuloEN.Usuario_0.Contains (usuario_0ENAux) == true) {
                                        articuloEN.Usuario_0.Remove (usuario_0ENAux);
                                        usuario_0ENAux.Articulo_0.Remove (articuloEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario_0_OIDs you are trying to unrelationer, doesn't exist in ArticuloEN");
                        }
                }

                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> DamePorTalla (DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum ? p_talla)
{
        System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where FROM ArticuloNH as articulo WHERE articulo.Talla= :p_talla;";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdamePorTallaHQL");
                query.SetParameter ("p_talla", p_talla);

                result = query.List<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
