using apilab1.validation;
namespace apilab1.models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [PastDate]
        public DateTime productiondate { get; set; }
        public string type { get; set; }
        public Cars(int id, string name, string description,DateTime dateofproduction, string cartype)
        {
            Id = id;
            Name = name;
            Description = description;
            productiondate= dateofproduction;
            type= cartype;
            
        }
    }
}
