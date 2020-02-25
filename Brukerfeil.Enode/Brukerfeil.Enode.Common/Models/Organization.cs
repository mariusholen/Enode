using System;
using System.Collections;
using System.Collections.Generic;

namespace Brukerfeil.Enode.Common.Models
{
    public class Organization
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
    }
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
    }
}