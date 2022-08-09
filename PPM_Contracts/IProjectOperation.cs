using System.Collections.Generic;
using PPM_Model;

namespace PPM.Contracts
{
    public interface IProjectOperation
    {
        string AddProject(ProjectModel project);
        ProjectModel ListByPid(int pId);
        void DeleteByPid(int pId);
        IEnumerable<ProjectModel> ListAll();
    }
}
