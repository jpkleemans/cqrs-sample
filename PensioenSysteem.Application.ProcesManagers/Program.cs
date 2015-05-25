using PensioenSysteem.Application.ProcesManagers.Commands;
using PensioenSysteem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Application.ProcesManagers
{
    class Program
    {
        static void Main(string[] args)
        {
            // start procesmanager
            RegistrerenAanmelding registrerenAanmelding = new RegistrerenAanmelding();
            registrerenAanmelding.Start();

            while (true)
            {
                Console.WriteLine("Druk op een toets om een nieuw RegistreerAanmelding proces te starten (Esc om te stoppen).");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }

                RegistreerAanmeldingCommand command = TestCommandFactory.MaakRegistreerAanmeldingCommand(); 
                registrerenAanmelding.RegistreerAanmelding(command);

                Console.Write("Proces gestart. ");
                Console.WriteLine("CorrelationID = " + command.CorrelationId);
                Console.WriteLine();
            }

            registrerenAanmelding.Stop();
        }
    }
}
