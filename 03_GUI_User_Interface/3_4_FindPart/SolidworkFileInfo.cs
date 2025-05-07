using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM_Lynx._03_GUI_User_Interface._3_4_FindPart
{

    /// <summary>
    /// Class : Lưu trũ
    /// </summary>
    public class SolidworkFileInfo
    {
        public string Title { get; set; }
        public string FullPath { get; set; }

        public SolidworkFileInfo(string title, string fullPath)
        {
            Title = title;
            FullPath = fullPath;
        }

        public override string ToString()
        {
            return Title; // Hiển thị trong ComboBox
        }
    }
}
