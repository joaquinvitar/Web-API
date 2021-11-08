using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locación.Shared.Data.Entidades
{
    [Index(nameof(PaísCódigo), Name = "UQ_País_PaísCódigo", IsUnique = true)]
    public class País
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "* Código de país no ingresado.")]
        [MaxLength(2, ErrorMessage = "* Máximo de caractéres sobrepasado.({1})")]
        public string PaísCódigo { get; set; }

        [Required(ErrorMessage = "* Nombre de país no ingresado.")]
        [MaxLength(100, ErrorMessage = "* Máximo de caractéres sobrepasado.({1})")]
        public string PaísNombre { get; set; }

        public List<Provincia> Provincias { get; set; }
    }
}
