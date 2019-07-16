using Core.CommonRepository;
using Core.DataBaseContext;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.KullanicilarRepository
{
   public class KullaniciRepository : Repository<Kullanicilar>, IKullaniciRepository
    {
        public KullaniciRepository(OnlineDatabaseContext context) : base(context)
        {
        }
    }
}
