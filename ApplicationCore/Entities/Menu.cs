using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Menu : IAggregateRoot
    {
        public int MenuId {get; set;}

        public string Name {get; set;}

        public string Genre {get; set;}

        public decimal Price {get;set;}

        public string Status {get;set;}
    }
}