namespace Onboarding.Domain.ReportExtensions;
public static class ReportExtensions
{
    public static string StatusToString(this Enums.Status status)
    {
        return status switch
        {
            Enums.Status.Todo => "A Fazer",
            Enums.Status.InProgress => "Em Progresso",
            Enums.Status.Concluled => "Terminado",
            _ => "Não Definida"
        };
    }

    public static string PriorityToString(this Enums.Priority priority)
    {
        return priority switch
        {
            Enums.Priority.High => "Alta",
            Enums.Priority.Medium => "Média",
            Enums.Priority.Low => "Baixa",
            _ => "Não Definida"
        };
    }
}
