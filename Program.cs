using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Ingrese la cantidad de universidades que participan en el proceso: ");
        if (int.TryParse(Console.ReadLine(), out int cantidadUniversidades) && cantidadUniversidades > 0)
        {
            List<Universidad> universidades = new List<Universidad>();

            for (int i = 1; i <= cantidadUniversidades; i++)
            {
                Console.Write($"Ingrese el nombre de la Universidad {i}: ");
                string nombre = Console.ReadLine();
                Universidad universidad = new Universidad(nombre);
                while (true)
                {
                    Console.Write($"Ingrese voto para {nombre} (A/Aceptar, R/Rechazar, N/Nulo, B/Blanco, X/Terminar): ");
                    string voto = Console.ReadLine().ToUpper();

                    if (voto == "X")
                        break;

                    universidad.RegistrarVoto(voto);
                }

                universidades.Add(universidad);
            }
            Console.WriteLine("\nResultados de la votación por universidad:");
            foreach (var universidad in universidades)
            {
                universidad.MostrarResultados();
            }
            MostrarResultadoGeneral(universidades);
        }
        else
        {
            Console.WriteLine("Por favor, ingrese una cantidad válida de universidades.");
        }
    }

    static void MostrarResultadoGeneral(List<Universidad> universidades)
    {
        int aceptan = 0, rechazan = 0, empate = 0;

        foreach (var universidad in universidades)
        {
            if (universidad.Resultado == "Aceptar")
                aceptan++;
            else if (universidad.Resultado == "Rechazar")
                rechazan++;
            else
                empate++;
        }

        Console.WriteLine($"\nResultados Generales:\nUniversidades que Aceptan: {aceptan}\nUniversidades que Rechazan: {rechazan}\nUniversidades con Empate: {empate}");
    }
}

class Universidad
{
    public string Nombre { get; }
    private int votosAceptar;
    private int votosRechazar;
    private int votosNulo;
    private int votosBlanco;

    public string Resultado
    {
        get
        {
            if (votosAceptar > votosRechazar)
                return "Aceptar";
            else if (votosRechazar > votosAceptar)
                return "Rechazar";
            else
                return "Empate";
        }
    }

    public Universidad(string nombre)
    {
        Nombre = nombre;
        votosAceptar = 0;
        votosRechazar = 0;
        votosNulo = 0;
        votosBlanco = 0;
    }

    public void RegistrarVoto(string voto)
    {
        switch (voto)
        {
            case "A":
                votosAceptar++;
                break;
            case "R":
                votosRechazar++;
                break;
            case "N":
                votosNulo++;
                break;
            case "B":
                votosBlanco++;
                break;
            default:
                Console.WriteLine("Voto no válido.");
                break;
        }
    }

    public void MostrarResultados()
    {
        Console.WriteLine($"\nResultados para la Universidad {Nombre}:\n" +
                          $"Votos Aceptar: {votosAceptar}\n" +
                          $"Votos Rechazar: {votosRechazar}\n" +
                          $"Votos Nulo: {votosNulo}\n" +
                          $"Votos Blanco: {votosBlanco}\n" +
                          $"Resultado: {Resultado}");
    }
}
