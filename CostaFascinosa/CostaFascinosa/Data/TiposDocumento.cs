﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CostaFascinosa.Data;

public partial class TiposDocumento
{
    public int IdTipoDoc { get; set; }

    public string Tipo { get; set; }
    [JsonIgnore]
    public virtual ICollection<Pasajero> Pasajeros { get; set; } = new List<Pasajero>();
}