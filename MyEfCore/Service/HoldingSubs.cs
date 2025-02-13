using Castle.Core.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyEfCore.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Service
{
    public class HoldingSubs
    {

        public void Add()
        {
            using (Context db = new Context())
            {
                string n = "ИП Какой-то";
                var transaction = db.Database.BeginTransaction();
                try
                {
                    var subs = db.Database.ExecuteSqlInterpolated($"pSubs {n}, {1}");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Edit()
        {
            using (Context db = new Context())
            {
                string n = "ИП Какой-то";
                string newN = "ИП Никакой";
                var transaction = db.Database.BeginTransaction();
                try
                {
                    var subs = db.Database.ExecuteSqlInterpolated($"pSubs;2 {n}, {newN}");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Delete()
        {
            using (Context db = new Context())
            {
                string n = "ИП Никакой";
                var transaction = db.Database.BeginTransaction();
                try
                {   
                    SqlParameter p = new SqlParameter("@name", n);
                    var subs = db.Database.ExecuteSqlRaw("pSubs;3 @name", p);
              
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

    }
}
