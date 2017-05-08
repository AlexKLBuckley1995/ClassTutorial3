using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gallery3SelfHost
{
    public class GalleryController: System.Web.Http.ApiController
    {
        public List<string> GetArtistNames() { //Service subroutine
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT Name FROM Artist", null); //Get the artist names and put them in a string
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
                return lcNames;
        }
    }
}
