using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    /// <summary>
    /// DTO - tblUsers
    /// </summary>
    public class tblUsers
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Passwords { get; set; }
        public string Roles { get; set; }
        public string Position { get; set; }
        public int Department { get; set; }
        public string DepartmentName { get; set; }
    }

    /// <summary>
    /// DTO - tblSupplier
    /// </summary>
    public class tblSupplier
    {
        public string SupName { get; set; }
        public string SupPhoneNumber { get; set; }
        public string SupTaxID { get; set; }
        public string SupLocation { get; set; }
        public string SupRepesentative { get; set; }
        public string SupNote { get; set; }
        public int SupID { get; set; }
    }

    public class tblPO
    {
        public string POCode { get; set; }

        public DateTime PODate { get; set; }
        public string PONhanVien { get; set; }
        public string POPartlist { get; set; }
        public string POAmount { get; set; }
        public string PONote { get; set; }
        public string POStatus { get; set; }
        public string POLog { get; set; }

    }

    public class tblCommonInfor
    {
        public int InforID { get; set; }
        public string InforName { get; set; }   
        public string InforValue { get; set; }
        public string InforLog { get; set; }


    }

    public class ListNearPart
    {
        public int NoListNearPart { get; set; }
        public string MeanListNearPart { get; set; }
    }

    public class ListNearECO
    {
        public int NoListNearECO { get; set; }
        public string MeanListNearECO { get; set; }
    }

    public class DataTransfer
    {
        public string _currentPartCode { get; set; }
        public string _currentPartName { get; set; }
        public int _currentPartStageID { get; set; }
        public DataTable listchild { get; set; }
    }


    public class tblECO
    {
        public int ECONo { get; set; }
        public  DateTime ECODate { get; set; }
        public string ECOLog { get; set; }
        public int ECOTypeID { get; set; }
        public int ECOIDProposal { get; set; }
        public int ECOIDApproved { get; set; }
        public int ECOStatusID { get; set; }
        public string ECOContent { get; set; }
        public string ECONameProposal {  get; set; }
        public string ECONameApproved { get; set; }
    }
}