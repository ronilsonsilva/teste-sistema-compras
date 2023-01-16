using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{

    public class SolicitacaoCompraRepository : ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this.context = context;
        }

        public void AtualizarCompra(Domain.SolicitacaoCompraAggregate.SolicitacaoCompra solicitacaoCompra)
        {
            context.Set<Domain.SolicitacaoCompraAggregate.SolicitacaoCompra>().Update(solicitacaoCompra);
        }

        public void ExcluirCompra(Domain.SolicitacaoCompraAggregate.SolicitacaoCompra solicitacaoCompra)
        {
            context.Set<Domain.SolicitacaoCompraAggregate.SolicitacaoCompra>().Remove(solicitacaoCompra);
        }

        public Domain.SolicitacaoCompraAggregate.SolicitacaoCompra ObterCompra(Guid id)
        {
            return context.Set<Domain.SolicitacaoCompraAggregate.SolicitacaoCompra>().Find(id);
        }

        public void RegistrarCompra(Domain.SolicitacaoCompraAggregate.SolicitacaoCompra solicitacaoCompra)
        {
            context.Set<Domain.SolicitacaoCompraAggregate.SolicitacaoCompra>().Add(solicitacaoCompra);
        }
    }
}
