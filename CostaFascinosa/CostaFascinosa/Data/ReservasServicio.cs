﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CostaFascinosa.Data;

public partial class ReservasServicio
{
    public int IdReservaServ { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdServicio { get; set; }

    public DateTime? Fecha { get; set; }

    public int? CantidadReservada { get; set; }

    [JsonIgnore]
    public virtual ServiciosGastronomico IdServicioNavigation { get; set; }
    [JsonIgnore]
    public virtual Usuario IdUsuarioNavigation { get; set; }
}