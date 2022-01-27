using System;

namespace EncontroRemoto
{
        class Program 
    {
        static void Main(string[]args)
        {
            Endereco end = new Endereco();
            end.logradouro = "X";
            end.numero = 100;
            end.complemento = "Próximo ao Senai";
            end.enderecoComercial = false;

            PessoaFisica novapf = new PessoaFisica();

            novapf.endereco = end;
            novapf.cpf = "123456789";
            novapf.dataNascimento = new DateTime(1995, 08, 05);
            novapf.nome = "Eduardo";

            PessoaFisica pf = new PessoaFisica();
            bool idadeValida = pf.ValidarDataNascimento(novapf.dataNascimento);

            if (idadeValida == true)
            {
                Console.WriteLine($"Cadastro Aprovado");
            }else{
                Console.WriteLine($"Cadastro Não Aprovado");
            }
            
            //pf.ValidarDataNascimento(pf.dataNascimento);
            //Console.WriteLine(pf.ValidarDataNascimento(novapf.dataNascimento));
            // Console.WriteLine(novapf.endereco.logradouro);
            // Console.WriteLine(novapf.endereco.numero);
            // Console.WriteLine(novapf.endereco.complemento);
            // Console.WriteLine(novapf.endereco.enderecoComercial);
            //Console.WriteLine($"Rua: {novapf.endereco.logradouro}, {novapf.endereco.numero}");
            //Console.WriteLine("Rua: " + novapf.endereco.logradouro + novapf.endereco.numero);



        }
    }
}