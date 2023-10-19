using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.Interfaces
{
    public interface IComboService
    {
        void FillGridCombobox<T>(DataGridView dataGrid, string columnDevName, List<T> nameOfMembers, string displayMember, string valueMember);
        void FillComboBox<T>(ComboBox comboBox, List<T> nameOfMembers, string displayMember, string valueMember);
        
    }
}
