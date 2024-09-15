using InstutueWeb.Data.Dtos;

namespace InstutueWeb.Data.Interfaces
{
    public interface IDepartment
    {
        void SaveDepartment(DepartmentAddDto addDto);
        void RemoveDepartment(DepartmentRemoveDto removeDto);
        void UpdateDepartment(DepartmentUpdateDto updateDto);
        List<DepartmentAddDto> GetDepartmens();
        DepartmentAddDto GetDepartmentById(int departmentId);
    }
}
