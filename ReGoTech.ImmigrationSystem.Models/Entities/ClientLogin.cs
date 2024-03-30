
namespace ReGoTech.ImmigrationSystem.Models.Entities
{
	public class ClientLogin : EntityBase
	{
        public static int LockoutTryCount = 5;

        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
		public bool IsLockedOut { get; set; }
        public bool IsEmailVerified { get; set; }
        public DateTime? LockoutDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string EmailVerificationCode { get; set; }
		public int VerificationSentFailCount { get; set; }
		public int VerificationResendRequestCount { get; set; }
		public DateTime LastVerificationSentTime { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }


        public int ClientId { get; set; }
        public virtual required Client Client { get; set; }
    }
}
