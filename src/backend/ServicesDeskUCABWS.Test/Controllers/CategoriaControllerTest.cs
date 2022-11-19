using ServicesDeskUCABWS.Persistence.DAO.Interface;
using ServicesDeskUCABWS.BussinessLogic.Mapper;
using ServicesDeskUCABWS.Persistence.Entity;
using ServicesDeskUCABWS.Controllers;
using ServicesDeskUCABWS.BussinessLogic.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Moq;
using Xunit;

namespace ServicesDeskUCABWS.Test.Controllers
{
    public class CategoriaControllerTest
    {
        private readonly CategoriaController _controller;
        private readonly Mock<ICategoriaDAO> _servicesMock;
        private readonly Mock<ILogger<CategoriaController>> _log;
        public CategoriaDTO categoria = It.IsAny<CategoriaDTO>();
        public Categoria cat = It.IsAny<Categoria>();

        public CategoriaControllerTest()
        {
            _log = new Mock<ILogger<CategoriaController>>();
            _servicesMock = new Mock<ICategoriaDAO>();
            _controller = new CategoriaController(_servicesMock.Object, _log.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }
        // En Proceso
        [Fact(DisplayName = "Agregar Categoria")]
        public Task CreateCategoriaControllerTest()
        {
            var dto = new CategoriaDTO() { Id = 5, Nombre = "Categoria1" };

            _servicesMock.Setup(t => t.AgregarCategoriaDAO(cat))
            .Returns(categoria);

            var result = _controller.CreateCategoria(dto);

            Assert.IsType<ActionResult<CategoriaDTO>>(result);
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Categoria con Excepcion")]
        public Task CreateCategoriaControllerTestException()
        {
            _servicesMock.Setup(t => t.AgregarCategoriaDAO(cat))
            .Throws(new NullReferenceException());

            Assert.Throws<NullReferenceException>(() => _controller.CreateCategoria(categoria));
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Consultar Lista Categoria")]
        public Task ConsultarCategoriaControllerTest()
        {
            _servicesMock.Setup(t => t.ConsultarTodosCategoriasDAO())
            .Returns(new List<CategoriaDTO>());

            var result = _controller.ConsultaCategorias();

            Assert.IsType<ActionResult<List<CategoriaDTO>>>(result);
            return Task.CompletedTask;
        }


        [Fact(DisplayName = "Consulta Lista Categoria con Excepcion")]
        public Task ConsultarCategoriaControllerTestException()
        {
            _servicesMock
                .Setup(t => t.ConsultarTodosCategoriasDAO())
                .Throws(new Exception("", new NullReferenceException()));

            Assert.Throws<NullReferenceException>(() => _controller.ConsultaCategorias());
            return Task.CompletedTask;
        }
    }
}
