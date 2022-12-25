using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scent.CO
{
    public class Address
    {
        public int ID { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public int Postcode { get; set; }
        public String AddressDetails { get; set; }
        public String RecipientName { get; set; }
        public String RecipientPhone { get; set; }

        public Address(int id, string state, string city, int postcode, string addressDetails, string recipientName, string recipientPhone)
        {
            ID = id;
            State = state;
            City = city;
            Postcode = postcode;
            AddressDetails = addressDetails;
            RecipientName = recipientName;
            RecipientPhone = recipientPhone;
        }
    }
}