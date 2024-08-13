using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feriados;

public class CalculosFeriados
{
    public List<(string, string)> feriadosFixosDates = [
    ("01-01", "Confraternização Universal"),
    ("21-04", "Tiradentes"),
    ("01-05", "Dia do Trabalhador"),
    ("07-09", "Independência do Brasil"),
    ("12-10", "Nossa Senhora Aparecida"),
    ("02-11", "Finados "),
    ("15-11", "Proclamação da republica"),
    ("20-11", "Dia Nacional de Zumbi e da Consciência Negra"),
    ("25-12", " Natal "),
    ("31-12", "Ano novo"),
    ];


    public IEnumerable<DateTime> RecuperaFeriados(int year)
    {

        var listFeriadosFixo = feriadosFixosDates;

        List<DateTime> listFeriados = new List<DateTime>();

        foreach (var date in listFeriadosFixo)
        {
            var feriado = date.Item1.Split('-');

            listFeriados.Add(new DateTime(year, int.Parse(feriado[1]), int.Parse(feriado[0])));
        }

        var feriados = feriadosCalculados(year);

        var listconcatenada = listFeriados.Concat(feriados);

        return listconcatenada;
    }

    public List<DateTime> feriadosCalculados(int year)
    {
        // Cálculo do Dia da Páscoa
        int x = 24;
        int y = 5;
        double a = year % 19;
        double b = year % 4;
        double c = year % 7;
        double d = (19 * a + x) % 30;
        double e = (2 * b + 4 * c + 6 * d + y) % 7;


        int dia;
        int mes;

        if ((d + e) > 9)
        {
            dia = (int)(d + e - 9);
            mes = 4;
        }
        else
        {
            dia = (int)(d + e + 22);
            mes = 3;
        }


        //dois casos particulares que aconteceram em 2049 e 2076
        if (dia == 26 && mes == 4)
        {
            dia = 19;
        }
        if (dia == 25 && d == 28 && a > 10)
        {
            dia = 18;
        }


        //domingo de pascoa
        DateTime date = new DateTime(year, mes, dia);
        List<DateTime> list = new List<DateTime>();

        //sexta feira da paixão
        list.Add(date.AddDays(-2));
        //segunda e terça de carnaval
        list.Add(date.AddDays(-47));
        list.Add(date.AddDays(-48));
        //quinta corpus christi
        list.Add(date.AddDays(60));


        return list;
    }
}
