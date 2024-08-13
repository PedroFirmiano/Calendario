namespace Feriados;

public class Calendario
{

    /// <summary>
    /// Retorna um booleano informando se eh feriado ou nao
    /// </summary>
    /// <param name="date">data que deseja validar</param>
    /// <returns>DateTime</returns>
    public bool EhFeriado(DateTime data)
    {
        var feriado = new CalculosFeriados();
        var listFeriados = feriado.RecuperaFeriados(data.Year).ToList();


        return (listFeriados.Contains(data));
    }

    /// <summary>
    /// Retorna um booleano informando se eh dia util ou nao
    /// </summary>
    /// <param name="date">data que deseja validar</param>
    /// <returns>DateTime</returns>
    public bool EhDiaUtil(DateTime data)
    {
        if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday) return false;

        var feriado = new CalculosFeriados();
        var listFeriados = feriado.RecuperaFeriados(data.Year).ToList();

        return (!listFeriados.Contains(data));
    }

    /// <summary>
    /// Retorna o proximo dia util a partir de uma data especifica
    /// </summary>
    /// <param name="date">data que deseja validar</param>
    /// <returns>DateTime</returns>
    public DateTime ProximoDiaUtil(DateTime date)
    {
        bool ehDiaUtil = true;
        while (ehDiaUtil == true)
        {
            date = date.AddDays(1);
            ehDiaUtil = EhDiaUtil(date);
        }
        return date;
    }


    /// <summary>
    /// Retorna a lista de feriados com data fixa de um determinado ano
    /// </summary>
    /// <param name="ano">Ano que deseja validar</param>
    /// <returns>List<DateTime></returns>
    public List<DateTime> RecuperaFeriadosDeAnos(int year)
    {
        var feriado = new CalculosFeriados();

        var listFeriadosAnoAnterior = feriado.RecuperaFeriados(year - 1).ToList();
        var listFeriadosEsteAno = feriado.RecuperaFeriados(year).ToList();
        var listFeriadosProximoAno = feriado.RecuperaFeriados(year + 1).ToList();

        return listFeriadosAnoAnterior.Concat(listFeriadosEsteAno).Concat(listFeriadosProximoAno).ToList();
    }
}
