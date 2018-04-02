using System;
using System.Collections.Generic;
using System.Linq;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.repository.Context;
using Microsoft.EntityFrameworkCore;

namespace alimentesebem.sesi.repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly ISesiContext _dbContext;

        public BaseRepository(ISesiContext context)
        {
            _dbContext = context;
        }


        public int Atualizar(T dados)
        {
            try
            {

                _dbContext.Set<T>().Update(dados);
                return _dbContext.SaveChanges();

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public T BuscarPorId(int id, string[] includes = null)
        {
            try
            {
                //Para buscar a chave primaria da classe
                var chavePrimaria = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];

                var query = _dbContext.Set<T>().AsQueryable();

                if (includes == null) return query.FirstOrDefault(e => EF.Property<int>(e, chavePrimaria.Name) == id);

                foreach (var item in includes)
                {
                    query = query.Include(item);
                }

                return query.FirstOrDefault(e => EF.Property<int>(e, chavePrimaria.Name) == id);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public int Deletar(int id)
        {
            try
            {
                var chavePrimaria = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];
                T dados = _dbContext.Set<T>().FirstOrDefault(e => EF.Property<int>(e, chavePrimaria.Name) == id);

                _dbContext.Set<T>().Remove(dados);
                return _dbContext.SaveChanges(); // retorna o numero de linhas afetadas              

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int Inserir(T dados)
        {
            try
            {

                _dbContext.Set<T>().Add(dados);
                return _dbContext.SaveChanges();

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> Listar(string[] includes = null)
        {
            try
            {
                var query = _dbContext.Set<T>().AsQueryable();

                if (includes == null) return query.ToList();

                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
                return query.ToList();
            }

            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
