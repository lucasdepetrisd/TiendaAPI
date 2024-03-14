using Application.Contracts.ExternalServices;
using Application.DTOs;
using Domain.Models;
using Domain.Repositories;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Application.Services.ExternalServices
{
    public class AutorizacionTarjetaService : IAutorizacionTarjetaService
    {
        private readonly HttpClient _httpClient;
        private readonly AutorizacionTarjetaApisSettings _tokenEndpoint;
        private readonly AutorizacionTarjetaApisSettings _paymentEndpoint;
        private readonly string _tokenApiKey;
        private readonly string _paymentApiKey;
        private readonly string _tokenUri;
        private readonly string _paymentUri;

        public AutorizacionTarjetaService(
            IOptionsSnapshot<AutorizacionTarjetaApisSettings> namedOptionsAccessor,
            HttpClient httpClient)
        {
            _httpClient = httpClient;

            _tokenEndpoint = namedOptionsAccessor.Get(AutorizacionTarjetaApisSettings.TokenEndpoint);
            _paymentEndpoint = namedOptionsAccessor.Get(AutorizacionTarjetaApisSettings.PaymentEndpoint);

            if (string.IsNullOrEmpty(_tokenEndpoint?.ApiKey))
            {
                throw new ArgumentNullException(nameof(_tokenEndpoint.ApiKey), "API key cannot be null or empty.");
            }
            else if (string.IsNullOrEmpty(_paymentEndpoint?.ApiKey))
            {
                throw new ArgumentNullException(nameof(_paymentEndpoint.ApiKey), "API key cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(_tokenEndpoint.Uri))
            {
                throw new ArgumentNullException(nameof(_tokenEndpoint), "Token endpoint cannot be null or empty.");
            }
            else if (string.IsNullOrEmpty(_paymentEndpoint.Uri))
            {
                throw new ArgumentNullException(nameof(_paymentEndpoint), "Payment endpoint cannot be null or empty.");
            }

            _tokenApiKey = _tokenEndpoint.ApiKey;
            _tokenUri = _tokenEndpoint.Uri;
            _paymentApiKey = _paymentEndpoint.ApiKey;
            _paymentUri = _paymentEndpoint.Uri;
        }

        public async Task<bool> Autorizar(Venta venta, TarjetaDTO datosTarjeta)
        {
            try
            {
                var token = await SolicitarTokenPago(datosTarjeta);

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("Error al solicitar el token de pago");
                }

                var paymentResponse = await ConfirmarPago(venta.CalcularTotal(), token);

                if (!paymentResponse.status.Equals("approved", StringComparison.CurrentCultureIgnoreCase))
                {
                    var details = paymentResponse.status_details;
                    string errorMessage;

                    if (details.error != null && details.error is string error)
                    {
                        errorMessage = $"Error al confirmar el pago. Detalles: {error}";
                    }
                    else
                    {
                        errorMessage = $"Error al confirmar el pago. Detalles: " +
                               $"Ticket: {details.ticket}, " +
                               $"Authorization Code: {details.card_authorization_code}, " +
                               $"Address Validation Code: {details.address_validation_code}";
                    }

                    throw new InvalidOperationException(errorMessage);
                }

                /*Cliente cliente = new Cliente();
                cliente.Nombre = datosTarjeta.Titular.NombreCompleto;

                if (datosTarjeta.Titular.TipoDocumento.ToString().ToLower() == "dni")
                {
                    cliente.Dni = datosTarjeta.Titular.NroDocumento;
                }
                else if (datosTarjeta.Titular.TipoDocumento.ToString().ToLower() == "cuil")
                {
                    cliente.Cuil = datosTarjeta.Titular.NroDocumento;
                }

                await _clienteRepository.AddAsync(cliente);*/

                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al autorizar el pago: {ex.Message}");
            }
        }

        private async Task<string> SolicitarTokenPago(TarjetaDTO datosTarjeta)
        {
            try
            {
                if (datosTarjeta == null)
                {
                    throw new ArgumentNullException(nameof(datosTarjeta), "TarjetaDTO cannot be null.");
                }

                var request = new TokenRequest
                (
                    card_number: datosTarjeta.NumeroTarjeta,
                    card_expiration_month: datosTarjeta.MesExpiracion,
                    card_expiration_year: datosTarjeta.AñoExpiracion,
                    security_code: datosTarjeta.CVV,
                    card_holder_name: datosTarjeta.Titular.NombreCompleto,
                    card_holder_identification: new CardHolderIdentification
                    (
                        type: datosTarjeta.Titular.TipoDocumento.ToString(),
                        number: datosTarjeta.Titular.NroDocumento
                    )
                );

                var jsonRequest = JsonSerializer.Serialize(request);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, _tokenUri)
                {
                    Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
                };
                httpRequest.Headers.Add("apikey", _tokenApiKey);

                var response = await _httpClient.SendAsync(httpRequest);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error en la solicitud: {response.StatusCode}");
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(jsonResponse);

                if (tokenResponse == null || string.IsNullOrEmpty(tokenResponse.id))
                {
                    throw new InvalidOperationException("Invalid token response.");
                }

                return tokenResponse.id;

            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("Error sending HTTP request.", ex);
            }
            catch (JsonException ex)
            {
                throw new JsonException("Error deserializing JSON response.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while requesting token.", ex);
            }
        }

        public async Task<PaymentResponse> ConfirmarPago(decimal monto, string token)
        {
            try
            {
                var request = new PaymentRequest(
                    site_transaction_id: Guid.NewGuid().ToString(),
                    payment_method_id: 1,
                    token: token,
                    bin: "450799",
                    amount: (int)monto,
                    currency: "ARS",
                    installments: 1,
                    description: "",
                    payment_type: "single",
                    establishment_name: "single",
                    sub_payments:
                    [
                        new SubPayment
                        (
                            site_id: "",
                            amount: (int)monto,
                            installments: null!
                        )
                    ]
                );

                var jsonRequest = JsonSerializer.Serialize(request);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, _paymentUri)
                {
                    Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
                };
                httpRequest.Headers.Add("apikey", _paymentApiKey);

                var response = await _httpClient.SendAsync(httpRequest);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error en la solicitud: {response.StatusCode}");
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var paymentResponse = JsonSerializer.Deserialize<PaymentResponse>(jsonResponse);

                if (paymentResponse == null || string.IsNullOrEmpty(paymentResponse.status))
                {
                    throw new InvalidOperationException("Respuesta de pago invalida.");
                }

                return paymentResponse;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error sending HTTP request.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al confirmar el pago.", ex);
            }
        }

    }

    public class AutorizacionTarjetaApisSettings
    {
        public const string TokenEndpoint = "TokenEndpoint";
        public const string PaymentEndpoint = "PaymentEndpoint";

        public string ApiKey { get; set; } = string.Empty;
        public string Uri { get; set; } = string.Empty;
    }

    //Token Records

    public record TokenRequest(
        string card_number,
        string card_expiration_month,
        string card_expiration_year,
        string security_code,
        string card_holder_name,
        CardHolderIdentification card_holder_identification
    );

    public record CardHolderIdentification(
        string type,
        string number
    );

    public record TokenResponse(
        string id,
        string status,
        int card_number_length,
        DateTime date_created,
        string bin,
        string last_four_digits,
        int security_code_length,
        int expiration_month,
        int expiration_year,
        DateTime date_due,
        CardHolder cardholder
    );

    public record CardHolder(
        CardHolderIdentification identification,
        string name
    );

    //Payment Records

    public record PaymentRequest(
        string site_transaction_id,
        int payment_method_id,
        string token,
        string bin,
        int amount,
        string currency,
        int installments,
        string description,
        string payment_type,
        string establishment_name,
        IReadOnlyList<SubPayment> sub_payments
    );

    public record SubPayment(
        string site_id,
        int amount,
        object installments
    );

    public record PaymentResponse(
        int id,
        string site_transaction_id,
        int payment_method_id,
        string card_brand,
        int amount,
        string currency,
        string status,
        StatusDetails status_details,
        string date,
        object payment_mode,
        object customer,
        string bin,
        int installments,
        object first_installment_expiration_date,
        string payment_type,
        IReadOnlyList<object> sub_payments,
        string site_id,
        object fraud_detection,
        object aggregate_data,
        string establishment_name,
        object spv,
        object confirmed,
        object pan,
        object customer_token,
        string card_data,
        string token,
        object authenticated_token
    );

    public record StatusDetails(
        string ticket,
        string card_authorization_code,
        string address_validation_code,
        object error
    );

}