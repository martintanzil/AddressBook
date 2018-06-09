using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public class AdressBook
    {
        //property = karakter = data = state
        public String Nama { get; set; }
        public String Alamat { get; set; }
        public String Kota { get; set; }
        public String NoHp { get; set; }
        public DateTime TanggalLahir { get; set; }
        public String  Email { get; set; }
    }
}
