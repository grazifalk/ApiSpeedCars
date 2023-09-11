using FluentValidation;

namespace Service.DTOs
{
    public class CarDTOValidator : AbstractValidator<CarDTO>
    {
        public CarDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name must be informed");
            RuleFor(x => x.Photo).NotEmpty().NotNull().WithMessage("Photo must be informed");
            RuleFor(x => x.Brand).NotEmpty().NotNull().WithMessage("Brand must be informed");
            RuleFor(x => x.Color).NotEmpty().NotNull().WithMessage("Color must be informed");
            RuleFor(x => x.Doors).NotEmpty().NotNull().WithMessage("Doors must be informed");
            RuleFor(x => x.Steering).NotEmpty().NotNull().WithMessage("Steering must be informed");
            /*RuleFor(x => x.PowerWindow).NotEmpty().NotNull().WithMessage("PowerWindow must be informed");
            RuleFor(x => x.PowerDoorLocks).NotEmpty().NotNull().WithMessage("PowerDoorLocks must be informed");
            RuleFor(x => x.AirConditioner).NotEmpty().NotNull().WithMessage("AirConditioner must be informed");*/
            RuleFor(x => x.Trunk).NotEmpty().NotNull().WithMessage("Trunk must be informed");
            RuleFor(x => x.Price).NotEmpty().NotNull().WithMessage("Price must be informed");
           /* RuleFor(x => x.Available).NotEmpty().NotNull().WithMessage("Available must be informed");*/
            RuleFor(x => x.ModelId).NotEmpty().NotNull().WithMessage("ModelId must be informed");
        }
    }
}
