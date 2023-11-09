﻿using Dal;
using DalApi;
using DO;

namespace DalTest;

internal class Program
{
    private static IEngineer? s_dalEngineer =new EngineerImplementation();
    private static ITask? s_dalTask = new TaskImplementation();
    private static IDependency? s_dalDependency = new DependencyImplementation();
    static void Main(string[] args)
    {
        try
        {
            Initialization.Do(s_dalEngineer!, s_dalTask!, s_dalDependency!);
            mainMenu();
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex);
        }    
    }
    #region create methods
    static int createEngineer()
    {
        Console.WriteLine("Enter engineer's details: id, name, email, level and cost:\n");
        int _id = Convert.ToInt32(Console.ReadLine());
        string _name = Console.ReadLine()!;
        string _email = Console.ReadLine()!;
        EngineerExperience _level = (EngineerExperience)Convert.ToInt32(Console.ReadLine());
        double _cost = Convert.ToDouble(Console.ReadLine());
        Engineer newEng = new(_id, _name, _email, _level, _cost);
        return s_dalEngineer!.Create(newEng);
    }
    static int createTask()
    {
        Console.WriteLine("Enter task's details: description, alias, milestone.\n dates of: creating, start, scheduled date, forecast , deadline and complete.\n deliverables, remarks, engineer's id and complexity level:\n");
        string _description = Console.ReadLine()!;
        string _alias = Console.ReadLine()!;
        bool _milestone = Convert.ToBoolean(Console.ReadLine()!);
        DateTime _createdAt= Convert.ToDateTime(Console.ReadLine()!);
        DateTime? _start=Convert.ToDateTime(Console.ReadLine());
        DateTime? _scheduledDate= Convert.ToDateTime(Console.ReadLine()); 
        DateTime? _forecastDate = Convert.ToDateTime(Console.ReadLine());
        DateTime? _deadline = Convert.ToDateTime(Console.ReadLine());
        DateTime? _complete = Convert.ToDateTime(Console.ReadLine());
        string? _deliverables = Console.ReadLine();
        string? _remarks = Console.ReadLine();
        int? _engineerId = Convert.ToInt32(Console.ReadLine());
        EngineerExperience? _complexityLevel= (EngineerExperience)Convert.ToInt32(Console.ReadLine());
        DO.Task newTask = new (-1,_description,_alias,_milestone,_createdAt, _start, _scheduledDate,_forecastDate,_deadline, _complete, _deliverables, _remarks, _engineerId, _complexityLevel);
        return s_dalTask!.Create(newTask);
    }
    static int createDependency()
    {
        Console.WriteLine("Enter dependency's details: dependent task and depends-on task:\n");
        int? _dependentTask = Convert.ToInt32(Console.ReadLine());
        int? _dependsOnTask = Convert.ToInt32(Console.ReadLine());
        Dependency newDep = new(-1, _dependentTask, _dependsOnTask);
        return s_dalDependency!.Create(newDep);
    }
    #endregion

    #region read methods
    static Engineer? readEngineer()
    {
        Console.WriteLine("Enter engineer's id for reading:\n");
        int id = Convert.ToInt32(Console.ReadLine());
        return s_dalEngineer!.Read(id);
    }

    static DO.Task? readTask()
    {
        Console.WriteLine("Enter task's id for reading:\n");
        int id = Convert.ToInt32(Console.ReadLine());
        return s_dalTask!.Read(id);
    }

    static Dependency? readDependency()
    {
        Console.WriteLine("Enter dependency's id for reading:\n");
        int id= Convert.ToInt32(Console.ReadLine());
        return s_dalDependency!.Read(id);
    }
    #endregion

    #region readAll methods
    static List<Engineer> readAllEngineers()
    {
        return s_dalEngineer!.ReadAll();
    }

    static List<DO.Task> readAllTasks()
    {
        return s_dalTask!.ReadAll();
    }

    static List<Dependency> readAllDependencies()
    {
        return s_dalDependency!.ReadAll();
    }
    #endregion

    #region update methods
    static void updateEngineers()
    {
     
    }
    static void updateTasks()
    {
    }

    static void updateDependenies()
    {

    }
    #endregion

    #region delete methods
    static void deleteEngineer()
    {
        Console.WriteLine("Enter engineer's id for deleting:\n");
        int id = Convert.ToInt32(Console.ReadLine());
        s_dalEngineer!.Delete(id);
    }

    static void deleteTask()
    {
        Console.WriteLine("Enter task's id for deleting:\n");
        int id = Convert.ToInt32(Console.ReadLine());
        s_dalTask!.Delete(id);
    }

    static void deleteDependency()
    {
        Console.WriteLine("Enter dependency's id for deleting:\n");
        int id = Convert.ToInt32(Console.ReadLine());
        s_dalDependency!.Delete(id);
    }
    #endregion
    static void engineerMenu()
    {
        while (true)
        {
            Console.WriteLine("Choose the method that you want to execute:\n 1 to exit\n 2 to Create\n 3 to Read\n 4 to ReadAll\n 5 to Update\n 6 to Delete");
            int methodChoice = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (methodChoice)
                {
                    case 1:
                        return;
                    case (int)CRUD.CREATE:
                        int returnedId = createEngineer();
                        Console.WriteLine($"The engineer's id: {returnedId}\n");
                        break;
                    case (int)CRUD.READ:
                        Console.WriteLine(readEngineer());
                        break;
                    case (int)CRUD.READALL:
                        List<Engineer> returnedList = readAllEngineers();
                        foreach (var en in returnedList)
                            Console.WriteLine(en);
                        break;
                    case (int)CRUD.UPDATE:
                        updateEngineers();
                        break;
                    case (int)CRUD.DELETE:
                        deleteEngineer();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
    static void taskMenu()
    {
        while (true)
        {
            Console.WriteLine("Choose the method that you want to execute:\n 1 to exit\n 2 to Create\n 3 to Read\n 4 to ReadAll\n 5 to Update\n 6 to Delete");
            int methodChoice = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (methodChoice)
                {
                    case 1:
                        return;
                    case (int)CRUD.CREATE:
                        int returnedId = createTask();
                        Console.WriteLine($"The task's id: {returnedId}\n");
                        break;
                    case (int)CRUD.READ:
                        Console.WriteLine(readTask());
                        break;
                    case (int)CRUD.READALL:
                        List<DO.Task> returnedList = readAllTasks();
                        foreach (var task in returnedList)
                            Console.WriteLine(task);
                        break;
                    case (int)CRUD.UPDATE:
                        updateTasks();
                        break;
                    case (int)CRUD.DELETE:
                        deleteTask();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
   static void dependencyMenu()
    {
        while (true)
        {
            Console.WriteLine("Choose the method that you want to execute:\n 1 to exit\n 2 to Create\n 3 to Read\n 4 to ReadAll\n 5 to Update\n 6 to Delete");
            int methodChoice = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (methodChoice)
                {
                    case 1:
                        return;
                    case (int)CRUD.CREATE:
                        int returnedId = createDependency();
                        Console.WriteLine($"The dependency's id: {returnedId} \n");
                        break;
                    case (int)CRUD.READ:
                        Console.WriteLine(readDependency());
                        break;
                    case (int)CRUD.READALL:
                        List<Dependency> returnedList = readAllDependencies();
                        foreach (var dep in returnedList)
                            Console.WriteLine(dep);
                        break;
                    case (int)CRUD.UPDATE:
                        updateDependenies();
                        break;
                    case (int)CRUD.DELETE:
                        deleteDependency();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
    static void mainMenu()
    {
        while (true)
        {
            Console.WriteLine("Choose an entity that you whant to check:\n 0 to exit\n 1 to Engineer\n 2 to Task\n 3 to Dependency\n");
            int entityChoice = Convert.ToInt32(Console.ReadLine());
            switch (entityChoice)
            {
                case 0:
                    return;
                case (int)EntityType.ENGINEER:
                    engineerMenu();
                    break;
                case (int)EntityType.TASK:
                    taskMenu();
                    break;
                case (int)EntityType.DEPENDENCY:
                    dependencyMenu();
                    break;
            }
        }
    }
}