using Microsoft.AspNetCore.Mvc;

namespace Epin.Controllers
{
    /// <summary>
    /// Iyzico 3D Secure ödeme işlemlerini yöneten controller.
    /// Checkout başlatma, callback işleme ve e-pin teslimatı.
    /// </summary>
    public class PaymentController : Controller
    {
        private readonly IyzicoPaymentService _paymentService;
        private readonly EpinDbContext _context;
        private readonly CellService _cellService;
        private readonly CellTrackingService _cellTrackingService;

        public PaymentController(
            IyzicoPaymentService paymentService,
            EpinDbContext context,
            CellService cellService,
            CellTrackingService cellTrackingService)
        {
            _paymentService = paymentService;
            _context = context;
            _cellService = cellService;
            _cellTrackingService = cellTrackingService;
        }

        /// <summary>
        /// Ödeme işlemini başlatır ve Iyzico checkout formunu oluşturur
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            // 1. Sepet doğrulama
            // 2. Sipariş oluşturma
            // 3. Kupon uygulama (varsa)
            // 4. Iyzico checkout form başlatma
            // 5. HTML form döndürme
            throw new NotImplementedException();
        }

        /// <summary>
        /// Iyzico'dan gelen ödeme sonucunu işler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Callback([FromForm] string token)
        {
            // 1. Ödeme sonucu sorgulama
            // 2. Başarılı ise: e-pin atama, sipariş tamamlama
            // 3. Başarısız ise: hata loglama, kupon rollback
            // 4. Referans komisyon işleme
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ödeme başarılı sayfası
        /// </summary>
        public IActionResult Success(int orderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ödeme başarısız sayfası
        /// </summary>
        public IActionResult Failed(string error)
        {
            throw new NotImplementedException();
        }
    }
}
