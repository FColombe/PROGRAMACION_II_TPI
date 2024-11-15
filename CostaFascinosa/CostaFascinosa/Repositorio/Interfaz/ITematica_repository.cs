﻿using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Repositorio.Interfaz
{
    public interface ITematica_repository
    {
        Task<List<Tematica>> GetTematicas();
        Task<bool> Add(Tematica tematica);

    }
}