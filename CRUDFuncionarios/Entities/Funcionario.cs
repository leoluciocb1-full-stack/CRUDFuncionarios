using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUDFuncionarios.Entities
{
    public class Funcionario
    {
        private Guid _id = Guid.NewGuid();
        private string _nome = string.Empty;
        private string _matricula = string.Empty;
        private string _cpf = string.Empty;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 10 || value.Length > 150)
                    throw new Exception("Nome deve ter entre 10 e 150 caracteres.");

                _nome = value;
            }
        }

        public string Matricula
        {
            get { return _matricula; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 6 || !value.All(char.IsDigit))
                    throw new Exception("Matrícula deve conter exatamente 6 números.");

                _matricula = value;
            }
        }

        public string Cpf
        {
            get { return _cpf; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 11 || !value.All(char.IsDigit))
                    throw new Exception("CPF deve conter exatamente 11 números.");

                _cpf = value;
            }
        }
    }
}