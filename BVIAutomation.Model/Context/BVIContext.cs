using BVIAutomation.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVIAutomation.Model.Context
{
    public class BVIContext : DbContext
    {
        public BVIContext()
            : this("ConnStringProviderName") { }

        private BVIContext(string sConnection)
            : base(sConnection) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            BuildModule<Module>(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void BuildModule<T>(DbModelBuilder modelBuilder, int index = 0) 
            where T : Module
        {       
            SetPrimaryKey<T>(modelBuilder);            

            modelBuilder.Entity<T>()
               .Property(_ => _.IdSystem)
               .HasColumnOrder(++index)
               .IsRequired();

            modelBuilder.Entity<T>()
                .Property(_ => _.IdModule)
                .HasColumnOrder(++index)
                .IsRequired();

            modelBuilder.Entity<T>()
               .Property(_ => _.FcName)
               .HasColumnOrder(++index)
               .IsRequired()
               .HasColumnType("varchar(255)");

            BuildEntityBase<T>(index, modelBuilder);
        }       
        
        private void SetPrimaryKey<T>(DbModelBuilder modelBuilder)
            where T : EntityBase
        {
            modelBuilder.Entity<T>()
              .HasKey(_ => _.Id);

            modelBuilder.Entity<T>()
              .Property(_ => _.Id)
              .HasColumnOrder(0)
              .IsRequired()
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        private void BuildEntityBase<T>(int columnCurrentIndex, DbModelBuilder modelBuilder) 
            where T : EntityBase
        {
            modelBuilder.Entity<T>()
                .Property(_ => _.IdUserInc)
                .HasColumnOrder(columnCurrentIndex++)
                .IsRequired();

            modelBuilder.Entity<T>()
               .Property(_ => _.IdUserAlt)
               .HasColumnOrder(columnCurrentIndex++)
               .IsRequired();

            modelBuilder.Entity<T>()
               .Property(_ => _.FdInc)
               .HasColumnOrder(columnCurrentIndex++)
               .IsRequired();

            modelBuilder.Entity<T>()
               .Property(_ => _.FdAlt)
               .HasColumnOrder(columnCurrentIndex++)
               .IsRequired();

            modelBuilder.Entity<T>()
               .Property(_ => _.FbStatus)
               .HasColumnOrder(columnCurrentIndex)
               .IsRequired();
        }
    }
}
