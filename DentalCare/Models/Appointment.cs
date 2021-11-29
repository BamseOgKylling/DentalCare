namespace DentalCare.Models
{
    class Appointment
    {
        public Patient Patient { get; protected set; }

        public DateTime Date { get; protected set; }

        public int Id { get; protected set; }


        public Appointment(Patient patient, DateTime date)
        {
            Patient = patient;
            Date = date;
        }
        public Appointment(DateTime date)
        {
            Date = date;
        }
    }
}