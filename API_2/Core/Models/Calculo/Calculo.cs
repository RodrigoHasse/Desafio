﻿using Core.Helpers;
using DecimalMath;
using FluentValidator.Validation;

namespace Core.Models.Calculo
{
    public partial class Calculo 
    {
        public decimal ValorInicial { get; set; }
        public int Tempo { get; set; }
        public decimal TaxaJuros { get; set; }
        private Calculo()
        {
            
        }
        public decimal Calcular()
        {
            var result = (DecimalEx.Pow(1 + TaxaJuros, Tempo));
            return DecimalHelpers.Truncate(ValorInicial * result, 2);
        }        
    }

    public class CalculoValidation : IContract
    {
        public ValidationContract Contract { get; }

        public CalculoValidation(Calculo calculo)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsGreaterThan(calculo.TaxaJuros, 0, "TaxaJuro", "A Taxa de juro deve ser maior que zero!")
                .IsGreaterThan(calculo.Tempo, 0, "Tempo", "O Tempo deve ser maior que zero!")
                .IsGreaterThan(calculo.ValorInicial, 0, "ValorInicial", "O Valor Inicial deve ser maior que zero!");
        }
    }
}