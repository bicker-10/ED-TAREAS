using ArbolesBinariosBST;
using System.Diagnostics;

while (true)
{
    Console.Clear();

    Console.WriteLine("=============================================");
    Console.WriteLine(" SISTEMA DE ÁRBOLES BINARIOS DE BÚSQUEDA");
    Console.WriteLine("=============================================");
    Console.WriteLine();

    Console.WriteLine("MENÚ PRINCIPAL");
    Console.WriteLine();
    Console.WriteLine("1. Cargar Árbol 1 - arbol1.txt");
    Console.WriteLine("2. Cargar Árbol 2 - arbol2.txt");
    Console.WriteLine("0. Salir");
    Console.WriteLine();
    Console.Write("Seleccione una opción: ");

    string? option = Console.ReadLine();

    string filePath;

    switch (option)
    {
        case "1":
            filePath = "arbol1.txt";
            break;

        case "2":
            filePath = "arbol2.txt";
            break;

        case "0":
            Console.WriteLine();
            Console.WriteLine("Programa finalizado correctamente.");
            return;

        default:
            Console.WriteLine();
            Console.WriteLine("Opción no válida.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            continue;
    }

    BinarySearchTree tree = new BinarySearchTree();

    Console.WriteLine();

    if (File.Exists(filePath))
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            if (int.TryParse(line, out int value))
            {
                tree.Insert(value);
            }
        }

        stopwatch.Stop();

        Console.WriteLine($"Archivo {filePath} cargado correctamente.");
        Console.WriteLine(
            $"Tiempo de construcción: " +
            $"{stopwatch.Elapsed.TotalMilliseconds:F4} ms"
        );

        Console.WriteLine();
        Console.WriteLine("INFORMACIÓN DEL ÁRBOL");
        Console.WriteLine("---------------------");
        Console.WriteLine($"Raíz del árbol: {tree.Root?.Value}");

        Console.Write("Recorrido inorden: ");
        tree.InOrder();

        Console.Write("Recorrido preorden: ");
        tree.PreOrder();

        Console.Write("Recorrido postorden: ");
        tree.PostOrder();

        Console.WriteLine($"Valor mínimo: {tree.FindMin()}");
        Console.WriteLine($"Valor máximo: {tree.FindMax()}");
        Console.WriteLine($"Altura del árbol: {tree.GetHeight()}");
        Console.WriteLine($"Número total de nodos: {tree.CountNodes()}");
        Console.WriteLine($"Número de hojas: {tree.CountLeaves()}");

        Console.WriteLine();
        Console.WriteLine("REPRESENTACIÓN GRÁFICA DEL ÁRBOL");
        Console.WriteLine("--------------------------------");
        tree.DisplayTree();

        Console.WriteLine();
        Console.WriteLine("CONSULTA DE ELEMENTOS");
        Console.WriteLine("---------------------");
        Console.Write("Ingrese un valor para buscar en el árbol: ");

        if (int.TryParse(Console.ReadLine(), out int searchValue))
        {
            if (tree.Search(searchValue))
            {
                Console.WriteLine(
                    $"El valor {searchValue} SÍ existe en el árbol."
                );
            }
            else
            {
                Console.WriteLine(
                    $"El valor {searchValue} NO existe en el árbol."
                );
            }
        }
        else
        {
            Console.WriteLine("El valor ingresado no es válido.");
        }
    }
    else
    {
        Console.WriteLine($"No se encontró el archivo {filePath}.");
    }

    Console.WriteLine();
    Console.WriteLine("Presione una tecla para volver al menú principal...");
    Console.ReadKey();
}