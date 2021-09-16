using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepoWebAPI.Entities;

namespace RepoWebAPI.Objects
{
    public class QuoteEntityConfiguration : IEntityTypeConfiguration<CoinMarketCapQuote>
    {
        public void Configure(EntityTypeBuilder<CoinMarketCapQuote> builder)
        {
            builder.Property(_ => _.Id).UseIdentityColumn();
            builder.Ignore(_ => _.Tags);
            builder.Ignore(_ => _.Platform);
        }
    }
}