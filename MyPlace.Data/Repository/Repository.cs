using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Myplace.Data;
using MyPlace.Negocios;

namespace MyPlace.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MyPlaceDbContext db;
        protected readonly DbSet<TEntity> dbSet;

        protected Repository(MyPlaceDbContext db){
            this.db = db;
            this.dbSet = db.Set<TEntity>();
        }

        public virtual async Task Adicionar(TEntity obj)
        {
            dbSet.Add(obj);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity obj)
        {
            dbSet.Update(obj);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return await dbSet.AsNoTracking()
                                .Where(predicado)
                                .ToListAsync();
        }

        public void Dispose()
        {
            db?.Dispose();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            TEntity tentity = new TEntity{id = id};

            dbSet.Remove(tentity);
            await db.SaveChangesAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await db.SaveChangesAsync();
        }
    }
}