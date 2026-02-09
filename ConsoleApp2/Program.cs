// CAJERO AUTOMATICO 
using System.ComponentModel.Design;

class CajeroAutomatico
{
    double saldo = 10000;

    void Menu()
    {
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(@"======SELECCIONE LA OPERACION======
            1. CONSULTAR SALDO
            2. DEPOSITAR
            3. RETIRAR
            4. SALIR");

            Console.WriteLine("Seleccione una opcion");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ConsultarSaldo();
                    break;
                case "2":
                    Depositar();
                    break;
                case "3":
                    Retirar();
                    break;
                case "4":
                    Salir();
                    break;
                default:
                    Console.WriteLine("OPCION NO VALIDA, PRESIONE ENTENER PARA CONTINUAR...");
                    Console.ReadKey();
                    break;

            }

        } while (opcion != "4");

        void ConsultarSaldo()
        {
            Console.Clear();
            Console.WriteLine($"saldo actual: {saldo}");
            OtraOperacion(); 
        }

        void Depositar()
        {
            Console.WriteLine("ingrese el monto a depositar...");
            double monto = Convert.ToDouble(Console.ReadLine());
            if(monto <= 0)
            {
                Console.WriteLine("Monto invalido. No debe ser 0, intente de nuevo...");
                Depositar();
            }
            else
            {
                saldo += monto;
                Console.WriteLine($"Deposito. Nuevo Saldo: {saldo}");
                OtraOperacion();

            }
        }


        void Retirar()
            {
                Console.WriteLine("Ingrese el monto a retirar");
                double retiro = Convert.ToDouble(Console.ReadLine());
                if (retiro <= 0)
                {
                    Console.WriteLine("Monto invalido, no puede ser 0, intente de nuevo...");
                    Retirar();
                }
                else if (retiro > saldo){
                Console.WriteLine("Fondos insuficientes, intente de nuevo...");
                Retirar();
                }
                else
                {
                    saldo -= retiro;
                Console.WriteLine($"retiro completo!" +
                    $"nuevo saldo : {saldo} "); 
                    OtraOperacion(); 
                }  
            }

        void Salir()
        {
            Console.WriteLine(@"===========================
GRACIAS POR USAR NUESTROS SERVICIOS
===============================");
            Environment.Exit(0);    
        }

        void OtraOperacion()
        {
            Console.WriteLine("\n DESEA REALIZAR OTRA OPERACION? (1=SI/ 2=NO)");
            int respuesta = Convert.ToInt32(Console.ReadLine()); 
            if(respuesta == 1){
                Menu();
            }
            else if(respuesta == 2)
            {
                Salir();
            }
            else
            {
                Console.WriteLine("\n OPCION NO VALIDA, ELIJA UNA OPCION CORRECTA");
                OtraOperacion();
            }
        }
    }

    static void Main(string[] args)
    {
        CajeroAutomatico cajero = new CajeroAutomatico();
        cajero.Menu();
    }

}