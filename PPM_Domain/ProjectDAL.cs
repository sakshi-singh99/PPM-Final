using System.Collections.Generic;
using System.Linq;
using PPM_Model;
using PPM.Contracts;
using System;

namespace PPM_DAL
{
    public class ProjectDal : IProjectOperation
    {
        // Add Project
        private static List<ProjectModel> _project {get; set;} = new List<ProjectModel>();
          
        public string AddProject(ProjectModel project)
        {
                _project.Add(project);
               return "Added Successfully";
        }
        
        //	List By Id
        public ProjectModel ListByPid(int pId)
        {
            var searchProjectId = _project.FirstOrDefault(i => i.ProjectId==pId);
           return searchProjectId;
        }

        //Delete
        public void DeleteByPid(int pId)
        {
            AddEmpToProjDal obj = new AddEmpToProjDal();
            var searchProjectId = _project.FirstOrDefault(i => i.ProjectId == pId);
             _project.Remove(searchProjectId);
              obj.DelProj(pId);
        }

        public IEnumerable<ProjectModel> ListAll()
        {
           return _project;
        }
    }
}

