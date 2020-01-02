using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTask.Repository
{
    class EFCategoryRepository
    {
        private ProductDBContext _db;
        private bool disposed = false;

        public EFCategoryRepository(ProductDBContext db)
        {
            if (db != null)
                _db = db;
            else
                throw new ArgumentNullException();
        }

        public void Create(Category item)
        {
            _db.Categories.Add(item);
        }

        public void Delete(int id)
        {
            Category item = _db.Categories.Find(id);
            if (item == null)
                _db.Categories.Remove(item);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            return _db.Categories.Find(id);
        }

        public IEnumerable<Category> GetList()
        {
            return _db.Categories;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
