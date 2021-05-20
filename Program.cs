﻿using Dapper;
using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace Best_buy_Dapper
{
    class Program
    {
        static void Main(string[] args)
        {

            
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);


            var repo = new DapperDeparmentRepo(conn);

            var departments = repo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"DepartmentsID: {dept.DepartmentID}");

                Console.WriteLine($"Name: {dept.Name}");

                Console.WriteLine();

                Console.WriteLine();
            }

            repo.InsertDepartment("Test Department");

            var depRepo = new DapperProductRepository(conn);

            depRepo.CreateProduct("newStuff", 20, 1);

            var products = depRepo.GetAllProducts(); // belongs to the instance of the DapperProductRepository class

            foreach (var prod in products)
            {
                Console.WriteLine(prod.Name);
            }

        }
    }
}
