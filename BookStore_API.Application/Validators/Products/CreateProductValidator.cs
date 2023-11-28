using BookStore_API.Application.ViewModels.Products;
using FluentValidation;

namespace BookStore_API.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<Vm_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().NotNull().WithMessage("Zəhmət olmasa düzgün məhsul adı daxil edin")
                .MinimumLength(2)
                .MaximumLength(150)
                .WithMessage("Məhsul adının uzunluğu 2 ilə 150 arası olmalıdır");

            RuleFor(p => p.ProductStock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Zəhmət olmasa stock məlumatlarını boş qoymayın")
                .Must(s => s >= 0)
                .WithMessage("Stock sayı 0 və ya daha artıq olmalıdır");

            RuleFor(p => p.ProductPrice)
                .NotEmpty()
                .NotNull()
                .WithMessage("Zəhmət olmasa Qiyməti boş qoymayın")
                .Must(s => s >= 0)
                .WithMessage("Məhsulun qiyməti 0-dan artıq olmalıdır");

        }
    }
}
