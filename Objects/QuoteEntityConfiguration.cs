using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepoWebAPI.Entities;

namespace RepoWebAPI.Objects
{
    public class QuoteEntityConfiguration : IEntityTypeConfiguration<CoinMarketCapQuote>
    {
        /*
         * configures model builder to ignore Tags and Platform properties
         */
        public void Configure(EntityTypeBuilder<CoinMarketCapQuote> builder)
        {
            builder.Ignore(_ => _.Tags);
            builder.Ignore(_ => _.Platform);
        }
    }
}