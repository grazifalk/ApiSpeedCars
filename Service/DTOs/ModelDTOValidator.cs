using FluentValidation;

namespace Service.DTOs
{
    public class ModelDTOValidator : AbstractValidator<ModelDTO>
    {
        public ModelDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name must be informed");
        }
    }
}
