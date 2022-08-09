using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPM_Model;

namespace PPM_Contracts
{
    public interface IMapOperation
    {
        IEnumerable<MapModel> ListAll();
    }
}
