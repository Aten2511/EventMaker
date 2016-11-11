using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventMaker.Model
{
   public class Event
    {
       public int  Id { get; set; }
       
       public string  Name { get; set; }

       public string  Description { get; set; }
       public string  Place { get; set; }
       public DateTime  DateTime { get; set; }

        public Event()
        {

        }
        public Event( int id,string name, string place, DateTime dateTime, string description)
       {
           Id = id;
           Name = name;
           Description = description;
           this.Place = place;
           DateTime = dateTime;
       }
      
        public override string ToString()
       {
           return $"Id-{Id}, Name: {Name}- Place: {Place}- DateTime: {DateTime}- Descripton: {Description}";
       }
    }
}
