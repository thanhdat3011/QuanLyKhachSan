using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PHONG
    {
        HOTELSEntities db = new HOTELSEntities();

        public string IDPHONG { get; set; }
        public string TENPHONG { get; set; }
        public int GIATIEN { get; set; }
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
            phong.IDLOAIPHONG = _p.IDLOAIPHONG;
            phong.IDTANG = _p.IDTANG;
            var tang = db.TANGs.FirstOrDefault(t => t.IDTANG == _p.IDTANG);
            phong.TENTANG = tang.TENTANG;
            var lp = db.LOAIPHONGs.FirstOrDefault(l => l.IDLOAIPHONG == _p.IDLOAIPHONG);
            phong.TENLOAIPHONG = lp.TENLOAI;
            phong.GIATIEN = int.Parse(lp.GIATIEN.ToString());
            return phong;

        }

        public List<DAL.PHONG> getAll()
        {
            return db.PHONGs.ToList();
        }

        public List<DAL.PHONG> getByTang(string idTang)
        {
            return db.PHONGs.Where(x => x.IDTANG == idTang).ToList();
        }

        public DAL.PHONG getItem(int idP)
        {
            return db.PHONGs.FirstOrDefault(x => x.IDPHONG == idP);
        }

        public List<DAL.PHONG> getAll(string idLP)
        {
            return db.PHONGs.Where(x => x.IDLOAIPHONG == idLP).ToList();
        }


        public void add(DAL.PHONG p)
        {
            try
            {
                db.PHONGs.Add(p);
                db.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void update(DAL.PHONG p)
        {
            DAL.PHONG _p = db.PHONGs.FirstOrDefault(x => x.IDPHONG == p.IDPHONG);
            _p.IDLOAIPHONG = p.IDLOAIPHONG; // lấy id lp
            _p.IDTANG = p.IDTANG; // lấy id tầng
            _p.IDPHONG = p.IDPHONG;
            _p.TENPHONG = p.TENPHONG;
            _p.TINHTRANG = p.TINHTRANG;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void delete(int idP)
        {
            DAL.PHONG p = db.PHONGs.FirstOrDefault(x => x.IDPHONG == idP);

            try
            {
                db.PHONGs.Remove(p);// xóa Row
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void updateStatus(int idP, bool i)
        {
            DAL.PHONG p = db.PHONGs.FirstOrDefault(x => x.IDPHONG == idP);
            p.TINHTRANG = i;
            db.SaveChanges();
        }
        public bool checkEmpty(int idPhong)
        {
            var p = db.PHONGs.FirstOrDefault(x => x.IDPHONG == idPhong);
            if(p.TINHTRANG == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<object> getPhongTrongFull()
        {
            var lstP = db.PHONGs.Where(x => x.TINHTRANG == false).Select(x => new
            {
                x.IDPHONG,
                x.TENPHONG,
                GIATIEN = x.LOAIPHONG.GIATIEN
            }).ToList<object>();
            return lstP;
        }
    }
}
