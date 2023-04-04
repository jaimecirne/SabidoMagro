using SabidoMagroAcademia.Domain.Validation;
using System;

namespace SabidoMagroAcademia.Domain.Entities
{
    public sealed class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Fone { get; private set; }
        public string Gender { get; private set; }
        public DateTime Born { get; private set; }
        public string Image { get; private set; }

        public User()
        {

        }

        public User(string name, string email, string gender, DateTime born, string image)
        {
            ValidateDomain(name, email, gender, born, image);
        }

        public User(int id, string name, string email, string gender, DateTime born, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, email, gender, born, image);
        }

        public void Update(string name, string email, string gender, DateTime born, string image)
        {
            ValidateDomain(name, email, gender, born, image);
        }

        private void ValidateDomain(string name, string email, string gender, DateTime born, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
                "Invalid description. Description is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(gender),
                "Invalid description. Description is required");

            // Validate if age is less then 13 years old 
            //DomainExceptionValidation.When(born < DateTime.,
            //    "Invalid description. Description is required");    

            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid image name, too long, maximum 250 characters");

            Name = name;
            Email = email;
            Gender = gender;
            Born = born;
            Image = image;

        }

    }
}
