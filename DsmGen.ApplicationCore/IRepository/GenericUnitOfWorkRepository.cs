
using System;
using System.Collections.Generic;
using System.Text;

namespace DsmGen.ApplicationCore.IRepository.Dominio_dsm
{
public abstract class GenericUnitOfWorkRepository
{
protected IUsuarioRepository usuariorepository;
protected IPedidoRepository pedidorepository;
protected ILineaPedidoRepository lineapedidorepository;
protected IUsuario_adminRepository usuario_adminrepository;
protected IArticuloRepository articulorepository;
protected IFotoRepository fotorepository;
protected IMarcaRepository marcarepository;
protected IDireccionRepository direccionrepository;


public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IPedidoRepository PedidoRepository {
        get;
}
public abstract ILineaPedidoRepository LineaPedidoRepository {
        get;
}
public abstract IUsuario_adminRepository Usuario_adminRepository {
        get;
}
public abstract IArticuloRepository ArticuloRepository {
        get;
}
public abstract IFotoRepository FotoRepository {
        get;
}
public abstract IMarcaRepository MarcaRepository {
        get;
}
public abstract IDireccionRepository DireccionRepository {
        get;
}
}
}
