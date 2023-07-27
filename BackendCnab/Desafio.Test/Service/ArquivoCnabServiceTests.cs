using AutoMapper;
using Desafio.Domain.DTOs.Arquivos.Layouts.Cnab;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Service.Services;
using Moq;
using Xunit;

namespace Desafio.Service.Tests
{
    public class ArquivoCnabServiceTests
    {
        private IMapper mapper;
        private ArquivoCnabService importacaoCNABService;
        private readonly Mock<IArquivoCnabRepository> _arquivoCnabMockRepository;

        public ArquivoCnabServiceTests()
        {
            mapper = new MapperConfiguration(cfg => { cfg.CreateMap<CnabDto, ArquivoCnabService>(); }).CreateMapper();
            _arquivoCnabMockRepository = new Mock<IArquivoCnabRepository>();
            importacaoCNABService = new ArquivoCnabService(mapper, _arquivoCnabMockRepository.Object);
        }

        [Fact]
        [Trait("Descrição","Teste para verificar se o método ObterTodosArquivos retorna uma lista não nula.")]
        public void ObterTodosArquivos_QuandoExistirDadosNaBase_DeveRetornarListaComArquivos()
        {
            // Arrange
            IEnumerable<Domain.Entities.Arquivos.Layouts.Cnab.Cnab> entities = new List<Domain.Entities.Arquivos.Layouts.Cnab.Cnab>();
            _arquivoCnabMockRepository.Setup(r => r.ObterTodosArquivos()).Returns(entities);

            // Act
            IEnumerable<CnabDto> result = importacaoCNABService.ObterTodosArquivos();

            // Assert
            Assert.NotNull(result);
        }

    }
}
