﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CostaFascinosa.Data;

public partial class ResenasServicio
{
    public int IdResenaServ { get; set; }

    public string Comentario { get; set; }

    public int? Puntuacion { get; set; }

    public int? IdServicio { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ServiciosGastronomico IdServicioNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }
}