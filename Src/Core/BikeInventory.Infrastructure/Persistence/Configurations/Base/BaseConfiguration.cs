using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeInventory.Infrastructure.Persistence
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        private EntityTypeBuilder<T> m_EntityTypeBuilder;

        protected virtual string Schema => "dbo";
        protected virtual string TableName => typeof(T).Name;

        protected virtual void KeyBuilder(BaseKeyBuilder<T> builder) 
        {
            var t = typeof(T);
            var idProp = t.GetProperty("ID");

            if (idProp == null)
            {
                idProp = t.GetProperty("Id");
            }

            if (idProp == null)
            {
                idProp = t.GetProperty($"{t.Name}ID");
            }

            if (idProp == null)
            {
                idProp = t.GetProperty($"{t.Name}Id");
            }

            if (idProp != null)
            {
                m_EntityTypeBuilder.Property(idProp.PropertyType, idProp.Name);
                builder.HasKey(idProp.Name);
            }
        }

        protected virtual void ConfigureProperty(BasePropertyBuilder<T> builder) { }
        protected virtual void ConfigureIndex(BaseIndexBuilder<T> builder) { }
        protected virtual void ConfigureRelationship(BaseRelationshipBuilder<T> builder) { }
        protected virtual void SeedData(BaseSeeder<T> builder) { }

        public void LoadSeedDataTo(IQueryable<T> dbSet) => SeedData(new CustomSeederBuilder<T>(dbSet));
        public string GetObjectName() => $"{Schema}.{TableName}";

        protected virtual void ConfigureEntity(EntityTypeBuilder<T> builder) { }

        public void Configure(EntityTypeBuilder<T> builder)
        {
            m_EntityTypeBuilder = builder;
            builder.ToTable(TableName, Schema);

            SetDecimalPrecisions(builder);
            ConfigureProperty(new BasePropertyBuilder<T>(builder));
            KeyBuilder(new BaseKeyBuilder<T>(builder));
            ConfigureIndex(new BaseIndexBuilder<T>(builder));
            ConfigureRelationship(new BaseRelationshipBuilder<T>(builder));
            ConfigureEntity(builder);
            SeedData(new BaseSeeder<T>(builder));
        }

        protected virtual void SetDecimalPrecisions(EntityTypeBuilder<T> builder, int precision = 20, int scale = 6)
        {
            var _properties = typeof(T).GetProperties()
               .Where(p => p.PropertyType == typeof(decimal)
                        || p.PropertyType == typeof(decimal?))
               .Select(a => a.Name)
               .ToList();

            foreach (var _prop in _properties)
            {
                builder.Property(_prop).HasColumnType($"DECIMAL({precision},{scale})");
            }
        }

        protected abstract class BaseBuilder<TEntity> where TEntity : class
        {
            protected readonly EntityTypeBuilder<TEntity> m_Builder;

            protected BaseBuilder(EntityTypeBuilder<TEntity> builder)
            {
                m_Builder = builder;
            }
        }

        protected class BasePropertyBuilder<TEntity> : BaseBuilder<TEntity>
            where TEntity : class
        {
            public BasePropertyBuilder(EntityTypeBuilder<TEntity> builder) : base(builder) { }

            public PropertyBuilder<TProperty> Property<TProperty>([NotNull] Expression<Func<TEntity, TProperty>> propertyExpression)
            {
                return m_Builder.Property(propertyExpression);
            }
            public PropertyBuilder<TProperty> Property<TProperty>([NotNull] string propertyName)
            {
                return m_Builder.Property<TProperty>(propertyName);
            }
        }

        protected class BaseRelationshipBuilder<TEntity> : BaseBuilder<TEntity>
            where TEntity : class
        {
            public BaseRelationshipBuilder(EntityTypeBuilder<TEntity> builder) : base(builder) { }

            public ReferenceNavigationBuilder<TEntity, TRelatedEntity> HasOne<TRelatedEntity>(string navigationName) where TRelatedEntity : class
            {
                return m_Builder.HasOne<TRelatedEntity>(navigationName);
            }

            public ReferenceNavigationBuilder<TEntity, TRelatedEntity> HasOne<TRelatedEntity>(Expression<Func<TEntity, TRelatedEntity>> navigationExpression = null) where TRelatedEntity : class
            {
                return m_Builder.HasOne<TRelatedEntity>(navigationExpression);
            }

            public CollectionNavigationBuilder<TEntity, TRelatedEntity> HasMany<TRelatedEntity>(Expression<Func<TEntity, IEnumerable<TRelatedEntity>>> navigationExpression = null) where TRelatedEntity : class
            {
                return m_Builder.HasMany(navigationExpression);
            }

            public CollectionNavigationBuilder<TEntity, TRelatedEntity> HasMany<TRelatedEntity>(string navigationName) where TRelatedEntity : class
            {
                return m_Builder.HasMany<TRelatedEntity>(navigationName);
            }
        }

        protected class BaseSeeder<TEntity> : BaseBuilder<TEntity>
            where TEntity : class
        {
            private readonly List<TEntity> tempData = new List<TEntity>();
            public IEnumerable<TEntity> Data => tempData;

            public BaseSeeder(EntityTypeBuilder<TEntity> builder) : base(builder) { }

            public virtual void HasData([NotNull] IEnumerable<object> data)
            {
                m_Builder?.HasData(data);
            }

            public virtual void HasData([NotNull] params object[] data)
            {
                m_Builder?.HasData(data);
            }

            public virtual void HasData([NotNull] IEnumerable<TEntity> data)
            {
                tempData.AddRange(data);

                m_Builder?.HasData(data);
            }

            public virtual void HasData([NotNull] params TEntity[] data)
            {
                tempData.AddRange(data);

                m_Builder?.HasData(data);
            }
        }
        protected class CustomSeederBuilder<TEntity> : BaseSeeder<TEntity>
            where TEntity : class
        {
            private readonly DbSet<TEntity> p_Entity;

            public CustomSeederBuilder(IQueryable<TEntity> entity) : base(null)
            {
                p_Entity = (DbSet<TEntity>)entity;
            }

            public override void HasData([NotNull] IEnumerable<TEntity> data)
            {
                p_Entity.AddRange(data);
            }

            public override void HasData([NotNull] params TEntity[] data)
            {
                p_Entity.AddRange(data);
            }

            public override void HasData([NotNull] IEnumerable<object> data)
            {
                throw new NotImplementedException("Not yet implemented");
            }

            public override void HasData([NotNull] params object[] data)
            {
                throw new NotImplementedException("Not yet implemented");
            }
        }


        protected class BaseIndexBuilder<TEntity> : BaseBuilder<TEntity>
            where TEntity : class
        {
            public BaseIndexBuilder(EntityTypeBuilder<TEntity> builder) : base(builder) { }

            public IndexBuilder HasIndex([NotNull] params string[] propertyNames)
            {
                return m_Builder.HasIndex(propertyNames);
            }

            public IndexBuilder<TEntity> HasIndex([NotNull] Expression<Func<TEntity, object>> indexExpression)
            {
                return m_Builder.HasIndex(indexExpression);
            }
        }

        protected class BaseKeyBuilder<TEntity> : BaseBuilder<TEntity>
            where TEntity : class
        {
            public BaseKeyBuilder(EntityTypeBuilder<TEntity> builder) : base(builder) { }

            public KeyBuilder HasKey([NotNull] params string[] propertyNames)
            {
                return m_Builder.HasKey(propertyNames);
            }

            public KeyBuilder HasKey([NotNullAttribute] Expression<Func<TEntity, object>> keyExpression)
            {
                return m_Builder.HasKey(keyExpression);
            }
        }
    }
}


