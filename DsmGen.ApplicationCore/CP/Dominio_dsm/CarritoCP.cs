
using System;
using System.Text;
using System.Collections.Generic;
using DsmGen.ApplicationCore.Exceptions;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;
using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using DsmGen.ApplicationCore.Utils;



namespace DsmGen.ApplicationCore.CP.Dominio_dsm
{
public partial class CarritoCP : GenericBasicCP
{
public CarritoCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public CarritoCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}