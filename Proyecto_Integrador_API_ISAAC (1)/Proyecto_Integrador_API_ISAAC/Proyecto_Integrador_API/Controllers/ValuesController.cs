﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto_Integrador_API.Controllers
{
    public class ValuesController : ApiController
    {
        //PRUEBA
        List<int> numeros = new List<int> { 1,2,3,4,5,6,7};

        // GET api/values
        public List<int> GetAll()
        {
            return numeros;
        }

        //PARA LA DECLARACION DEL MENSAJE
        public string GetMessage()
        {
            return "jajajaajajaja";
        }

        // GET api/values/5
        // ES DE MUCHA UTILIDAD SI QUIERES TRAER UN ID
        public int Get(int id)
        {
            return numeros.FirstOrDefault(x => x == id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
