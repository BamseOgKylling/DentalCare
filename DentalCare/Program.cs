using DentalCare.Data;
using DentalCare.Models;
using static System.Console;
namespace DentalCare
{
    public class Program
    {
        public static void Main(string[] args)
        {

            bool applicationRunning = true;

            do
            {
                WriteLine("1. Register patient");
                WriteLine("2. Search Patient");
                WriteLine("3. Exit");

                CursorVisible = false;

                ConsoleKeyInfo input;
                bool invalidChoice;

                do
                {
                    input = ReadKey(true);

                    invalidChoice = !(input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.NumPad1
                        || input.Key == ConsoleKey.D2 || input.Key == ConsoleKey.NumPad2
                        || input.Key == ConsoleKey.D3 || input.Key == ConsoleKey.NumPad3);

                } while (invalidChoice);

                Clear();

                CursorVisible = true;

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        RegisterPatient();

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        SearchPatient();

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:

                        applicationRunning = false;

                        break;
                }

                Clear();

            } while (applicationRunning);

        }

        private static void SearchPatient()
        {
            Write("Patient (SSN): ");

            string sSN = ReadLine();

            Clear();

            var patient = FindPatient(sSN);

            if (patient == null)
            {
                Notify("Patient not found");
                return;
            }

            WriteLine(patient.FullName);
            WriteLine(patient.SSN);

            while (ReadKey(true).Key != ConsoleKey.Escape);


        }

        private static Patient? FindPatient(string sSN)
        {
            using var context = new DentalCareContext();

            var patient = context.Patients.FirstOrDefault(x => x.SSN == sSN);

            return patient;
        }

        private static void RegisterPatient()
        {

            Write("First Name: ");

            string firstName = ReadLine();


            Write("Last name: ");

            string lastName = ReadLine();


            Write("SSN: ");

            string sSN = ReadLine();

            var patient = new Patient(firstName, lastName, sSN);

            SavePatient(patient);


            Notify("Patient Registered");

        }

        private static void SavePatient(Patient patient)
        {
            using var context = new DentalCareContext();

            context.Patients.Add(patient);

            context.SaveChanges();
        }

        static void Notify(string message)
        {
            WriteLine(message);
            Thread.Sleep(2000);
        }
    }
}
