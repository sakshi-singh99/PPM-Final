using System.Collections.Generic;
using PPM_Model;

namespace PPM.Contracts
{
    public interface IRoleOperation
    {
        string AddRole(RoleModel role);
        RoleModel ListByRid(int rId);
        void DeleteByRid(int rId);
        IEnumerable<RoleModel> ListAll();
    }
}
