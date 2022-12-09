﻿using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinessLogic.DTO;
using ServicesDeskUCABWS.BussinessLogic.Mapper;
using ServicesDeskUCABWS.Exceptions;
using ServicesDeskUCABWS.Persistence.DAO.Interface;
using ServicesDeskUCABWS.Persistence.Database;
using ServicesDeskUCABWS.Persistence.Entity;


namespace ServicesDeskUCABWS.Persistence.DAO.Implementations
{
    public class TicketDao : ITicketDao
    {
        private readonly IMigrationDbContext _context;
        private readonly IEmailDao _emailRepository;

        public TicketDao(IMigrationDbContext context, IEmailDao emailDao)
        {
            _context = context;
            _emailRepository = emailDao;

        }

        public string AgregarTicketDAO(TickectCreateDTO newTickect)
        {
            try
            {
                Ticket ticket = new Ticket();
                ticket.creadopor = _context.Usuario.Where(c => c.id == newTickect.creadopor).FirstOrDefault();
                ticket.categoria = _context.Categorias.Where(c => c.id == newTickect.categoriaid).FirstOrDefault();
                ticket.departamento = _context.Departamentos.Where(c => c.id == newTickect.Departamentoid).FirstOrDefault();
                ticket.nombre = newTickect.nombre;
                ticket.descripcion = newTickect.descripcion;
                ticket.fecha = newTickect.fecha;
                ticket.Estado = _context.Estados.Where(c => c.nombre == "En espera").FirstOrDefault();
                _context.Tickets.Add(ticket);
                _context.DbContext.SaveChanges();
                return "Ticket Creado";
            }
            catch (Exception ex)
            {
                throw new TickectExeception("Ha ocurrido un error al intentar guardar el ticket: "
              + newTickect, ex.Message, ex);
            }

        }

        public string CambiarEstado(TickectEstadoDTO tickectEstadoDTO)
        {
            try
            {
                var ticket = _context.Tickets.Where(c => c.id == tickectEstadoDTO.idticket).FirstOrDefault();
                ticket.Estado = _context.Estados.Where(c => c.id == tickectEstadoDTO.idestado).FirstOrDefault();
                _context.Tickets.Update(ticket);
                _context.DbContext.SaveChanges();
                return "Estatus cambiado";
            }
            catch (Exception ex)
            {
                throw new TickectExeception("Ha ocurrido un error al intentar cambiar estado del ticket: "
              + tickectEstadoDTO, ex.Message, ex);
            }

        }
        public string AsignarTicket(AsignarTicketDTO asignarTicket)
        {
            try
            {
                var ticket = _context.Tickets.Where(c => c.id == asignarTicket.ticketid).FirstOrDefault();
                ticket.asginadoa = _context.Usuario.Where(c => c.id == asignarTicket.asginadoa).FirstOrDefault();
                ticket.prioridad = _context.Prioridades.Where(c => c.id == asignarTicket.prioridadid).FirstOrDefault();
                ticket.Estado = _context.Estados.Where(c => c.nombre == "En proceso").FirstOrDefault();
                _context.Tickets.Update(ticket);
                _context.DbContext.SaveChanges();
                return "Ticket Asignado";
            }
            catch (Exception ex)
            {
                throw new TickectExeception("Ha ocurrido un error al asginar el ticket: "
              + asignarTicket, ex.Message, ex);
            }

        }
        public string DelegarTicket(TickectDelegadoDTO delegadoDTO)
        {
            try
            {
                var ticket = _context.Tickets.Where(c => c.id == delegadoDTO.idticket).FirstOrDefault();
                ticket.asginadoa = _context.Usuario.Where(c => c.id == delegadoDTO.idAsignadoa).FirstOrDefault();
                ticket.departamento = _context.Departamentos.Where(c => c.id == delegadoDTO.idDepartamento).FirstOrDefault();
                ticket.Estado = _context.Estados.Where(c => c.nombre == "En espera").FirstOrDefault();
                _context.Tickets.Update(ticket);
                _context.DbContext.SaveChanges();
                return "Ticket Delegado";
            }
            catch (Exception ex)
            {
                throw new TickectExeception("Ha ocurrido un error al Delegar el ticket: ", ex.Message, ex);
            }

        }



        public string TikcetsRelacionados(TicketsRelacionadosDTO ticketsRelacionados)
        {
            try
            {
                var ticketHijo = _context.Tickets.Where(c => c.id == ticketsRelacionados.idtickethijo).FirstOrDefault();
                var ticketPadre = _context.Tickets.Where(c => c.id == ticketsRelacionados.idticketpadre).FirstOrDefault();
                TickectsRelacionados tickects = new TickectsRelacionados();
                tickects.TicketRelacion = ticketHijo;
                tickects.ticket = ticketPadre;
                _context.TickectsRelacionados.Add(tickects);
                _context.DbContext.SaveChanges();
                return "Ticket Mergeado";
            }
            catch (Exception ex)
            {
                throw new TickectExeception("Ha ocurrido un error al Relacionar el ticket: ", ex.Message, ex);
            }

        }
        public string EliminarRelacionMerge(TicketsRelacionadosDTO ticketsRelacionados)
        {
            try
            {
                var TicketRelacion = _context.TickectsRelacionados.Where(c => c.Ticketid == ticketsRelacionados.idticketpadre && c.TicketRelacionadoid == ticketsRelacionados.idtickethijo).FirstOrDefault();
                _context.TickectsRelacionados.Remove(TicketRelacion);
                _context.DbContext.SaveChanges();
                return "Ticket Eliminado";
            }
            catch (Exception ex)
            {
                throw new TickectExeception("Ha ocurrido un error al Relacionar el ticket: ", ex.Message, ex);
            }

        }
    
        


