using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery3WinForm
{
    public class clsArtist //This is a data only class known as a DTO. We use DTO to transfer complex objects (e.g. artists and artworks) between tiers so we must declare our objects in the client and server projects. 
    {
        public string Name { get; set; } //This is a shorthand for properites without backing variables
        public string Speciality { get; set; }
        public string Phone { get; set; }
        public List<clsAllWork> WorksList { get; set; }
    }

    public class clsAllWork
    {
        public char WorkType { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public float? Width { get; set;  }
        public float? Height { get; set; }
        public string Type { get; set; }
        public float? Weight { get; set; }
        public string Material { get; set; }
        public string ArtistName { get; set; }

        public static readonly string FACTORY_PROMPT = "Enter P for Painting, S for Sculpture and H for Photograph";

        public static clsAllWork NewWork(char prChoice)
        {
            switch (char.ToUpper(prChoice))
            {
                case 'P': return new clsAllWork { WorkType = 'P' };
                case 'S': return new clsAllWork { WorkType = 'S' };
                case 'H': return new clsAllWork { WorkType = 'H' };
                default: return null;
            }
        }

        public override string ToString()
        {
            return Name + "\t" + Date.ToShortDateString();
        }
    }
}
