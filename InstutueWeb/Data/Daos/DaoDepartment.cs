using InstutueWeb.Data.Context;
using InstutueWeb.Data.Dtos;
using InstutueWeb.Data.Entities;
using InstutueWeb.Data.Exceptions;
using InstutueWeb.Data.Interfaces;
using System.Collections.Generic;

namespace InstutueWeb.Data.Daos
{
    public class DaoDepartment : IDepartment
    {
        private readonly InstituteDbContext instituteDb;
        private readonly ILogger<DaoDepartment> logger;

        public DaoDepartment(InstituteDbContext instituteDb,
                             ILogger<DaoDepartment> logger)
        {
            this.instituteDb = instituteDb;
            this.logger = logger;
        }
        public List<DepartmentAddDto> GetDepartmens()
        {
            List<DepartmentAddDto> departments = new List<DepartmentAddDto>();
            try
            {
                departments = (from depto in this.instituteDb.Departments
                               where depto.Deleted == false
                               orderby depto.CreationDate descending
                               select new DepartmentAddDto()
                               {
                                   AdministratorId = depto.Administrator,
                                   Budget = depto.Budget,
                                   CreationDate = depto.CreationDate,
                                   CreationUser = depto.CreationUser,
                                   Name = depto.Name,
                                   StartDate = depto.StartDate,
                                   DepartmentId = depto.DepartmentID
                               }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los departamentos", ex.ToString());
            }
            return departments;
        }

        public DepartmentAddDto GetDepartmentById(int departmentId)
        {
            DepartmentAddDto departmentResult = new DepartmentAddDto();
            try
            {
                var department = this.instituteDb.Departments.Find(departmentId);

                if (department is null)
                    throw new DepartmentException("El deparmento no se encuentra registrado.");


                departmentResult.AdministratorId = department.Administrator;
                departmentResult.Budget = department.Budget;
                departmentResult.CreationDate = department.CreationDate;
                departmentResult.CreationUser = department.CreationUser;
                departmentResult.Name = department.Name;
                departmentResult.DepartmentId = department.DepartmentID;
                departmentResult.StartDate = department.StartDate;


            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el departamento", ex.ToString());
            }
            return departmentResult;
        }

        public void RemoveDepartment(DepartmentRemoveDto removeDto)
        {
            try
            {
                if (removeDto is null)
                    throw new DepartmentException("El objeto deparmento no puede ser nulo.");


                var department = this.instituteDb.Departments.Find(removeDto.DepartmentId);

                if (department is null)
                    throw new DepartmentException("El deparmento no se encuentra registrado.");

                department.Deleted = true;
                department.DeletedDate = removeDto.DeletedDate;
                department.UserDeleted = removeDto.DeleteUser;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error removiendo el departamento", ex.ToString());
            }
        }

        public void SaveDepartment(DepartmentAddDto addDto)
        {
            try
            {
                if (addDto is null)
                    throw new DepartmentException("El objeto deparmento no puede ser nulo.");

                if (this.instituteDb.Departments.Any(depto => depto.Name == addDto.Name))
                    throw new DepartmentException("El objeto deparmento no puede ser nulo.");


                Department department = new Department()
                {
                    Administrator = addDto.AdministratorId,
                    Budget = addDto.Budget,
                    CreationDate = addDto.CreationDate,
                    CreationUser = addDto.CreationUser,
                    Name = addDto.Name,
                    StartDate = addDto.StartDate

                };
                this.instituteDb.Departments.Add(department);
                this.instituteDb.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error guardando el departamento", ex.ToString());

            }
        }

        public void UpdateDepartment(DepartmentUpdateDto updateDto)
        {
            try
            {
                if (updateDto is null)
                    throw new DepartmentException("El objeto deparmento no puede ser nulo.");


                Department department = this.instituteDb.Departments.Find(updateDto.DepartmentId);


                if (department is null)
                    throw new DepartmentException("El deparmento no se encuentra registrado.");


                department.Name = updateDto.Name;
                department.StartDate = updateDto.StartDate;
                department.UserMod = updateDto.ModifyUser;
                department.ModifyDate = updateDto.ModifyDate;
                department.Budget = updateDto.Budget;

                this.instituteDb.Departments.Update(department);
                this.instituteDb.SaveChanges();

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error actualizando el departamento", ex.ToString());

            }
        }
    }
}
