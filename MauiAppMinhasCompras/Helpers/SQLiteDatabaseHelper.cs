using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection conexao;

        public SQLiteDatabaseHelper(string caminho_pro_db3)
        {
            conexao = new SQLiteAsyncConnection(caminho_pro_db3);
            conexao.CreateTableAsync<Produto>().Wait(); // Cria uma tabela (arquivo de txt), com base na model Produto

        }

        public Task<int> Insert(Produto produto)
        {
            return conexao.InsertAsync(produto);
        }

        public Task<List<Produto>> Update(Produto produto)
        {
            string sql = "Update Produto SET Descricao=?, Quantidade=?, Preco=?" +
                         "WHERE Id=?";

            return conexao.QueryAsync<Produto>(
                sql, produto.Descricao, produto.Quantidade, produto.Quantidade, produto.Preco, produto.Id
                );
        }

        public Task<int> Delete(int Id)
        {
            return conexao.Table<Produto>().DeleteAsync(i => i.Id == Id);
        }

        public Task<List<Produto>> GetAll()
        {
            return conexao.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = $"SELECT * FROM Produto WHERE Descricao LIKE '%{q}%' ";

            return conexao.QueryAsync<Produto>(sql);
        }

    } // Fim Class
} // Fim Namespace
