using Domain.Entities.Enum;
using FluentValidation;
using System.Net;
using System.Xml.Linq;

namespace Service.DTOs
{
    public class RenterDTOValidator : AbstractValidator<RenterDTO>
    {
        public RenterDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name must be informed");
            RuleFor(x => x.Birth).NotEmpty().NotNull().WithMessage("Birth must be informed");
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().WithMessage("PhoneNumber must be informed");
            RuleFor(x => x.Address).NotEmpty().NotNull().WithMessage("Address must be informed");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email must be informed");
            RuleFor(x => x.CPF).NotEmpty().NotNull().WithMessage("CPF must be informed");
            RuleFor(x => x.IdentityDocumentNumber).NotEmpty().NotNull().WithMessage("IdentityDocumentNumber must be informed");
            RuleFor(x => x.DriverLicenseNumber).NotEmpty().NotNull().WithMessage("DriverLicenseNumber must be informed");
            RuleFor(x => x.DocumentType).NotEmpty().NotNull().WithMessage("DocumentType must be informed");
        }
    }
}
