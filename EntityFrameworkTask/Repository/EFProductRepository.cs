using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTask
{
    class EFProductRepository : IRepository<Product>
    {
        private ProductDBContext _db;
        private bool disposed = false;

        public EFProductRepository(ProductDBContext db)
        {
            if (db != null)
                _db = db;
            else
                throw new ArgumentNullException();
        }

        public void Create(Product item)
        {
            _db.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product item = _db.Products.Find(id);
            if (item == null)
                _db.Products.Remove(item);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            return _db.Products.Find(id);
        }

        public IEnumerable<Product> GetList()
        {
            return _db.Products;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
