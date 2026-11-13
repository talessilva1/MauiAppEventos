using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppEventos.Models
{
    internal class Evento
    {
        public required String NomeEvento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public uint QntParticipantes { get; set; }
        public required String Local { get; set; }
        public decimal CustoIndividual { get; set; }

        public int Duracao
        {
            get
            {
                TimeSpan diferenca = DataTermino.Subtract(DataInicio);
                return diferenca.Days;
            }
        }

        public decimal CustoTotal
        {
            get => CustoIndividual * QntParticipantes;
        }
    }
}