        public ICollection<TicketCDTO> GetTickets()
        {
            try
            {
                var q = (from tk in _context.Tickets
                         join us in _context.Usuario on tk.creadopor equals us
                         join us2 in _context.Usuario on tk.asginadoa equals us2
                         join e in _context.Estados on tk.Estado equals e
                         join p in _context.Prioridades on tk.prioridad equals p
                         join ca in _context.Categorias on tk.categoria equals ca
                         select new TicketCDTO()
                         {
                             id = tk.id,
                             nombre = tk.nombre,
                             idasignad = us2.id,
                             asginadoa = us2.email,
                             creadopor = us.email,
                             descripcion = tk.descripcion,
                             fecha = tk.fecha,
                             idestado = e.id,
                             estado = e.nombre,
                             idprioridad = p.id,
                             prioridad = p.nombre,
                             idcategoria = ca.id,
                             categoria = ca.nombre

                         }).ToList();
                return q;
            }
            catch (Exception ex)
            {
                throw new TickectExeception("Ha ocurrido un error al consultar: "
              , ex.Message, ex);
            }
        }
        

        public ICollection<TicketCDTO> TicketsMergeados(int ticketid)
        {
            try
            {
                      var q = (from trk in _context.TickectsRelacionados
                         join tk in _context.Tickets on trk.Ticketid equals tk.id
                         join tkrelacion in _context.Tickets on trk.TicketRelacionadoid equals tkrelacion.id
                         join us in _context.Usuario on tk.creadopor equals us
                         join us2 in _context.Usuario on tk.asginadoa equals us2
                         join e in _context.Estados on tk.Estado equals e
                         join p in _context.Prioridades on tk.prioridad equals p
                         join ca in _context.Categorias on tk.categoria equals ca
                         where trk.Ticketid == ticketid
                         select new TicketCDTO()
                         {
                             id = tkrelacion.id,
                             nombre = tkrelacion.nombre,
                             idasignad = us2.id,
                             asginadoa = us2.email,
                             creadopor = us.email,
                             descripcion = tkrelacion.descripcion,
                             fecha = tkrelacion.fecha,
                             idestado = e.id,
                             estado = e.nombre,
                             idprioridad = p.id,
                             prioridad = p.nombre,
                             idcategoria = ca.id,
                             categoria = ca.nombre
                         }).ToList();
                return q;
            }
            catch (Exception ex)
            {
                throw new TickectExeception("Ha ocurrido un error al consultar: "
              , ex.Message, ex);
            }
        }
        public TicketCDTO GetTicket(int ticketid)
        {
            try
            {
                var q = (from tk in _context.Tickets
                         join us in _context.Usuario on tk.creadopor equals us
                         join us2 in _context.Usuario on tk.asginadoa equals us2
                         join e in _context.Estados on tk.Estado equals e
                         join p in _context.Prioridades on tk.prioridad equals p
                         join ca in _context.Categorias on tk.categoria equals ca
                         where tk.id == ticketid
                         select new TicketCDTO()
                         {
                             id = tk.id,
                             nombre = tk.nombre,
                             idasignad = us2.id,
                             asginadoa = us2.email,
                             creadopor = us.email,
                             descripcion = tk.descripcion,
                             fecha = tk.fecha,
                             idestado = e.id,
                             estado = e.nombre,
                             idprioridad = p.id,
                             prioridad = p.nombre,
                             idcategoria = ca.id,
                             categoria = ca.nombre
                         }).FirstOrDefault();
                return q;
            }
            catch (Exception ex)
            {
                throw new TickectExeception("Ha ocurrido un error al consultar: "
              , ex.Message, ex);
            }
        }

        public ICollection<TicketCDTO> GetTicketporusuarioasignado(int usuarioasignado)
        {
            try
            {

                var usu = _context.Usuario.Where(c => c.id == usuarioasignado).FirstOrDefault();
                var q = (from tk in _context.Tickets
                         join us in _context.Usuario on tk.creadopor equals us
                         join us2 in _context.Usuario on tk.asginadoa equals us2
                         join e in _context.Estados on tk.Estado equals e
                         join p in _context.Prioridades on tk.prioridad equals p
                         join ca in _context.Categorias on tk.categoria equals ca
                         where tk.asginadoa == usu
                         select new TicketCDTO()
                         {
                             nombre = tk.nombre,
                             asginadoa = us2.email,
                             creadopor = us.email,
                             descripcion = tk.descripcion,
                             fecha = tk.fecha,
                             estado = e.nombre,
                             prioridad = p.nombre,
                             categoria = ca.nombre
                         }).ToList();
                return q;
            }
            catch (Exception ex)
            {
                throw new TickectExeception("Ha ocurrido un error al consultar: "
              , ex.Message, ex);
            }

        }
    }
}
