
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
 * Clase LineaPedido:
 *
 */

namespace DsmGen.Infraestructure.Repository.Dominio_dsm
{
public partial class LineaPedidoRepository : BasicRepository, ILineaPedidoRepository
{
public LineaPedidoRepository() : base ()
{
}


public LineaPedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public LineaPedidoEN ReadOIDDefault (int num
                                     )
{
        LineaPedidoEN lineaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Get (typeof(LineaPedidoNH), num);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaPedidoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaPedidoNH)).List<LineaPedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), lineaPedido.Num);


                lineaPedidoNH.Cantidad = lineaPedido.Cantidad;


                lineaPedidoNH.Importe = lineaPedido.Importe;


                session.Update (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (LineaPedidoEN lineaPedido)
{
        LineaPedidoNH lineaPedidoNH = new LineaPedidoNH (lineaPedido);

        try
        {
                SessionInitializeTransaction ();
                if (lineaPedido.Pedido != null) {
                        // Argumento OID y no colección.
                        lineaPedidoNH
                        .Pedido = (DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN)session.Load (typeof(DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN), lineaPedido.Pedido.Id);

                        lineaPedidoNH.Pedido.LineaPedido
                        .Add (lineaPedidoNH);
                }
                if (lineaPedido.Articulo != null) {
                        // Argumento OID y no colección.
                        lineaPedidoNH
                        .Articulo = (DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN)session.Load (typeof(DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN), lineaPedido.Articulo.Id);

                        lineaPedidoNH.Articulo.LineaPedido
                        .Add (lineaPedidoNH);
                }

                session.Save (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoNH.Num;
}

public void Modificar (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), lineaPedido.Num);

                lineaPedidoNH.Cantidad = lineaPedido.Cantidad;


                lineaPedidoNH.Importe = lineaPedido.Importe;

                session.Update (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (int num
                      )
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), num);
                session.Delete (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<LineaPedidoEN> DameALL (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LineaPedidoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                else
                        result = session.CreateCriteria (typeof(LineaPedidoNH)).List<LineaPedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DsmGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DsmGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
