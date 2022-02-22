using System;
using System.Threading;

namespace EncontroRemoto
{   
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(@$"
========================================
|    Bem vindo ao sistema de cadastro  |
|    de pessoa física e jurídica       |
========================================
");

            BarraCarregamento("Iniciando");

            string? opcao;

            do
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(@$"
=====================================        
|   Escolha uma das opções abaixo   |
|                                   |
|        1 - Pessoa Física          |   
|        2 - Pessoa Jurídica        |
|                                   |
|        0 - Sair                   |
===================================== 
");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        {
                            Endereco endpf = new Endereco();
                            endpf.logradouro = "X";
                            endpf.numero = 100;
                            endpf.complemento = "Próximo ao Senai";
                            endpf.enderecoComercial = false;

                            PessoaFisica novapf = new PessoaFisica();

                            novapf.endereco = endpf;
                            novapf.cpf = "123456789";
                            novapf.rendimento = 1500;
                            novapf.dataNascimento = new DateTime(1995, 08, 05);
                            novapf.nome = "Eduardo";
                            
                            

                            PessoaFisica pf = new PessoaFisica();
                            //pf.ValidarDataNascimento(pf.dataNascimento);
                            
                            Console.WriteLine(pf.PagarImposto(novapf.rendimento).ToString("N2")); 
                            
                            bool idadeValida = pf.ValidarDataNascimento(novapf.dataNascimento);
                            Console.WriteLine(idadeValida);
                            
                            if (idadeValida == true)
                            {
                                Console.WriteLine($"Cadastro Aprovado.");
                            }
                            else
                            {
                                Console.WriteLine($"Cadastro Não Aprovado.");
                            }

                            //Console.WriteLine(pf.ValidarDataNascimento(novapf.dataNascimento));
                            //Console.WriteLine(novapf.endereco.logradouro);
                            //Console.WriteLine(novapf.endereco.numero);
                            //Console.WriteLine(novapf.endereco.complemento);
                            //Console.WriteLine(novapf.endereco.enderecoComercial);
                            //Console.WriteLine($"Rua: {novapf.endereco.logradouro}, {novapf.endereco.numero}");
                            //Console.WriteLine("Rua: " + novapf.endereco.logradouro + novapf.endereco.numero); 
                            break;
                        }

                    case"2":
                        {
                            PessoaJuridica pj = new PessoaJuridica();
                            PessoaJuridica novapj = new PessoaJuridica();

                            Endereco endpj = new Endereco();
                            endpj.logradouro = "X";
                            endpj.numero = 100;
                            endpj.complemento = "Próximo ao Senai";
                            endpj.enderecoComercial = true;

                            novapj.endereco = endpj;
                            novapj.cnpj = "11123456790001";
                            novapj.rendimento = 8000;
                            novapj.razaoSocial = "Pessoa Jurídica";

                            Console.WriteLine(pj.PagarImposto(pj.rendimento).ToString("N2")); 

                            if (pj.ValidarCNPJ(novapj.cnpj))
                            {
                                Console.WriteLine("CNPJ Válido.");
                            }
                            else
                            {
                                Console.WriteLine("CNPJ inválido.");

                            }
                            break;
                        }
        
                    case "0":
                        {   
                            Console.WriteLine($"Obrigado por utilizar o sistema. ");
                            BarraCarregamento("Finalizando...");
                            Thread.Sleep(500);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine($"Opção inválida, digite uma opção válida.");
                            break;        
                        }
                }
            }while (opcao != "0") ;
        }

        static void BarraCarregamento(string textoCarregamento)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(textoCarregamento);
            Thread.Sleep(500);
            
            for (var contador = 0; contador < 10; contador++)
            {
                Console.Write($".");
                Thread.Sleep(500);
                
            }
            Console.ResetColor();
        }
    }
}