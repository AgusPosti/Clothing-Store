using System;
using System.Collections.Generic;
using System.Linq;

namespace TiendaRopa
{
    // Estructuras principales
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

    struct Empleado
    {
        public int Codigo;
        public string NombreCompleto;
        public string Contrasena;

        public Empleado(int codigo, string nombreCompleto, string contrasena)
        {
            Codigo = codigo;
            NombreCompleto = nombreCompleto;
            Contrasena = contrasena;
        }
    }

    class Program
    {
        // Listas y contadores
        static List<Producto> productos = new List<Producto>();
        static List<Cliente> clientes = new List<Cliente>();
        static List<Empleado> empleados = new List<Empleado>();

        static int proximoCodigoProducto = 1;
        static int proximoCodigoCliente = 1;
        static int proximoCodigoEmpleado = 1;

        // Constantes
        const double IVA_PORC = 0.21;
        const double DESCUENTO_EFECTIVO = 0.10; // 10% descuento
        const double RECARGO_TARJETA = 0.15;    // 15% recargo

        static void Main(string[] args)
        {
            Console.Title = "Sistema de Gestión - Tienda de Ropa";
            CargarDatosIniciales();
            MenuPrincipal();
        }

        // ---------- Menú Principal ----------
        static void MenuPrincipal()
        {
            int opcion;
            do
            {
                string[] opciones = new string[]
                {
                    "1. Emisión de presupuestos / Ventas",
                    "2. Productos",
                    "3. Clientes",
                    "4. Empleados",
                    "5. Calcular precio final (descuento/recargos)",
                    "0. Salir"
                };

                opcion = MostrarMenu("MENÚ PRINCIPAL", opciones);

                switch (opcion)
                {
                    case 1: MenuVentas(); break;
                    case 2: MostrarMenuProductos(); break;
                    case 3: MostrarMenuClientes(); break;
                    case 4: MostrarMenuEmpleados(); break;
                    case 5: calcularPrecioFinal(); break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nGracias por usar el sistema. ¡Hasta luego!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nOpción inválida.");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0);
        }

        // ---------- MENÚ VENTAS (presupuestos / ventas) ----------
        static void MenuVentas()
        {
            Console.Clear();
            MostrarEncabezado("VENTAS / PRESUPUESTOS");

            // Asegurar que exista "Consumidor Final"
            if (clientes.FindIndex(c => c.Nombre.Equals("Consumidor Final", StringComparison.OrdinalIgnoreCase)) == -1)
            {
                clientes.Add(new Cliente(proximoCodigoCliente++, "Consumidor Final", "", ""));
            }

            Console.WriteLine("Clientes disponibles:");
            listaClienteSimple();

            int idCliente = LeerEnteroConMensaje("Ingrese el código del cliente (o 0 para Consumidor Final): ", allowZero: true);
            Cliente clienteSeleccionado;
            if (idCliente == 0)
            {
                clienteSeleccionado = clientes.First(c => c.Nombre.Equals("Consumidor Final", StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                int idx = clientes.FindIndex(c => c.Codigo == idCliente);
                if (idx == -1)
                {
                    MostrarError("Cliente no encontrado.");
                    return;
                }
                clienteSeleccionado = clientes[idx];
            }

            // Mostrar productos
            if (productos.Count == 0)
            {
                MostrarError("No hay productos cargados.");
                return;
            }

            listaProductos();

            int codigoProducto = LeerEnteroConMensaje("Ingrese código del producto: ");
            int idxProducto = productos.FindIndex(p => p.Codigo == codigoProducto);
            if (idxProducto == -1)
            {
                MostrarError("Producto no encontrado.");
                return;
            }

            Producto producto = productos[idxProducto];

            int cantidad = LeerEnteroConMensaje($"Cantidad (stock disponible: {producto.Stock}): ");
            if (cantidad <= 0)
            {
                MostrarError("La cantidad debe ser mayor a cero.");
                return;
            }
            if (cantidad > producto.Stock)
            {
                MostrarError("Stock insuficiente.");
                return;
            }


            double subtotal = producto.Precio * cantidad;
            double total = subtotal;

            // Método de pago
            Console.WriteLine("\nMétodo de pago:");
            Console.WriteLine("1. Efectivo (10% descuento)");
            Console.WriteLine("2. Tarjeta (sin recargo inicial)");
            int pago = LeerEnteroConMensaje("Opción: ");
            if (pago == 1)
            {
                total = total * (1 - DESCUENTO_EFECTIVO);
            }
            else if (pago != 2)
            {
                MostrarError("Método de pago inválido.");
                return;
            }

            // Actualizar stock
            producto.Stock -= cantidad;
            productos[idxProducto] = producto;

            // --- FACTURA ---
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--- FACTURA / PRESUPUESTO ---");
            Console.WriteLine($"Cliente: {clienteSeleccionado.Nombre}");
            Console.WriteLine($"Producto: {producto.Nombre} - Talle: {producto.Talle}");
            Console.WriteLine($"Precio unitario: ${producto.Precio:F2}");
            Console.WriteLine($"Cantidad: {cantidad}");
            Console.WriteLine($"Subtotal: ${subtotal:F2}");
            Console.WriteLine($"Total a pagar: ${total:F2}");
            if (pago == 1) Console.WriteLine("Pago: Efectivo (10% descuento aplicado)");
            else Console.WriteLine("Pago: Tarjeta (sin recargo inicial)");
            Console.ResetColor();

            // === NUEVO BLOQUE: CÁLCULO DE CUOTAS ===
            if (pago == 2) // Solo si se paga con tarjeta
            {
                Console.WriteLine("\n¿Desea calcular cuotas? (S/N): ");
                string opcionCuotas = Console.ReadLine().ToUpper();

                if (opcionCuotas == "S")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("=== PLANES DE CUOTAS DISPONIBLES ===");
                    Console.ResetColor();

                    Console.WriteLine("1 cuota sin interés.");
                    Console.WriteLine("3 cuotas con 10% de recargo total.");
                    Console.WriteLine("6 cuotas con 20% de recargo total.");
                    Console.WriteLine("12 cuotas con 35% de recargo total.");

                    int cuotas = LeerEnteroConMensaje("\nSeleccione cantidad de cuotas (1, 3, 6 o 12): ");
                    double totalConCuotas = total;
                    double interes = 0;

                    switch (cuotas)
                    {
                        case 1:
                            interes = 0;
                            break;
                        case 3:
                            interes = 0.10;
                            break;
                        case 6:
                            interes = 0.20;
                            break;
                        case 12:
                            interes = 0.35;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Cantidad de cuotas inválida. Se deja en 1 cuota sin interés.");
                            Console.ResetColor();
                            cuotas = 1;
                            interes = 0;
                            break;
                    }

                    totalConCuotas *= (1 + interes);
                    double valorCuota = totalConCuotas / cuotas;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nTotal con interés: ${totalConCuotas:F2}");
                    Console.WriteLine($"En {cuotas} cuotas de ${valorCuota:F2} cada una.");
                    Console.ResetColor();
                }
            }
            // === FIN BLOQUE NUEVO ===

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }


        // ---------- MENÚ PRODUCTOS ----------
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
                    case 0: return;
                    default:
                        MostrarError("Opción inválida.");
                        break;
                }

            } while (true);
        }

