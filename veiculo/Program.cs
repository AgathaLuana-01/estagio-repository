using System;
using System.Collections.Generic;

namespace veiculo
{
    class Program
    {
        static void Main(string[] args)
        {
            int enquanto = 0;
            string idPlaca;

            List<Veiculo> veiculos = new List<Veiculo>();

            do
            {
                Veiculo veiculo = new Veiculo();

                Console.WriteLine("0 = Novo Cadastro");
                Console.WriteLine("1 = Horário de Saída");
                Console.WriteLine("2 = Sair");
                enquanto = Convert.ToInt32(Console.ReadLine());

                if(enquanto == 0)
                {

                    Console.WriteLine("_________Cadastro_________");
                    Console.Write("Nome do Dono:\t");
                    veiculo.nome = Console.ReadLine();
                    Console.Write("CPF: ");
                    veiculo.cpf = Console.ReadLine();
                    Console.Write("Placa do Veículo: ");
                    veiculo.placa_Veiculo = Console.ReadLine();
                    Console.Write("Horário de chegada: ");
                    veiculo.horario_Chegada = TimeSpan.Parse(Console.ReadLine());

                    veiculos.Add(veiculo);
                    Console.WriteLine("___________________________\n");
                }
                if ((enquanto == 1) && veiculos.Count > 0) {
                    Console.WriteLine("Informe a placa do veículo: ");
                    idPlaca = Console.ReadLine();
                    
                    foreach(var v in veiculos)
                    {
                        if (v.placa_Veiculo == idPlaca)
                        {
                            Console.WriteLine("Horário de saída: ");
                            v.horario_Saida = TimeSpan.Parse(Console.ReadLine());
                            TimeSpan tempoTotal = v.horario_Saida - v.horario_Chegada;
                            Console.WriteLine("\ntempo total: " + tempoTotal);
                            double total = tempoTotal.TotalMinutes;
                            double totalAPagar = 5;
                            Console.WriteLine("Até 2hrs, custo de R$ 5,00.\nApós, acréssimo de R$0.05 por minuto!!");    
                            if (total > 120)
                                {
                                total = total - 120;
                                totalAPagar += total * 0.05;
                                }
                                Console.WriteLine("Total a pagar: R$" + totalAPagar + "\n\n");
                        }
                        else 
                        {
                            Console.WriteLine("Placa não cadastrada amore.\n\n");
                        }
                    }
                    
                }               

            } while (enquanto != 2);
            Console.Clear();            

            foreach (Veiculo aVeiculo in veiculos)
            {
                Console.WriteLine("********************************************");
                Console.WriteLine("Nome: "+ aVeiculo.nome +"\nCPF: "+ aVeiculo.cpf +"\nPlaca: "+ aVeiculo.placa_Veiculo +"\nHorário entrada: "+ aVeiculo.horario_Chegada+"\nHorário de saída:" + aVeiculo.horario_Saida+"\n\n");    
            }
        }
    }
}
