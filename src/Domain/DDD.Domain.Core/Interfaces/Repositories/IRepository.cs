using System;
using System.Collections.Generic;
using System.Text;

namespace PGLaw.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryFull<T> : IRepositoryRead<T>, IRepositoryWrite<T>
    {
    }
}
