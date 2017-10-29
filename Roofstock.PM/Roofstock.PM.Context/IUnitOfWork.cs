using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roofstock.PM.Context
{
    public interface IUnitOfWork
    {
        PMContext Context { get; }
        void Commit();
        void ForceIdentity(string name);
    }
}
