using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DATPHONG
    {
        HOTELSEntities db = new HOTELSEntities();

        public DAL.DATPHONG getItem(int idDP)
        {
            return db.DATPHONGs.FirstOrDefault(x => x.IDDATPHONG == idDP);
        }

        public DAL.DATPHONG getItemByDP(int idP)
        {
            return db.DATPHONGs.FirstOrDefault(x => x.IDPHONG == idP);
        }

        public List<object> getAll()
        {
            var getAll = (from dp in db.DATPHONGs
                          join nv in db.NHANVIENs on dp.IDNV equals nv.IDNV
                          join kh in db.KHACHHANGs on dp.IDKH equals kh.IDKH
                          join p in db.PHONGs on dp.IDPHONG equals p.IDPHONG
                          select new
                          {
                              dp.IDDATPHONG,
                              dp.NGAYDAT,
                              dp.NGAYTRA,
                              dp.TRANGTHAI,
                              TENKH = kh.TENKH,
                              TENNV = nv.TENNV,
                              TENPHONG = p.TENPHONG,
                              dp.SONGUOIO,
                              dp.SONGAYO,
                              dp.SOTIEN,
                              dp.GHICHU
                          }
                          ).ToList<object>();
            return getAll;
        }


        public DAL.DATPHONG add(DAL.DATPHONG dphong) // hàm thêm
        {
            try
            {
                db.DATPHONGs.Add(dphong);
                db.SaveChanges();
                return dphong;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }


        public void updateStatus(int idDP)
        {
            DAL.DATPHONG dp = db.DATPHONGs.FirstOrDefault(x => x.IDDATPHONG == idDP);
            dp.TRANGTHAI = true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public DAL.DATPHONG update(DAL.DATPHONG _dp)
        {
            DAL.DATPHONG dp = db.DATPHONGs.FirstOrDefault(x => x.IDDATPHONG == _dp.IDDATPHONG);
            dp.IDKH = _dp.IDKH;
            dp.IDNV = _dp.IDNV;
            dp.IDDV = _dp.IDDV;
            dp.IDPHONG = _dp.IDPHONG;
            dp.NGAYDAT = _dp.NGAYDAT;
            dp.NGAYTRA = _dp.NGAYTRA;
            dp.GHICHU = _dp.GHICHU;
            dp.SONGUOIO = _dp.SONGUOIO;
            dp.SOTIEN = _dp.SOTIEN;

            try
            {
                db.SaveChanges();
                return _dp;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public void delete(int idDP)
        {
            DAL.DATPHONG dp = db.DATPHONGs.FirstOrDefault(x => x.IDDATPHONG == idDP);

            try
            {
                db.DATPHONGs.Remove(dp);// xóa Row
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
            }
        }

        public List<DoanhThuDTO> getDTTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            List<DoanhThuDTO> lstDT = new List<DoanhThuDTO>();
            var lstDP = db.DATPHONGs.Where(x => x.NGAYDAT >= tuNgay && x.NGAYDAT <= denNgay).ToList();
            
            foreach (var dp in lstDP)
            {
                DoanhThuDTO dtDTO = new DoanhThuDTO();
                dtDTO.IDDP = dp.IDDATPHONG;
                dtDTO.IDPHONG = dp.IDPHONG;

                var ph = db.PHONGs.FirstOrDefault(p => p.IDPHONG == dp.IDPHONG);
                dtDTO.TENPHONG = ph.TENPHONG;

                dtDTO.SONGAYO = (int)dp.SONGAYO;
                dtDTO.DOANHTHU = (int)dp.SOTIEN;
                dtDTO.TONGTIEN = lstDT.Sum(x => x.DOANHTHU);

                dtDTO.TUNGAY = tuNgay;
                dtDTO.DENNGAY = denNgay;
                lstDT.Add(dtDTO);
            }
            return lstDT;
        }
    }
}
