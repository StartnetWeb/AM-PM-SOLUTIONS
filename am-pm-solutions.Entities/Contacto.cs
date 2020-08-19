using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace am_pm_solutions.Entities
{
    [Table("tblContactos")]
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        public DateTime FechaContacto { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(100, ErrorMessage = "El campo no puede superar los 100 caracteres")]
        [Display(Name = "Nombre y apellido")]
        public string NombreApellido { get; set; }

        [StringLength(50, ErrorMessage = "El campo no puede superar los 50 caracteres"), Required(ErrorMessage = "El número no puede estar vacio")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [StringLength(80, ErrorMessage = "El campo no puede superar los 80 caracteres"), Required(ErrorMessage = "El campo no puede estar vacio")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo no puede estar Vacio")]
        [Display(Name = "Mensaje")]
        public string Mensaje { get; set; }
    }
}
