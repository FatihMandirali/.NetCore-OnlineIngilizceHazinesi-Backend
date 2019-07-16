using Core.CommonRepository;
using Core.DataBaseContext;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.KelimelerRepository
{
   public class KelimeRepository : Repository<Kelimeler>, IKelimeRepository
    {
        public KelimeRepository(OnlineDatabaseContext context) : base(context)
        {
        }
    }
}
