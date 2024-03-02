
using Infrastructure.Services;
var studentService=new StudentService();
var courseService=new CourseService();
/*
System.Console.WriteLine(studentService.GroupStudents(1).Group.Name);
System.Console.WriteLine("-----------------------------------");
foreach (var item in studentService.GroupStudents(1).Students )
{
    System.Console.WriteLine(item.Name);
}
System.Console.WriteLine("-----------------------------------");
*/
/*
foreach (var item in studentService.ListOfGroupWithStudents())
{
    
    System.Console.WriteLine(item.Group.Id);
    System.Console.WriteLine(item.Group.Name);
    System.Console.WriteLine("-----------------------------------");
    foreach (var item1 in item.Students )
    {
        System.Console.WriteLine(item1.Name);
        System.Console.WriteLine(item1.age);
    }

    System.Console.WriteLine("-----------------------------------");
}

*/


foreach (var item in courseService.courseGroups())
{
    
    System.Console.WriteLine(item.Course.Id);
    System.Console.WriteLine(item.Course.Name);
    System.Console.WriteLine("-----------------------------------");
    foreach (var item1 in item.Groups )
    {
        System.Console.WriteLine(item1.Name);
       
    }

    System.Console.WriteLine("-----------------------------------");
}