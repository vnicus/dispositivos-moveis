using MauiMinhasCompras2.Models;
using SQLite;

namespace MauiMinhasCompras2.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection conexao;

        public SQLiteDatabaseHelper(string db)
        {
            conexao = new SQLiteAsyncConnection(db);
            conexao.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return conexao.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string query = "Update Produto SET Descricao=?, Quantidade=?, Preco=?" + "WHERE id=?";

            return conexao.QueryAsync<Produto>(query, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }

        public Task<int> Delete(Produto p)
        {
            return conexao.Table<Produto>().DeleteAsync(i=> i.Id == p.Id);
        }
        
        public Task<List<Produto>> GetAll()
        {
            return conexao.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q)
        {
            string query = $"SELECT * FROM Produto WHERE Descricao LIKE '%{q}%'";

            return conexao.QueryAsync<Produto>(query);
        }
    }
}
