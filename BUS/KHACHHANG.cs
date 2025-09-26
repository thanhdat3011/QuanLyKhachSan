using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KHACHHANG
    {
        HOTELSEntities db = new HOTELSEntities();
        public List<DAL.KHACHHANG> getAll()
        {
            return db.KHACHHANGs.ToList();
        }

        public DAL.KHACHHANG getItem(string idP)
        {
            return db.KHACHHANGs.FirstOrDefault(x => x.IDKH == idP);
        }

        public List<DAL.KHACHHANG> getAll(string idKH)
        {
            return db.KHACHHANGs.Where(x => x.IDKH == idKH).ToList();
        }


        public void add(DAL.KHACHHANG kh)
        {
            try
            {
                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void update(DAL.KHACHHANG kh)
        {
            DAL.KHACHHANG _kh = db.KHACHHANGs.FirstOrDefault(x => x.IDKH == kh.IDKH);
            _kh.IDKH = kh.IDKH; // lấy id lp
            _kh.TENKH = kh.TENKH;
            _kh.CCCD = kh.CCCD;
            _kh.SDT = kh.SDT;
            _kh.DIACHI = kh.DIACHI;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void delete(string idKH)
        {
            DAL.KHACHHANG kh = db.KHACHHANGs.FirstOrDefault(x => x.IDKH == idKH);

            try
            {
                db.KHACHHANGs.Remove(kh);// xóa Row
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }
    }
}
