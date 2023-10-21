using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.Interfaces
{
    public interface IComboService
    {
        void FillObsCollection<T>(ObservableCollection<T> collection, List<T> dtos);

    }
}
