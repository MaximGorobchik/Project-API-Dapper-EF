﻿using EFCatalogs.DAL.Data.Interfaces;
using EFCatalogs.Interfaces;
using main.Models.Employees;

namespace EFCatalogs.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employees>> GetAllEmployeesAsync()
        {
            // Виконати потрібні операції для отримання всіх співробітників
            return await _unitOfWork._EmployeesRepository.GetAllAsync();
        }

        public async Task<Employees> GetEmployeeByIdAsync(int id)
        {
            // Виконати потрібні операції для отримання співробітника за ідентифікатором
            return await _unitOfWork._EmployeesRepository.GetByIdAsync(id);
        }

        public async Task<int> AddEmployeeAsync(Employees employee)
        {
            // Виконати потрібні операції для додавання нового співробітника
            return await _unitOfWork._EmployeesRepository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(int id, Employees employee)
        {
            // Виконати потрібні операції для оновлення співробітника
            var existingEmployee = await _unitOfWork._EmployeesRepository.GetByIdAsync(id);
            if (existingEmployee != null)
            {
                // Виконати оновлення співробітника
                existingEmployee.Firstname = employee.Firstname;
                existingEmployee.Lastname = employee.Lastname;
                await _unitOfWork._EmployeesRepository.UpdateAsync(existingEmployee);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            // Виконати потрібні операції для видалення співробітника за ідентифікатором
            await _unitOfWork._EmployeesRepository.DeleteAsync(id);
        }
    }
}
