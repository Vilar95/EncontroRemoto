using System;
using System.Threading;
using System.Collections.Generic;

namespace EncontroRemoto
{   
    class Program
    {
        static void Main(string[] args)
        {
            List<PessoaFisica> listaPF = new List<PessoaFisica>();
            List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();
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
|           PESSOA FÍSICA           |
|    1 - Cadastrar Pessoa Física    |   
|    2 - Lista Pessoa Física        |
|    3 - Remover Pessoa Física      |
|                                   |
|           PESSOA JURÍDICA         |
|    4 - Cadastrar Pessoa Jurídica  |   
|    5 - Lista Pessoa Jurídica      |
|    6 - Remover Pessoa Jurídica    |
|                                   |
|        0 - Sair                   |
===================================== 
");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        {
                            Endereco endPF = new Endereco();
                            
                            Console.WriteLine($"Digite seu logradouro.");  
                            endPF.logradouro = Console.ReadLine();
                            
                            Console.WriteLine($"Digite o número.");
                            endPF.numero = int.Parse(Console.ReadLine());
                            
                            Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio.)");
                            endPF.complemento = Console.ReadLine();

                            Console.WriteLine($"Este endereço é comercial? S/N.");   
                            string endComercial = Console.ReadLine().ToUpper();
                            
                            if(endComercial == "S")
                            {
                                endPF.enderecoComercial = true;
                            }
                            else
                            {
                                endPF.enderecoComercial = false;
                            }

                            PessoaFisica novaPF = new PessoaFisica();
                            Console.WriteLine($"Digite seu CPF(Somente números).");
                            novaPF.cpf = Console.ReadLine();
                            
                            Console.WriteLine($"Digite seu nome.");
                            novaPF.nome = Console.ReadLine();
                            
                            Console.WriteLine($"Digite sua data de nascimento.");
                            novaPF.dataNascimento = DateTime.Parse(Console.ReadLine());
                            
                            PessoaFisica pf = new PessoaFisica();
                            //pf.ValidarDataNascimento(pf.dataNascimento);
                            
                            Console.WriteLine(pf.PagarImposto(novaPF.rendimento).ToString("N2")); 
                            
                            bool idadeValida = pf.ValidarDataNascimento(novaPF.dataNascimento);
                            Console.WriteLine(idadeValida);
                            
                            if (idadeValida == true)
                            {
                                Console.WriteLine($"Cadastro Aprovado.");
                                listaPF.Add(novaPF);
                                Console.WriteLine(pf.PagarImposto(novaPF.rendimento).ToString("N2")); 
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
                    case "2":
                    {
                    
                        foreach (var cadaItem in listaPF)
                        {
                            Console.WriteLine($"{cadaItem.nome}, {cadaItem.cpf}, {cadaItem.dataNascimento}");
                        }
                        break;
                    }
                    case "3":
                    {
                    
                        Console.WriteLine($"Digite o CPF que deseja remover");
                        string cpfProcurado = Console.ReadLine();
                        PessoaFisica pessoaEncontrada = listaPF.Find(cadaItem => cadaItem.cpf == cpfProcurado);
                        if(pessoaEncontrada != null)
                        {
                            listaPF.Remove(pessoaEncontrada);
                            Console.WriteLine($"Cadastro Removido");
                        }
                        else
                        {
                            Console.WriteLine($"CPF não encontrado");
                        }
                        break;
                    }
                    case"4":
                        {
                            Endereco endPJ = new Endereco();
                            Console.WriteLine($"Digite seu logradouro.");  
                            endPJ.logradouro = Console.ReadLine();
                            
                            Console.WriteLine($"Digite o número.");
                            endPJ.numero = int.Parse(Console.ReadLine());
                            
                            Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio.)");
                            endPJ.complemento = Console.ReadLine();

                            Console.WriteLine($"Este endereço é comercial? S/N.");   
                            string endComercial = Console.ReadLine().ToUpper();
                            
                            if(endComercial == "S")
                            {
                                endPJ.enderecoComercial = true;
                            }
                            else
                            {
                                endPJ.enderecoComercial = false;
                            }
                            PessoaJuridica novaPJ = new PessoaJuridica();
                            
                            Console.WriteLine($"Digite seu CNPJ(Somente números).");
                            novaPJ.cnpj = Console.ReadLine();

                            Console.WriteLine($"Digite seu nome.");
                            novaPJ.nome = Console.ReadLine();
                            
                            Console.WriteLine($"Digite a Razão Social.");
                            novaPJ.razaoSocial = Console.ReadLine();
                            
                            PessoaJuridica pj = new PessoaJuridica();
                            
                            Console.WriteLine(pj.PagarImposto(novaPJ.rendimento).ToString("N2")); 

                            if (pj.ValidarCNPJ(novaPJ.cnpj))
                            {
                                Console.WriteLine("CNPJ Válido.");
                                Console.WriteLine($"Cadastro Aprovado.");
                                listaPJ.Add(novaPJ);
                                Console.WriteLine(pj.PagarImposto(novaPJ.rendimento).ToString("N2"));
                            }
                            else
                            {
                                Console.WriteLine("CNPJ inválido.");
                                Console.WriteLine($"Cadastro Não Aprovado.");
                            }
                            break;
                        }
                    case "5":
                        {
                            foreach (var cadaItem in listaPJ)
                            {
                                Console.WriteLine($"{cadaItem.cnpj}, {cadaItem.nome}, {cadaItem.razaoSocial}");
                            }
                            break;
                        }
                    case "6":
                    {
                    
                        Console.WriteLine($"Digite o CPF que deseja remover");
                        string cnpjProcurado = Console.ReadLine();
                        PessoaJuridica empresaEncontrada = listaPJ.Find(cadaItem => cadaItem.cnpj == cnpjProcurado);
                        if(empresaEncontrada != null)
                        {
                            listaPJ.Remove(empresaEncontrada);
                            Console.WriteLine($"Cadastro Removido");
                        }
                        else
                        {
                            Console.WriteLine($"CNPJ não encontrado");
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