using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Program
{

    // Estructura para guardar los datos de cada producto
    struct Producto
    {
        public int Codigo;
        public string Nombre;
        public string Categoria;
        public string Talle;
        public double Precio;
        public int Stock;

        public Producto(int codigo, string nombre, string categoria, string talle, double precio, int stock)
        {
            Codigo = codigo;
            Nombre = nombre;
            Categoria = categoria;
            Talle = talle;
            Precio = precio;
            Stock = stock;
        }

    }

    //Estructura guardar datos de empleados
    struct Empleado
    {
        public int Codigo { get; }
        public string NombreCompleto { get; }
        public string Contrasena { get; }

        public Empleado(int codigo, string nombreCompleto, string contrasena)
        {
            Codigo = codigo;
            NombreCompleto = nombreCompleto;
            Contrasena = contrasena;
        }
    }



    class Program
    {
        //Lista para guardar productos
        static List<Producto> productos = new List<Producto>();
        static int proximoCodigo = 1; //Generador automático de códigos


        static List<Empleado> empleados = new List<Empleado>();
        static int contadorCodigo = 1;//Generador de codigo unico


        static void Main(string[] args)
        {

            empleados.Add(new Empleado(contadorCodigo++, "Administrador", "1234"));





            menuPrincipal();
            // Pago en efectivo = 20% de descuento
            // Pago en cuotas = 5% de interes por cantidad de cuotas (maximo 12 cuotas)

        }


        static void menuPrincipal()
        {
            int opcionPrincipal;

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
                for (int i = 0; i < 29; i++) Console.Write(bordeHorizontal);
                Console.WriteLine(esquinSupDer);

                Console.Write(bordeVertical);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  MENÚ DE LA TIENDA DE ROPA  ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);

                Console.Write(bordeHoriCenIzq);
                for (int i = 0; i < 29; i++) Console.Write(bordeHorizontal);
                Console.WriteLine(bordeHoriCenDer);

                Console.Write(bordeVertical);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" 1. Emisión de presupuestos  ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);

                Console.Write(bordeVertical);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" 2. Productos                ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);

                Console.Write(bordeVertical);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" 3. Clientes                 ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);

                Console.Write(bordeVertical);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" 4. Ventas                   ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);

                Console.Write(bordeVertical);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" 5. Empleados                ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);

                Console.Write(bordeVertical);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" 0. Salir                    ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);

                Console.Write(esquinInfIzq);
                for (int i = 0; i < 29; i++) Console.Write(bordeHorizontal);
                Console.WriteLine(esquinInfDer);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Seleccione una opción: ");
                string inputOpcionPrincipal = Console.ReadLine();

                if (int.TryParse(inputOpcionPrincipal, out opcionPrincipal))
                {
                    switch (opcionPrincipal)
                    {
                        case 1:
                            Console.Clear();

                            //menuPrincipalOpcion1();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            MostrarMenuProductos();
                            //menuPrincipalOpcion2();
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            //menuPrincipalOpcion3();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            //menuPrincipalOpcion4();
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            MostrarMenuEmpleados();
                            Console.ReadKey();
                            break;
                        case 0:

                            //menuPrincipalSalida();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Ingrese una opción válida.");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nOpción no encontrada. Reintente.");
                Console.ResetColor();

            } while (opcionPrincipal != 0);
        }





        static void MostrarMenuProductos()
        {
            int opcion;
            do
            {
                string[] opciones = new string[]
                {
                    "1. Agregar producto",
                    "2. Lista de productos",
                    "3. Buscar producto",
                    "4. Ordenar por precio",
                    "5. Ordenar por código",
                    "6. Modificar stock",
                    "0. Volver al menú principal"
                };

                opcion = MostrarMenu("MENÚ DE PRODUCTOS", opciones);

                switch (opcion)
                {
                    case 1: agregarProductos(); break;
                    case 2: listaProductos(); Console.ReadKey(); break;
                    case 3: buscarProductos(); Console.ReadKey(); break;
                    case 4: ordenarPorPrecio(); Console.ReadKey(); break;
                    case 5: ordenarPorCodigo(); Console.ReadKey(); break;
                    case 6: modificarStock(); Console.ReadKey(); break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nRegresando al menú principal...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpción inválida. Intente nuevamente.");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0);
        }


        static void agregarProductos()
        {

            Console.Clear();
            MostrarEncabezado("AGREGAR PRODUCTO");

            Producto nuevo = new Producto();
            nuevo.Codigo = proximoCodigo++;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ingresar '0' para regresar.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nNombre(no vacío): ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string nombre = Console.ReadLine();

            if (nombre == "0") return;//para volver en caso de equivocarse de opcion

            // Validar que no esté vacío
            while (string.IsNullOrWhiteSpace(nombre))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Nombre no puede estar vacío. Ingreselo de nuevo: ");
                Console.ResetColor();
                nombre = Console.ReadLine();
                if (nombre == "0") return;
            }

            nuevo.Nombre = nombre;

            //arreglo de categorias
            string[] categoriasValidas = { "Parte Superior", "Parte Inferior", "Parte Interior" };
            string categoria;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Categoría (Parte Superior / Parte Inferior / Parte Interior): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                categoria = Console.ReadLine();

                if (categoria == "0") return;

                if (!categoriasValidas.Contains(categoria, StringComparer.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Categoria inválida. Tiene que ser exactamente una de las que se piden.\n");
                    Console.ResetColor();
                    categoria = null; //reinicia el bucle
                }
            } while (string.IsNullOrWhiteSpace(categoria));

            //guarda categoria en formato estandar
            nuevo.Categoria = categoriasValidas.First(c => c.Equals(categoria, StringComparison.OrdinalIgnoreCase));

            //arreglo talles
            string[] tallesValidos = { "XS", "S", "M", "L", "XL" };
            string talle;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Talle('XS', 'S', 'M', 'L', 'XL'): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                talle = Console.ReadLine()?.ToUpper();

                if (talle == "0") { return; }

                if (!tallesValidos.Contains(talle))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Talle inválido. Ingrese uno igual al que se pide.\n");
                    talle = null;
                }
            } while (string.IsNullOrWhiteSpace(talle));

            nuevo.Talle = talle;


            double precio;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Precio(número positivo): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string inputPrecio = Console.ReadLine();

                if (!double.TryParse(inputPrecio, out precio) || precio <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Precio inválido. Debe ser un número positivo.\n");
                }
            } while (precio <= 0);

            nuevo.Precio = precio;


            //validar stock
            int stock;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Stock inicial(0 en adelante): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string inputStock = Console.ReadLine();

                if (!int.TryParse(inputStock, out stock) || stock < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Stock inválido. Ingrese un numero entero mayor o igual a 0.\n");
                }
            } while (stock < 0);

            nuevo.Stock = stock;

            productos.Add(nuevo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Producto agregado correctamente.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nCódigo asignado: {nuevo.Codigo}");
            Console.WriteLine($"{nuevo.Nombre} - Categoría: {nuevo.Categoria}, Talle {nuevo.Talle} - ${nuevo.Precio} - Stock: {nuevo.Stock}");

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void listaProductos()
        {
            Console.Clear();
            MostrarEncabezado("LISTA DE PRODUCTOS");

            if (productos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No hay productos cargados.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("COD  | NOMBRE           | CATEGORÍA       | TALLE | PRECIO   | STOCK");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var p in productos)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{p.Codigo,-4} | {p.Nombre,-15} | {p.Categoria,-15} | {p.Talle,-5} | ${p.Precio,-8} | {p.Stock}");
            }
        }

        static void buscarProductos()
        {
            Console.Clear();
            MostrarEncabezado("BUSCAR PRODUCTO POR NOMBRE");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Buscar: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string busqueda = Console.ReadLine().ToLower();

            var encontrados = productos.FindAll(p => p.Nombre.ToLower().Contains(busqueda));

            if (encontrados.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No se encontraron productos con ese nombre.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nResultados:");
            foreach (var p in encontrados)
            {
                Console.WriteLine($"\n[{p.Codigo}] {p.Nombre} - {p.Categoria} - Talle {p.Talle} - ${p.Precio} - Stock: {p.Stock}");
            }
        }

        static void modificarStock()
        {
            Console.Clear();
            MostrarEncabezado("MODIFICAR STOCK");

            int codigo;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Ingrese el código del producto: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string inputCodigo = Console.ReadLine();
            if (int.TryParse(inputCodigo, out codigo))
            {
                var producto = productos.Find(p => p.Codigo == codigo);
                if (producto.Codigo == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Producto no encontrado.");
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Producto: {producto.Nombre} - Stock actual: {producto.Stock}");
                Console.Write("Nuevo stock: ");
                producto.Stock = int.Parse(Console.ReadLine());

                // Actualizamos el producto en la lista
                int index = productos.FindIndex(p => p.Codigo == codigo);
                productos[index] = producto;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Ingrese un número válido.");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nStock actualizado correctamente.");
        }

        //funcion para ordenar por precio productos, haciendo bubble sort
        static void ordenarPorPrecio()
        {
            Console.Clear();
            MostrarEncabezado("ORDENAR POR PRECIO DE '-' A '+'");

            if (productos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No hay productos cargados.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nPresione una tecla para volver...");
                Console.ReadKey();
                return;
            }

            // Copia de la lista original
            var listaOrdenada = new List<Producto>(productos);

            for (int i = 0; i < listaOrdenada.Count - 1; i++)
            {
                for (int j = 0; j < listaOrdenada.Count - i - 1; j++)
                {
                    if (listaOrdenada[j].Precio > listaOrdenada[j + 1].Precio)
                    {
                        var temp = listaOrdenada[j];
                        listaOrdenada[j] = listaOrdenada[j + 1];
                        listaOrdenada[j + 1] = temp;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("COD  | NOMBRE           | CATEGORÍA       | TALLE | PRECIO   | STOCK");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var p in listaOrdenada)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{p.Codigo,-4} | {p.Nombre,-15} | {p.Categoria,-15} | {p.Talle,-5} | ${p.Precio,-8} | {p.Stock}");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
        }

        //funcion para ordenar por codigo productos, haciendo bubble sort
        static void ordenarPorCodigo()
        {
            Console.Clear();
            MostrarEncabezado("ORDENAR POR CÓDIGO");

            if (productos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No hay productos cargados.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nPresione una tecla para volver...");
                Console.ReadKey();
                return;
            }

            // Copia de la lista original para no modificarla
            var listaOrdenada = new List<Producto>(productos);

            // Bubble Sort ascendente por Código
            for (int i = 0; i < listaOrdenada.Count - 1; i++)
            {
                for (int j = 0; j < listaOrdenada.Count - i - 1; j++)
                {
                    if (listaOrdenada[j].Codigo > listaOrdenada[j + 1].Codigo)
                    {
                        var temp = listaOrdenada[j];
                        listaOrdenada[j] = listaOrdenada[j + 1];
                        listaOrdenada[j + 1] = temp;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("COD  | NOMBRE           | CATEGORÍA       | TALLE | PRECIO   | STOCK");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var p in listaOrdenada)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{p.Codigo,-4} | {p.Nombre,-15} | {p.Categoria,-15} | {p.Talle,-5} | ${p.Precio,-8} | {p.Stock}");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
        }


        //funcion para ser llamada en el menú principal
        static void MostrarMenuEmpleados()
        {
            int opcion;
            do
            {
                string[] opciones = new string[]
                {
                    "1. Lista de empleados",
                    "2. Cargar nuevo empleado",
                    "3. Eliminar empleado",
                    "0. Volver al menú principal",
                };

                opcion = MostrarMenu("MENÚ DE EMPLEADOS", opciones);

                switch (opcion)
                {
                    case 1: listaEmpleados(); break;
                    case 2: agregarEmpleado(); Console.ReadKey(); break;
                    case 3: eliminarEmpleado(); Console.ReadKey(); break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nRegresando al menú principal...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nOpción inválida. Intente nuevamente.");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0);
        }


        static void listaEmpleados()
        {
            Console.Clear();
            MostrarEncabezado("LISTA EMPLEADOS");

            if (empleados.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                foreach (var e in empleados)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Código: {e.Codigo} | Nombre: {e.NombreCompleto}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }


        static void agregarEmpleado()
        {
            Console.Clear();
            MostrarEncabezado("AGREGAR NUEVO EMPLEADO");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Ingrese nombre completo: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string nombre = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nombre))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("El nombre no puede estar vacío. Ingrese nuevamente: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                nombre = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Ingrese contraseña: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string contrasena = Console.ReadLine();

            empleados.Add(new Empleado(contadorCodigo++, nombre, contrasena));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEmpleado agregado correctamente.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }




        static void eliminarEmpleado()
        {
            Console.Clear();
            MostrarEncabezado("ELIMINAR EMPLEADO");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("'0' para regresar.");

            if (empleados.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No hay empleados para eliminar.");
                Console.ReadKey();
                return;
            }
            else
            {
                foreach (var e in empleados)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Código: {e.Codigo} | Nombre: {e.NombreCompleto}");
                }
            }

            int codigo;

            // Bucle para que el usuario vuelva a intentar si hay error
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nIngrese el código del empleado a eliminar ('0' para regresar): ");

                // Validar entrada
                if (!int.TryParse(Console.ReadLine(), out codigo))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Entrada no válida. Intente de nuevo.");
                    continue; // vuelve a pedir
                }

                // Opción para regresar
                if (codigo == 0)
                    return;

                // Buscar el índice del empleado
                int index = empleados.FindIndex(e => e.Codigo == codigo);

                if (index == -1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Código no encontrado. Intente de nuevo.");
                    continue; // vuelve a pedir
                }

                // Evitar eliminar al Administrador
                if (empleados[index].NombreCompleto.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No se puede eliminar al empleado 'Administrador'.");
                    Console.ReadKey();
                    return;
                }

                // Confirmar eliminación
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Empleado {empleados[index].NombreCompleto} eliminado correctamente.");
                empleados.RemoveAt(index);
                Console.ReadKey();
                return;
            }
        }



















        /*    
        static void menuPagos()
        {
                int opcionPagos;

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
                    string inputOpcionPagos = Console.ReadLine();

                    if (int.TryParse(inputOpcionPagos, out opcionPagos))
                    {
                        switch (opcionPagos)
                        {
                            case 1:
                                Console.Clear();
                                menuPagosOpcion1();
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                menuPagosOpcion2();
                                Console.ReadKey();
                                break;
                            case 0:

                                menuPagosOpcionSalida();
                                break;
                            default:
                                Console.WriteLine("Ingrese una opción válida.");
                                break;
                        }
                    }
                    else
                        Console.WriteLine("\nOpción no encontrada. Reintente.");

                } while (opcionPagos != 0);
        }

            
        
        static void menuPagosOpcion1()
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


            
        static void menuPagosOpcion2()
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


            
        static void menuPrincipalSalida()
        {

                Console.WriteLine("Desea Salir Del Programa?  ('s' para confirmar salida):  ");
                char confirmacion = Convert.ToChar(Console.ReadLine());

                if (confirmacion == 's' || confirmacion == 'S')
                {
                    Console.WriteLine("\nGracias por usar el programa. ¡Hasta luego!");
                    Environment.Exit(0); // cierra programa
                }
        }
        */









        // Función genérica para mostrar un menú con el mismo estilo visual
        static int MostrarMenu(string titulo, string[] opciones)
        {
            Console.Clear();

            char esquinSupIzq = '╔';
            char esquinSupDer = '╗';
            char esquinInfIzq = '╚';
            char esquinInfDer = '╝';
            char bordeHorizontal = '═';
            char bordeVertical = '║';
            char bordeHoriCenIzq = '╠';
            char bordeHoriCenDer = '╣';

            int ancho = opciones.Max(o => o.Length) + 6; // Ajusta el ancho automáticamente según el texto

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(esquinSupIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinSupDer);

            // Título centrado
            Console.Write(bordeVertical);
            Console.ForegroundColor = ConsoleColor.Cyan;
            string tituloCentrado = titulo.PadLeft((ancho + titulo.Length) / 2).PadRight(ancho);
            Console.Write($"{tituloCentrado}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(bordeVertical);

            Console.Write(bordeHoriCenIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(bordeHoriCenDer);

            // Mostrar opciones
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.Write(bordeVertical);

                if (opciones[i].Trim().StartsWith("0"))
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write($" {opciones[i].PadRight(ancho - 1)}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bordeVertical);
            }

            Console.Write(esquinInfIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinInfDer);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            int.TryParse(input, out int opcion);
            return opcion;
        }


        // Función para mostrar un encabezado con el mismo estilo visual
        static void MostrarEncabezado(string titulo)
        {
            Console.Clear();

            char esquinSupIzq = '╔';
            char esquinSupDer = '╗';
            char esquinInfIzq = '╚';
            char esquinInfDer = '╝';
            char bordeHorizontal = '═';
            char bordeVertical = '║';

            int ancho = titulo.Length + 10; // margen lateral

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(esquinSupIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinSupDer);

            Console.Write(bordeVertical);
            string tituloCentrado = titulo.PadLeft((ancho + titulo.Length) / 2).PadRight(ancho);
            Console.Write(tituloCentrado);
            Console.WriteLine(bordeVertical);

            Console.Write(esquinInfIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinInfDer);
            Console.ResetColor();
        }


















    }
}

