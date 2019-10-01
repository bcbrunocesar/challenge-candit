using System.Collections.Generic;

namespace Challenge.Domain.DTO
{
    public class RootObject
    {
        public RootObject()
        {
            Cities = new List<City>();
        }

        public List<City> Cities { get; private set; }
    }

    public class City
    {
        public string Longitude { get; set; }
        public string Name_uri { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }
        public string Summary { get; set; }
        public string Latitude { get; set; }
        public int Id { get; set; }
    }
}