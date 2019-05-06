using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_HocSinh_GiaoVien_THPT.Model
{
    class ComboItem
    {
        public string Key { get; set; }
        public int Value { get; set; }
        public ComboItem(string key, int value)
        {
            Key = key; Value = value;
        }
        public override string ToString()
        {
            return Key;
        }
    }
}
