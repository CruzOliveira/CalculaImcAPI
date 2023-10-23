using Domain.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ConsultaUser : BaseEntity
    {
        
        public int id_user { get; set; }
        public string nome { get; set; }
        public decimal peso { get; set; }
        public decimal altura { get; set; }
        public decimal imc { get; set; }
        public string classificado { get; set; }
        public DateTime dt_pesquisa { get; set; }



    }
    public class ListConsultaUser
    {
        public List<USUARIO> USUARIO { get; set; }
    }


    public class HISTORIOCOIMC
    {
        public decimal peso { get; set; }
        public decimal altura { get; set; }
        public decimal imc { get; set; }
        public string classificado { get; set; }
        public DateTime dt_pesquisa { get; set; }
    }


    public class USUARIO
    {
        public int id_user { get; set; }
        public string nome { get; set; }
        public List<HISTORIOCOIMC> HISTORIOCOIMC { get; set; }
    }


}

