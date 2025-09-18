using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Common.Repositories;
using TaskManager.DAL.Entities;
using TaskManager.DAL.Mapper;

namespace TaskManager.DAL.Services
{
    public class UserService : BaseService, IUserRepository<User>
    {
        public UserService(IConfiguration configuration) : base(configuration, "localDb") { }
        
        /* Constructeur pour les tests en console
        public UserService() { }*/
        public IEnumerable<User> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_Get_All";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToUser();
                        }
                    }
                }
            }
        }

        public User Get(Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_Get";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(userId), userId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToUser();
                        }
                        throw new ArgumentOutOfRangeException(nameof(userId));
                    }
                }
            }
        }

        public Guid Insert(User entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(entity.Email), entity.Email);
                    command.Parameters.AddWithValue(nameof(entity.Password), entity.Password);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }

        //public bool Update(Guid userId, User entity)
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand command = connection.CreateCommand())
        //        {
        //            command.CommandText = "SP_User_Update";
        //            command.CommandType = CommandType.StoredProcedure;
        //        }
        //    }
        //}

        public bool Delete(Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_Delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(userId), userId);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public User CheckPassword(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_CheckPassword";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(email), email);
                    command.Parameters.AddWithValue(nameof(password), password);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            return reader.ToUser();
                        }
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}
