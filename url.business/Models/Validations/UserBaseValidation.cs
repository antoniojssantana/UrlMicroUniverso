using FluentValidation;

namespace url.business.Models.Validations
{
    public class UserBaseValidation : AbstractValidator<UserBaseModel>
    {
        public UserBaseValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(p => p.Name)
              .MaximumLength(150).WithMessage("O campo {PropertyName} não pode ser maior que {MaxLength}.");

            RuleFor(p => p.Cpf)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(p => p.Cpf)
              .MaximumLength(11).WithMessage("O campo {PropertyName} não pode ser maior que {MaxLength}.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(p => p.Email)
              .MaximumLength(75).WithMessage("O campo {PropertyName} não pode ser maior que {MaxLength}.");

            RuleFor(p => p.Telephone)
              .MaximumLength(15).WithMessage("O campo {PropertyName} não pode ser maior que {MaxLength}.");

            RuleFor(p => p.Address)
              .MaximumLength(150).WithMessage("O campo {PropertyName} não pode ser maior que {MaxLength}.");

            RuleFor(p => p.Complement)
              .MaximumLength(75).WithMessage("O campo {PropertyName} não pode ser maior que {MaxLength}.");

            RuleFor(p => p.ZipCode)
              .MaximumLength(8).WithMessage("O campo {PropertyName} não pode ser maior que {MaxLength}.");
        }
    }
}