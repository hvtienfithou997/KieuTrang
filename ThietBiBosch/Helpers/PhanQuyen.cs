using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThietBiBosch.Database;

namespace ThietBiBosch.Helpers
{
    public static class PhanQuyen
    {
        public static readonly ThietBiNoiThatEntities db = new ThietBiNoiThatEntities();
        public static List<Database.PhanQuyen> GetPhanQuyen()
        {
            return db.PhanQuyens.ToList();
        }
    }
}