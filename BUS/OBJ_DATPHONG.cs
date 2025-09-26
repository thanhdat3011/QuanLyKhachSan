using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class OBJ_DATPHONG
    {
        HOTELSEntities db = new HOTELSEntities();


        public int IDPHONG { get; set; }
        public string TENPHONG { get; set; }
        public int GIATIEN { get; set; }
        public bool TINHTRANG { get; set; }
        public string IDTANG { get; set; }
        public string IDLOAIPHONG { get; set; }
        public string TENTANG { get; set; }
        public string TENLOAIPHONG { get; set; }

        public OBJ_DATPHONG getItemFull(int id)
        {
            var _p = db.PHONGs.FirstOrDefault(x => x.IDPHONG == id);
            OBJ_DATPHONG phong = new OBJ_DATPHONG();
            phong.IDPHONG = _p.IDPHONG;
            phong.TENPHONG = _p.TENPHONG;
            phong.TINHTRANG = _p.TINHTRANG;
            phong.IDLOAIPHONG = _p.IDLOAIPHONG;
            phong.IDTANG = _p.IDTANG;
            var tang = db.TANGs.FirstOrDefault(t => t.IDTANG == _p.IDTANG);
            phong.TENTANG = tang.TENTANG;
            var lp = db.LOAIPHONGs.FirstOrDefault(l => l.IDLOAIPHONG == _p.IDLOAIPHONG);
            phong.TENLOAIPHONG = lp.TENLOAI;
            phong.GIATIEN = int.Parse(lp.GIATIEN.ToString());
            return phong;
            
        }
    }
}
