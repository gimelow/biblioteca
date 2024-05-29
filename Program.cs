using System;
using System.Collections.Generic;
using System.Linq;
using FuzzySharp;

Dictionary<string, List<double>> livrosLidos = new Dictionary<string, List<double>>();
livrosLidos.Add("billy summers", new List<double> { 4.5 });
livrosLidos.Add("a garota do lago", new List<double> { 3 });
livrosLidos.Add("cidades de papel", new List<double> { 3 });

Dictionary<string, List<double>> livrosLendo = new Dictionary<string, List<double>>();
livrosLendo.Add("a guerra dos tronos", new List<double> { 0 });

Dictionary<string, List<double>> livrosQueroLer = new Dictionary<string, List<double>>();
livrosQueroLer.Add("verity", new List<double> { 0 });
livrosQueroLer.Add("o festim dos corvos", new List<double> { 0 });
livrosQueroLer.Add("a culpa é das estrelas", new List<double> { 0 });
livrosQueroLer.Add("it a coisa", new List<double> { 0 });

Menu();

//função menu
void Menu()
{
    Console.WriteLine("MINHA BIBLIOTECA");
    Console.WriteLine("1 - LISTA DE LIVROS");
    Console.WriteLine("2 - AVALIAR LIVRO");
    Console.WriteLine("3 - VER NOTAS DOS LIVROS");
    Console.WriteLine("4 - MARCAR LIVRO COMO LIDO");
    Console.WriteLine("5 - MARCAR LIVRO COMO LENDO");
    Console.WriteLine("6 - ADICIONAR LIVRO");

    int opcao = int.Parse(Console.ReadLine()!);
    switch (opcao)
    {
        case 1:
            ListaDeLivros();
            break;
        case 2:
            AvaliarLivro();
            break;
        case 3:
            VerNotas();
            break;
        case 4:
            MarcarComoLido();
            break;
        case 5:
            MarcarComoLendo();
            break;
        case 6:
            AdicionarLivro();
            break;
        default:
            Menu();
            break;
    }
}

//função menu de listar livros
void ListaDeLivros()
{
        Console.Clear();
        Console.WriteLine("qual opção deseja ver?");
        Console.WriteLine("1 - lendo");
        Console.WriteLine("2 - lidos");
        Console.WriteLine("3 - quero ler");
        int opcao = int.Parse(Console.ReadLine()!);
        switch (opcao)
        {
            case 1:
                ListarLivrosLendo();
                break;
            case 2:
                ListarLivrosLidos();
                break;
            case 3:
            ListarLivrosQueroLer();
                break;
            default:
                Console.Clear();
                Console.WriteLine("digite uma opção válida");
                Thread.Sleep(2000);
                Console.Clear();
                Menu();
                break;
        }
       
        
 }

