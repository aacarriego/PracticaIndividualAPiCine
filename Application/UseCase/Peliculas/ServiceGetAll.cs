using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Peliculas
{
    public class ServiceGetAll: IServiceGetAll
    {
        public object GetAll()
        {
            return new { name = "string" };
        }
    }
}
