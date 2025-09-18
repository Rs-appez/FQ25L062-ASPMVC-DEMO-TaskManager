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

namespace TaskManager.DAL.Services
{
    public class ManagedTaskService : BaseService, ITaskRepository<ManagedTask>
    {
        public ManagedTaskService(IConfiguration configuration, string connectionStringName) : base(configuration, "localDb")
        {
        }

        public bool Delete(Guid taskId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Task_Delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(taskId), taskId);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public IEnumerable<ManagedTask> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Task_Get_All";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new ManagedTask()
                            {
                                TaskId = (Guid)reader[nameof(ManagedTask.TaskId)],
                                Title = (string)reader[nameof(ManagedTask.Title)],
                                Description = (reader[nameof(ManagedTask.Description)] is DBNull) ? null : (string)reader[nameof(ManagedTask.Description)],
                                CreationDate = (DateTime)reader[nameof(ManagedTask.CreationDate)],
                                CreatorId = (Guid)reader[nameof(ManagedTask.CreatorId)],
                                DeadLine = (reader[nameof(ManagedTask.DeadLine)] is DBNull) ? null : (DateTime)reader[nameof(ManagedTask.DeadLine)]
                            };
                        }
                    }
                }
            }
        }

        public ManagedTask Get(Guid taskId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Task_Get";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(taskId), taskId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ManagedTask()
                            {
                                TaskId = (Guid)reader[nameof(ManagedTask.TaskId)],
                                Title = (string)reader[nameof(ManagedTask.Title)],
                                Description = (reader[nameof(ManagedTask.Description)] is DBNull) ? null : (string)reader[nameof(ManagedTask.Description)],
                                CreationDate = (DateTime)reader[nameof(ManagedTask.CreationDate)],
                                CreatorId = (Guid)reader[nameof(ManagedTask.CreatorId)],
                                DeadLine = (reader[nameof(ManagedTask.DeadLine)] is DBNull) ? null : (DateTime)reader[nameof(ManagedTask.DeadLine)]
                            };
                        }
                        throw new ArgumentOutOfRangeException(nameof(taskId));
                    }
                }
            }
        }

        public Guid Insert(ManagedTask entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Task_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(entity.Title), entity.Title);
                    command.Parameters.AddWithValue(nameof(entity.Description), entity.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue(nameof(entity.CreationDate), entity.CreationDate);
                    command.Parameters.AddWithValue(nameof(entity.CreatorId), entity.CreatorId);
                    command.Parameters.AddWithValue(nameof(entity.DeadLine), entity.DeadLine ?? (object)DBNull.Value);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }

        public bool Update(Guid taskId, ManagedTask entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Task_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(taskId), taskId);
                    command.Parameters.AddWithValue(nameof(entity.Title), entity.Title);
                    command.Parameters.AddWithValue(nameof(entity.Description), entity.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue(nameof(entity.CreationDate), entity.CreationDate);
                    command.Parameters.AddWithValue(nameof(entity.DeadLine), entity.DeadLine ?? (object)DBNull.Value);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
