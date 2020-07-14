using Paycompute.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paycompute.Persistence;

namespace Paycompute.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext context;
        private decimal studentLoanAmount;

        public EmployeeService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(Employee newEmployee)
        {
           await context.Employees.AddAsync(newEmployee);
           await context.SaveChangesAsync();
        }

        public Employee GetById(int employeeId) => 
            context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            context.Remove(employee);
            await context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll() => context.Employees;

        public async Task UpdateAsync(Employee employee)
        {
            context.Update(employee);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            context.Update(employee);
            await context.SaveChangesAsync();
        }

        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            var employee = GetById(id);
            if (employee.StudentLoan == StudentLoan.Yes && totalAmount > 1750 && totalAmount < 2000)
            {
                studentLoanAmount = 15m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2000 && totalAmount < 2250)
            {
                studentLoanAmount = 38m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2250 && totalAmount < 2500)
            {
                studentLoanAmount = 60m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2500)
            {
                studentLoanAmount = 83m;
            }
            else
            {
                studentLoanAmount = 0m;
            }

            return studentLoanAmount;
        }

        public decimal UnionFees(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
