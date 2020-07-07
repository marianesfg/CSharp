using System;
using System.Globalization;
using System.Text;

namespace Tax
{
    internal class Contribuinte
    {
        protected private string Nome { get; set; }

        protected private Decimal RendaAnual { get; set; }

        protected internal Contribuinte (string nome, decimal rendaAnual)
        {
            this.Nome = nome;
            this.RendaAnual = rendaAnual;
        }

        protected internal virtual decimal CalcImposto()
        {
            return 0;
        }

        protected internal string PrintTaxesPaid(decimal tax)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Nome);
            sb.Append(": $ ");
            sb.Append(tax.ToString("F2", CultureInfo.InvariantCulture));               
            return sb.ToString();            
        }

    }
}
