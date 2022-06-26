using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Testes
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultValidObjectState()
        {
            Action action = () => new Product(1, "Product name", "Product description", 9.99m, 99, "Product image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product name", "Product description", 9.99m, 99, "Product image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product description", 9.99m, 99, "Product image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name is too short. Minimun 3 caracters");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product name", "Product description", 9.99m, 99, "Product image Product image Product image Product image Product image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image name, maximum 50 characters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product name", "Product description", 9.99m, 99, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product name", "Product description", 9.99m, 99, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainInvalidValue(int value)
        {
            Action action = () => new Product(1, "Product name", "Product description", 9.99m, value, "Product image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value");
        }
    }
}
