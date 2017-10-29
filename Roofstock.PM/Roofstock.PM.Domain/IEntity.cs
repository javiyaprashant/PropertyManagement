using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roofstock.PM.Domain
{
    public interface IEntity
    {
        string CreatedBy { get; }

        DateTime CreatedDate { get; }
    }
}
