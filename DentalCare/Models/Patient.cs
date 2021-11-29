using System.ComponentModel.DataAnnotations;

namespace DentalCare.Models
{
    class Patient
    {   
        public int Id { get; protected set; }

        [MaxLength(50)]
        public string FirstName { get; protected set; }

        [MaxLength(50)]
        public string LastName { get; protected set; }
        
        [MaxLength(13)]
        public string SSN { get; protected set; }



        public Patient(string firstName, string lastName, string sSN)
        {
            FirstName = firstName;
            LastName = lastName;
            SSN = sSN;
        }
    }
}