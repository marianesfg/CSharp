namespace Tax
{
    class PessaoFisica : Contribuinte
    {      
        protected private decimal GastosSaude { set; get; }

        protected internal PessaoFisica(string nome, decimal rendaAnual, decimal gastosSaude) : base(nome, rendaAnual)
        {
            this.GastosSaude = gastosSaude;
        }      

        protected internal override decimal CalcImposto()
        {
            decimal impostoRenda;
            decimal gastosSaude = this.GastosSaude / 2;
            
            if (base.RendaAnual < 20000)
               impostoRenda =  this.RendaAnual * 3 / 20;
            else
                impostoRenda = this.RendaAnual / 4;

            return impostoRenda - gastosSaude;
        }
    }
}
