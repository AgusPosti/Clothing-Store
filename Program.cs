using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();
            // Pago en efectivo = 20% de descuento
            // Pago en cuotas = 5% de interes por cantidad de cuotas (maximo 12 cuotas)


            static void menu()
            {
                int opcion;

                do
                {
                    char esquinSupIzq = '╔';
                    char esquinSupDer = '╗';
                    char esquinInfIzq = '╚';
                    char esquinInfDer = '╝';
                    char bordeHorizontal = '═';
                    char bordeVertical = '║';
                    char bordeHoriCenIzq = '╠';
                    char bordeHoriCenDer = '╣';

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
                    string inputOpcion = Console.ReadLine();
                    if (int.TryParse(inputOpcion, out opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                Console.Clear();
                                menuOpcion1();
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                menuOpcion2();
                                Console.ReadKey();
                                break;
                            case 0:

                                menuOpcionSalida();
                                break;
                            default:
                                Console.WriteLine("Ingrese una opción válida.");
                                break;
                        }
                    }
                    else
                        Console.WriteLine("\nOpción no encontrada. Reintente.");

                } while (opcion != 3);
            }

            static void menuOpcion1()
            {
                double montoCompra;

                while (true) //Bucle hasta que ingresa bien el dato
                {
                    Console.Write("Ingrese monto de compra: ");
                    string inputMontoCompra = Console.ReadLine();
                    double porcDescuento, precioFinal, descuentoTotal;

                    if (double.TryParse(inputMontoCompra, out montoCompra))
                    {
                        porcDescuento = 0.20;
                        precioFinal = montoCompra * (1 - porcDescuento);
                        descuentoTotal = montoCompra * porcDescuento;

                        Console.WriteLine($"Por pago en efectivo, el cliente tendrá un {porcDescuento * 100}% de descuento.");
                        Console.WriteLine($"El cliente ahorrará $ {descuentoTotal:F2}.");
                        Console.WriteLine($"El cliente pagará finalmente $ {precioFinal:F2}.");
                        Console.WriteLine("\nIngrese cualquier tecla para volver al menú principal.");

                        break; //Sale del bucle por ingreso válido de dato
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un valor válido de dinero.\n");
                    }
                }
            }

            static void menuOpcion2()
            {

                while (true) // Bucle hasta que ingresa bien el dato
                {
                    Console.Write("Ingrese monto de compra: ");
                    string inputMonto = Console.ReadLine();
                    double porcInteres, precioFinal, interesTotal, cuota;

                    if (double.TryParse(inputMonto, out double montoCompra))
                    {
                        Console.WriteLine("Ingrese cantidad de cuotas (1-12):");
                        string inputCuotas = Console.ReadLine();
                        int cantCuotas;

                        if (int.TryParse(inputCuotas, out cantCuotas))
                        {
                            //validar cantidad de cuotas
                            if (cantCuotas < 1 || cantCuotas > 12)
                            {
                                Console.WriteLine("Cantidad de cuotas no válida. Solo se puede elegir entre 1 y 12 cuotas. ");
                            }

                            // Calcular interés según las cuotas
                            porcInteres = 0.05 * cantCuotas;
                            precioFinal = montoCompra * (1 + porcInteres);
                            interesTotal = precioFinal - montoCompra;
                            cuota = precioFinal / cantCuotas;

                            Console.WriteLine($"\nEl cliente tendrá un {(porcInteres * 100):F2}% de interés.");
                            Console.WriteLine($"El cliente pagará $ {interesTotal:F2} de interés.");
                            Console.WriteLine($"El cliente pagará finalmente $ {precioFinal:F2}.");
                            Console.WriteLine($"El cliente pagará {cantCuotas} cuotas de $ {cuota:F2} cada una.");
                            Console.WriteLine("\nIngrese cualquier tecla para volver al menú principal.");

                            break; // Corta el bucle cuando se ingresa bien el dato
                        }
                        else
                            Console.WriteLine("Ingrese una opción valida de cuota para continuar correctamente.\n");
                    }
                    else
                        Console.WriteLine("Monto no válido.\n");
                }
            }


            static void menuOpcionSalida()
            {

                Console.WriteLine("Desea Salir Del Programa?  ('s' para confirmar salida):  ");
                char confirmacion = Convert.ToChar(Console.ReadLine());

                if (confirmacion == 's' || confirmacion == 'S')
                {
                    Console.WriteLine("\nGracias por usar el programa. ¡Hasta luego!");
                    Environment.Exit(0); // cierra programa
                }
            }


        }
    }
}


