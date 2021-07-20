using FluentValidation;
namespace url.business.Models.Validations
{
	public class ShortenedURLValidation : AbstractValidator<ShortenedURLModel>
	{
		public ShortenedURLValidation()
		{
			RuleFor(p => p.OriginSiteId)
				.NotEmpty()
				.WithMessage("O campo Site Original é de preenchimento obrigatório.");
			RuleFor(p => p.Link)
				.MaximumLength(75)
				.WithMessage("O campo Link não pode ser maior que 75 caracteres.");
			RuleFor(p => p.Link)
				.NotEmpty()
				.WithMessage("O campo Link é de preenchimento obrigatório.");
			RuleFor(p => p.InitialDate)
				.NotEmpty()
				.WithMessage("O campo Data Inicial é de preenchimento obrigatório.");
			RuleFor(p => p.ExpiredDate)
				.NotEmpty()
				.WithMessage("O campo Data de Expiracao é de preenchimento obrigatório.");
		}
	}
}

