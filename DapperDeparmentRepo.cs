using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Dapper;

namespace Best_buy_Dapper
{
    class DapperDeparmentRepo : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        public DapperDeparmentRepo(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }

        public IEnumerable<Department> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }
        public void UpdateDepartment(string name, int id)
        {
            _connection.Execute("UPDATE departments SET (@name) WHERE Departmentid = @id;",
                new { name = name, id = id });

        }
    }
}
