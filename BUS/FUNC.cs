using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class FUNC
    {
        HOTELSEntities db = new HOTELSEntities();

        public FUNC()
        {
            db = new HOTELSEntities();
        }

        public List<DAL.FUNC> getParent()
        {
            return db.FUNCs.Where(x => x.ISGROUP == true && x.MENU == true).OrderBy(s => s.SORT).ToList();
        }

        public List<DAL.FUNC> getChild(string parent)
        {
            return db.FUNCs.Where(x => x.ISGROUP == false && x.MENU == true && x.PARENT == parent).OrderBy(s => s.SORT).ToList();
        }
    }
}
