namespace Lesson04.Models
{
    public class DataLocal
    {
        public static List<People> _peoples = new List<People>()
        {
            new People()
            {Id=1,Name="Nguyen",
                Email="nguyen@gmail.com",
                Phone="0923138479",
                Address="Hà Nội",
                Avatar="~/Image/Avatar/avatar-1.png",
                Birthday=Convert.ToDateTime("2000/01/01"),
                Bio="Người thứ nhất",
                Gender=0},
            new People()
            {Id=2,
                Name="Tuan",
                Email="tuan@gmail.com",
                Phone="0912313849",
                Address="Hà Nam",
                Avatar="~/Image/Avatar/avatar-2.png",
                Birthday=Convert.ToDateTime("2001/02/02"),
                Bio="Người thứ hai",
                Gender=1},
            new People()
            {Id=3,
                Name="Anh",
                Email="anh@gmail.com",
                Phone="0943128479",
                Address="Bắc Ninh",
                Avatar="~/Image/Avatar/avatar-3.jpg",
                Birthday=Convert.ToDateTime("2002/03/03"),
                Bio="Người thứ ba",
                Gender=0},
            new People()
            {Id=4,
                Name="Van",
                Email="van@gmail.com",
                Phone="0923138569",
                Address="Hà Nội",
                Avatar="~/Image/Avatar/avatar-4.jpg",
                Birthday=Convert.ToDateTime("2003/04/04"),
                Bio="Người thứ tư",
                Gender=1},
        };

        public static List<People> GetPeoples()
        {
            return _peoples;
        }

        public static People? GetPeopleById(int id)
        {
            var people = _peoples.FirstOrDefault(x => x.Id == id);
            return people;
        }
    }
}