        static void agregarProductos()
        {
            Console.Clear();
            MostrarEncabezado("AGREGAR PRODUCTO");

            Producto nuevo = new Producto();
            nuevo.Codigo = proximoCodigoProducto++;

            Console.WriteLine("Ingresar '0' en cualquier momento para cancelar.");

            // Nombre (no vacío)
            string nombre;
            do
            {
                Console.Write("Nombre (no vacío): ");
                nombre = Console.ReadLine();
                if (nombre == "0") return;
                if (string.IsNullOrWhiteSpace(nombre)) MostrarErrorSinPausa("El nombre no puede estar vacío.");
            } while (string.IsNullOrWhiteSpace(nombre));
            nuevo.Nombre = nombre;

            // Categoría (validación sencilla)
            string[] categoriasValidas = { "Parte Superior", "Parte Inferior", "Parte Interior" };
            string categoria = null;
            do
            {
                Console.Write("Categoría (Parte Superior / Parte Inferior / Parte Interior): ");
                categoria = Console.ReadLine();
                if (categoria == "0") return;
                if (!categoriasValidas.Contains(categoria, StringComparer.OrdinalIgnoreCase))
                {
                    MostrarErrorSinPausa("Categoría inválida.");
                    categoria = null;
                }
            } while (string.IsNullOrWhiteSpace(categoria));
            nuevo.Categoria = categoriasValidas.First(c => c.Equals(categoria, StringComparison.OrdinalIgnoreCase));

            // Talle
            string[] tallesValidos = { "XS", "S", "M", "L", "XL" };
            string talle = null;
            do
            {
                Console.Write("Talle (XS, S, M, L, XL): ");
                talle = Console.ReadLine()?.ToUpper();
                if (talle == "0") return;
                if (!tallesValidos.Contains(talle))
                {
                    MostrarErrorSinPausa("Talle inválido.");
                    talle = null;
                }
            } while (string.IsNullOrWhiteSpace(talle));
            nuevo.Talle = talle;

            // Precio
            double precio = 0;
            do
            {
                Console.Write("Precio (número positivo): ");
                string input = Console.ReadLine();
                if (input == "0") return;
                if (!double.TryParse(input, out precio) || precio <= 0) MostrarErrorSinPausa("Precio inválido.");
            } while (precio <= 0);
            nuevo.Precio = precio;

            // Stock
            int stock = -1;
            do
            {
                Console.Write("Stock inicial (0 o más): ");
                string input = Console.ReadLine();
                if (input == "0") { stock = 0; break; }
                if (!int.TryParse(input, out stock) || stock < 0) MostrarErrorSinPausa("Stock inválido.");
            } while (stock < 0);
            nuevo.Stock = stock;

            productos.Add(nuevo);
            MostrarOK("Producto agregado correctamente.");
        }

