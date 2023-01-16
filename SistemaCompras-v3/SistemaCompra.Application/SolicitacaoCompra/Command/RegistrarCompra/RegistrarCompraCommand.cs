using MediatR;
using SistemaCompra.Application.SolicitacaoCompra.DTO;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string NomeFornecedor { get; set; }
        public string UsuarioSolicitante { get; set; } //TO DO: Obter a partir do usuário da requisição
        public IList<ItemDto> Itens { get; set; }
    }

}
