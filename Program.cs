using System;
using System.Collections.Generic;

namespace DIO.Bank{

class Program{

    static List<Conta> listContas = new List<Conta>();

    static void Main(string[] args){
        string opcaoUsuario = ObterOpcaoUsuario();

        while(opcaoUsuario.ToUpper() != "X"){
            switch(opcaoUsuario){
                case "1":
                ListarContas();
                break;
                case "2":
                InserirConta();
                break;
                case "3":
                Transferir();
                break;
                case "4":
                Sacar();
                break;
                case "5":
                Depositar();
                break;
                case "C":
                Console.Clear();
                break;
                
                default:
                throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = ObterOpcaoUsuario();
        }
    }

        private static void Transferir()
        {
           Console.Write("Digite o numero da conta de origem: ");
           int indiceContaOrigem = int.Parse(Console.ReadLine());

           Console.Write("Digite o numero da conta destinataria: ");
           int indiceContaDestino = int.Parse(Console.ReadLine());

           Console.Write("Digite o valor a ser transferido: ");
           double valorTransferencia = double.Parse(Console.ReadLine());

           listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
             Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
            
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorDeposito);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listContas.Count == 0){
                Console.WriteLine("Nenhuma conta encontrada!");
                return;
            }

            for ( int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para pessoa física ou 2 para jurídica");
             int entradaTipoConta = int.Parse(Console.ReadLine());

             Console.Write("Digite o nome do cliente: ");
             string entradaNome = Console.ReadLine();

             Console.Write("Digite o seu saldo inicial: ");
             double entradaSaldo = double.Parse(Console.ReadLine());

             
             double entradaCredito = entradaSaldo / 2;
             Console.Write($"O seu crédito inicial será: {entradaCredito} ");
             

             Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
             saldo: entradaSaldo,
             credito: entradaCredito,
             nome: entradaNome );

             listContas.Add(novaConta);


        }

        private static string ObterOpcaoUsuario(){

        Console.WriteLine();
        Console.WriteLine("DIO Bank ao seu dispor!");
        Console.WriteLine("Informe a Opção desejada:");

        Console.WriteLine("1- Listar contas");
        Console.WriteLine("2- Inserir nova conta");
        Console.WriteLine("3- Transferir");
        Console.WriteLine("4- Sacar");
        Console.WriteLine("5- Depositar");
        Console.WriteLine("C- Limpar tela");
        Console.WriteLine("X- Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;

    }

}

}
