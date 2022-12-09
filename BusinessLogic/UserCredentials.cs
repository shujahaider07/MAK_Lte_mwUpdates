using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class UserCredentials
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public char IsBLock { get; set; }
        public int LoginRetryCount { get; set; }
        public int MaxTry { get; set; }
        public int IsUserLogedin { get; set; }
        public string LastLoginTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string plainPassword { get; set; }
        public string Name { get; set; }

    }
}
