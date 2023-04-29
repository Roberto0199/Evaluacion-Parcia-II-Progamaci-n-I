int[,] tablero = new int[7, 7]; 

void paso1_crear_tablero()
{
    for (int i = 0; i < tablero.GetLength(0); i++)
    {
        for (int j = 0; j < tablero.GetLength(1); j++)
        {
            tablero[i, j] = 0;
        }
    }
}

void paso2_colocar_barcos()
{
    Random Aleatoria = new Random();
    
    for (int i = 0; i < 15; i++)
    {
        int fila = Aleatoria.Next(0, tablero.GetLength(0));
        int columna = Aleatoria.Next(0, tablero.GetLength(1));
        if (tablero[fila, columna] == 0)
        {
            tablero[fila, columna] = 1;
        }
        else
        {
            i--; 
        }
    }
}

void paso3_imprimir_tablero()
{
    Console.WriteLine(" 0 1 2 3 4 5 6");
    for (int i = 0; i < tablero.GetLength(0); i++)
    {
        Console.Write(i + " ");
        for (int j = 0; j < tablero.GetLength(1); j++)
        {
            string caracter_a_imprimir;
            switch (tablero[i, j])
            {
                case 0:
                    caracter_a_imprimir = "-";
                    break;
                case 1:
                    caracter_a_imprimir = "-";
                    break;
                case -1:
                    caracter_a_imprimir = "*";
                    break;
                case -2:
                    caracter_a_imprimir = "X";
                    break;
                default:
                    caracter_a_imprimir = "-";
                    break;
            }
            Console.Write(caracter_a_imprimir + " ");
        }
        Console.WriteLine();
    }
}

void paso4_ingreso_coordenadas()
{
    int fila = 0, columna = 0;
    int intentos_restantes = 15;
    int barcos_restantes = 3;
    do
    {
        Console.WriteLine($"Intentos restantes: {intentos_restantes}");
        try
        {
            Console.Write("Ingresa la fila: ");
            fila = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingresa la columna: ");
            columna = Convert.ToInt32(Console.ReadLine());

                if (fila < 0 || fila >= tablero.GetLength(0) || columna < 0 || columna >= tablero.GetLength(1))
            {

                throw new ArgumentException("Coordenadas fuera de rango.");
            }
            if (tablero[fila, columna] == 1)
            {
                Console.WriteLine("¡Le diste a un barco!");
                Console.Beep();
                tablero[fila, columna] = -1;
                barcos_restantes--;
            }
            else
            {
                Console.WriteLine("Fallaste");
                tablero[fila, columna] = -2;
            }

            intentos_restantes--;
            if (intentos_restantes == 0)
            {
                Console.WriteLine("¡Se acabaron los intentos!");
                break;
            }

            Console.Clear();
            paso3_imprimir_tablero();

            if (barcos_restantes == 0)
            {
                Console.WriteLine("¡Ganaste!");
                break;
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        } 
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida. Ingresa un número entero.");
        }
    } while (true);
}
paso1_crear_tablero();
paso2_colocar_barcos();
paso3_imprimir_tablero();
paso4_ingreso_coordenadas();
