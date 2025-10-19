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


    //Estructura guardar datos clientes
    struct Cliente
    {
        public int Codigo;
        public string Nombre;
        public string Email;
        public string Telefono;

        public Cliente(int codigo, string nombre, string email, string telefono)
        {
            Codigo = codigo;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
        }
    }


    class Program
    {
        //Lista para guardar productos
        static List<Producto> productos = new List<Producto>();
        static int proximoCodigo = 1; //Generador automático de códigos

        //Lista para guardar empleados
        static List<Empleado> empleados = new List<Empleado>();
        static int contadorCodigo = 1;//Generador de codigo unico

        //Lista para guardar clientes
        static List<Cliente> clientes = new List<Cliente>();
        static int contadorCodigoCliente = 1;


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
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            MostrarMenuClientes();
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
        static void MostrarMenuClientes()
        {
            // Pre-cargar "Consumidor Final" si no existe
            if (clientes.FindIndex(c => c.Nombre.Equals("Consumidor Final", StringComparison.OrdinalIgnoreCase)) == -1)
            {
                clientes.Add(new Cliente(contadorCodigoCliente++, "Consumidor Final", "", ""));
            }

            int opcion;
            do
            {
                string[] opciones = new string[]
                {
                    "1. Lista de clientes",
                    "2. Cargar nuevo cliente",
                    "3. Modificar datos cliente",
                    "4. Eliminar cliente",
                    "0. Volver al menú principal",
                };

                opcion = MostrarMenu("MENÚ DE CLIENTES", opciones);

                switch (opcion)
                {
                    case 1: listaCliente(); break;
                    case 2: agregarCliente(); Console.ReadKey(); break;
                    case 3: modificarCliente(); Console.ReadKey(); break;
                    case 4: eliminarCliente(); Console.ReadKey(); break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nRegresando al menú principal...");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nOpción inválida. Intente nuevamente.");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0);
        }


        static void listaCliente()
        {
            Console.Clear();
            MostrarEncabezado("LISTA CLIENTES");

            if (clientes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No hay clientes registrados.");
            }
            else
            {
                foreach (var c in clientes)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Código: [{c.Codigo}] | Nombre: {c.Nombre} | Email: {c.Email} | Tel: {c.Telefono}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }


        static void agregarCliente()
        {
            Console.Clear();
            MostrarEncabezado("AGREGAR CLIENTE");

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

            string email;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Ingrese email (opcional): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                email = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(email))
                {
                    email = ""; // lo dejamos vacío
                    break;
                }

                //valida que contenga un dominio valido
                if (!email.Contains("@") || !email.Contains(".com"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Email inválido. Si lo ingresa, debe contener '@' y '.com'. Intente de nuevo.");
                    continue;
                }

                break; // email válido
            }

            string telefono;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Ingrese teléfono(opcional): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                telefono = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    telefono = "";
                    break;
                }

                // Validar que todos los caracteres sean números
                bool esNumerico = true;
                foreach (char c in telefono)
                {
                    if (!char.IsDigit(c))
                    {
                        esNumerico = false;
                        break;
                    }
                }

                if (!esNumerico)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("El teléfono debe contener solo números. Intente de nuevo.");
                    continue;
                }

                break;
            }


            clientes.Add(new Cliente(contadorCodigoCliente++, nombre, email, telefono));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCliente agregado correctamente.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }


        static void modificarCliente()
        {
            Console.Clear();
            MostrarEncabezado("MODIFICAR CLIENTE");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Ingrese el código o nombre del cliente: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string input = Console.ReadLine();
            Console.ResetColor();

            int index = -1;

            // Buscar por código o por nombre (ignorando mayúsculas/minúsculas)
            if (int.TryParse(input, out int codigoBuscado))
            {
                index = clientes.FindIndex(c => c.Codigo == codigoBuscado);
            }
            else
            {
                index = clientes.FindIndex(c => c.Nombre.Equals(input, StringComparison.OrdinalIgnoreCase));
            }

            if (index == -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nCliente no encontrado.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            // Obtener copia del cliente actual
            var clienteActual = clientes[index];

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCliente encontrado: [{clienteActual.Codigo}] - {clienteActual.Nombre}");
            Console.ResetColor();

            // Mostrar opciones de modificación
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n¿Qué desea modificar?");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. Teléfono");
            Console.WriteLine("3. Nombre");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("0. Cancelar");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            Console.ResetColor();

            // Valores que vamos a usar para reconstruir el struct (empezamos con los actuales)
            string nuevoNombre = clienteActual.Nombre;
            string nuevoEmail = clienteActual.Email;
            string nuevoTelefono = clienteActual.Telefono;

            switch (opcion)
            {
                case "1":
                    // Email opcional pero validado
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Ingrese nuevo email (opcional): ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        string e = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(e))
                        {
                            nuevoEmail = "";
                            break;
                        }

                        if (!e.Contains("@") || !e.Contains(".com"))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Email inválido. Si lo ingresa, debe contener '@' y '.com'. Intente de nuevo.");
                            continue;
                        }

                        nuevoEmail = e;
                        break;
                    }
                    break;

                case "2":
                    // Teléfono opcional pero numérico
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Ingrese nuevo teléfono (opcional): ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        string t = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(t))
                        {
                            nuevoTelefono = "";
                            break;
                        }

                        bool esNumerico = true;
                        foreach (char c in t)
                        {
                            if (!char.IsDigit(c))
                            {
                                esNumerico = false;
                                break;
                            }
                        }

                        if (!esNumerico)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("El teléfono debe contener solo números. Intente de nuevo.");
                            continue;
                        }

                        nuevoTelefono = t;
                        break;
                    }
                    break;

                case "3":
                    // Modificar nombre (no vacío)
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Ingrese nuevo nombre completo: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        string n = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(n))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("El nombre no puede estar vacío. Intente de nuevo.");
                            continue;
                        }
                        nuevoNombre = n;
                        break;
                    }
                    break;

                case "0":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nOperación cancelada.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nOpción inválida.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    return;
            }

            // Reconstruir el struct Cliente y sobrescribir en la lista
            clientes[index] = new Cliente(clienteActual.Codigo, nuevoNombre, nuevoEmail, nuevoTelefono);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDatos del cliente modificados correctamente.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }




        static void eliminarCliente()
        {
            Console.Clear();
            MostrarEncabezado("ELIMINAR CLIENTE");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("'0' para regresar.");

            if (clientes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No hay clientes para eliminar.");
                Console.ReadKey();
                return;
            }

            foreach (var c in clientes)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Código: {c.Codigo} | Nombre: {c.Nombre} | Email: {c.Email} | Tel: {c.Telefono}");
            }

            int codigo;

            while (true) // Bucle para volver a pedir si hay error
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nIngrese el código del cliente a eliminar: ");

                if (!int.TryParse(Console.ReadLine(), out codigo))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Entrada no válida. Intente de nuevo.");
                    continue;
                }

                if (codigo == 0)
                    return;

                int index = clientes.FindIndex(c => c.Codigo == codigo);

                if (index == -1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Código no encontrado. Intente de nuevo.");
                    continue;
                }

                if (clientes[index].Nombre.Equals("Consumidor Final", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No se puede eliminar al cliente 'Consumidor Final'.");
                    Console.ReadKey();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Cliente {clientes[index].Nombre} eliminado correctamente.");
                clientes.RemoveAt(index);
                Console.ReadKey();
                return;
            }

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

