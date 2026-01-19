using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class DepartmentModel
    {


        [Key]
        [Required(ErrorMessage = "Department ID is required")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [MaxLength(150, ErrorMessage = "Department name cannot exceed 150 characters")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Creation date is required")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Modification date is required")]
        public DateTime Modified { get; set; }

    } 

}

/*
Referances
             https://www.youtube.com/watch?v=s4AU9xGe4yg&list=PL0_CROGOai7vP5mrOhyNncLtyOltUnGlB&index=4 
*/