        static void listaProductos()
        {
            Console.Clear();
            MostrarEncabezado("LISTA DE PRODUCTOS");

            if (productos.Count == 0)
            {
                MostrarErrorSinPausa("No hay productos cargados.");
                return;
            }

            Console.WriteLine("COD  | NOMBRE           | CATEGORÍA       | TALLE | PRECIO    | STOCK");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var p in productos)
            {
                Console.WriteLine($"{p.Codigo,-4} | {p.Nombre,-15} | {p.Categoria,-15} | {p.Talle,-5} | ${p.Precio,-8:F2} | {p.Stock}");
            }
        }

        static void buscarProductos()
        {
            Console.Clear();
            MostrarEncabezado("BUSCAR PRODUCTO POR NOMBRE");
            Console.Write("Buscar: ");
            string busqueda = Console.ReadLine()?.ToLower() ?? "";

            var encontrados = productos.FindAll(p => p.Nombre.ToLower().Contains(busqueda));
            if (encontrados.Count == 0)
            {
                MostrarErrorSinPausa("No se encontraron productos con ese nombre.");
                return;
            }

            Console.WriteLine("\nResultados:");
            foreach (var p in encontrados)
            {
                Console.WriteLine($"[{p.Codigo}] {p.Nombre} - {p.Categoria} - Talle {p.Talle} - ${p.Precio:F2} - Stock: {p.Stock}");
            }
        }

