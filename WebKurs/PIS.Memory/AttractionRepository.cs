using PIS.Repository;

namespace PIS.Memory
{
    public class AttractionRepository : IAttractionRepository
    {
        private readonly List<Attraction> attractions = new List<Attraction>
        {
        new Attraction(1, "Красная площадь (Москва)", "Площадь", 1,"https://catherineasquithgallery.com/uploads/posts/2021-02/1612905349_204-p-krasnaya-ploshchad-fon-249.jpg"),
        new Attraction(2, "Патрики", "Район для богатых", 1,"https://www.frommillion.ru/uploads/content/picture/6195d3c310971e13a85db090/EBXPWJYXYAEA_Ro.jpg_large.jpg"),
        new Attraction(3, "Огарев Арена", "Спорткомплекс", 2,"https://sdelanounas.ru/i/y/m/l/f_YmlsZXRvbi5ydS91cGxvYWRzL2xhcmdlL2VlMDc0NTZmZTcxYjIxNWY2MjI2NzA5MGRhNjA2MTcyLmpwZz9fX2lkPTE0NTQ3Nw==.jpeg"),
        new Attraction(4, "Жопа осла", "Серая", 3,"https://i.ytimg.com/vi/MFPzF9VII4E/maxresdefault.jpg")
        };

        public List<Attraction> GetAllAttractions()
        {
            return attractions;
        }

        public List<Attraction> GetAllAttractionsByCityId(int cityId)
        {
            return attractions.Where(attr => attr.CityId.Equals(cityId))
                              .ToList();      
        }

        public List<Attraction> GetAllAttractionsByName(string namePart)
        {
            return attractions.Where(attr => attr.AttractionName.IndexOf(namePart, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();
        }
    }
}
