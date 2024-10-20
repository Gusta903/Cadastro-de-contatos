using Cadastro_de_contatos.Data;
using Cadastro_de_contatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_de_contatos.Repositório
{
    public class ContatoRepositorio : IContatorepositorio
    {
       
        private readonly BancoContext _bancoContext ;
        
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        //Lista o ID de cada contato para saber qual é 
        public ContatoModel ListaPorId(int Id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == Id);
        }
        //Lista todos os contatos para exibir na "Index"
        public List<ContatoModel> Todos()
        {
            return _bancoContext.Contatos.ToList();
        }
        //Adiciona um contato com "_context.Contatos.Add(contato)"
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
        //ContatoDB são as alterãções que irão ser feitas no contato
        //verifica se o Id é ou não nulo se for ocorre um erro se não ele vai dar ao contatoDB  as alterações do nome e depois retorna o contatoDB no lugar do contato

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListaPorId(contato.Id);
            
            if(contatoDB.Id == null)
            {
                throw new System.Exception("OCorreu um erro na atualização do contato");
            }
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Numero = contato.Numero;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }
        public bool Remover(int Id)
        {
            ContatoModel contatoDB = ListaPorId(Id);
            if (contatoDB == null) throw new System.Exception("Ocorreu um erro na remoção do contato");


            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
     
    }
}
