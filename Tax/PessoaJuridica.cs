namespace Tax
{
    class PessoaJuridica : Contribuinte
    {
        protected private int NumeroFuncionarios { get; set; }

        protected internal PessoaJuridica (string nome, decimal rendaAnual, int numeroFuncionarios) : base (nome, rendaAnual)
        {
            this.NumeroFuncionarios = numeroFuncionarios;
        }

        protected internal override decimal CalcImposto()
        {
            if (this.NumeroFuncionarios > 10)
                return this.RendaAnual * 7 / 50;
            else
                return this.RendaAnual * 4 / 25;
        }
    }
}
