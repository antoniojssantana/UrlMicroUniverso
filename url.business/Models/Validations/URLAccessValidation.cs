using FluentValidation;
namespace url.business.Models.Validations
{
	public class URLAccessValidation : AbstractValidator<URLAccessModel>
	{
		public URLAccessValidation()
		{
			RuleFor(p => p.ShortenedURLId)
				.NotEmpty()
				.WithMessage("O campo URL Encurtada é de preenchimento obrigatório.");
			RuleFor(p => p.DateAccess)
				.NotEmpty()
				.WithMessage("O campo Data de acesso é de preenchimento obrigatório.");
			RuleFor(p => p.Source)
				.MaximumLength(150)
				.WithMessage("O campo Origem não pode ser maior que 150 caracteres.");
			RuleFor(p => p.Source)
				.NotEmpty()
				.WithMessage("O campo Origem é de preenchimento obrigatório.");
		}
	}
}

