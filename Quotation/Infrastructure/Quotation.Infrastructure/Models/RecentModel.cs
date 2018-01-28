using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Models
{
    public class RecentListModel
    {
        int allowedCount = 20;
        public RecentListModel()
        {
            RecentList = new List<RecentItem>();
        }

        public List<RecentItem> RecentList { get; private set; }

        public int ListCount
        {
            get
            {
                return RecentList.Count;
            }
        }

        public void Add(RecentItem item)
        {
            if(item != null)
            {
                bool anyExist = this.RecentList.Any(ri => ri.QuotationNo == item.QuotationNo);
                if(anyExist == false)
                {
                    if (this.RecentList.Count == 0)
                    {
                        this.RecentList.Add(item);
                    }
                    else
                    {
                        if(this.ListCount == allowedCount)
                        {
                            this.RecentList.RemoveAt(allowedCount - 1);
                        }

                        this.RecentList.Insert(0, item);
                    }
                }
                else
                {
                    var rItem = this.RecentList.Single(ri => ri.QuotationNo == item.QuotationNo);
                    int rIndex = this.RecentList.IndexOf(rItem);
                    this.RecentList.RemoveAt(rIndex);
                    this.RecentList.Insert(0, item);
                }
            }
        }
    }

    public class RecentItem
    {
        public RecentItem()
        {

        }

        public string QuotationNo { get; set; }
        public string NRIC { get; set; }
        public string OwnerName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
