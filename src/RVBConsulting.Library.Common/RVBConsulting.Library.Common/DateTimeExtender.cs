using System;

namespace RVBConsulting.Library.Common
{
    /// <summary>
	/// Classe extendida para os objetos DateTime
	/// </summary>
	public static class DateTimeExtender
    {
        /// <summary>
        /// Retorna a hora no formato HH:MM:SS
        /// </summary>
        /// <example>
        /// <code>
        /// using RVBConsulting.Library.Common;
        /// 
        /// public class ExemploDateTimeExtender
        /// {
        ///     public void BuscaHora()
        ///     {
        ///         var dataAtual = DateTime.Now;
        ///         var dataAtualHora = dataAtual.ToStringTimer();
        ///         
        ///         Console.Writeline(dataAtualHora);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <param name="date">Valor do tipo DateTime</param>
        /// <returns>Retorna a hora no ormato HH:mm:ss</returns>
        public static string ToStringTimer(this DateTime date)
        {
            string results;
            results = string.Format("{0:T}", date);

            return results;
        }

        /// <summary>
        /// Retorna a data com o mês por extenso
        /// </summary>
        /// <example>
        /// <code>
        /// using RVBConsulting.Library.Common;
        /// 
        /// public class ExemploDateTimeExtender
        /// {
        ///     public void DataMesporExtenso()
        ///     {
        ///         var dataAtual = DateTime.Now;
        ///         var dataAtualExtenso = dataAtual.GetExtensiceMonth();
        ///         
        ///         Console.Writeline(dataAtualExtenso);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <param name="date">Valor do tipo DateTime</param>
        /// <returns>Example: 01 de Janeiro de 1990</returns>
        public static string GetExtensiceMonth(this DateTime date)
        {
            string results = DateTime.Now.ToShortDateString();
            results = string.Format("{0:D}", date);
            string[] ar = results.Split(',');

            return ar[1];
        }

        /// <summary>
        /// Obter Saudações
        /// </summary>
        /// <example>
        /// <code>
        /// using RVBConsulting.Library.Common;
        /// 
        /// public class ExemploDateTimeExtender
        /// {
        ///     public void SaudacaoData()
        ///     {
        ///         var dataAtual = DateTime.Now;
        ///         var dataAtualSaudacao = dataAtual.GetSalutation();
        ///         
        ///         Console.Writeline(dataAtualSaudacao);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <param name="date">Valor do tipo DateTime</param>
        /// <returns>Retorna Bom Dia, Boa Tarde ou Boa Noite</returns>
        public static string GetSalutation(this DateTime date)
        {
            string results = string.Empty;

            if (date.Hour >= 0 && (date.Hour <= 12 && date.Minute <= 59))
                results = "Bom dia";
            else if (date.Hour >= 13 && (date.Hour <= 17 && date.Minute <= 59))
                results = "Boa Tarde";
            else
                results = "Boa Noite";

            return results;
        }

        /// <summary>
        /// Inverte data
        /// </summary>
        /// <example>
        /// <code>
        /// using RVBConsulting.Library.Common;
        /// 
        /// public class ExemploDateTimeExtender
        /// {
        ///     public void InverteData()
        ///     {
        ///         var dataAtual = DateTime.Now;
        ///         var dataAtualInvertida = dataAtual.ReverseDate();
        ///         
        ///         Console.Writeline(dataAtualInvertida);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <param name="date">Valor do tipo DateTime</param>
        /// <returns>Retorna o valor Invertido</returns>
        public static int ReverseDate(this DateTime date)
        {
            int results = 0;
            string[] data = new string[3];
            data[0] = date.Year.ToString();
            data[1] = ("00" + date.Month).Right(2);
            data[2] = ("00" + date.Day).Right(2);
            results = Convert.ToInt32(data[0] + data[1] + data[2]);

            return results;
        }
    }
}
