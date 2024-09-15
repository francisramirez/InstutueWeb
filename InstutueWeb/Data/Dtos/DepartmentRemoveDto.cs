namespace InstutueWeb.Data.Dtos
{
    public class DepartmentRemoveDto
    {
        public int DepartmentId { get; set; }
        public bool Deleted { get; set; }
        public int DeleteUser { get; set; }
        public DateTime DeletedDate { get; set; }

    }
}
