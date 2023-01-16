using MediatR;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        private readonly IProdutoRepository _produtoRepository;

        public RegistrarCompraCommandHandler(IUnitOfWork uow, IMediator mediator, ISolicitacaoCompraRepository solicitacaoCompraRepository, IProdutoRepository produtoRepository) : base(uow, mediator)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacao =  new Domain.SolicitacaoCompraAggregate.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);
            var itens = request.Itens.Select(x => new Item(_produtoRepository.Obter(x.ProdutoId), x.Qtde)).ToList();
            solicitacao.RegistrarCompra(itens);

            _solicitacaoCompraRepository.RegistrarCompra(solicitacao);
            Commit();
            PublishEvents(solicitacao.Events);
            return await Task.FromResult(true);
        }
    }

}
