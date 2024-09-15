

using InstutueWeb.Data.Base;

namespace InstutueWeb.Data.Entities
{
   
    public sealed class Course : AuditEntity
    {
        
        public int CourseID { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
    }
}
