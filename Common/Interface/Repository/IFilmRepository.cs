﻿using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface.Repository
{
   public interface IFilmRepository
    {
        bool Dodaj(Film film);
        bool Izmeni(Film film);
        bool Obrisi(int idFilma);
        List<Film> SviFilmovi();
        List<Film> Pretraga(string by, Film film);
    }
}
