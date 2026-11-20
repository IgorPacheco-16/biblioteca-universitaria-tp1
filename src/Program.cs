// Igor Pacheco Santos
// 26T4-ENG-R1C2N1L1-DVBE-L5

using System.Text;

Console.OutputEncoding = Encoding.UTF8;

const int LimiteEmprestimos = 3;
const int PrazoDias = 14;

// Em cada grupo de arrays, o mesmo índice representa o mesmo registro.
int[] membroMatricula = { 2024001, 2024002, 2024003 };
string[] membroNome = { "Ana Souza", "Bruno Lima", "Carla Mendes" };

string[] empExemplar = { "PAT-0001", "PAT-0002", "PAT-0003", "PAT-0004", "PAT-0005", "PAT-0006", "PAT-0007" };
string[] empTitulo =
{
    "Algoritmos: Teoria e Prática",
    "Clean Code",
    "Introdução à Programação com C#",
    "Estruturas de Dados",
    "Banco de Dados Relacionais",
    "Engenharia de Software",
    "Redes de Computadores"
};
int[] empMatricula = { 2024001, 2024001, 2024001, 2024003, 2024003, 2024003, 2024003 };
DateTime[] empRetirada =
{
    DateTime.Today.AddDays(-5),
    DateTime.Today.AddDays(-20),
    DateTime.Today.AddDays(-30),
    DateTime.Today.AddDays(-2),
    DateTime.Today.AddDays(-7),
    DateTime.Today.AddDays(-10),
    DateTime.Today.AddDays(-1)
};
bool[] empDevolvido = { false, false, true, false, false, false, true };

Console.WriteLine("=== Biblioteca Universitária - Consulta de Empréstimos Ativos ===");
Console.WriteLine("Matrículas de exemplo: 2024001, 2024002, 2024003");

while (true)
{
    Console.WriteLine();
    Console.Write("Informe a matrícula do membro (0 para sair): ");
    string? entrada = Console.ReadLine();

    if (entrada is null)
    {
        break;
    }

    if (!int.TryParse(entrada, out int matricula))
    {
        Console.WriteLine("Entrada inválida. Digite apenas números.");
        continue;
    }

    if (matricula == 0)
    {
        Console.WriteLine("Encerrando o programa.");
        break;
    }

    int posicaoMembro = -1;
    for (int i = 0; i < membroMatricula.Length; i++)
    {
        if (membroMatricula[i] == matricula)
        {
            posicaoMembro = i;
            break;
        }
    }

    if (posicaoMembro == -1)
    {
        Console.WriteLine("Membro não cadastrado.");
        continue;
    }

    Console.WriteLine();
    Console.WriteLine($"Membro: {membroNome[posicaoMembro]} (matrícula {matricula})");
    Console.WriteLine("--------------------------------------------------");

    int totalAtivos = 0;
    for (int i = 0; i < empExemplar.Length; i++)
    {
        if (empMatricula[i] == matricula && !empDevolvido[i])
        {
            totalAtivos++;
            DateTime prazo = empRetirada[i].AddDays(PrazoDias);
            string situacao = prazo < DateTime.Today ? " (em atraso)" : "";

            Console.WriteLine($"Exemplar: {empExemplar[i]} - {empTitulo[i]}");
            Console.WriteLine($"Prazo de devolução: {prazo:dd/MM/yyyy}{situacao}");
            Console.WriteLine();
        }
    }

    if (totalAtivos == 0)
    {
        Console.WriteLine("Nenhum empréstimo ativo para este membro.");
        Console.WriteLine();
    }

    int vagas = LimiteEmprestimos - totalAtivos;
    if (vagas < 0)
    {
        vagas = 0;
    }

    Console.WriteLine($"Total de empréstimos ativos: {totalAtivos}");
    Console.WriteLine($"Vagas restantes até o limite de {LimiteEmprestimos}: {vagas}");
}
