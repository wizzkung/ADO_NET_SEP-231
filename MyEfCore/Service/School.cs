//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using MyEfCore.Model.HomeWork_School;
//using MyEfCore.MyContext;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyEfCore.Service
//{
//    public class School
//    {
//        public void Add()
//        {
//            using (Context db = new Context())
//            {
//                var teacher1 = new Teacher { FirstName = "John", LastName = "Smith", Age = 30 };
//                var teacher2 = new Teacher { FirstName = "Emily", LastName = "Davis", Age = 31 };

//                var subject1 = new Subject { Name = "Mathematics", Teacher = teacher1, TeacherID = 0};
//                var subject2 = new Subject { Name = "History", Teacher = teacher2, TeacherID = 1 };
//                var subject3 = new Subject { Name = "Physics", Teacher = teacher1, TeacherID = 0 };

//                var student1 = new Student { FirstName = "Alice", LastName = "Johnson", Age = 14 };
//                var student2 = new Student { FirstName = "Bob", LastName = "Brown", Age = 15 };
//                var student3 = new Student { FirstName = "Charlie", LastName = "Wilson", Age = 15 };

//                db.Teachers.AddRange(teacher1, teacher2);
//                db.Subjects.AddRange(subject1, subject2, subject3);
//                db.students.AddRange(student1, student2, student3);

//                try
//                {
//                    var changes = db.SaveChanges(); 
//                    if (changes > 0)
//                    {
//                        Console.WriteLine($"Успешно добавлено {changes} записей.");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Данные не были добавлены.");
//                    }

//                    // Проверка состояния сущностей
//                    var unsavedEntities = db.ChangeTracker.Entries()
//                        .Where(e => e.State != Microsoft.EntityFrameworkCore.EntityState.Unchanged)
//                        .ToList();

//                    if (unsavedEntities.Any())
//                    {
//                        Console.WriteLine("Есть сущности, которые не были добавлены:");
//                        foreach (var entity in unsavedEntities)
//                        {
//                            Console.WriteLine($"Сущность: {entity.Entity.GetType().Name}, Состояние: {entity.State}");
//                        }
//                    }
//                }
//                catch (DbUpdateException ex)
//                {
//                    if (ex.InnerException != null)
//                        Console.WriteLine($"InnerException: {ex.InnerException.Message}");
//                    else
//                        Console.WriteLine($"DbUpdateException: {ex.Message}");
//                }
//            }
//        }

//    }
//}
