using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roofstock.PM.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        PMContext context;
        bool disposed = false;

        public UnitOfWork(PMContext context)
        {
            this.context = context;
        }

        public UnitOfWork()
        {
            context = new PMContext();
        }
        public PMContext Context
        {
            get
            {
                return context;
            }
        }

        public static IUnitOfWork Begin()
        {
            return new UnitOfWork(new PMContext());
        }

        public static void Commit(IUnitOfWork work)
        {
            work.Commit();
        }

        public void Commit()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //saveFailed = true;
                //ex.Entries.Single().Reload();
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void ForceIdentity(string name)
        {
            Context.ForceIdentity(name);
        }

    }
}
