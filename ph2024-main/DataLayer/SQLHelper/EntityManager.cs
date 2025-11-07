using System;
using System.Configuration;

namespace DataAccess.Implementation
{
    public class EntityManager : IDisposable
    {
        public static string connectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            }
        }
        public void Dispose()
        {
        }
    }
}
