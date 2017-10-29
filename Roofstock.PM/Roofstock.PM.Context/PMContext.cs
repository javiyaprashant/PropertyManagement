using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Roofstock.PM.Domain;
using System.Threading;

namespace Roofstock.PM.Context
{
    public class PMContext : DbContext
    {
        const string CONTEXT_NAME = "PropertyManagement";

        private string identity;

        public PMContext() : base(CONTEXT_NAME) { }

        public PMContext(string connectionString) : base(connectionString) { }

        public void ForceIdentity(string name)
        {
            identity = name;
        }

        public DbSet<Property> Properties { get; set; }

        public override int SaveChanges()
        {
            var user = identity ?? Thread.CurrentPrincipal.Identity.Name ?? string.Empty;
            var now = DateTime.Now;

            foreach (var item in ChangeTracker.Entries().Where(s =>
                                     s.State == EntityState.Added ||
                                     s.State == EntityState.Deleted ||
                                     s.State == EntityState.Modified))
            {
                var entityState = item.State;
                var entity = (Entity)item.Entity;

                if (item.State == EntityState.Added)
                {
                    entity.CreatedBy = user;
                    entity.CreatedDate = now;

                }
                item.State = entityState;

            }

            var errorCode = default(int);

            try
            {                
                errorCode = base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            { 
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }

                    throw;
                }
            }
            return errorCode;
        }
    }   
}
