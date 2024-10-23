

using DsmGen.ApplicationCore.IRepository.Dominio_dsm;
using DsmGen.Infraestructure.Repository.Dominio_dsm;
using DsmGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace DsmGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IPedidoRepository PedidoRepository {
        get
        {
                this.pedidorepository = new PedidoRepository ();
                this.pedidorepository.setSessionCP (session);
                return this.pedidorepository;
        }
}

public override ILineaPedidoRepository LineaPedidoRepository {
        get
        {
                this.lineapedidorepository = new LineaPedidoRepository ();
                this.lineapedidorepository.setSessionCP (session);
                return this.lineapedidorepository;
        }
}

public override IUsuario_adminRepository Usuario_adminRepository {
        get
        {
                this.usuario_adminrepository = new Usuario_adminRepository ();
                this.usuario_adminrepository.setSessionCP (session);
                return this.usuario_adminrepository;
        }
}

public override IArticuloRepository ArticuloRepository {
        get
        {
                this.articulorepository = new ArticuloRepository ();
                this.articulorepository.setSessionCP (session);
                return this.articulorepository;
        }
}

public override IFotoRepository FotoRepository {
        get
        {
                this.fotorepository = new FotoRepository ();
                this.fotorepository.setSessionCP (session);
                return this.fotorepository;
        }
}

public override IMarcaRepository MarcaRepository {
        get
        {
                this.marcarepository = new MarcaRepository ();
                this.marcarepository.setSessionCP (session);
                return this.marcarepository;
        }
}

public override IDireccionRepository DireccionRepository {
        get
        {
                this.direccionrepository = new DireccionRepository ();
                this.direccionrepository.setSessionCP (session);
                return this.direccionrepository;
        }
}

public override IResenyaRepository ResenyaRepository {
        get
        {
                this.resenyarepository = new ResenyaRepository ();
                this.resenyarepository.setSessionCP (session);
                return this.resenyarepository;
        }
}

public override ICodigo_promocionalRepository Codigo_promocionalRepository {
        get
        {
                this.codigo_promocionalrepository = new Codigo_promocionalRepository ();
                this.codigo_promocionalrepository.setSessionCP (session);
                return this.codigo_promocionalrepository;
        }
}

public override INotificacionRepository NotificacionRepository {
        get
        {
                this.notificacionrepository = new NotificacionRepository ();
                this.notificacionrepository.setSessionCP (session);
                return this.notificacionrepository;
        }
}

public override ICarritoRepository CarritoRepository {
        get
        {
                this.carritorepository = new CarritoRepository ();
                this.carritorepository.setSessionCP (session);
                return this.carritorepository;
        }
}
}
}

