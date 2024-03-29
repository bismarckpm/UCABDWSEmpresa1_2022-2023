using ServicesDeskUCABWS.Persistence.DAO.Interface;
using ServicesDeskUCABWS.Persistence.Entity;
using ServicesDeskUCABWS.BussinessLogic.DTO;
using ServicesDeskUCABWS.BussinessLogic.Mapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Persistence.Database;
using System;
using ServicesDeskUCABWS.Exceptions;

namespace ServicesDeskUCABWS.Persistence.DAO.Implementations
{
    public class CategoriaDAO : ICategoriaDAO
    {
        private readonly IMigrationDbContext _context;

        public CategoriaDAO(IMigrationDbContext context)
        {
            this._context = context;
        }


        //          SERVICIO DE CREAR CATEGORIA
        public CategoriaDTO AgregarCategoriaDAO(Categoria categ)
        {
            try
            {
                _context.Categorias.Add(categ);
                _context.DbContext.SaveChanges();

                var data = _context.Categorias.Where(a => a.id == categ.id)
                .Select(
                        a => new CategoriaDTO
                        {
                            Id = a.id,
                            Nombre = a.nombre
                        }
                    );

                return data.First();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw new ServicesDeskUcabWsException("Ha ocurrido un error al crear categoria.", ex);
            }
        }


        //          SERVICIO DE CONSULTAR CATEGORIA
        public List<CategoriaDTO> ConsultarTodosCategoriasDAO()
        {
            try
            {
                var data = _context.Categorias.Select(
                    p => new CategoriaDTO
                    {
                        Id = p.id,
                        Nombre = p.nombre
                        //FlujoAprobacion = a.flujoaprobacion
                    }
                );

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw new ServicesDeskUcabWsException("Ha ocurrido un error al consultar la lista de categorias.", ex);
            }
        }


        //          SERVICIO DE ACTUALIZAR CATEGORIA
        public CategoriaDTO ActualizarCategoriaDAO(Categoria categ)
        {
            try
            {
                _context.Categorias.Update(categ);
                _context.DbContext.SaveChanges();

                return CategoriaMapper.EntityToDto(categ);

            }
            catch (NullReferenceException ex)
            {
                throw new ServicesDeskUcabWsException("Ha ocurrido un error al actualizar una categoria.", ex);
            }
        }


        //          SERVICIO DE ELIMINAR CATEGORIA
        public CategoriaDTO EliminarCategoriaDAO(int id)
        {
            try
            {
                var categoria = (Categoria)_context.Categorias.Where(
                    p => p.id == id).First();
                _context.Categorias.Remove(categoria);
                _context.DbContext.SaveChanges();

                return CategoriaMapper.EntityToDto(categoria);

            }
            catch (Exception ex)
            {
                throw new ServicesDeskUcabWsException("Ha ocurrido un error al eliminar la categoria.", ex);
            }
        }


        //          SERVICIO DE CONSULTAR CATEGORIA
        public CategoriaDTO ConsultaCategoriaDAO(int id)
        {
            try
            {
                var categoria = _context.Categorias.Where(
                p => p.id == id).First();
                return CategoriaMapper.EntityToDto(categoria); ;

            }
            catch (Exception ex)
            {
                throw new ServicesDeskUcabWsException("Ha ocurrido un error al consultar la categoria.", ex);
            }
        }
    }
}