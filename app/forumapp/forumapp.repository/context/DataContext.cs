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
        public DataContext() : base("conn")
        {
            Database.SetInitializer<DataContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Criação
            //base.OnModelCreating(modelBuilder);

            //Configuração
            //modelBuilder.Configurations.Add(new ModelConfiguration());
        }

        //Declaração dos Dbs Ses
        //public DbSet<model> Model { get; set; }



        #region ## Controle de Transações

        /// <summary>
        /// Mantém um objeto interno de controle de transação
        /// </summary>
        private DbContextTransaction _InnerTransaction;

        /// <summary>
        /// Inicia uma transação com o Entity
        /// </summary>
        public DbContextTransaction BeginTransaction()
        {
            _InnerTransaction = base.Database.BeginTransaction();
            return _InnerTransaction;
        }

        /// <summary>
        /// Commit uma transação com o Entity
        /// </summary>
        public void Commit()
        {
            try
            {
                if (_InnerTransaction == null)
                    throw new InvalidOperationException("Transação não iniciada!");

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
        /// Rollback em uma transação do Entity
        /// </summary>
        public void Rollback()
        {
            try
            {
                if (_InnerTransaction == null)
                    throw new InvalidOperationException("Transação não iniciada!");

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
        /// Atualiza as referencias das classes
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
