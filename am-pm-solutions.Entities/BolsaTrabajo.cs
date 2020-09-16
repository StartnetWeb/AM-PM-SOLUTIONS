using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace am_pm_solutions.Entities
{
    [Table("tblBolsaTrabajo")]
    public class BolsaTrabajo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(100, ErrorMessage = "El campo no puede superar los 100 caracteres")]
        [Display(Name = "Nombre y apellido")]
        public string NombreApellido { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(100, ErrorMessage = "El campo no puede superar los 100 caracteres")]
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(100, ErrorMessage = "El campo no puede superar los 100 caracteres")]
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(100, ErrorMessage = "El campo no puede superar los 100 caracteres")]
        [Display(Name = "País")]
        public string País { get; set; }

        [StringLength(80, ErrorMessage = "El campo no puede superar los 80 caracteres"), Required(ErrorMessage = "El campo no puede estar vacio")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Nombre Archivo")]
        public string NombreArchivoCV { get; set; }

        [NotMapped][Display(Name = "Archivo")]
        public HttpPostedFileBase ArchivoCV { get; set; }
    }
}
