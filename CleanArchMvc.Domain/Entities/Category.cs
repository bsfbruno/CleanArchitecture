﻿using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

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

        public ICollection<Product> Products { get; set; }

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
