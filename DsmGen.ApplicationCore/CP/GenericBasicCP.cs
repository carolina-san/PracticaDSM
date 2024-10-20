

using System;
using System.Collections.Generic;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;
using DsmGen.ApplicationCore.Utils;

namespace DsmGen.ApplicationCore.CP.Dominio_dsm
{
public abstract class GenericBasicCP
{
protected GenericSessionCP CPSession;
protected GenericUnitOfWorkRepository unitRepo;
protected GenericUnitOfWorkUtils unitUtils;

protected GenericBasicCP (GenericSessionCP currentSession)
{
        this.CPSession = currentSession;
        this.unitRepo = this.CPSession.UnitRepo;
}
protected GenericBasicCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
{
        this.CPSession = currentSession;
        this.unitRepo = this.CPSession.UnitRepo;
        this.unitUtils = unitUtils;
}
protected GenericBasicCP()
{
        this.CPSession = null;
        this.unitRepo = null;
}
}
}

