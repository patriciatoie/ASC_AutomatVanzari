using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatVanzari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int valoareMoneda = 0;
            int stareAutomat = 0;
            string tipMoneda;
            bool ok = true;
            Stack<int> stack = new Stack<int>();
            while (true)
            {
                tipMoneda = Console.ReadLine().ToUpper();
                if (tipMoneda == "N")
                    valoareMoneda = 5;
                else if (tipMoneda == "D")
                    valoareMoneda = 10;
                else if (tipMoneda == "Q")
                    valoareMoneda = 25;
                else
                    throw new Exception("Automatul accepta doar 5, 10 sau 25 centi!");

                stareAutomat += valoareMoneda; // regasim in automat monedele pe care le-am introdus
                stack.Push(stareAutomat); // starea actuala a automatului se regaseste in varful stivei

                while (stack.Peek() >= 20) // nu se sterge valoarea din varful stivei, 20 fiind minimul pt obtinerea unui produs
                {
                    if (stareAutomat == 20)
                    {
                        Console.WriteLine("Selecteaza produsul dorit, restul tau este 0.");
                        stareAutomat = stareAutomat - 20;
                        stack.Push(stareAutomat);
                        break;
                    }
                    if (stareAutomat > 20 && stareAutomat != 40)
                    {
                        Console.WriteLine("Selecteaza produsul dorit, automatul iti restituie restul.");
                        stareAutomat = stareAutomat - 20;
                        Console.WriteLine($"Ridica restul tau care este {stareAutomat} centi.");
                    }
                    if (stareAutomat == 40)
                    {
                        Console.WriteLine("Selecteaza produsul dorit, iar automatul iti va da restul de 20 centi");
                        stareAutomat = stareAutomat - 20; // 40-20 = 20 centi rest
                        int aux = stareAutomat; // aux = 20
                        Console.WriteLine("Daca mai doresti un produs, selecteaza-l si apasa X, daca doresti ca automatul sa-ti restituie restul de 20 centi, apasa R.");
                        string optiune = Console.ReadKey().Key.ToString();
                        if (optiune.ToUpper() == "X")
                        {
                            stareAutomat = stareAutomat - 20; // se mai da un produs de cei 20 de centi ramasi iar restul devine 0
                            stack.Push(stareAutomat);
                            Console.WriteLine("Ridicati si al doilea produs, restul este 0.");
                        }
                        else if (optiune.ToUpper() == "R")
                        {
                            stareAutomat = stareAutomat - 20; //starea automatului devine 0, se primeste restul de 20 centi
                            stack.Push(stareAutomat);
                            Console.WriteLine($"Ridicati restul de {aux} centi"); // restituie restul de 20 centi 
                        }
                    }
                }
            }
        }
    }
}

    
    

