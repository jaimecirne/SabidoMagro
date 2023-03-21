using SabidoMagroAcademia.Domain.Validation;

namespace SabidoMagroAcademia.Domain.Entities
{
    //atributo sealed impede que outra classe possa herdar de Product
    public sealed class Client : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Weight { get; private set; }
        public int Height { get; private set; }
        public string Image { get; private set; }

        public Client(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Client(int id, string name, string description, decimal weight, int height, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, weight, height, image);
        }

        public void Update(string name, string description, decimal weight, int height, string image, int planId)
        {
            ValidateDomain(name, description, weight, height, image);
            PlanId = planId;
        }
        //valida as regras de negócio para cada atributo
        private void ValidateDomain(string name, string description, decimal weight, int height, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters");

            DomainExceptionValidation.When(weight < 0, "Invalid price value");

            DomainExceptionValidation.When(height < 0, "Invalid stock value");

            //comando ? avalia o valor de imagen, se for null, o resultado será null, caso contrário ele testa a expressão.
            //O objetivo e evitar que gere uma exceção NullReferenceException.
            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid image name, too long, maximum 250 characters");

            Name = name;
            Description = description;
            Weight = weight;
            Height = height;
            Image = image;

        }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
