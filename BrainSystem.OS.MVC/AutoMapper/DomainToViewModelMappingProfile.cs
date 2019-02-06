using System;
using AutoMapper;
using BrainSystem.OS.Domain.Entities;
using BrainSystem.OS.MVC.ViewModels;

namespace BrainSystem.OS.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {

            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<FuncionarioViewModel, Funcionario>();
            Mapper.CreateMap<ProdutosFalhadosViewModel, ProdutoFalhado>();
            Mapper.CreateMap<PecasAplicadasViewModel, PecaAplicada>();
            Mapper.CreateMap<SolicitacoesPecasViewModel, SolicitacaoPeca>();
            Mapper.CreateMap<RetiradaEquipamentosViewModel, RetiraEquipamento>();
            Mapper.CreateMap<OrdemServicoViewModel, OrdemServico>()
                   .ForMember(d =>d.HoraChegada, o => o.MapFrom(s => s.HoraChegada.ToString()));
        }
    }
}