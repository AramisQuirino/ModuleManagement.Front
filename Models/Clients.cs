using System.ComponentModel.DataAnnotations;

namespace ModuleManagement.Web.Client.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ClientList
    {
        // El Id se asigna automáticamente, por lo que no se ingresa en el formulario.
        public int IdClient { get; set; }

        [Required(ErrorMessage = "NameRequired")]
        [StringLength(100, ErrorMessage = "NameMaxLength")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SurnameRequired")]
        [StringLength(100, ErrorMessage = "SurnameMaxLength")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [StringLength(20, ErrorMessage = "OfficialIdentificationMaxLength")]
        public string OfficialIdentification { get; set; }

        // Usamos un dropdown para IdGender, de ahí el int
        [Required(ErrorMessage = "GenderRequired")]
        [Range(1, int.MaxValue, ErrorMessage = "GenderRequired")]
        public int IdGender { get; set; }

        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress(ErrorMessage = "EmailInvalid")]
        [StringLength(100, ErrorMessage = "EmailMaxLength")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneRequired")]
        [Phone(ErrorMessage = "PhoneInvalid")]
        [StringLength(15, ErrorMessage = "PhoneMaxLength")]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessage = "StreetMaxLength")]
        public string Street { get; set; }

        [StringLength(10, ErrorMessage = "ExtNumberMaxLength")]
        public string ExtNumber { get; set; }

        [StringLength(10, ErrorMessage = "IntNumberMaxLength")]
        public string IntNumber { get; set; }

        [StringLength(100, ErrorMessage = "NeighborhoodMaxLength")]
        public string Neighborhood { get; set; }

        [StringLength(10, ErrorMessage = "PostalCodeMaxLength")]
        public string PostalCode { get; set; }

        [StringLength(50, ErrorMessage = "StateMaxLength")]
        public string State { get; set; }
    }

    public class Gender
    {
        public int IdGender { get; set; }
        public string Name { get; set; }
    }
}
