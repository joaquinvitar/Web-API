using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locación.Shared.Data.Entidades
{
    [Index(nameof(ProvCódigo), Name = "UQ_País_ProvCódigo", IsUnique = true)]
    public class Provincia
    {
        public int    ID         { get; set; }

        [Required(ErrorMessage = "* Código de provincia no ingresado.")]
        [MaxLength(2, ErrorMessage = "* Máximo de caractéres sobrepasado.({1})")]
        public string ProvCódigo { get; set; }

        [Required(ErrorMessage = "* Nombre de provincia no ingresado.")]
        [MaxLength(100, ErrorMessage = "* Máximo de caractéres sobrepasado.({1})")]
        public string ProvNombre { get; set; }

        [Required(ErrorMessage = "* Provincia no ingresada.")]
        public int    PaísID     { get; set; }
        public País   País       { get; set; }
    }
}
