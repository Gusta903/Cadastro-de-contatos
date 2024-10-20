using Cadastro_de_contatos.Models;
namespace Cadastro_de_contatos.Repositório
{
    public interface IContatorepositorio
    {
        ContatoModel ListaPorId(int Id);
        List<ContatoModel> Todos();
        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);
        bool Remover(int Id);
    }
}
