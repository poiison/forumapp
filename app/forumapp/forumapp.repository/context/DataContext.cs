using forumapp.entity.db;
using forumapp.repository.entityconfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.repository.context
{
    public class DataContext : DbContext
    {
        public DataContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\projetos\ForumApp\app\forumapp\forumapp.repository\db\Database1.mdf;Integrated Security=True")
        {
            Database.SetInitializer<DataContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }

        //Dataset
        public DbSet<dbCategory> Category { get; set; }



        #region ## Controle de Transações

        /// <summary>
        /// Transaction Object
        /// </summary>
        private DbContextTransaction _InnerTransaction;

        /// <summary>
        /// Begins a transaction
        /// </summary>
        public DbContextTransaction BeginTransaction()
        {
            _InnerTransaction = base.Database.BeginTransaction();
            return _InnerTransaction;
        }

        /// <summary>
        /// Commit transaction
        /// </summary>
        public void Commit()
        {
            try
            {
                if (_InnerTransaction == null)
                    throw new InvalidOperationException("Transaction not started!");

                _InnerTransaction.Commit();

                base.SaveChanges();

            }
            finally
            {
                if (_InnerTransaction != null)
                {
                    _InnerTransaction.Dispose();
                }
                _InnerTransaction = null;
            }

        }

        /// <summary>
        /// Rollback 
        /// </summary>
        public void Rollback()
        {
            try
            {
                if (_InnerTransaction == null)
                    throw new InvalidOperationException("Transaction not started!");

                _InnerTransaction.Rollback();
            }
            finally
            {
                if (_InnerTransaction != null)
                {
                    _InnerTransaction.Dispose();
                }
                _InnerTransaction = null;
            }
        }

        /// <summary>
        /// Refresh
        /// </summary>
        public void RefreshAll()
        {
            foreach (var entity in base.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }

        #endregion
    }
}
