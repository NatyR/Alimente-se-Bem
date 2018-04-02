using System.Collections.Generic;

namespace alimentesebem.sesi.domain.Contracts
{
   public interface IBaseRepository<T> where T :class
    {
         IEnumerable<T> Listar(string[] includes = null);

         int Atualizar(T dados);

         int Inserir(T dados);

         int Deletar(int id);               

         T BuscarPorId(int id, string[] include = null);

    }
}