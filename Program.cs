using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pago en efectivo = 20% de descuento
            // Pago en cuotas = 5% de interes por cantidad de cuotas (maximo 12 cuotas)

            /* string entrada;
             int cantCuotas;
             double montoCompra, precioFinal, porcInteres, porcDescuento, cuota, interesTotal, descuentoTotal;



             do
             {

                 Console.WriteLine("Ingrese cantidad de cuotas");
                 Console.WriteLine("En caso de pago en efectivo ingrese 1");
                 Console.WriteLine("Para salir, ingrese 0");
                 entrada = Console.ReadLine();
                 cantCuotas = int.Parse(entrada);

                 Console.WriteLine("Ingrese monto de compra");
                 entrada = Console.ReadLine();
                 montoCompra = double.Parse(entrada);



                 switch (cantCuotas)
                 {
                     case 1:
                         porcDescuento = 0.20;
                         precioFinal = montoCompra * (1 - porcDescuento);
                         descuentoTotal = montoCompra * porcDescuento;
                         Console.WriteLine($"Por pago en efectivo, el cliente tendra {porcDescuento * 100} % de descuento");
                         Console.WriteLine($"El cliente ahorrara $ {descuentoTotal} ");
                         Console.WriteLine($"El cliente pagara $ {precioFinal}");

                         break;

                     case 2:
                     case 3:
                     case 4:
                     case 5:
                     case 6:
                     case 7:
                     case 8:
                     case 9:
                     case 10:
                     case 11:
                     case 12:
                         porcInteres = 0.05 * cantCuotas;
                         precioFinal = montoCompra * (1 + porcInteres);
                         interesTotal = precioFinal - montoCompra;
                         cuota = precioFinal / cantCuotas;
                         Console.WriteLine($"El cliente tendra {porcInteres * 100} % de interes");
                         Console.WriteLine($"El cliente pagara $ {interesTotal} de interes ");
                         Console.WriteLine($"El cliente pagara finalmente $ {precioFinal}");
                         Console.WriteLine($"El cliente pagara {cantCuotas} cuotas de $ {cuota} cada una");
                         Console.ReadLine();
                         break;

                     default:
                         Console.WriteLine("Cantidad de cuotas no valida");
                         break 


                 }



             }

             while (cantCuotas != 0); */




            string entrada;
            int cantCuotas;
            double montoCompra, precioFinal, porcInteres, porcDescuento, cuota, interesTotal, descuentoTotal;
            char esquinSupIzq = '╔';
            char esquinSupDer = '╗';
            char esquinInfIzq = '╚';
            char esquinInfDer = '╝';
            char bordeHorizontal = '═';
            char esquinSuperior = '╔';
            char bordeVertical = '║';
            char bordeHoriCenIzq = '╠';
            char bordeHoriCenDer = '╣';
            do
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(esquinSupIzq);
                for (int i = 0; i < 38; i++) Console.Write(bordeHorizontal);
                Console.WriteLine(esquinSupDer);

                Console.Write(bordeVertical);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  MENÚ DE PAGOS DE LA TIENDA DE ROPA  ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);

                Console.Write(bordeHoriCenIzq);
                for (int i = 0; i < 38; i++) Console.Write(bordeHorizontal);
                Console.WriteLine(bordeHoriCenDer);

                Console.Write(bordeVertical);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" 1. Pago en efectivo (20% desc.)      ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);

                Console.Write(bordeVertical);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" 2. Pago en cuotas (hasta 12 cuotas)  ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);

                Console.Write(bordeVertical);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" 0. Salir                             ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);

                Console.Write(esquinInfIzq);
                for (int i = 0; i < 38; i++) Console.Write(bordeHorizontal);
                Console.WriteLine(esquinInfDer);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Seleccione una opción: ");
                entrada = Console.ReadLine();
                int opcion = int.Parse(entrada);

                if (opcion == 0)
                {
                    Console.WriteLine("Desea Salir Del Programa?  (s para sí, n para no):  ");
                    char confirmacion = Convert.ToChar(Console.ReadLine());

                    if (confirmacion == 's' || confirmacion == 'S')
                    {
                        Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
                        break;
                    }
                    else if (confirmacion == 'n' || confirmacion == 'N')
                    {
                        Console.WriteLine("Regresando al menú...");
                        continue;
                    }


                    Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
                    break;

                }

                // Verifica que la opción ingresada es válida
                if (opcion != 1 && opcion != 2)
                {
                    Console.WriteLine("Opción no válida. Por favor intente nuevamente.");
                    continue;
                }

                // Solicitar monto de compra
                Console.WriteLine("Ingrese monto de compra: ");
                entrada = Console.ReadLine();
                montoCompra = double.Parse(entrada);

                // Caso de pago en efectivo
                if (opcion == 1)
                {
                    porcDescuento = 0.20;
                    precioFinal = montoCompra * (1 - porcDescuento);
                    descuentoTotal = montoCompra * porcDescuento;

                    Console.WriteLine($"Por pago en efectivo, el cliente tendrá un {porcDescuento * 100}% de descuento.");
                    Console.WriteLine($"El cliente ahorrará $ {descuentoTotal:F2}.");
                    Console.WriteLine($"El cliente pagará finalmente $ {precioFinal:F2}.");
                }
                // Caso de pago en cuotas
                else if (opcion == 2)
                {
                    // Solicitar cantidad de cuotas
                    Console.WriteLine("Ingrese cantidad de cuotas (1-12):");
                    entrada = Console.ReadLine();
                    cantCuotas = int.Parse(entrada);

                    // Validar cantidad de cuotas
                    if (cantCuotas < 1 || cantCuotas > 12)
                    {
                        Console.WriteLine("Cantidad de cuotas no válida. Solo se pueden elegir entre 1 y 12 cuotas.");
                        continue;
                    }

                    // Calcular interés según las cuotas
                    porcInteres = 0.05 * cantCuotas;
                    precioFinal = montoCompra * (1 + porcInteres);
                    interesTotal = precioFinal - montoCompra;
                    cuota = precioFinal / cantCuotas;

                    Console.WriteLine($"El cliente tendrá un {porcInteres * 100}% de interés.");
                    Console.WriteLine($"El cliente pagará $ {interesTotal:F2} de interés.");
                    Console.WriteLine($"El cliente pagará finalmente $ {precioFinal:F2}.");
                    Console.WriteLine($"El cliente pagará {cantCuotas} cuotas de $ {cuota:F2} cada una.");
                }

                // Espera para volver a mostrar el menú
                Console.WriteLine("\nPresione cualquier tecla para volver al menú.");
                Console.ReadKey();
            }
            while (true);
        }
    }



}