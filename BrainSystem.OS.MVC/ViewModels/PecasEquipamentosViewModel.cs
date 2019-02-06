using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrainSystem.OS.MVC.ViewModels
{
    public class PecasEquipamentosViewModel
    {
        public IEnumerable<PecasAplicadasViewModel> PecasAplicadas;
        public IEnumerable<SolicitacoesPecasViewModel> SolicitacoesPecas;
    }
}