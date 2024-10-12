using System;
using Microsoft.Maui.Controls;

namespace ConversorApp
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnDistanciaClicked(object sender, EventArgs e)
        {
            ConverterDistancia();
        }

        private void OnPesoClicked(object sender, EventArgs e)
        {
            ConverterPeso();
        }

        private void OnTemperaturaClicked(object sender, EventArgs e)
        {
            ConverterTemperatura();
        }

        private void ConverterDistancia()
        {
            if (double.TryParse(NumDistancia.Text, out double distancia))
            {
                string unidadeOrigem = selectDistanciaOrigem.SelectedItem?.ToString();
                string unidadeDestino = selectDistanciaDestino.SelectedItem?.ToString();

                // Converte a entrada para metros
                double distanciaEmMetros = unidadeOrigem switch
                {
                    "Km" => distancia * 1000,
                    "Milhas" => distancia * 1609.34,
                    _ => distancia // Metro
                };

                // Converte para a unidade de destino
                double resultado = unidadeDestino switch
                {
                    "Km" => distanciaEmMetros / 1000,
                    "Milhas" => distanciaEmMetros / 1609.34,
                    _ => distanciaEmMetros // Metro
                };

                ResultadoDistancia.Text = $"Distância convertida: {resultado} {unidadeDestino}";
            }
            else
            {
                ResultadoDistancia.Text = "Erro: Insira um valor válido para a distância.";
            }
        }

        private void ConverterPeso()
        {
            if (double.TryParse(NumPeso.Text, out double peso))
            {
                string unidadeOrigem = selectPesoOrigem.SelectedItem?.ToString();
                string unidadeDestino = selectPesoDestino.SelectedItem?.ToString();

                // Converte a entrada para quilogramas
                double pesoEmQuilogramas = unidadeOrigem switch
                {
                    "Grama" => peso / 1000,
                    "Libra" => peso / 2.20462,
                    _ => peso // Quilograma
                };

                // Converte para a unidade de destino
                double resultado = unidadeDestino switch
                {
                    "Grama" => pesoEmQuilogramas * 1000,
                    "Libra" => pesoEmQuilogramas * 2.20462,
                    _ => pesoEmQuilogramas // Quilograma
                };

                ResultadoPeso.Text = $"Peso convertido: {resultado} {unidadeDestino}";
            }
            else
            {
                ResultadoPeso.Text = "Erro: Insira um valor válido para o peso.";
            }
        }

        private void ConverterTemperatura()
        {
            if (double.TryParse(NumTemp.Text, out double temp))
            {
                string unidadeOrigem = selectTemperaturaOrigem.SelectedItem?.ToString();
                string unidadeDestino = selectTemperaturaDestino.SelectedItem?.ToString();
                double tempEmCelsius;

                // Converte a entrada para Celsius
                tempEmCelsius = unidadeOrigem switch
                {
                    "Fahrenheit" => (temp - 32) * 5 / 9,
                    "Kelvin" => temp - 273.15,
                    _ => temp // Celsius
                };

                // Converte para a unidade de destino
                double resultado = unidadeDestino switch
                {
                    "Fahrenheit" => (tempEmCelsius * 9 / 5) + 32,
                    "Kelvin" => tempEmCelsius + 273.15,
                    _ => tempEmCelsius // Celsius
                };

                ResultadoTemperatura.Text = $"Temperatura convertida: {resultado} {unidadeDestino}";
            }
            else
            {
                ResultadoTemperatura.Text = "Erro: Insira um valor válido para a temperatura.";
            }
        }
    }
}
