﻿using ServicesDeskUCABWS.Persistence.Entity;

namespace ServicesDeskUCABWS.BussinessLogic.DTO
{
    public class TicketDTO
    {

        public string? nombre { get; set; }
        public DateTime? fecha { get; set; }
        public string? descripcion { get; set; }

    }
}
