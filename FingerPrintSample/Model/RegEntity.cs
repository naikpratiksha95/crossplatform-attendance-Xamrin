using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintSample.Model
{
   public class RegEntity
    {
        public RegEntity()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime dateTime { get; set; }

    }
}
