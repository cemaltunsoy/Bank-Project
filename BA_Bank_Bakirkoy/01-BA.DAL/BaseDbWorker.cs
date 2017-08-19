using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BA.DAL
{
    public class BaseDbWorker<T> : ICRUD<T>, IListEntity<T> where T : class
    {
        public BA_BankDbContext db;
        public virtual void Insert(T entity)
        {
            using (db = new BA_BankDbContext())
            {
                bool saveFailed = false;
                do
                {
                    try
                    {
                        db.Set<T>().Add(entity);
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;
                        ex.Entries.Single().Reload();
                    }
                } while (saveFailed);

            }

        }

        public virtual void Update(T entity)
        {
            using (db = new BA_BankDbContext())
            {
                bool saveFailed = false;
                do
                {
                    try
                    {
                        db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;
                        ex.Entries.Single().Reload();

                        // Update original values from the database 
                        //var entry = ex.Entries.Single();
                        //entry.OriginalValues.SetValues(entry.GetDatabaseValues()); 
                    }
                } while (saveFailed);

            }
        }

        public void Delete(T entity)
        {
            using (db = new BA_BankDbContext())
            {
                bool saveFailed = false;
                do
                {
                    try
                    {
                        db.Set<T>().Remove(entity);
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;
                        ex.Entries.Single().Reload();
                    }
                } while (saveFailed);
            }
        }

        public void SaveChanges()
        {
            try
            {
                using (db = new BA_BankDbContext())
                {
                    db.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public virtual List<T> GetAll()
        {
            using (db = new BA_BankDbContext())
            {
                bool saveFailed = false;
                do
                {
                    try
                    {
                        return db.Set<T>().ToList();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;
                        throw;
                    }
                } while (saveFailed);
            }
        }

        public T GetById(int Id)
        {
            using (db = new BA_BankDbContext())
            {
                bool saveFailed = false;
                do
                {
                    try
                    {
                        return db.Set<T>().Find(Id);
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;
                        throw;
                    }
                } while (saveFailed);
            }
        }

        public virtual List<T> GetByAll(System.Linq.Expressions.Expression<Func<T, bool>> exprs)
        {
            using (db = new BA_BankDbContext())
            {
                bool saveFailed = false;
                do
                {
                    try
                    {
                        return db.Set<T>().Where(exprs).ToList();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;
                        throw;
                    }
                } while (saveFailed);
            }
        }
    }
}
