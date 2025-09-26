using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LOAIPHONG
    {
        HOTELSEntities db = new HOTELSEntities();
        public DAL.LOAIPHONG getItem(string idLP)
        {
            return db.LOAIPHONGs.FirstOrDefault(x => x.IDLOAIPHONG == idLP);
        }

        public List<DAL.LOAIPHONG> getAll()
        {
            return db.LOAIPHONGs.ToList();
        } 

        public void add(DAL.LOAIPHONG lphong) // hàm thêm
        {
            try
            {
                db.LOAIPHONGs.Add(lphong);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void update(DAL.LOAIPHONG lphong)
        {
            DAL.LOAIPHONG _lp= db.LOAIPHONGs.FirstOrDefault(x => x.IDLOAIPHONG == lphong.IDLOAIPHONG);
            _lp.TENLOAI = lphong.TENLOAI;
            _lp.GIATIEN = lphong.GIATIEN;
            _lp.MOTA = lphong.MOTA;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }

        }

        public void delete(string idLP)
        {
            DAL.LOAIPHONG lp = db.LOAIPHONGs.FirstOrDefault(x => x.IDLOAIPHONG == idLP);

            try
            {
                db.LOAIPHONGs.Remove(lp);// xóa Row
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

    }
}
