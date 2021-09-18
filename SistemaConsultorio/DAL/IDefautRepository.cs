using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaConsultorio.DAL
{
    public interface IDefautRepository<TEntity> where TEntity : class
    {
            public List<TEntity> ListarTodos();
            public TEntity SelecionarPorId(int id);
            public TEntity Inserir(TEntity item);
            public TEntity Atualizar(TEntity item);
            public void Deletar(int id);
    }
}
