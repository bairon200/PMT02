using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PMT02.Models
{
    public class Datos
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]

        public int Edad { get; set; }
        [MaxLength(50)]

        public string Fecha { get; set; }
        [MaxLength(50)]

        public string Direccion { get; set; }
        [MaxLength(100)]
        public string Sexo { get; set; }

    }
}
