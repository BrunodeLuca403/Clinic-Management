using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Service.CreateService
{
    public class CreateServiceCommand
    {
        public CreateServiceCommand(string name, string descripton, decimal price, int duration)
        {
            Name = name;
            Descripton = descripton;
            Price = price;
            Duration = duration;
        }

        public string Name { get; set; }
        public string Descripton { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
