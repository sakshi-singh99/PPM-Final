using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_Model
{
    public class AddEmpToProjModel
    {
        public AddEmpToProjModel() { }

        public AddEmpToProjModel(int projectId, int empID)
        {
            ProjectId = projectId;
            EmployeeId = empID;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public ProjectModel ProjectModel { get; set; }

        [Required(ErrorMessage = "Required")]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public EmployeeModel EmployeeModel { get; set; }

    }
}

