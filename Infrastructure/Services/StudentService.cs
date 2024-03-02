namespace Infrastructure.Services;
using DataContext;
using Domain.Models;
using Dapper;
using Npgsql;

public class StudentService
{

   private readonly DapperContext context;

   public StudentService()
   {
     context=new DapperContext();
   }
    

    public GroupStudents GroupStudents(int id)
    {
       var sql =@"select * from Groups where id=@id;
       
       select * from Students where id_group=@id;
       
       ";
       using (var multiple = context.connection().QueryMultiple(sql,new{Id=id}))
       {
          var studentService =new GroupStudents();
          studentService.Group=multiple.ReadFirst<Groups>();
          studentService.Students=multiple.Read<Students>().ToList(); 
          return studentService;
       }

    }

    public List<GroupStudents>ListOfGroupWithStudents()
    {
      
     
    var sql1 = "select id from Groups";

    var listOfId = context.connection().Query<int>(sql1).ToList();


     var sql2 =@"select * from Groups where id=@id;
       
       select * from Students where id_group=@id;
       
       ";

    List<GroupStudents> listAll = new List<GroupStudents>();
    foreach (var item in listOfId)
    {
      using (var multiple = context.connection().QueryMultiple(sql2, new { Id = item }))
      {
        var Students = new GroupStudents();
        Students.Group = multiple.ReadFirst<Groups>();
        Students.Students = multiple.Read<Students>().ToList();
        listAll.Add(Students);
      }
    }
    return listAll;

    }





}
