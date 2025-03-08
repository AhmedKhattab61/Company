using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DAL.Models;

namespace Company.BLL.Interfaces
{
    internal interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();

        Department? GetById(int id);

        int Add(Department model);

        int Update(Department model);
        int Delete(Department model);

    }
}
