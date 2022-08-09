using System.Collections.Generic;
using System.Text.RegularExpressions;
using PPM_Model;
using PPM_EntityFrameWork;
using System.Linq;

namespace PPM_Domain
{
    public class ProjectDomain
    {
        ProjectList objProj = new ProjectList();
        AddEmpToProjList objMap = new AddEmpToProjList();

        public string AddProj(ProjectModel project)
        {
            //Regex regexPname = new Regex("^[A-Z][a-zA-Z ]*$");

            //if (!regexPname.Match(project.ProjectName).Success)
            //{
            //    throw new System.Exception("Invalid Name !!");
            //}
            if (project.ProjectStartDate > project.ProjectEndDate)
            {
                return ("End Date is less than start Date");
            }
            if (objProj.ListAll().Any(p => p.ProjectName == project.ProjectName))
            {
                return ("Project Allready exist");
            }
            else
            {
                objProj.AddProject(project);
                return "Successfully added...";
        }
    }

        // List All
        public IEnumerable<ProjectModel> ListAll()
        {
            return objProj.ListAll();
        }

        //	List By Id
        public ProjectModel ListByProjid(int pId)
        {
            return objProj.ListByPid(pId);

        }

        //Delete

        public void DeleteByPid(int pId)
        {
            var project = objProj.ListByPid(pId);
            if (project == null)
            {
                //throw new System.Exception("Project does not exist");
            }
            else if (objMap.GetMappingInfo().Any(x => x.ProjectId == pId))
            {
                //throw new System.Exception("Remove dependencies before deleting project");
            }
            else
            {
                objProj.DeleteByPid(pId);
            }
        }

        public void UpdateProj(ProjectModel model)
        {
            objProj.UpdateProj(model);
        }

        public IEnumerable<ProjectModel> ListEmp()
        {
            return objProj.List();
        }

        //public string s(ProjectModel project)
        //{
        //    //if (objProj.ListAll().Any(p => p.ProjectName == project.ProjectName))
        //    //{
        //    //    return ("Project Allready exist");
        //    //}
        //    if (project.ProjectStartDate > project.ProjectEndDate)
        //    {
        //        return ("End Date is less than start Date");
        //    }
        //    return "";

        //}
    }
}
