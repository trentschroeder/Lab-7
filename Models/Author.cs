using System;

namespace Fisher.Bookstore.Api.Models
{
    public class Author
    {
        public int id { get; set;}
        
        public string FName {get;set;}

        public string LName {get;set;}

        public string Genre {get;set;}

        public string Publisher {get;set;}
    }
}