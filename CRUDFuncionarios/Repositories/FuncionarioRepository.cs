using CRUDFuncionarios.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDFuncionarios.Repositories
{
    public class FuncionarioRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDFuncionarios;Integrated Security=True;";

        public void Inserir(Funcionario funcionario)
        {
            var query = @"
                INSERT INTO FUNCIONARIOS(ID, NOME, MATRICULA, CPF)
                VALUES(@Id, @Nome, @Matricula, @Cpf)
            ";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, funcionario);
            }
        }

        public void Alterar(Funcionario funcionario)
        {
            var query = @"
                UPDATE FUNCIONARIOS 
                SET NOME = @Nome, 
                    MATRICULA = @Matricula,
                    CPF = @Cpf
                WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, funcionario);
            }
        }

        public void Excluir(Guid id)
        {
            var query = @"
                DELETE FROM FUNCIONARIOS 
                WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new { Id = id });
            }
        }

        public List<Funcionario> Consultar()
        {
            var query = @"
                SELECT ID, NOME, MATRICULA, CPF
                FROM FUNCIONARIOS
                ORDER BY NOME ASC
            ";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }

        public Funcionario? ObterPorId(Guid id)
        {
            var query = @"
                SELECT ID, NOME, MATRICULA, CPF
                FROM FUNCIONARIOS
                WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query, new { Id = id }).FirstOrDefault();
            }
        }
    }
}