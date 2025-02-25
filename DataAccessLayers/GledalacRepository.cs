﻿using Common.Interface.Repository;
using Common.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class GledalacRepository : IGledalacRepository
    {
        public bool Dodaj(Gledalac gledalac)
        {
            string query = string.Format($"INSERT INTO gledalac(email,ime,prezime) " +
                $"VALUES('{gledalac.Email}','{gledalac.Ime}','{gledalac.Prezime}')");
            return BaseConnection.ExecuteNonQuerySqlCommand(query);
        }

        public bool Izmeni(Gledalac gledalac)
        {
            string query = string.Format($"UPDATE gledalac SET email='{gledalac.Email}', " +
                $"ime='{gledalac.Ime}', prezime='{gledalac.Prezime}' WHERE id_gledaoca='{gledalac.IdGledaoca}'");
            return BaseConnection.ExecuteNonQuerySqlCommand(query);
        }

        public bool Obrisi(int idGledaoca)
        {
            string query = $"DELETE FROM gledalac WHERE id_gledaoca='{idGledaoca}'";
            return BaseConnection.ExecuteNonQuerySqlCommand(query);
        }

        private List<Gledalac> SviGledaociInternal(string query)
        {
            List<Gledalac> retlist = new List<Gledalac>();
            using (SqlCommand sqlCommnad = BaseConnection.GetSqlCommand(query))
            {
                SqlDataReader reader = sqlCommnad.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Gledalac gledalac = new Gledalac();
                        gledalac.IdGledaoca = reader.GetInt32(0);
                        gledalac.Email = reader.GetString(1);
                        gledalac.Ime = reader.GetString(2);
                        gledalac.Prezime = reader.GetString(3);
                        retlist.Add(gledalac);
                    }
                }
            }
            return retlist;
        }


        public List<Gledalac> SviGledaoci()
        {
            return SviGledaociInternal("SELECT * FROM gledalac");
        }

        public List<Gledalac> Pretraga(string by, Gledalac gledalac)
        {
            string query = string.Empty;
            switch (by)
            {
                case "IME":
                    query = $"SELECT * FROM gledalac WHERE ime LIKE '%{gledalac.Ime}%'";
                    return SviGledaociInternal(query);
                case "PREZIME":
                    query = $"SELECT * FROM gledalac WHERE prezime LIKE '%{gledalac.Prezime}%'";
                    return SviGledaociInternal(query);
                default:
                    return new List<Gledalac>();

            }
        }
    }


}

