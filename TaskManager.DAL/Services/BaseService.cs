using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Services
{
    public abstract class BaseService
    {
        protected readonly string _connectionString;

        public BaseService (IConfiguration configuration, string connectionStringName)
        {
            _connectionString = configuration.GetConnectionString(connectionStringName);
        }
    }
}
