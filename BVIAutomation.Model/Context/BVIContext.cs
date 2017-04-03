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
            MapEntity<Entities.System>(modelBuilder, BuildSystem);
            MapEntity<Module>(modelBuilder, BuildModule);
            MapEntity<User>(modelBuilder, BuildUser);

            base.OnModelCreating(modelBuilder);
        }

        private int BuildSystem(DbModelBuilder modelBuilder, int index)
        {
            modelBuilder.Entity<Entities.System>()
               .Property(_ => _.FcName)
               .HasColumnOrder(++index)
               .IsRequired()
               .HasColumnType("varchar(255)");

            return index;
        }

        private int BuildModule(DbModelBuilder modelBuilder, int index)
        {
            var entityConfig = modelBuilder.Entity<Module>();

            entityConfig
               .Property(_ => _.IdSystem)
               .HasColumnOrder(++index)
               .IsRequired();

            entityConfig
                .Property(_ => _.IdModule)
                .HasColumnOrder(++index)
                .IsRequired();

            entityConfig
               .Property(_ => _.FcName)
               .HasColumnOrder(++index)
               .IsRequired()
               .HasColumnType("varchar(255)");

            return index;
        }       

        private int BuildUser(DbModelBuilder modelBuilder, int index)
        {
            var entityConfig = modelBuilder.Entity<User>();

            entityConfig
              .Property(_ => _.IdUserProfile)
              .HasColumnOrder(++index)
              .IsRequired();

            entityConfig
                .Property(_ => _.FcName)
               .HasColumnOrder(++index)
               .IsRequired()
               .HasColumnType("varchar(255)");

            entityConfig
               .Property(_ => _.FcEmail)
               .HasColumnOrder(++index)
               .IsRequired()
               .HasColumnType("varchar(255)");

            entityConfig
              .Property(_ => _.FdLastLogin)
              .HasColumnOrder(++index)
              .IsRequired();

            return index;
        }

        private void MapEntity<T>(DbModelBuilder modelBuilder, Func<DbModelBuilder, int, int> EntityMapAction
            , int index = 0)
            where T : EntityBase
        {
            SetPrimaryKey<T>(modelBuilder);

            BuildEntityBase<T>(modelBuilder, EntityMapAction(modelBuilder, index));
        }
       
        private void SetPrimaryKey<T>(DbModelBuilder modelBuilder)
            where T : EntityBase
        {
            var entityTypeConfig = modelBuilder.Entity<T>();

            entityTypeConfig
              .HasKey(_ => _.Id);

            entityTypeConfig
               .Property(_ => _.Id)
              .HasColumnOrder(0)
              .IsRequired()
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        private void BuildEntityBase<T>(DbModelBuilder modelBuilder, int index) 
            where T : EntityBase
        {
            var entityTypeConfig = modelBuilder.Entity<T>();

            entityTypeConfig
                .Property(_ => _.IdUserInc)
                .HasColumnOrder(++index)
                .IsRequired();

            entityTypeConfig
               .Property(_ => _.IdUserAlt)
               .HasColumnOrder(++index)
               .IsRequired();

            entityTypeConfig
               .Property(_ => _.FdInc)
               .HasColumnOrder(++index)
               .IsRequired();

            entityTypeConfig
               .Property(_ => _.FdAlt)
               .HasColumnOrder(++index)
               .IsRequired();

            entityTypeConfig
               .Property(_ => _.FbStatus)
               .HasColumnOrder(++index)
               .IsRequired();
        }
    }
}
