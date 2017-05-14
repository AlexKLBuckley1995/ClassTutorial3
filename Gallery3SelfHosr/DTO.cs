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
        //public List<clsAllWork> WorksList { get; set; }
    }
}
