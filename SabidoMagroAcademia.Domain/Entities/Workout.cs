using SabidoMagroAcademia.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    public sealed class Workout : Entity
    {
        public string Label { get; set; }

        public List<WorkoutActivity> WorkoutActivities { get; set; }

        public Workout()
        {

        }

        public Workout(int id, string label)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(label),
             "Invalid name.Name is required");

            DomainExceptionValidation.When(label.Length < 3,
               "Invalid name, too short, minimum 3 characters");

            Label = label;
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
        }

        public Workout(string label, List<WorkoutActivity> workoutActivities)
        {
            ValidateDomain(label, workoutActivities);
        }

        public void Update(int id, string label, List<WorkoutActivity> workoutActivities)
        {
            ValidateDomain(label, workoutActivities);
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
        }
        public ICollection<Client> Clients { get; set; }

        private void ValidateDomain(string label, List<WorkoutActivity> workoutActivities)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(label),
                "Invalid name.Name is required");

            DomainExceptionValidation.When(label.Length < 3,
               "Invalid name, too short, minimum 3 characters");

            Label = label;
            WorkoutActivities = workoutActivities;
        }
    }
}
