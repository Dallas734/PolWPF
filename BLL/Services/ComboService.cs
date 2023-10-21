using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.Services
{
    public class ComboService : IComboService
    {
        IDbRepository dbContext;

        public ComboService(IDbRepository repository)
        {
            dbContext = repository;
        }

        public void FillObsCollection<T>(ObservableCollection<T> collection, List<T> dtos)
        {
            collection.Clear();

            foreach (var d in dtos)
            {
                collection.Add(d);
            }
        }
    }
}
