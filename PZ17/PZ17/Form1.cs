using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace PZ17
{
    public partial class Form1 : Form
    {
        private const string ApiUrl = "https://api.frankfurter.app/latest";

        public Form1()
        {
            InitializeComponent();
            LoadCurrencies();
        }

        private async void LoadCurrencies()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(ApiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        CurrencyConversionResult result = JsonConvert.DeserializeObject<CurrencyConversionResult>(json);

                        comboBox1.Items.AddRange(result.Rates.Keys.ToArray());
                        comboBox2.Items.AddRange(result.Rates.Keys.ToArray());
                    }

                    else
                    {
                        MessageBox.Show("Failed to fetch currency data. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Failed to connect to the API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        private class CurrencyConversionResult
        {
            public Dictionary<string, decimal> Rates { get; set; }
        }

        private async void btnConvert_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                string fromCurrency = comboBox1.SelectedItem.ToString();
                string toCurrency = comboBox2.SelectedItem.ToString();

                if (decimal.TryParse(textBox1.Text, out decimal amount))
                {
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            HttpResponseMessage response = await client.GetAsync(ApiUrl);

                            if (response.IsSuccessStatusCode)
                            {
                                string json = await response.Content.ReadAsStringAsync();
                                CurrencyConversionResult result = JsonConvert.DeserializeObject<CurrencyConversionResult>(json);

                                if (result.Rates.ContainsKey(fromCurrency) && result.Rates.ContainsKey(toCurrency))
                                {
                                    decimal fromRate = result.Rates[fromCurrency];
                                    decimal toRate = result.Rates[toCurrency];
                                    decimal convertedAmount = amount * (toRate / fromRate);

                                    label.Text = $"{amount} {fromCurrency} = {convertedAmount} {toCurrency}";
                                }
                                else
                                {
                                    MessageBox.Show("Selected currencies are not available for conversion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Failed to fetch currency data. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show($"Failed to connect to the API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
