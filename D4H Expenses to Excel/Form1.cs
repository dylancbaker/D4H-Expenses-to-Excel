using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Jitbit.Utils;

namespace D4H_Expenses_to_Excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Member> members = new List<Member>();
        List<string> files = new List<string>();
        List<ReimbursementItem> allReimbursementItems = new List<ReimbursementItem>();
        Guid sargroupMemberID = new Guid("3eed6c59-088c-44b9-8aae-8a4685f3e7dd");

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvReimbursementItems.AutoGenerateColumns = false;
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            lbFiles.DataSource = null;
            if (ofdFiles.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in ofdFiles.FileNames)
                {
                    if (!files.Contains(filename))
                    {
                        files.Add(filename);
                    }
                }

                if(files.Count > 0)
                {
                    allReimbursementItems = getAllReimbursementItemsFromFiles();
                    members = getUniqueMembers();
                    guessAtMember();

                    dgvReimbursementItems.DataSource = allReimbursementItems;
                    foreach (DataGridViewRow row in dgvReimbursementItems.Rows)
                    {
                        DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)row.Cells["colMember"];
                        cell.DataSource = members;
                        cell.DisplayMember = "Name";
                        cell.ValueMember = "MemberID";
                        ReimbursementItem item = (ReimbursementItem)row.DataBoundItem;
                        if (item.SelectedMemberID != Guid.Empty) { cell.Value = item.SelectedMemberID; }
                    }

                }
            }
            lbFiles.DataSource = files;
            lbFiles.Refresh();
        }

        private void ofdFiles_FileOk(object sender, CancelEventArgs e)
        {

        }

        private List<ReimbursementItem> getAllReimbursementItemsFromFiles()
        {
            List<ReimbursementItem> reimbursementItems = new List<ReimbursementItem>();
            foreach (string filename in files)
            {
                using (TextFieldParser parser = new TextFieldParser(filename))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        //Process row
                        string[] fields = parser.ReadFields();
                        if (fields[0] != "Item Type")
                        {
                            ReimbursementItem item = new ReimbursementItem();
                            item.ItemType = fields[0];
                            item.Description = fields[1];
                            item.Ref = fields[2];
                            item.CostPerHour = Convert.ToDecimal(fields[3]);
                            item.Hours = Convert.ToDecimal(fields[4]);
                            item.HourlyTotal = Convert.ToDecimal(fields[5]);
                            item.CostPerUse = Convert.ToDecimal(fields[6]);
                            item.Used = Convert.ToDecimal(fields[7]);
                            item.UsageTotal = Convert.ToDecimal(fields[8]);
                            item.CostPerDistance = Convert.ToDecimal(fields[9]);
                            item.Distance = Convert.ToDecimal(fields[10]);
                            item.DistanceTotal = Convert.ToDecimal(fields[11]);
                            item.Meals = Convert.ToDecimal(fields[12]);
                            item.TotalCost = Convert.ToDecimal(fields[13]);
                            reimbursementItems.Add(item);
                        }
                        /*
                        foreach (string field in fields)
                        {
                            //TODO: Process field
                            string hi = field;
                        }*/
                    }
                }
            }

            return reimbursementItems;
        }

        private List<Member> getUniqueMembers()
        {
            List<Member> members = new List<Member>();
            

            foreach (ReimbursementItem item in allReimbursementItems)
            {
                if (item.ItemType == "member")
                {
                    string memberName = item.DescriptionWithoutBracket;
                    if (members.Where(o => o.Name == memberName).Count() <= 0)
                    {
                        Member member = new Member();
                        member.Name = memberName;
                        members.Add(member);
                        item.SelectedMemberID = member.MemberID;
                    }
                    else if (members.Where(o => o.Name == memberName).Count() == 1)
                    {
                        Member member = members.Where(o => o.Name == memberName).First();
                        item.SelectedMemberID = member.MemberID;
                    }
                }
            }
            members = members.OrderBy(o => o.Name).ToList();
            Member sargroup = new Member();
            sargroup.Name = "SAR Group";
            sargroup.MemberID = sargroupMemberID;
            members.Insert(0, sargroup);
            return members;
        }

        private void guessAtMember()
        {
            foreach(ReimbursementItem item in allReimbursementItems.Where(o=>o.SelectedMemberID == Guid.Empty))
            {
                foreach(Member member in members)
                {
                    if (item.Ref.ToLower().Contains(member.Name.ToLower()))
                    {
                        item.SelectedMemberID = member.MemberID;
                        break;
                    }
                }
                if(item.SelectedMemberID == Guid.Empty) { item.SelectedMemberID = sargroupMemberID; }
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            svdSaveLocation.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DateTime today = DateTime.Now;
            svdSaveLocation.FileName = "sargroup-reimbursement-" + string.Format("{0:yyyy-MM-dd}", today) + ".csv";
            if (svdSaveLocation.ShowDialog()== DialogResult.OK)
            {
                CsvExport export = getExport();
               if(ByteArrayToFile(svdSaveLocation.FileName, export.ExportToBytes()))
                {
                    MessageBox.Show("Saved! " + svdSaveLocation.FileName);
                } else
                {
                    MessageBox.Show("Something broke, tell Dylan.");
                }
            }
            


        }

        private CsvExport getExport()
        {
            foreach (DataGridViewRow row in dgvReimbursementItems.Rows)
            {
                string strMemberID = row.Cells["colMember"].Value.ToString();
                Guid SelectedMemberID = Guid.Empty;
                if (!string.IsNullOrEmpty(strMemberID))
                {
                    SelectedMemberID = new Guid(strMemberID);
                }
                else
                {
                    SelectedMemberID = sargroupMemberID;
                }

                ReimbursementItem item = (ReimbursementItem)row.DataBoundItem;
                item.SelectedMemberID = SelectedMemberID;
            }

            CsvExport export = new CsvExport();
            foreach (Member member in members.Where(o=>o.MemberID != sargroupMemberID))
            {
                member.reimbursementItems = allReimbursementItems.Where(o => o.SelectedMemberID == member.MemberID).ToList();
                export.AddRow();
                export["Member Name"] = member.Name;
                export["Total Reimbursement"] = member.MemberTotal;
            }
            if (members.Where(o => o.MemberID == sargroupMemberID).Count() > 0)
            {
                export.AddRow();
                export["Member Name"] = "";
                export["Total Reimbursement"] = "";

                Member superMember = new Member();
                superMember.isGroup = true;
                superMember.MemberID = sargroupMemberID;
                superMember.reimbursementItems = allReimbursementItems.Where(o => o.SelectedMemberID == superMember.MemberID).ToList();

                List<Member> groupItemMembers = new List<Member>();

                foreach(ReimbursementItem item in superMember.reimbursementItems)
                {
                    if(groupItemMembers.Where(o=>o.Name == item.DescWithRef).Count() <= 0)
                    {
                        Member member = new Member();
                        member.isGroup = true;
                        member.Name = item.DescWithRef;
                        groupItemMembers.Add(member);
                    }
                    Member ThisMember = groupItemMembers.Where(o => o.Name == item.DescWithRef).First();
                    ThisMember.reimbursementItems.Add(item);

                }


                foreach (Member member in groupItemMembers)
                {
                    export.AddRow();
                    export["Member Name"] = member.Name;
                    export["Total Reimbursement"] = member.MemberTotal;
                }
            }

            return export;
        }

        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }
    }
}
