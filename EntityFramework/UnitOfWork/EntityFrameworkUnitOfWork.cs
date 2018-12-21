﻿using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;

namespace EntityFrameworkINFR.UnitOfWork
{
    public class EntityFrameworkUnitOfWork : UnitOfWorkBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityFrameworkUnitOfWork" /> class.
        /// </summary>
        public EntityFrameworkUnitOfWork(Func<DbContext> dbContextFactory)
        {
            Context = dbContextFactory?.Invoke() ?? throw new ArgumentException("Db context factory cant be null!");
        }

        /// <summary>
        ///     Gets the <see cref="DbContext" />.
        /// </summary>
        public DbContext Context { get; }

        /// <summary>
        ///     Commits the changes.
        /// </summary>
        protected override async Task CommitCore()
        {
            await Context.SaveChangesAsync();
        }

        public override void Dispose()
        {
            Context.Dispose();
        }
    }
}