//função para listar livros lendo
void ListarLivrosLendo()
{
    Console.Clear();
    if (livrosLendo.Count == 0)
    {
        Console.WriteLine("nenhum livro está sendo lido no momento ;(.");
        Thread.Sleep(2000);
        Console.WriteLine("\ndigite qualquer teclar para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
    foreach (string livro in livrosLendo.Keys)
    {
        Console.WriteLine(livro);
    }
    Thread.Sleep(2000);
    Console.WriteLine("\ndigite qualquer teclar para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    Menu();
}

//função para listar livros lidos
void ListarLivrosLidos()
{
    Console.Clear();
    foreach (string livro in livrosLidos.Keys)
    {
        Console.WriteLine(livro);
    }
    Thread.Sleep(2000);
    Console.WriteLine("\ndigite qualquer teclar para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    Menu();
}

//função para listar livros queroler
void ListarLivrosQueroLer()
{
    Console.Clear();
    foreach (string livro in livrosQueroLer.Keys)
    {
        Console.WriteLine(livro);
    }
    Thread.Sleep(2000);
    Console.WriteLine("\ndigite qualquer teclar para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    Menu();
}

//função para avaliar livros
void AvaliarLivro()
    {
        Console.Clear();
        Console.WriteLine("qual livro deseja avaliar?");
        Console.WriteLine("somente um livro lido pode ser avaliado.");
        string livro = Console.ReadLine()!;

        var todosOsLivros = livrosLidos.Keys.Concat(livrosLendo.Keys).Concat(livrosQueroLer.Keys).ToList();
        var resultado = Process.ExtractOne(livro, todosOsLivros);

    if (resultado.Score >= 65)
    {
        Console.WriteLine($"\nvocê quis dizer: {resultado.Value}?");
        Console.WriteLine("1 - sim");
        Console.WriteLine("2 - não");
        int opcao = int.Parse(Console.ReadLine()!);
        if (opcao == 1)
        {
            livro = resultado.Value;
            if (livrosLidos.ContainsKey(livro))
            {
                Console.Clear();
                Console.WriteLine("\nqual nota você deseja dar para este livro?");
                double nota = Convert.ToDouble(Console.ReadLine()!);
                livrosLidos[livro].Add(nota);
                Console.WriteLine($"\na nota {nota} foi registrada com sucesso para o livro {livro}");
                Thread.Sleep(2000);
                Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }
            else if (livrosLendo.ContainsKey(livro) || livrosQueroLer.ContainsKey(livro))
            {
                Console.Clear();
                Console.WriteLine("\nesse livro ainda não foi finalizado e não pode ser avaliado.");
                Thread.Sleep(2000);
                Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }
        }
    }
    else
    {
        Console.WriteLine($"\no livro {livro} não foi encontrado!");
        Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
        }        
    

    //função pra ver notas
    void VerNotas()
    {
        Console.Clear();
        Console.WriteLine("qual livro deseja consultar a nota?");
        string livro = Console.ReadLine()!;
        if (livrosLidos.ContainsKey(livro))
        {
            Console.WriteLine($"\nnotas do livro {livro}");
            foreach (double nota in livrosLidos[livro])
            {
                Console.WriteLine(nota);
            }
            Thread.Sleep(2000);
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        if(livrosLendo.ContainsKey(livro))
        {
            Console.WriteLine("\nesse livro ainda está sendo lido e não possui notas.");
            Thread.Sleep(2000);
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        if(livrosQueroLer.ContainsKey(livro))
        {
            Console.WriteLine("\nesse livro ainda não foi iniciado e não possui notas.");
            Thread.Sleep(2000);
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        else
        {
            Console.WriteLine($"\no livro {livro} não foi encontrado!");
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }

    void MarcarComoLido()
    {
        Console.Clear();
        Console.WriteLine("qual livro deseja marcar como lido?");
        string livro = Console.ReadLine()!;
        if (livrosLendo.ContainsKey(livro))
        {
            livrosLidos.Add(livro, new List<double> { 0 });
            livrosLendo.Remove(livro);
            Console.WriteLine($"\no livro {livro} foi movido para a lista de livros lidos.");
            Thread.Sleep(2000);
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        if(livrosQueroLer.ContainsKey(livro))
        {
            Console.WriteLine($"\no livro {livro} ainda não foi iniciado e não pode ser marcado como lido.");
            Thread.Sleep(2000);
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        if(livrosLidos.ContainsKey(livro))
        {
            Console.WriteLine($"\no livro {livro} já foi lido.");
            Thread.Sleep(2000);
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        else
        {
            Console.WriteLine($"\no livro {livro} não foi encontrado!");
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }

    void MarcarComoLendo()
    {
        Console.Clear();
        Console.WriteLine("qual livro deseja marcar como lendo?");
        string livro = Console.ReadLine()!;
        if (livrosQueroLer.ContainsKey(livro))
        {
            livrosLendo.Add(livro, new List<double> { 0 });
            livrosQueroLer.Remove(livro);
            Console.WriteLine($"\no livro {livro} foi movido para a lista de livros sendo lidos.");
            Thread.Sleep(2000);
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        if (livrosLendo.ContainsKey(livro))
        {
            Console.WriteLine($"\no livro {livro} já está sendo lido.");
            Thread.Sleep(2000);
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        if(livrosLidos.ContainsKey(livro))
        {
            Console.WriteLine($"\no livro {livro} já foi lido.");
            Thread.Sleep(2000);
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        else
        {
            Console.WriteLine($"\no livro {livro} não foi encontrado!");
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
    void AdicionarLivro()
    {
        Console.Clear();
        Console.WriteLine("qual livro você deseja adicionar na sua biblioteca?");
        string livro = Console.ReadLine()!;
        if (livrosLidos.ContainsKey(livro) || livrosLendo.ContainsKey(livro) || livrosQueroLer.ContainsKey(livro))
        {
            Console.WriteLine($"\no livro {livro} já está na sua biblioteca.");
            Thread.Sleep(2000);
            Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        else
        {
            Console.WriteLine("\nqual a situação do livro?");
            Console.WriteLine("1 - quero ler");
            Console.WriteLine("2 - lendo");
            Console.WriteLine("3 - lido");
            int opcao = int.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 1:
                    livrosQueroLer.Add(livro, new List<double> { 0 });
                    Console.Clear();
                    Console.WriteLine($"o livro {livro} foi adicionado à sua biblioteca - quero ler");
                    Thread.Sleep(2000);
                    Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case 2:
                    livrosLendo.Add(livro, new List<double> { 0 });
                    Console.Clear();
                    Console.WriteLine($"o livro {livro} foi adicionado à sua biblioteca - lendo");
                    Thread.Sleep(2000);
                    Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case 3:
                    livrosLidos.Add(livro, new List<double> { 0 });
                    Console.Clear();
                    Console.WriteLine($"o livro {livro} foi adicionado à sua biblioteca - lido");
                    Thread.Sleep(2000);
                    Console.WriteLine("\ndigite qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                default:    
                    Console.WriteLine("digite uma opção válida");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Menu();
                    break;
            }
        }
    }

