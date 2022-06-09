using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        //propriedade navegação EF
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomainName(name);
        }
        public Category(int id, string name)
        {
            ValidateDomainId(id);
            ValidateDomainName(name);
        }

        public void update(string name)
        {
            ValidateDomainName(name);
        }

        private void ValidateDomainName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Name is too short");

            Name = name;
        }

        private void ValidateDomainId(int id)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");

            Id = Id;
        }
    }
}
