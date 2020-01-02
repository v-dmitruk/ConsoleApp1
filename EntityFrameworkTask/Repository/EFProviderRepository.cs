using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTask
{
    class EFProviderRepository
    {
        private ProductDBContext _db;
        private bool disposed = false;

        public EFProviderRepository(ProductDBContext db)
        {
            if (db != null)
                _db = db;
            else
                throw new ArgumentNullException();
        }

        public void Create(Provider item)
        {
            _db.Providers.Add(item);
        }

        public void Delete(int id)
        {
            Provider item = _db.Providers.Find(id);
            if (item == null)
                _db.Providers.Remove(item);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Provider Get(int id)
        {
            return _db.Providers.Find(id);
        }

        public IEnumerable<Provider> GetList()
        {
            return _db.Providers;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Provider item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
