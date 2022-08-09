using PPM_Model;
using System.Data.Entity;
using PPM.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PPM_EntityFrameWork
{
    public class ProjectList : IProjectOperation
    {
        //Add
        public string AddProject(ProjectModel project)
        {
          
                using (var db = new AppDbContextEntities())
                {
                var proj = new ProjectModel
                {
                    ProjectId = project.ProjectId,
                    ProjectName = project.ProjectName,
                    ProjectStartDate = project.ProjectStartDate,
                    ProjectEndDate = project.ProjectEndDate
                };
                db.Projects.Add(proj);
                    db.SaveChanges();
                }
                return "Added Successfully";
            
           
        }


        //List All
        public IEnumerable<ProjectModel> ListAll()
        {
            using (var db = new AppDbContextEntities())
            {
                var projects = new List<ProjectModel>();
                var allProjects = db.Projects.ToList();
                if (allProjects?.Any() == true)
                {
                    foreach (var project in allProjects)
                    {
                        projects.Add(new ProjectModel()
                        {
                            ProjectId = project.ProjectId,
                            ProjectName = project.ProjectName,
                            ProjectStartDate = project.ProjectStartDate,
                            ProjectEndDate = project.ProjectEndDate
                        });
                    }
                }
                return projects;
            }
        }

        //List By ID
        public ProjectModel ListByPid(int pId)
        {
            using (var db = new AppDbContextEntities())
            {
                var project = db.Projects.Where(s => s.ProjectId == pId).FirstOrDefault<ProjectModel>();               
                return project;
            }
        }

        //Delete by ID
        public void DeleteByPid(int pId)
        {
            using (var db = new AppDbContextEntities())
            {
                var project = db.Projects.Where(s => s.ProjectId == pId).FirstOrDefault<ProjectModel>();
                db.Projects.Remove(project);
                db.SaveChanges();
            }
        }

        public void UpdateProj(ProjectModel model)
        {
            using (var db = new AppDbContextEntities())
            {
                db.Entry(model).State =EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IEnumerable<ProjectModel> List()
        {
            using (var db = new AppDbContextEntities())
            {
                List<ProjectModel> r = db.Projects.ToList();

                return r;
            }
        }
    }

}
