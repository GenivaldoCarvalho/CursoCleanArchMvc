using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
        //sealed não deixa ser herdada
    {
       
        public string Name { get; private  set; }

        //criar um construtor - digita ctor
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            //criado na pasta Validation a excpetion
            DomainExceptionValidation.When(id < 0, "Invalid ID value.");
            Id = id;
            ValidateDomain(name);
        }
        //atualização 
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        public void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length < 3 ,
                "Invalid name, too short, minimum 3 characters");
            Name = name;
        }


    }
}
