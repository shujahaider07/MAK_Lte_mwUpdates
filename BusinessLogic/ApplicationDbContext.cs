using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }



        public DbSet<Users> users { get; set; }
        public DbSet<Association> association { get; set; }
        public DbSet<Participants> participants { get; set; }
        public DbSet<ParticipantType> participantType { get; set; }
        public DbSet<Adaptor> adaptor { get; set; }
        public DbSet<AdaptorType> adaptorType { get; set; }
        public DbSet<TransactionIdentifier> TransactionIdentifier { get; set; }
        public DbSet<TransactionCodes> TransactionCodes { get; set; }
        public DbSet<TransactionCodeMapping> TransactionCodeMapping { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<TransactionalLogs> TransactionalLogs { get; set; }
        public DbSet<TransactionFields> TransactionFields { get; set; }
        public DbSet<ResponseCodes> ResponseCodes { get; set; }
        public DbSet<ResponseCodeMapping> ResponseCodeMapping { get; set; }
        public DbSet<TransactionRouter> TransactionRouter { get; set; }
        public DbSet<TransactionRoutings> TransactionRoutings { get; set; }
        public DbSet<UserCredentials> UserCredentials { get; set; }
        public DbSet<SafConfiguration> SafConfiguration { get; set; }
        public DbSet<SafLog> SafLog { get; set; }
        public DbSet<RuntimeFieldsCustomization> RuntimeFieldsCustomization { get; set; }
        public DbSet<EncodingType> EncodingType { get; set; }
        public DbSet<GeneralConfigurations> GeneralConfigurations { get; set; }
        public DbSet<InternalFields> InternalFields { get; set; }
        public DbSet<MessageFormatconfiguration> MessageFormatconfiguration { get; set; }
        public DbSet<Modules> Modules { get; set; }
        public DbSet<ApplicationPages> ApplicationPages { get; set; }
        public DbSet<PageAction> pageAction { get; set; }







    }

}
