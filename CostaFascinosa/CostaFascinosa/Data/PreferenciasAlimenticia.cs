﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CostaFascinosa.Data;

public partial class PreferenciasAlimenticia
{
    public int IdPreferencia { get; set; }

    public string Preferencia { get; set; }
    [JsonIgnore]
    public virtual ICollection<ServiciosGastronomico> ServiciosGastronomicos { get; set; } = new List<ServiciosGastronomico>();
}