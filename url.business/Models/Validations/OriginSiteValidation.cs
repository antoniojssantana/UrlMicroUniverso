using FluentValidation;
namespace url.business.Models.Validations
{
	public class OriginSiteValidation : AbstractValidator<OriginSiteModel>
	{
		public OriginSiteValidation()
		{
			RuleFor(p => p.Description)
				.MaximumLength(150)
				.WithMessage("O campo Descricao não pode ser maior que 150 caracteres.");
			RuleFor(p => p.Description)
				.NotEmpty()
				.WithMessage("O campo Descricao é de preenchimento obrigatório.");
			RuleFor(p => p.URL)
				.MaximumLength(150)
				.WithMessage("O campo URL não pode ser maior que 150 caracteres.");
			RuleFor(p => p.URL)
				.NotEmpty()
				.WithMessage("O campo URL é de preenchimento obrigatório.");
			RuleFor(p => p.UserBaseId)
				.NotEmpty()
				.WithMessage("O campo Usuario  é de preenchimento obrigatório.");
			RuleFor(p => p.State)
				.NotEmpty()
				.WithMessage("O campo Estado é de preenchimento obrigatório.");
		}
	}
}

