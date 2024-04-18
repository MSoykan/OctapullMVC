using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



namespace DataAccessLayer.Concrete.Repositories {
    public class GenericRepository<T> : IRepository<T> where T : class {

        Context context = new Context();

        DbSet<T> _object;

        public GenericRepository() {
            _object = context.Set<T>();
        }

        //public async Task DeleteAsync(T p) {
        //    _object.Remove(p);
        //    await context.SaveChangesAsync();
        //}

        public async Task Delete(Expression<Func<T, bool>> filter) {
                var deletedEntity = await context.Set<T>().SingleOrDefaultAsync(filter);
                var entity = context.Entry(deletedEntity);
                entity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter) {
            return await context.Set<T>().SingleOrDefaultAsync(filter);
            }

        public async Task AddAsync(T entity) {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> ListAsync() {
            return await _object.ToListAsync();
        }

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> filter) {
            return filter == null
                   ? await context.Set<T>().ToListAsync()
                   : await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task UpdateAsync(T entity) {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> filter) {
            var deletedEntity = await context.Set<T>().SingleOrDefaultAsync(filter);
            var entity = context.Entry(deletedEntity);
            entity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}

//namespace DataAccessLayer.Concrete.Repositories {
//    public class GenericRepository<T> : IRepository<T> where T : class {

//        Context context = new Context();

//        DbSet<T> _object;

//        public GenericRepository() {
//            _object = context.Set<T>();
//        }

//        public void Delete(T p) {
//            _object.Remove(p);
//            context.SaveChanges();
//        }

//        public T Get(Expression<Func<T, bool>> filter) {
//            return _object.SingleOrDefault(filter);
//        }

//        public async Task AddAsync(T entity) {
//            _object.Add(entity);
//            context.SaveChanges();
//            var addedEntity = context.Entry(entity);
//            addedEntity.State = EntityState.Added;
//            await context.SaveChangesAsync();
//        }

//        public List<T> List() {
//            return _object.ToList();
//        }

//        public List<T> List(Expression<Func<T, bool>> filter) {
//            return _object.Where(filter).ToList();
//        }

//        public void Update(T p) {
//            context.SaveChanges();
//        }
//    }
//}
