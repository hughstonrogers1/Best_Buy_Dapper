using System;
using System.Collections.Generic;
using System.Text;

namespace Best_buy_Dapper
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetDepartments();
        
    }
}
