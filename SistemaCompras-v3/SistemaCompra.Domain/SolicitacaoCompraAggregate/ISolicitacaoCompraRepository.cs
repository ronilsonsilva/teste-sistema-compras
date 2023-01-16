using System;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        SolicitacaoCompra ObterCompra(Guid id);
        void RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
        void AtualizarCompra(SolicitacaoCompra solicitacaoCompra);
        void ExcluirCompra(SolicitacaoCompra solicitacaoCompra);

    }
}
