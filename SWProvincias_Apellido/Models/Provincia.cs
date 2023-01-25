using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SWProvincias_Apellido.Models
{
  [Table("Provincia")]
    public class Provincia
    {
       [Key]
       public int IdProvincia{ get; set; }

       [Required]
       [Column(TypeName = "varchar(50)")]
       public string Nombre { get; set; }

       public List<Ciudad> Ciudades { get; set; }

    }
}
