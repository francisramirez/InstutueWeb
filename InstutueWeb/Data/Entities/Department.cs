using InstutueWeb.Data.Base;

namespace InstutueWeb.Data.Entities
{

    public sealed class Department : AuditEntity
    {
        
        public  int DepartmentID { get; set; }
        public string? Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime? StartDate { get; set; }

        public int? Administrator { get; set; }
    }
}
