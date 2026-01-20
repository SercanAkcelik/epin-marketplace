namespace Epin.Services
{
    /// <summary>
    /// Çekiliş yönetim servisi.
    /// Oluşturma, katılım, kazanan seçimi.
    /// </summary>
    public class RaffleService
    {
        private readonly EpinDbContext _context;

        public RaffleService(EpinDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Tüm aktif çekilişleri listeler
        /// </summary>
        public async Task<List<Raffle>> GetActiveRafflesAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Kullanıcının çekilişe katılıp katılamayacağını kontrol eder
        /// </summary>
        /// <param name="userId">Kullanıcı ID</param>
        /// <param name="raffleId">Çekiliş ID</param>
        /// <returns>(Katılabilir mi, Hata mesajı)</returns>
        public async Task<(bool CanJoin, string? Error)> CanUserJoinAsync(
            int userId, 
            int raffleId)
        {
            // Katılım koşulları:
            // 1. ParticipationType.MembershipOnly - Sadece üyelik
            // 2. ParticipationType.ProductPurchase - Belirli ürün satın almış
            // 3. ParticipationType.MinimumOrderCount - Minimum sipariş sayısı
            throw new NotImplementedException();
        }

        /// <summary>
        /// Kullanıcıyı çekilişe ekler
        /// </summary>
        public async Task<bool> JoinRaffleAsync(int userId, int raffleId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rastgele kazanan seçer (cryptographically secure)
        /// </summary>
        public async Task<Users?> SelectWinnerAsync(int raffleId)
        {
            // RandomNumberGenerator kullanarak güvenli seçim
            throw new NotImplementedException();
        }

        /// <summary>
        /// Çekilişi tamamlandı olarak işaretler
        /// </summary>
        public async Task CompleteRaffleAsync(int raffleId, int winnerId)
        {
            throw new NotImplementedException();
        }
    }
}
