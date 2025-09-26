using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NHANVIEN
    {
        HOTELSEntities db = new HOTELSEntities();

        public List<DAL.NHANVIEN> getAll()
        {
            return db.NHANVIENs.ToList();
        }

        public DAL.NHANVIEN getItem(string idNV)
        {
            return db.NHANVIENs.FirstOrDefault(x => x.IDNV == idNV);
        }

        public List<DAL.NHANVIEN> getAll(string idNV)
        {
            return db.NHANVIENs.Where(x => x.IDNV == idNV).ToList();
        }


        public void add(DAL.NHANVIEN nv)
        {
            try
            {
                db.NHANVIENs.Add(nv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void update(DAL.NHANVIEN nv)
        {
            DAL.NHANVIEN _nv = db.NHANVIENs.FirstOrDefault(x => x.IDNV == nv.IDNV);
            _nv.IDNV = nv.IDNV;
            _nv.TENNV = nv.TENNV;
            _nv.SDT = nv.SDT;
            _nv.CHUCVU = nv.CHUCVU;


            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void delete(string idNV)
        {
            DAL.NHANVIEN nv = db.NHANVIENs.FirstOrDefault(x => x.IDNV == idNV);

            try
            {
                db.NHANVIENs.Remove(nv);// xóa Row
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }
    }
}
