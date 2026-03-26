using CRUDFuncionarios.Entities;
using CRUDFuncionarios.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDFuncionarios.Controllers
{
    /// <summary>
    /// Controlador para implementar os fluxos de entrada de dados
    /// do usuário para cadastrar, alterar, consultar e excluir
    /// funcionarios no sistema.
    /// </summary>
    public class FuncionarioController
    {
        private FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        public void GerenciarFuncionarios()
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE FUNCIONÁRIOS:\n");
            Console.WriteLine("\t(1) CADASTRAR FUNCIONÁRIO");
            Console.WriteLine("\t(2) ATUALIZAR FUNCIONÁRIO");
            Console.WriteLine("\t(3) EXCLUIR FUNCIONÁRIO");
            Console.WriteLine("\t(4) CONSULTAR FUNCIONÁRIOS");
            Console.Write("\nINFORME A OPÇÃO DESEJADA: ");

            var opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1": CadastrarFuncionario(); break;
                case "2": AtualizarFuncionario(); break;
                case "3": ExcluirFuncionario(); break;
                case "4": ConsultarFuncionario(); break;
                default:
                    Console.WriteLine("\nOPÇÃO INVÁLIDA!");
                    break;
            }
            Console.Write("\nDESEJA EXECUTAR OUTRA OPERAÇÃO? (S,N): ");
            var confirmacao = Console.ReadLine();
            if (confirmacao.ToUpper().Equals("S"))
            {
                Console.Clear(); //Limpar o console do DOS
                GerenciarFuncionarios(); //Recursividade
            }
            else
            {
                Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }
        private void CadastrarFuncionario()
        {
            Console.WriteLine("\nCADASTRO DE FUNCIONARIO:\n");
            var funcionario = new Funcionario();
            Console.Write("NOME DO FUNCIONARIO.........: ");
            funcionario.Nome = Console.ReadLine();
            Console.Write("MATRÍCULA...................: ");
            funcionario.Matricula = Console.ReadLine();
            Console.Write("CPF.........................: ");
            funcionario.Cpf = Console.ReadLine();
            funcionarioRepository.Inserir(funcionario);
            Console.WriteLine("\nFUNCIONÁRIO CADASTRADO COM SUCESSO!");
        }
        private void AtualizarFuncionario()
        {
            Console.WriteLine("\nATUALIZAÇÂO DE FUNCIONÁRIO:\n");
            Console.Write("INFORME O ID DO FUNCIONÁRIO.....: ");

            if (!Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                Console.WriteLine("\nID inválido! Verifique o correto no item (4) CONSULTAR FUNCIONÁRIOS");
                return; // volta para o menu
            }

            var funcionario = funcionarioRepository.ObterPorId(id);

            if (funcionario != null)
            {
                try
                {
                    Console.Write("NOME DO FUNCIONARIO.........: ");
                    funcionario.Nome = Console.ReadLine();

                    Console.Write("MATRÍCULA...................: ");
                    funcionario.Matricula = Console.ReadLine();

                    Console.Write("CPF.........................: ");
                    funcionario.Cpf = Console.ReadLine();

                    funcionarioRepository.Alterar(funcionario);

                    Console.WriteLine("\nFUNCIONÁRIO ATUALIZADO COM SUCESSO!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nERRO: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("\nNENHUM FUNCIONARIO FOI ENCONTRADO.");
            }
        }
        private void ExcluirFuncionario()
        {
            Console.WriteLine("\nEXCLUSÃO DE FUNCIONARIO:\n");
            Console.Write("INFORME O ID DO FUNCIONARIO....: ");

            if (!Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                Console.WriteLine("\nID inválido! Verifique o correto no item (4) CONSULTAR FUNCIONÁRIOS");
                return; // volta ao menu
            }

            var funcionario = funcionarioRepository.ObterPorId(id);

            if (funcionario != null)
            {
                Console.WriteLine("\tNOME..................: " + funcionario.Nome);
                Console.WriteLine("\tMATRÍCULA.............: " + funcionario.Matricula);
                Console.WriteLine("\tCPF...................: " + funcionario.Cpf);

                Console.Write("\nDESEJA EXCLUIR ESTE FUNCIONÁRIO? (S,N): ");
                var escolha = Console.ReadLine();

                if (escolha.ToUpper().Equals("S"))
                {
                    funcionarioRepository.Excluir(id);
                    Console.WriteLine("\nFUNCIONÁRIO EXCLUIDO COM SUCESSO!");
                }
            }
            else
            {
                Console.WriteLine("\nNENHUM FUNCIONÁRIO FOI ENCONTRADO.");
            }
        }
        private void ConsultarFuncionario()
        {
            var funcionarios = funcionarioRepository.Consultar();
            Console.WriteLine("\nCONSULTA DE FUNCIONÁRIOS:\n");
            foreach (var item in funcionarios)
            {
                Console.WriteLine("ID......................: " + item.Id);
                Console.WriteLine("NOME....................: " + item.Nome);
                Console.WriteLine("MATRÍCULA...............: " + item.Matricula);
                Console.WriteLine("CPF.....................: " + item.Cpf);
                Console.WriteLine("...");
            }
        }
    }
}