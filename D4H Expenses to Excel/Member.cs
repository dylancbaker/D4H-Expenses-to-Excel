using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D4H_Expenses_to_Excel
{
    class Member
    {
        public Member() { MemberID = Guid.NewGuid(); }
        public Guid MemberID { get; set; }
        public string Name { get; set; }
        private List<ReimbursementItem> l_reimbursementItems = new List<ReimbursementItem>();
        public List<ReimbursementItem> reimbursementItems { get { return l_reimbursementItems; } set { l_reimbursementItems = value; } }
        public decimal MemberTotal { get { return reimbursementItems.Sum(o => o.TotalCostLessUsage); } }
        public bool isGroup { get; set; }
    }
}
