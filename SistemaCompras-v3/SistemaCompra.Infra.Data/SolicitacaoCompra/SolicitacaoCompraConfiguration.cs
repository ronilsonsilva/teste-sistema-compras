using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<Domain.SolicitacaoCompraAggregate.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<Domain.SolicitacaoCompraAggregate.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");

            builder.OwnsOne(x => x.TotalGeral, tg => tg.Property("Value").HasColumnName("TotalGeral"));
            builder.OwnsOne(x => x.CondicaoPagamento, tg => tg.Property("Valor").HasColumnName("CondicaoPagamento"));
            builder.OwnsOne(x => x.NomeFornecedor, tg => tg.Property("Nome").HasColumnName("NomeFornecedor"));
            builder.OwnsOne(x => x.UsuarioSolicitante, tg => tg.Property("Nome").HasColumnName("UsuarioSolicitante"));
            builder.HasMany(x => x.Itens).WithOne();
        }
    }

}
