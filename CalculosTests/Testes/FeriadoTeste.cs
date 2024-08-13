using Feriados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculosTests.Testes;

public class FeriadoTeste
{
    private readonly Calendario calendario;
    public FeriadoTeste() 
    { 
        calendario = new Calendario();
    }

    [Theory]
    [InlineData("01/01/2024", false)]
    [InlineData("01/05/2003", false)]
    [InlineData("09/04/2004", false)]
    [InlineData("21/04/2004", false)]
    [InlineData("01/05/2004", false)]
    [InlineData("10/06/2004", false)]
    [InlineData("07/09/2004", false)]
    [InlineData("08/02/2005", false)]
    [InlineData("25/03/2005", false)]
    [InlineData("21/04/2005", false)]
    [InlineData("01/05/2005", false)]
    [InlineData("26/05/2005", false)]
    [InlineData("07/09/2005", false)]
    [InlineData("12/10/2005", false)]
    [InlineData("02/11/2005", false)]
    [InlineData("15/11/2005", false)]
    [InlineData("14/04/2006", false)]
    [InlineData("21/04/2006", false)]
    [InlineData("01/05/2006", false)]
    [InlineData("15/06/2006", false)]
    [InlineData("07/06/2007", false)]
    [InlineData("07/09/2007", false)]
    [InlineData("12/10/2007", false)]
    [InlineData("02/11/2007", false)]
    [InlineData("15/11/2007", false)]
    [InlineData("21/04/2008", false)]
    [InlineData("01/05/2008", false)]
    [InlineData("22/05/2008", false)]
    [InlineData("07/09/2008", false)]
    [InlineData("12/10/2008", false)]
    [InlineData("07/09/2009", false)]
    [InlineData("12/10/2009", false)]
    [InlineData("01/01/2010", false)]
    [InlineData("15/02/2010", false)]
    [InlineData("16/02/2010", false)]
    [InlineData("02/04/2010", false)]
    [InlineData("21/04/2010", false)]
    [InlineData("01/05/2010", false)]
    [InlineData("03/06/2010", false)]
    [InlineData("07/09/2010", false)]
    [InlineData("15/11/2010", false)]
    [InlineData("01/01/2012", false)]
    [InlineData("20/02/2012", false)]
    [InlineData("21/02/2012", false)]
    [InlineData("06/04/2012", false)]
    [InlineData("21/04/2012", false)]
    [InlineData("01/05/2012", false)]
    [InlineData("07/06/2012", false)]
    [InlineData("07/09/2012", false)]
    [InlineData("12/10/2012", false)]
    [InlineData("02/11/2012", false)]
    [InlineData("11/02/2013", false)]
    [InlineData("12/02/2013", false)]
    [InlineData("29/03/2013", false)]
    [InlineData("21/04/2013", false)]
    [InlineData("15/11/2013", false)]
    [InlineData("25/12/2013", false)]
    [InlineData("01/01/2014", false)]
    [InlineData("03/03/2014", false)]
    [InlineData("04/03/2014", false)]
    [InlineData("18/04/2014", false)]
    [InlineData("21/04/2014", false)]
    [InlineData("01/05/2014", false)]
    [InlineData("19/06/2014", false)]
    [InlineData("07/09/2014", false)]
    [InlineData("12/08/2024", true)]
    [InlineData("13/08/2024", true)]
    [InlineData("14/08/2024", true)]
    [InlineData("15/08/2024", true)]
    [InlineData("16/08/2024", true)]
    [InlineData("17/08/2024", false)]
    [InlineData("18/08/2024", false)]
    public void VerificaSeEhDiaUtil(string data, bool resultadoEsperado)
    {
        var splitDate = data.Split('/');
        var dataFormatada = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));

        Assert.Equal(calendario.EhDiaUtil(dataFormatada), resultadoEsperado);
    }

    [Theory]
    [InlineData("16/08/2024", "19/08/2024")]
    [InlineData("30/12/2030", "02/01/2031")]
    [InlineData("13/02/2026", "18/02/2026")]
    public void VerificaProximoDiaUtil(string data, string dataEsperada)
    {
        var splitDate = data.Split('/');
        var dataFormatada = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));

        var splitDataEsperada = dataEsperada.Split('/');
        var dataEsperadaFormatada = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));

        calendario.ProximoDiaUtil(dataFormatada);

        Assert.True(dataFormatada ==  dataEsperadaFormatada);
    }
}
