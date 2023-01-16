using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class ItemConfiguration : IEntityTypeConfiguration<Domain.SolicitacaoCompraAggregate.Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("SolicitacaoCompraItem");

            builder.HasOne(x => x.Produto).WithMany();
        }
    }

}
