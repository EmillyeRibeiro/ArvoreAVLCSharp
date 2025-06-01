using System;

namespace ArvoreAVL
{
    class Program
    {
        static void Main(string[] args)
        {
            Arvore arvore = new Arvore();

            if (File.Exists("dados.txt"))
            {
                string[] linhas = File.ReadAllLines("dados.txt");
                foreach (var linha in linhas)
                {
                    if (int.TryParse(linha, out int valor))
                    {
                        arvore.Inserir(valor);
                    }
                }
            }

            int opcao = -1;
            while (opcao != 0)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1 - Inserir valor");
                Console.WriteLine("2 - Remover valor");
                Console.WriteLine("3 - Buscar valor");
                Console.WriteLine("4 - Imprimir InOrder");
                Console.WriteLine("5 - Imprimir PosOrdem");
                Console.WriteLine("6 - Imprimir PreOrdem");
                Console.WriteLine("7 - Verificar balanceamento");
                Console.WriteLine("8 - Ver árvore visualmente");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string? entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out opcao))
                {
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o valor a inserir: ");
                        if (int.TryParse(Console.ReadLine(), out int valorInserir))
                        {
                            if (arvore.Existe(valorInserir))
                            {
                                Console.WriteLine("Valor já existe na árvore!");
                            }
                            else
                            {
                                arvore.Inserir(valorInserir);
                                Console.WriteLine("Valor inserido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido.");
                        }
                        break;

                    case 2:
                        Console.Write("Digite o valor a remover: ");
                        if (int.TryParse(Console.ReadLine(), out int valorRemover))
                        {
                            arvore.Remover(valorRemover);
                            Console.WriteLine("Valor removido (se existir).");
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido.");
                        }
                        break;

                    case 3:
                        Console.Write("Digite o valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorBuscar))
                        {
                            bool encontrado = arvore.Buscar(valorBuscar);
                            Console.WriteLine(encontrado ? "Valor encontrado!" : "Valor não encontrado.");
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Impressão InOrder:");
                        arvore.ImprimirInOrder();
                        break;

                    case 5:
                        Console.WriteLine("Impressão Pós-Ordem:");
                        arvore.ImprimirPosOrdem();
                        break;

                    case 6:
                        Console.WriteLine("Impressão Pré-Ordem:");
                        arvore.ImprimirPreOrdem();
                        break;

                    case 7:
                        Console.WriteLine("Verificando balanceamento...");
                        arvore.VerificarBalanceamento();
                        break;

                    case 8:
                        Console.WriteLine("Visual da árvore:");
                        arvore.ImprimirArvoreVisual();
                        break;

                    case 0:
                        Console.WriteLine("Encerrando o programa.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
