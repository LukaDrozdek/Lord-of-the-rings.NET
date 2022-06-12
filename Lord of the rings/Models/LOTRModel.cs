using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lord_of_the_rings.Models
{
    public class LOTRModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AppearsIn { get; set; }
        public string WithThisActor { get; set; }


        public LOTRModel()
        {
            ID = -1;
            Name = "null";
            Description = "null";
            AppearsIn = "null";
            WithThisActor = "null";
        }

        public LOTRModel(int id, string name, string description, string appearsIn, string withThisActor)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.AppearsIn = appearsIn;
            this.WithThisActor = withThisActor;
        }
    }
}