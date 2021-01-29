using DoWhat.Models.CatagoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Contracts
{
    public interface ICatagoryService
    {
        IEnumerable<CatagoryListItem> GetCatagories();

        CatagoryDetail GetCatagoryById(int id);

        bool CreateCatagory(CatagoryCreate model);

        bool UpdateCatagory(CatagoryEdit model);

        bool DeleteCatagory(int catagoryId);

    }
}
