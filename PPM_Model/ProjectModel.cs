using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPM_Model
{
    public class ProjectModel
    {
        public ProjectModel() { }

       
        public ProjectModel(string projectName, 
            DateTime projectStartDate, DateTime projectEndDate)
        {
            
           // ProjectId = projectId;
            ProjectName = projectName;
            ProjectStartDate = projectStartDate;
            ProjectEndDate = projectEndDate;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage ="Required")]
        [ConcurrencyCheck]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(20, ErrorMessage = "Project name not be exceed")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public DateTime? ProjectStartDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public DateTime? ProjectEndDate { get; set; }

}
}
