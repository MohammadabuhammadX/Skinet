//Supporting classes for order
namespace Core.Entities.OrderAggregate
{
    public class Address
    {
        public Address(string firstName, string lastName, string street,
            string city, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
        public Address()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

    }
}
//this is kind of entity that's considered a value entity ,it's going to be owned by our order so it doesn't have an id , it doesn't have a relation to any other entity , it's just going to be owned by our order and it's going to be used to store the address of our customer when they place an order , so we can use it to ship the order to them .
//but we de give it a ctor with the properties inside this particuler class 
//the parameterless Ctor is for EF Core to be able to create an instance of this class when it needs to, for example when it retrieves an order from the database, it will create an instance of this class and populate the properties with the values from the database.