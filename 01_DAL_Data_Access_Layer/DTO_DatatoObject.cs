using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    public class DTO_DatatoObject
    {

    }

    public class ListNearPart
    {
        public int NoListNearPart { get; set; }
        public string MeanListNearPart { get; set; }

    }

    public class DataTransfer
    {
        public string _currentPartCode { get; set; }
        public string _currentPartName { get; set; }
        public DataTable listchild { get; set; }
    }

}
