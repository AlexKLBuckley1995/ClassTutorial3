using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gallery3WinForm
{
    public class GalleryController : System.Web.Http.ApiController
    {
        public List<string> GetArtistNames()
        { //Service subroutine
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT Name FROM Artist", null); //Get the artist names and put them in a string
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        //Below is a new service method that uses clsArtist 
        public clsArtist GetArtist(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name); 
            DataTable lcResult =
            clsDbConnection.GetDataTable("SELECT * FROM Artist WHERE Name = @Name", par); //Prepare the SQL statement and call the db-connection accordingly. This uses a parameterterized query because it is using a placeholder @Name and the value is delivered seperately. These parameters exist in a Dictionary<string, object>

            if (lcResult.Rows.Count > 0) //This block of code unpacks the data-table and sticks the values from the database into a new clsArtistDTO
                return new clsArtist()
                {
                    Name = (string)lcResult.Rows[0]["Name"],
                    Speciality = (string)lcResult.Rows[0]["Speciality"],
                    Phone = (string)lcResult.Rows[0]["Phone"]
                };
            else
                return null;
        }
    }
}
