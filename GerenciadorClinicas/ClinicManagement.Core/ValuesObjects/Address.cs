namespace ClinicManagement.Core.ValuesObjects
{
    public class Address
    {
        public Address(string street, string number, string complement, string neighborhood, string state, string city, string zipCode)
        {
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            State = state;
            City = city;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
    }
}
