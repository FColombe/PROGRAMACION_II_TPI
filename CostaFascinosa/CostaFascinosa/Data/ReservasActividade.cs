﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CostaFascinosa.Data;

public partial class ReservasActividade
{
    public int IdReservaAct { get; set; }

    public int? IdActividad { get; set; }

    public int? IdConsumo { get; set; }

    public DateTime? FechaReservada { get; set; }

    public int? CantidadReservada { get; set; }

    public decimal? CostoUnitario { get; set; }
    [JsonIgnore]
    public virtual Actividade IdActividadNavigation { get; set; }
    [JsonIgnore]
    public virtual ConsumosHabitacione IdConsumoNavigation { get; set; }
}