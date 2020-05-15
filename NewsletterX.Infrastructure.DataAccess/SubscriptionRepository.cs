using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NewsletterX.Core.Domain.Model;
using NewsletterX.Core.Domain.Service;

namespace NewsletterX.Infrastructure.DataAccess
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public Task<bool> Create(Subscription subscription)
        {
            //string connStr = "";
            //var conn = new SqlConnection(connStr);
            //conn.ExecuteAsync("INSERT INTO Registrations (Email, Code) VALUES (@Email, @Code)")
            return Task.FromResult(true);
        }

        public Task<Subscription> ReadByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
