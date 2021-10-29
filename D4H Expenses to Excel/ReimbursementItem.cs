using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D4H_Expenses_to_Excel
{
    class ReimbursementItem
    {
        public string ItemType { get; set; }
        public string Description { get; set; }
        public string DescriptionWithoutBracket
        {
            get
            {
                if (Description.Contains("("))
                {
                    string temp = Description.Substring(0, Description.IndexOf("(")).Trim();
                    return temp;
                }
                else { return Description; }
            }
        }
        public string Ref { get; set; }
        public string DescWithRef
        {
            get
            {
                if(!string.IsNullOrEmpty(Ref) && !string.IsNullOrEmpty(Description))
                {
                    if (Ref == Description) { return Ref; }
                    else { return Description + " - " + Ref; }
                }
                else { return Description + Ref; }
            }

        }
        public decimal CostPerHour { get; set; }
        public decimal Hours { get; set; }
        public decimal HourlyTotal { get; set; }
        public decimal CalculatedHourlyTotal { get { return CostPerHour * Hours; } }
        public decimal CostPerUse { get; set; }
        public decimal Used { get; set; }
        public decimal UsageTotal { get; set; }
        public decimal CostPerDistance { get; set; }
        public decimal Distance { get; set; }
        public decimal DistanceTotal { get; set; }
        public decimal Meals { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalCostLessUsage
        {
            get
            {
                if (ItemType == "member")
                {
                    return TotalCost - UsageTotal;

                }
                else { return TotalCost; }
            }
        }
        public Guid SelectedMemberID { get; set; }
    }
}
