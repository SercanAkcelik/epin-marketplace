using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;

namespace Epin.Services
{
    /// <summary>
    /// Iyzico 3D Secure ödeme entegrasyonu.
    /// Checkout form oluşturma ve sonuç sorgulama.
    /// </summary>
    public class IyzicoPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly Options _options;

        public IyzicoPaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
            _options = new Options
            {
                ApiKey = _configuration["Iyzico:ApiKey"],
                SecretKey = _configuration["Iyzico:SecretKey"],
                BaseUrl = _configuration["Iyzico:BaseUrl"]
            };
        }

        /// <summary>
        /// Iyzico checkout form başlatır
        /// </summary>
        /// <param name="order">Sipariş bilgileri</param>
        /// <param name="user">Kullanıcı bilgileri</param>
        /// <param name="callbackUrl">Ödeme sonuç URL</param>
        /// <returns>Checkout form HTML içeriği</returns>
        public async Task<string> InitiateCheckoutAsync(
            Order order, 
            Users user, 
            string callbackUrl)
        {
            // 1. CreateCheckoutFormInitializeRequest oluştur
            // 2. Buyer, Address, BasketItem ekle
            // 3. CheckoutFormInitialize.Create çağır
            // 4. HTML form döndür
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ödeme sonucunu sorgular
        /// </summary>
        /// <param name="token">Callback token</param>
        /// <returns>Checkout form sonucu</returns>
        public async Task<CheckoutForm> RetrieveCheckoutFormAsync(string token)
        {
            // 1. RetrieveCheckoutFormRequest oluştur
            // 2. CheckoutForm.Retrieve çağır
            // 3. Sonuç döndür
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ödeme başarılı mı kontrol eder
        /// </summary>
        public bool IsPaymentSuccessful(CheckoutForm result)
        {
            // Status ve PaymentStatus kontrolü
            throw new NotImplementedException();
        }
    }
}
