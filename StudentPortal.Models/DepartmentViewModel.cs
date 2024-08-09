using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class DepartmentViewModel
    {
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Department Head")]
        public string DepartmentHead { get; set; }
    }
}
