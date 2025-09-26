using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TANG
    {
        HOTELSEntities db = new HOTELSEntities();
        public List<DAL.TANG> getAll()
        {
            return db.TANGs.ToList();
        }

        public void add(DAL.TANG tANG) // hàm thêm
        {
            try
            {
                db.TANGs.Add(tANG);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void update(DAL.TANG tANG)
        {
            DAL.TANG t = db.TANGs.FirstOrDefault(x => x.IDTANG == tANG.IDTANG);
            t.TENTANG = tANG.TENTANG;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void delete(string idT)
        {
            DAL.TANG t = db.TANGs.FirstOrDefault(x => x.IDTANG == idT);

            try
            {
                db.TANGs.Remove(t);// xóa Row
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }
    }
}
