using MauiAppEventos.Models;
using static System.Net.Mime.MediaTypeNames;

namespace MauiAppEventos.Views;

public partial class Cadastro : ContentPage
{
	public Cadastro()
	{
		InitializeComponent();

		data_inicio.MinimumDate = DateTime.Now;
        data_inicio.MaximumDate = DateTime.Now.AddMonths(5);

        data_termino.MinimumDate = DateTime.Now.AddDays(1);
        data_termino.MaximumDate = DateTime.Now.AddMonths(6);
    }
    private void data_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        data_termino.MinimumDate = e.NewDate?.AddDays(1);
    }

    private void Cadastrar_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(nome_evento.Text))
                throw new ArgumentException("Nome do evento está vazio!");

            uint qntParticipantes;
            if (!uint.TryParse(qnt_participantes.Text, out qntParticipantes) || qntParticipantes <= 0)
                throw new ArgumentException("O número de participantes deve ser um número inteiro maior que 0!");

            if (string.IsNullOrWhiteSpace(local_evento.Text))
                throw new ArgumentException("Local do evento está vazio!");

            decimal custoIndividual;
            if (!decimal.TryParse(custo_individual.Text.TrimStart("R$"), out custoIndividual) || custoIndividual <= 0 ||
                custoIndividual != decimal.Round(custoIndividual, 2))
                throw new ArgumentException("O custo por participante deve ser um número maior que 0 e ter no máximo duas casas!");

            Evento evento = new()
            {
                NomeEvento = nome_evento.Text,
                DataInicio = data_inicio.Date.Value,
                DataTermino = data_termino.Date.Value,
                QntParticipantes = qntParticipantes,
                Local = local_evento.Text,
                CustoIndividual = custoIndividual
            };

            Navigation.PushAsync(new Resultado
            {
                BindingContext = evento,
            });
        } catch (Exception ex)
        {
            DisplayAlertAsync("Ops!", ex.Message, "OK");
        }
    }
}