using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFuncionesCommand
    {
        Task InsertFuncion(Funcion funcion);
        Task DeleteFuncion(Funcion funcionId);
    }
}
