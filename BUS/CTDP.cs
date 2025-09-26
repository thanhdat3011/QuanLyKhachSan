using DAL;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CTDP
    {
        HOTELSEntities db = new HOTELSEntities();
        public List<DAL.DPCT> getAll()
        {
            return db.DPCTs.ToList();
        }

        public List<object> getAllDPCT()
        {
            var dpct = (from ct in db.DPCTs
                        join p in db.PHONGs on ct.IDPHONG equals p.IDPHONG
                        join dv in db.DICHVUs on ct.IDDV equals dv.IDDV
                        select new
                        {
                            ct.IDCTDV,
                            ct.IDDATPHONG,
                            ct.IDPHONG,
                            TENPHONG = p.TENPHONG,
                            ct.IDDV,
                            TENDV = dv.TENDV,
                            ct.NGAY,
                            ct.SOLUONG,
                            ct.DONGIA,
                            ct.THANHTIEN
                        }
                        ).ToList<object>();
            return dpct;
        }

        public List<OBJ_DSDV> getAllByDatPhong(int idDP)
        {
            var lst = db.DPCTs.Where(x => x.IDDATPHONG == idDP).ToList();
            List<OBJ_DSDV> lstDSDV = new List<OBJ_DSDV>();
            OBJ_DSDV dv;
            foreach (var item in lst)
            {
                dv = new OBJ_DSDV();
                dv.IDCTDV = item.IDCTDV;
                dv.IDDP = int.Parse(item.IDDATPHONG.ToString());
                dv.IDPHONG = int.Parse(item.IDPHONG.ToString());
                var p = db.PHONGs.FirstOrDefault(x => x.IDPHONG == item.IDPHONG);
                dv.TENPHONG = p.TENPHONG;
                dv.IDDV = int.Parse(item.IDDV.ToString());
                var d = db.DICHVUs.FirstOrDefault(x => x.IDDV == item.IDDV);
                dv.TENDV = d.TENDV;
                dv.SOLUONG = int.Parse(item.SOLUONG.ToString());
                dv.DONGIA = int.Parse(item.DONGIA.ToString());
                dv.THANHTIEN = int.Parse(item.THANHTIEN.ToString());

                lstDSDV.Add(dv);
            }
            return lstDSDV;

        }

        public DPCT getItem(int? idDP, int idP)
        {
            return db.DPCTs.FirstOrDefault(x => x.IDDATPHONG == idDP && x.IDPHONG == idP);
        }


        public List<DPCT> getAllByPhong(int idDP)
        {
            return db.DPCTs.Where(x => x.IDDATPHONG == idDP).ToList();
        }


        public DAL.DPCT add(DAL.DPCT dphongCT) // hàm thêm
        {
                try
                {
                    if (dphongCT.IDDV != null)
                    {
                        db.DPCTs.Add(dphongCT);
                        db.SaveChanges();
                    }
                return dphongCT;
                }
                catch (Exception ex)
                {
                    throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!" + ex.Message);
                }
        }



        public DPCT getIDDPbyPhong(int idP)
        {
            return db.DPCTs.OrderByDescending(x => x.NGAY).FirstOrDefault(x => x.IDPHONG == idP);
        }

        public void deleteByIdDatPhong(int idDatPhong) // của chatGPT
        {
            var list = db.DPCTs.Where(x => x.IDDATPHONG == idDatPhong).ToList();
            db.DPCTs.RemoveRange(list);
            db.SaveChanges();
        }

      

        public void update(DPCT dPCT)
        {
            DPCT dpct = db.DPCTs.FirstOrDefault(x => x.IDCTDV == dPCT.IDCTDV);
            dpct.IDDATPHONG = dPCT.IDDATPHONG;
            dpct.IDPHONG = dPCT.IDPHONG;
            dpct.SOLUONG = dPCT.SOLUONG;
            dpct.DONGIA = dPCT.DONGIA;
            dpct.NGAY = dPCT.NGAY;
            dpct.THANHTIEN = dPCT.THANHTIEN;
            dpct.IDDV = dPCT.IDDV;
            try
            {
                db.SaveChanges();
            }
            catch(Exception )
            {
                
            }
                
        }

        public class DPDTO
        {
            public int IDDATPHONG { get; set; }
            public string IDNV { get; set; }
            public string TENNV { get; set; }
            public string IDKH { get; set; }
            public string TENKH { get; set; }
            public string GHICHU { get; set; }
            public int SONGAYO { get; set; }
            public int SONGUOIO { get; set; }
            public List<DVSD> DSDV  { get; set; }
            public int SOTIEN { get; set; }
        }

        public class DVSD
        {
            public string TENDV { get; set; }
            public DateTime NGAY { get; set; }
            public int SOLUONG { get; set; }
            public int DONGIA { get; set; }
            public int THANHTIEN { get; set; }

        }

        public List<DATPHONG_DTO> getListFull(int idDP)
        {

            var lstDP = db.DPCTs.Where(x => x.IDDATPHONG == idDP).ToList();
            List<DATPHONG_DTO> lstDPDTO = new List<DATPHONG_DTO>();
            DATPHONG_DTO dpDTO;
            foreach (var item in lstDP)
            {
                dpDTO = new DATPHONG_DTO();
                dpDTO.IDCTDV = item.IDCTDV;
                
                dpDTO.IDDATPHONG = (int)item.IDDATPHONG;
                var dp = db.DATPHONGs.FirstOrDefault(d => d.IDDATPHONG == item.IDDATPHONG);
                dpDTO.GHICHU = dp.GHICHU;
                dpDTO.SONGUOIO = (int)dp.SONGUOIO;
                dpDTO.SONGAYO = (int)dp.SONGAYO;
                dpDTO.SOTIEN = (int)dp.SOTIEN;
                dpDTO.NGAYDAT = dp.NGAYDAT;
                dpDTO.NGAYTRA = dp.NGAYTRA;
                dpDTO.SOLUONG = (int)item.SOLUONG;

                dpDTO.IDKH = dp.IDKH;
                var kh = db.KHACHHANGs.FirstOrDefault(k => k.IDKH == dp.IDKH);
                dpDTO.TENKH = kh.TENKH;
                dpDTO.SDT = kh.SDT;

                dpDTO.IDNV = dp.IDNV;
                var nv = db.NHANVIENs.FirstOrDefault(n => n.IDNV == dp.IDNV);
                dpDTO.TENNV = nv.TENNV;

                dpDTO.IDPHONG = dp.IDPHONG;
                var ph = db.PHONGs.FirstOrDefault(p => p.IDPHONG == dp.IDPHONG);
                dpDTO.TENPHONG = ph.TENPHONG;
                
                dpDTO.IDLP = ph.IDLOAIPHONG;
                var lp = db.LOAIPHONGs.FirstOrDefault(l => l.IDLOAIPHONG == ph.IDLOAIPHONG);
                dpDTO.GIATIEN = (int)lp.GIATIEN;

                dpDTO.DONGIA = (int)item.DONGIA;
                dpDTO.THANHTIEN = (int)item.THANHTIEN;

                dpDTO.IDDV = (int)item.IDDV;
                var dv = db.DICHVUs.FirstOrDefault(d => d.IDDV == item.IDDV);
                dpDTO.TENDV = dv.TENDV;


                lstDPDTO.Add(dpDTO);
            }
            return lstDPDTO;
        }
    }
}
