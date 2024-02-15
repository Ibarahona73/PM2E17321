using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PM2E17321.Models
{
    [Table("Sitios")]
    public class Sitios
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [MaxLength(20),NotNull]
        public double Latitud{ get; set; }

        [MaxLength(20),NotNull]
        public double Longitud { get; set; }

        public string Desc{ get; set; }

        public string foto { get; set; }

    }
}
