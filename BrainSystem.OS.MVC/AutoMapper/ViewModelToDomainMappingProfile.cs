using AutoMapper;
using BrainSystem.OS.Domain.Entities;
using BrainSystem.OS.MVC.ViewModels;

namespace BrainSystem.OS.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<ProdutoFalhado, ProdutosFalhadosViewModel>();
            Mapper.CreateMap<OrdemServico, OrdemServicoViewModel>();
            Mapper.CreateMap<Funcionario, FuncionarioViewModel>();
            Mapper.CreateMap<PecaAplicada, PecasAplicadasViewModel>();
            Mapper.CreateMap<SolicitacaoPeca, SolicitacoesPecasViewModel>();
            Mapper.CreateMap<RetiraEquipamento, RetiradaEquipamentosViewModel>();

        }
    }
}