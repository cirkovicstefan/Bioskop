﻿using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface.Repository
{
    public interface IGledalacRepository
    {
        bool Dodaj(Gledalac gledalac);
        bool Izmeni(Gledalac gledalac);
        bool Obrisi(int idGledaoca);
        List<Gledalac> SviGledaoci();
        List<Gledalac> Pretraga(string by, Gledalac gledalac);
    }
}
