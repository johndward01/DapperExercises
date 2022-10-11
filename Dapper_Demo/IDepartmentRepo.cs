using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Demo;
internal interface IDepartmentRepo
{
    public IEnumerable<Department> GetAllDepartments();

    public Department GetDepartment(int newID);

    public void InsertDepartment(string newDepartmentName);

    public void UpdateDepartment(int newID, string newName);

    public void DeleteDepartment(int newID);

    //public void DeleteDepartments(int startPosition, int endPosition);
}