        static void ordenarPorPrecio()
        {
            Console.Clear();
            MostrarEncabezado("ORDENAR POR PRECIO");

            if (productos.Count == 0) { MostrarErrorSinPausa("No hay productos cargados."); return; }

            var listaOrdenada = new List<Producto>(productos);
            // Bubble sort (como ejemplo educativo)
            for (int i = 0; i < listaOrdenada.Count - 1; i++)
                for (int j = 0; j < listaOrdenada.Count - i - 1; j++)
                    if (listaOrdenada[j].Precio > listaOrdenada[j + 1].Precio)
                    {
                        var tmp = listaOrdenada[j];
                        listaOrdenada[j] = listaOrdenada[j + 1];
                        listaOrdenada[j + 1] = tmp;
                    }

            Console.WriteLine("COD  | NOMBRE           | CATEGORÍA       | TALLE | PRECIO    | STOCK");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var p in listaOrdenada)
                Console.WriteLine($"{p.Codigo,-4} | {p.Nombre,-15} | {p.Categoria,-15} | {p.Talle,-5} | ${p.Precio,-8:F2} | {p.Stock}");
        }

        static void ordenarPorCodigo()
        {
            Console.Clear();
            MostrarEncabezado("ORDENAR POR CÓDIGO");

            if (productos.Count == 0) { MostrarErrorSinPausa("No hay productos cargados."); return; }

            var listaOrdenada = new List<Producto>(productos);
            listaOrdenada.Sort((a, b) => a.Codigo.CompareTo(b.Codigo));

            Console.WriteLine("COD  | NOMBRE           | CATEGORÍA       | TALLE | PRECIO    | STOCK");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var p in listaOrdenada)
                Console.WriteLine($"{p.Codigo,-4} | {p.Nombre,-15} | {p.Categoria,-15} | {p.Talle,-5} | ${p.Precio,-8:F2} | {p.Stock}");
        }

        static void modificarStock()
        {
            Console.Clear();
            MostrarEncabezado("MODIFICAR STOCK");

            if (productos.Count == 0) { MostrarErrorSinPausa("No hay productos cargados."); return; }

            listaProductos();
            int codigo = LeerEnteroConMensaje("Ingrese el código del producto: ");
            int index = productos.FindIndex(p => p.Codigo == codigo);
            if (index == -1) { MostrarErrorSinPausa("Producto no encontrado."); return; }

            var producto = productos[index];
            Console.WriteLine($"Producto: {producto.Nombre} - Stock actual: {producto.Stock}");
            int nuevoStock = LeerEnteroConMensaje("Nuevo stock (0 o más): ");
            if (nuevoStock < 0) { MostrarErrorSinPausa("Stock inválido."); return; }

            producto.Stock = nuevoStock;
            productos[index] = producto;
            MostrarOK("Stock actualizado correctamente.");
        }

        // ---------- MENÚ CLIENTES ----------
        static void MostrarMenuClientes()
        {
            // Asegurar Consumidor Final
            if (clientes.FindIndex(c => c.Nombre.Equals("Consumidor Final", StringComparison.OrdinalIgnoreCase)) == -1)
            {
                clientes.Add(new Cliente(proximoCodigoCliente++, "Consumidor Final", "", ""));
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
                    "0. Volver al menú principal"
                };

                opcion = MostrarMenu("MENÚ DE CLIENTES", opciones);

                switch (opcion)
                {
                    case 1: listaCliente(); break;
                    case 2: agregarCliente(); break;
                    case 3: modificarCliente(); break;
                    case 4: eliminarCliente(); break;
                    case 0: return;
                    default:
                        MostrarError("Opción inválida.");
                        break;
                }
            } while (true);
        }

        static void listaCliente()
        {
            Console.Clear();
            MostrarEncabezado("LISTA CLIENTES");

            if (clientes.Count == 0)
            {
                MostrarErrorSinPausa("No hay clientes registrados.");
                return;
            }

            foreach (var c in clientsOrdered())
                Console.WriteLine($"Código: [{c.Codigo}] | Nombre: {c.Nombre} | Email: {c.Email} | Tel: {c.Telefono}");

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        // Helper simple list (sin pausa)
        static void listaClienteSimple()
        {
            foreach (var c in clientsOrdered())
                Console.WriteLine($"[{c.Codigo}] {c.Nombre}");
        }

        static IEnumerable<Cliente> clientsOrdered()
        {
            return clientes.OrderBy(c => c.Codigo);
        }

        static void agregarCliente()
        {
            Console.Clear();
            MostrarEncabezado("AGREGAR CLIENTE");

            Console.WriteLine("Ingrese '0' para cancelar en cualquier momento.");

            string nombre;
            do
            {
                Console.Write("Ingrese nombre completo: ");
                nombre = Console.ReadLine();
                if (nombre == "0") return;
                if (string.IsNullOrWhiteSpace(nombre)) MostrarErrorSinPausa("El nombre no puede estar vacío.");
            } while (string.IsNullOrWhiteSpace(nombre));

            // Email opcional pero validado si se ingresa
            string email;
            while (true)
            {
                Console.Write("Ingrese email (opcional): ");
                email = Console.ReadLine();
                if (email == "0") return;
                if (string.IsNullOrWhiteSpace(email)) { email = ""; break; }
                if (!email.Contains("@") || (!email.Contains(".com") && !email.Contains(".net") && !email.Contains(".org")))
                {
                    MostrarErrorSinPausa("Email inválido. Debe contener '@' y un dominio válido (ej. .com)");
                    continue;
                }
                break;
            }

            // Teléfono opcional y numérico si se ingresa
            string telefono;
            while (true)
            {
                Console.Write("Ingrese teléfono (opcional): ");
                telefono = Console.ReadLine();
                if (telefono == "0") return;
                if (string.IsNullOrWhiteSpace(telefono)) { telefono = ""; break; }
                if (!telefono.All(char.IsDigit)) { MostrarErrorSinPausa("El teléfono debe contener solo números."); continue; }
                break;
            }

            clientes.Add(new Cliente(proximoCodigoCliente++, nombre, email, telefono));
            MostrarOK("Cliente agregado correctamente.");
        }

        static void modificarCliente()
        {
            Console.Clear();
            MostrarEncabezado("MODIFICAR CLIENTE");

            if (clientes.Count == 0) { MostrarErrorSinPausa("No hay clientes registrados."); return; }

            listaClienteSimple();
            Console.Write("Ingrese el código o nombre del cliente: ");
            string input = Console.ReadLine();
            int index = -1;

            if (int.TryParse(input, out int code))
                index = clientes.FindIndex(c => c.Codigo == code);
            else
                index = clientes.FindIndex(c => c.Nombre.Equals(input, StringComparison.OrdinalIgnoreCase));

            if (index == -1) { MostrarErrorSinPausa("Cliente no encontrado."); return; }

            var clienteActual = clientes[index];
            Console.WriteLine($"Cliente seleccionado: [{clienteActual.Codigo}] {clienteActual.Nombre}");

            Console.WriteLine("1. Modificar email");
            Console.WriteLine("2. Modificar teléfono");
            Console.WriteLine("3. Modificar nombre");
            Console.WriteLine("0. Cancelar");
            string opcion = Console.ReadLine();

            string nuevoNombre = clienteActual.Nombre;
            string nuevoEmail = clienteActual.Email;
            string nuevoTelefono = clienteActual.Telefono;

            switch (opcion)
            {
                case "1":
                    while (true)
                    {
                        Console.Write("Ingrese nuevo email (opcional): ");
                        string e = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(e)) { nuevoEmail = ""; break; }
                        if (!e.Contains("@") || (!e.Contains(".com") && !e.Contains(".net") && !e.Contains(".org")))
                        {
                            MostrarErrorSinPausa("Email inválido.");
                            continue;
                        }
                        nuevoEmail = e;
                        break;
                    }
                    break;
                case "2":
                    while (true)
                    {
                        Console.Write("Ingrese nuevo teléfono (opcional): ");
                        string t = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(t)) { nuevoTelefono = ""; break; }
                        if (!t.All(char.IsDigit)) { MostrarErrorSinPausa("Teléfono inválido."); continue; }
                        nuevoTelefono = t;
                        break;
                    }
                    break;
                case "3":
                    while (true)
                    {
                        Console.Write("Ingrese nuevo nombre completo: ");
                        string n = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(n)) { MostrarErrorSinPausa("El nombre no puede estar vacío."); continue; }
                        nuevoNombre = n;
                        break;
                    }
                    break;
                case "0":
                    Console.WriteLine("Operación cancelada.");
                    Console.ReadKey();
                    return;
                default:
                    MostrarErrorSinPausa("Opción inválida.");
                    return;
            }

            clientes[index] = new Cliente(clienteActual.Codigo, nuevoNombre, nuevoEmail, nuevoTelefono);
            MostrarOK("Cliente modificado correctamente.");
        }

        static void eliminarCliente()
        {
            Console.Clear();
            MostrarEncabezado("ELIMINAR CLIENTE");

            if (clientes.Count == 0) { MostrarErrorSinPausa("No hay clientes registrados."); return; }

            listaCliente();

            int codigo = LeerEnteroConMensaje("Ingrese el código del cliente a eliminar ('0' para cancelar): ", allowZero: true);
            if (codigo == 0) return;

            int index = clientes.FindIndex(c => c.Codigo == codigo);
            if (index == -1) { MostrarErrorSinPausa("Código no encontrado."); return; }

            if (clientes[index].Nombre.Equals("Consumidor Final", StringComparison.OrdinalIgnoreCase))
            {
                MostrarErrorSinPausa("No se puede eliminar el cliente 'Consumidor Final'.");
                return;
            }

            clientes.RemoveAt(index);
            MostrarOK("Cliente eliminado correctamente.");
        }

        // ---------- MENÚ EMPLEADOS ----------
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
                    "0. Volver al menú principal"
                };

                opcion = MostrarMenu("MENÚ DE EMPLEADOS", opciones);

                switch (opcion)
                {
                    case 1: listaEmpleados(); break;
                    case 2: agregarEmpleado(); break;
                    case 3: eliminarEmpleado(); break;
                    case 0: return;
                    default:
                        MostrarError("Opción inválida.");
                        break;
                }
            } while (true);
        }

        static void listaEmpleados()
        {
            Console.Clear();
            MostrarEncabezado("LISTA EMPLEADOS");
            if (empleados.Count == 0) { MostrarErrorSinPausa("No hay empleados registrados."); return; }
            foreach (var e in empleados)
                Console.WriteLine($"Código: [{e.Codigo}] | Nombre: {e.NombreCompleto}");
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void agregarEmpleado()
        {
            Console.Clear();
            MostrarEncabezado("AGREGAR EMPLEADO");

            Console.Write("Ingrese nombre completo: ");
            string nombre = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nombre)) { MostrarErrorSinPausa("El nombre no puede estar vacío."); Console.Write("Ingrese nombre completo: "); nombre = Console.ReadLine(); }

            Console.Write("Ingrese contraseña: ");
            string pass = Console.ReadLine();

            empleados.Add(new Empleado(proximoCodigoEmpleado++, nombre, pass));
            MostrarOK("Empleado agregado correctamente.");
        }

        static void eliminarEmpleado()
        {
            Console.Clear();
            MostrarEncabezado("ELIMINAR EMPLEADO");
            if (empleados.Count == 0) { MostrarErrorSinPausa("No hay empleados registrados."); return; }

            listaEmpleados();
            int codigo = LeerEnteroConMensaje("Ingrese el código del empleado a eliminar ('0' para cancelar): ", allowZero: true);
            if (codigo == 0) return;

            int index = empleados.FindIndex(e => e.Codigo == codigo);
            if (index == -1) { MostrarErrorSinPausa("Código no encontrado."); return; }

            if (empleados[index].NombreCompleto.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                MostrarErrorSinPausa("No se puede eliminar al empleado 'Administrador'.");
                return;
            }

            empleados.RemoveAt(index);
            MostrarOK("Empleado eliminado correctamente.");
        }


        static void calcularPrecioFinal()
        {
            Console.Clear();
            MostrarEncabezado("CÁLCULO DE PRECIO FINAL");

            // Métodos de pago y cuotas
            string[] metodosPago = { "Efectivo", "Tarjeta", "Transferencia" };
            string[] cuotas = { "1 cuota", "3 cuotas", "6 cuotas", "12 cuotas" };

            // Matriz de recargos/descuentos (filas = método, columnas = cuotas)
            double[,] recargos = new double[3, 4]
            {
                { -0.10, 0.00, 0.00, 0.00 },  // Efectivo
                {  0.00, 0.10, 0.20, 0.35 },  // Tarjeta
                { -0.05, 0.00, 0.00, 0.00 }   // Transferencia
            };

            // Ingresar monto base
            Console.Write("Ingrese el monto total de la compra: $");
            if (!double.TryParse(Console.ReadLine(), out double montoBase))
            {
                Console.WriteLine("Monto inválido. Presione una tecla para volver...");
                Console.ReadKey();
                return;
            }

            // Elegir método de pago
            Console.WriteLine("\nMétodos de pago disponibles:");
            for (int i = 0; i < metodosPago.Length; i++)
                Console.WriteLine($"{i + 1}. {metodosPago[i]}");
            Console.Write("Seleccione el método de pago: ");
            int metodo = int.Parse(Console.ReadLine()) - 1;

            // Elegir cuotas
            Console.WriteLine("\nOpciones de cuotas:");
            for (int j = 0; j < cuotas.Length; j++)
                Console.WriteLine($"{j + 1}. {cuotas[j]}");
            Console.Write("Seleccione cantidad de cuotas: ");
            int opcionCuota = int.Parse(Console.ReadLine()) - 1;

            // Calcular recargo o descuento
            double porcentaje = recargos[metodo, opcionCuota];
            double montoFinal = montoBase * (1 + porcentaje);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== RESUMEN DE PAGO ===");
            Console.WriteLine($"Método: {metodosPago[metodo]}");
            Console.WriteLine($"Cuotas: {cuotas[opcionCuota]}");

            if (porcentaje < 0)
                Console.WriteLine($"Descuento aplicado: {Math.Abs(porcentaje * 100)}%");
            else if (porcentaje > 0)
                Console.WriteLine($"Recargo aplicado: {porcentaje * 100}%");
            else
                Console.WriteLine("Sin recargo ni descuento.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nMonto final a pagar: ${montoFinal:F2}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }




        // ---------- UTILIDADES: menus, encabezados, mensajes y lectura segura ----------
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

            int ancho = Math.Max(titulo.Length, opciones.Max(o => o.Length)) + 6;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(esquinSupIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinSupDer);

            Console.Write(bordeVertical);
            string tituloCentrado = titulo.PadLeft((ancho + titulo.Length) / 2).PadRight(ancho);
            Console.Write($"{tituloCentrado}");
            Console.WriteLine(bordeVertical);

            Console.Write(bordeHoriCenIzq);
            for (int i = 0; i < ancho; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(bordeHoriCenDer);

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
            Console.ResetColor();

            string input = Console.ReadLine();
            int.TryParse(input, out int opcion);
            return opcion;
        }

        static void MostrarEncabezado(string titulo)
        {
            Console.Clear();
            char esquinSupIzq = '╔';
            char esquinSupDer = '╗';
            char esquinInfIzq = '╚';
            char esquinInfDer = '╝';
            char bordeHorizontal = '═';
            char bordeVertical = '║';
            int ancho = titulo.Length + 10;

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

        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n⚠️  {mensaje}");
            Console.ResetColor();
            Console.ReadKey();
        }

        // versión sin ReadKey (para usar dentro de bucles)
        static void MostrarErrorSinPausa(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n⚠️  {mensaje}");
            Console.ResetColor();
        }

        static void MostrarOK(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✔️  {mensaje}");
            Console.ResetColor();
            Console.ReadKey();
        }

        // Lectura segura de enteros con mensaje
        static int LeerEnteroConMensaje(string mensaje, bool allowZero = false)
        {
            int res;
            while (true)
            {
                Console.Write(mensaje);
                string s = Console.ReadLine();
                if (allowZero && s == "0") return 0;
                if (int.TryParse(s, out res)) return res;
                MostrarErrorSinPausa("Entrada no válida. Ingrese un número entero.");
            }
        }

        // ---------- Datos de prueba ----------
        static void CargarDatosIniciales()
        {
            // Productos de ejemplo
            productos.Add(new Producto(proximoCodigoProducto++, "Remera Nike", "Parte Superior", "M", 25000, 10));
            productos.Add(new Producto(proximoCodigoProducto++, "Zapatillas Adidas", "Calzado", "42", 75000, 5));
            productos.Add(new Producto(proximoCodigoProducto++, "Campera Puma", "Parte Superior", "L", 90000, 3));

            // Clientes de ejemplo
            clientes.Add(new Cliente(proximoCodigoCliente++, "Juan Pérez", "juan@mail.com", "3814567890"));
            clientes.Add(new Cliente(proximoCodigoCliente++, "María López", "maria@mail.com", "3814123456"));
            // Consumidor Final se asegura en los menús

            // Empleados de ejemplo: administrador por defecto
            empleados.Add(new Empleado(proximoCodigoEmpleado++, "Administrador", "1234"));
        }
    }
}
