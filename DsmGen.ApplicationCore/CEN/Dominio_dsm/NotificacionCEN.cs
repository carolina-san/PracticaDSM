

using System;
using System.Text;
using System.Collections.Generic;

using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
/*
 *      Definition of the class NotificacionCEN
 *
 */
public partial class NotificacionCEN
{
private INotificacionRepository _INotificacionRepository;

public NotificacionCEN(INotificacionRepository _INotificacionRepository)
{
        this._INotificacionRepository = _INotificacionRepository;
}

public INotificacionRepository get_INotificacionRepository ()
{
        return this._INotificacionRepository;
}

public int Nueva (string p_texto, string p_usuario, int p_pedido)
{
        NotificacionEN notificacionEN = null;
        int oid;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Texto = p_texto;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                notificacionEN.Usuario = new DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN ();
                notificacionEN.Usuario.Email = p_usuario;
        }


        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids id
                notificacionEN.Pedido = new DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN ();
                notificacionEN.Pedido.Id = p_pedido;
        }



        oid = _INotificacionRepository.Nueva (notificacionEN);
        return oid;
}

public void Eliminar (int id
                      )
{
        _INotificacionRepository.Eliminar (id);
}

public NotificacionEN DameOID (int id
                               )
{
        NotificacionEN notificacionEN = null;

        notificacionEN = _INotificacionRepository.DameOID (id);
        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> DameAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> list = null;

        list = _INotificacionRepository.DameAll (first, size);
        return list;
}
}
}
