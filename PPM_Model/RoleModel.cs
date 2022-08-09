using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPM_Model
{
    public class RoleModel 
    {
        public RoleModel() { }
        public RoleModel( string roleName)
        {
            RoleName = roleName;
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage ="Required")]
        public int RoleId{get; set;}

        [Required(ErrorMessage = "Required")]
        public string RoleName{get; set;}

    }
}
