using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Models
{
    public class LeaveRequests
    {
        public int LeaveID { get; set; }
        public int EmployeeID 
        {   
            get; 
            set; 
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; } // e.g., "Pending", "Approved", "Rejected"
    }
}
