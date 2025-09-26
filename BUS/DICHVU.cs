using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DICHVU
    {
        HOTELSEntities db = new HOTELSEntities();

        public DAL.DICHVU getItem(int idDV)
        {
            return db.DICHVUs.FirstOrDefault(x => x.IDDV == idDV);
        }

        public List<DAL.DICHVU> getAll()
        {
            return db.DICHVUs.ToList();
        }

        public void add(DAL.DICHVU dvu) // hàm thêm
        {
            try
            {
                db.DICHVUs.Add(dvu);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void update(DAL.DICHVU dvu)
        {
            DAL.DICHVU _dv = db.DICHVUs.FirstOrDefault(x => x.IDDV == dvu.IDDV);
            _dv.TENDV = dvu.TENDV;
            _dv.DONGIA = dvu.DONGIA;
            _dv.DONVITINH = dvu.DONVITINH;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void delete(int idDV)
        {
            DAL.DICHVU dv = db.DICHVUs.FirstOrDefault(x => x.IDDV == idDV);

            try
            {
                db.DICHVUs.Remove(dv);// xóa Row
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }
    }
}
