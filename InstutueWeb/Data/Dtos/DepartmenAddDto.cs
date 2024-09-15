namespace InstutueWeb.Data.Dtos
{
    public record DepartmentAddDto
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public int? AdministratorId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }   
    }
}
