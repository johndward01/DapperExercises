using Dapper;
using System.Data;
using System.Data.Common;

internal class DepartmentRepo
{
    private readonly IDbConnection _conn;

    public DepartmentRepo(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _conn.Query<Department>("SELECT * FROM departments;");
    }

    public Department GetDepartment(int newID)
    {
        return _conn.QuerySingle<Department>("SELECT * FROM departments WHERE DepartmentId = @ID;",
            new { ID = newID });
    }

    public void InsertDepartment(string newDepartmentName)
    {
        _conn.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
    }

    public void UpdateDepartment(int departmentId, string newName)
    {
        _conn.Execute("UPDATE departments SET Name = @name WHERE DepartmentID = @id;",
            new { name = newName, id = departmentId });
    }

    public void DeleteDepartment(int id)
    {
        _conn.Execute("DELETE FROM departments WHERE DepartmentID = @id;", new { id = id });
    }

    //public void DeleteDepartments(int startPosition, int endPosition)
    //{
    //    _connection.Execute("DELETE FROM departments WHERE DepartmentID BETWEEN @start AND @end;", new { start = startPosition, end = endPosition });
    //}
}