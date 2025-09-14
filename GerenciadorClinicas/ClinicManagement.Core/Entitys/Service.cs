
namespace ClinicManagement.Core.Entitys
{
    public class Service : BaseEntity
    {
        public Service(string name, string descripton, decimal price, int duration)
        {
            Name = name;
            Descripton = descripton;
            Price = price;
            Duration = duration;
            Cares = [];
        }

        public string Name { get; private set; }
        public string Descripton { get; private set; }
        public decimal Price { get; private set; }
        public int Duration { get; private set; }
        public List<Care> Cares { get; set; }
        public bool IsDeleted { get; set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
        public void UpdateService(string name, string description, decimal price, int duration)
        {
            Name = name;
            Descripton = description;
            Price = price;
            Duration = duration;
        }
    }
}
