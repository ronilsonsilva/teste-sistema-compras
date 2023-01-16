using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;

            TotalGeral = new Money();
            Itens = new List<Item>();
            CondicaoPagamento = new CondicaoPagamento(0);
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            if (qtde < 1) throw new BusinessRuleException("Quantidade de itens deve ser maior que 0!");

            var item = new Item(produto, qtde);
            Itens.Add(item);

            TotalGeral = TotalGeral.Add(item.Subtotal);
        }


        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (!itens.Any()) throw new BusinessRuleException("A solicitação de compra deve possuir itens!");

            itens.ToList().ForEach(x => AdicionarItem(x.Produto, x.Qtde));

            if (TotalGeral.Value > 50000m)
                CondicaoPagamento.SetValor(30);
            else CondicaoPagamento.SetValor(0);
        }
    }
}
