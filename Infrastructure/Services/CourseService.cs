using Domain.Models;
using Infrastructure.DataContext;
using Dapper;
namespace Infrastructure.Services;

public class CourseService
{
  private readonly DapperContext context;



  public CourseService()
  {
    context = new DapperContext();
  }

  public List<CourseGroups> courseGroups()
  {

    var sql1 = "select id from Courses";

    var listOfId = context.connection().Query<int>(sql1).ToList();


    var sql2 = @"select * from Courses where id=@id;
       
       select * from Groups where id_course=@id;
       
       ";

    List<CourseGroups> listAll = new List<CourseGroups>();
    foreach (var item in listOfId)
    {
      using (var multiple = context.connection().QueryMultiple(sql2, new { Id = item }))
      {
        var Groups = new CourseGroups();
        Groups.Course = multiple.ReadFirst<Courses>();
        Groups.Groups = multiple.Read<Groups>().ToList();
        listAll.Add(Groups);
      }
    }
    return listAll;

  }






     public void AddCourse (Courses course)
    { 
      var sql="insert into Courses (name) values (@name)";

       context.connection().Execute(sql,course);

    }

   public void DeleteCourse(int id)
   {
    var sql="delete from Courses where id= @id" ;

       context.connection().Execute(sql,new{Id=id});
   }  

   public void UpdateCourse(Courses course)
   {
      var sql="Update from Courses set name=@name where id=@id";
      context.connection().Execute(sql,course);
   }

   public List<Courses> GetCourses(){

    var sql="select * from Courses";

   return context.connection().Query<Courses>(sql).ToList();
       
   }



}
