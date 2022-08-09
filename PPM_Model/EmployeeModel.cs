using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit;
using Xunit.Sdk;

namespace PPM_Model
{
   public class EmployeeModel
    {
        public EmployeeModel() { }

        public EmployeeModel(string empFirstName, string empLastName, string empEmail, string empMobile, string empPassword, string empAddress, int empRoleId )
        {
            EmpFirstName = empFirstName;
            EmpLastName = empLastName;
            EmpEmail = empEmail;
            EmpMobile = empMobile;
            EmpPassword = empPassword;
            EmpAddress = empAddress;
            EmpRoleId = empRoleId;
           
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ConcurrencyCheck]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Requied")]
        [DisplayName("First Name")]
        [RegularExpression("^[A-Z][a-zA-Z ]*$", ErrorMessage = "Invalid First Name !!")]
        public string EmpFirstName { get; set; }

        [Required(ErrorMessage = "Requied")]
        [RegularExpression("^[A-Z][a-zA-Z ]*$", ErrorMessage = "Invalid Last Name !!")]
        [DisplayName("Last Name")]
        public string EmpLastName { get; set; }

        [Required(ErrorMessage = "Requied")]
        [EmailAddress]
        [DisplayName("Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email !!")]
        public string EmpEmail { get; set; }

        [Required(ErrorMessage = "Requied")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
         ErrorMessage = "Required")]
        public string EmpPassword { get; set; }

        [Required(ErrorMessage = "Requied")]
        [DisplayName("Address")]
        [StringLength(20,ErrorMessage="Address length not be exceed")]
        public string EmpAddress { get; set; }

        [Required(ErrorMessage = "Requied")]
        [DisplayName("Mobile")]
        [RegularExpression(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})", ErrorMessage= "Invalid Mobile Number !!")]
        public string EmpMobile { get; set; }

        [Required(ErrorMessage = "Requied")]
        [DisplayName("Role Id")]
        public int  EmpRoleId { get; set; }

        [ForeignKey("EmpRoleId")]
        public RoleModel RoleMode { get; set; }

        //[NotMapped]
        //public List<EmployeeModel> Collection { get; set; }

        public string FullName
        {
            get { return EmpFirstName + " " + EmpLastName; }
        }

        
    }
}

