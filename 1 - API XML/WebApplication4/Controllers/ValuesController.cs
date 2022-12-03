using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication4.Controllers
{
    /// <summary>
    /// Está é uma API de teste.
    /// </summary>
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Método Get - Retorna todos os itens relacionados.
        /// </summary>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Método Get - Retorna o item relacionado a um ID específico.
        /// </summary>
        /// <param name="id">ID inteiro</param>
        /// <returns>String com informação</returns>
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Método Post - Registra um item novo.
        /// </summary>
        /// <param name="value">String para registro a partir do Body</param>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Método Put - Atualiza um item existente.
        /// </summary>
        /// <param name="id">ID inteiro do registro </param>
        /// <param name="value">String para alteração a partir do Body</param>
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Método Delete - Excluí um item.
        /// </summary>
        /// <param name="id">ID inteiro do registro</param>
        public void Delete(int id)
        {
        }
    }
}
