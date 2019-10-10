using SpellsReference.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace SpellsReference.Data
{
    public class Context : DbContext, IContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Spellbook> Spellbooks { get; set; }
        public DbSet<Spell> Spells { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Spellbook>()
                .HasMany<Spell>(sb => sb.Spells)
                .WithMany(s => s.Spellbooks)
                .Map(cs =>
                {
                    cs.MapLeftKey("SpellbookId");
                    cs.MapRightKey("SpellId");
                    cs.ToTable("SpellbookSpell");
                });
        }

        /// <summary>
        /// This method updates a row in the database through an entity represented by 
        /// the input parameters.
        /// 
        /// The parameters must follow the following order:
        /// {`property1 name`, `property1 value`, `property2 name`, `property2 value`, ...}
        /// Having an odd number of parameters causes an exception to be thrown.
        /// 
        /// NOTE: This method temporarily disables automatic validation to allow partially
        /// initialized entities to be updated (e.g. Properties with the Required attribute 
        /// can be left null). Since automatic validation is disabled, all input parameters
        /// MUST be manually validated prior to calling this method.
        /// </summary>
        /// <typeparam name="TEntityType">The type of the entity to update.</typeparam>
        /// <param name="id">The primary key Id of the entity.</param>
        /// <param name="parameters">The array of property names and values to update.</param>
        public void UpdateEntity<TEntityType>(int id, params object[] parameters)
        {
            if (parameters.Count() % 2 != 0)
            {
                throw new ArgumentException("Invalid number of parameters");
            }

            Type entityType = typeof(TEntityType);
            TEntityType entity = Activator.CreateInstance<TEntityType>();
            entityType.GetProperty("Id").SetValue(entity, id);
            var set = Set(entityType);
            set.Attach(entity);
            for (int index = 0; index < parameters.Length; index += 2)
            {
                var parameterName = (string)parameters[index];
                var parameterValue = parameters[index + 1];

                entityType.GetProperty(parameterName).SetValue(entity, parameterValue);
                Entry((object)entity).Property(parameterName).IsModified = true;
            }

            Configuration.ValidateOnSaveEnabled = false;
            SaveChanges();
            Configuration.ValidateOnSaveEnabled = true;

        }

        /// <summary>
        /// This method updates a row in the database through an input instance of an 
        /// entity. The entity must have a valid Id property, and all other properties
        /// must pass automatic validation.
        /// 
        /// </summary>
        /// <typeparam name="TEntityType">The type of the entity to update.</typeparam>
        /// <param name="context">The Context object for updating the database.</param>
        /// <param name="entity">The entity to update.</param>
        public void UpdateEntity<TEntityType>(TEntityType entity)
            where TEntityType : class
        {
            Type entityType = typeof(TEntityType);
            if (entityType.GetProperty("Id").GetValue(entity) == null)
            {
                throw new ArgumentException("Entity does not have an ID");
            }
            var dbSet = Set<TEntityType>();
            dbSet.Attach(entity);
            Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }
    }
}