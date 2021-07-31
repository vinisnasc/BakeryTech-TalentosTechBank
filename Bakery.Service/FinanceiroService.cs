using Bakery.Model;
using Bakery.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Service
{
    public class FinanceiroService : IFinanceiroService
    {
        private readonly IBibliotecaRepositorio _bibliotecaRepositorio;

        public FinanceiroService(IBibliotecaRepositorio bibliotecaRepositorio)
        {
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }

        public Financeiro SelecionarPorId()
        {
            return _bibliotecaRepositorio.FinanceiroRepositorio.SelecionarPorId(1);
        }
    }
}
