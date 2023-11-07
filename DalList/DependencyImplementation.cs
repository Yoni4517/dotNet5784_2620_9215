﻿
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class DependencyImplementation : IDependency
{
    public int Create(Dependency item)
    {
        int newId = DataSource.Config.NextDependId;
        Dependency newDependency = new Dependency(item.DependentTask, item.DependsOnTask, newId);
        DataSource.Dependencies.Add(newDependency);
        return newId;
    }

    public void Delete(int id)
    {
        Dependency obj = DataSource.Dependencies.Find(curDep => curDep.Id == id);
        if (obj == null)
            throw new Exception($"An object of type Dependency with ID {id} does not exist");
        DataSource.Dependencies.Remove(obj);
    }

    public Dependency? Read(int id)
    {
        return DataSource.Dependencies.Find(curTask => curTask.Id == id);
    }

    public List<Dependency> ReadAll()
    {
        return new List<Dependency>(DataSource.Dependencies);
    }

    public void Update(Dependency item)
    {
        Dependency obj = DataSource.Dependencies.Find(curDep => curDep.Id == item.Id);
        if (obj == null)
            throw new Exception($"An object of type Dependency with ID {item.Id} does not exist");
        DataSource.Dependencies.Remove(obj);
        DataSource.Dependencies.Add(item);
    }
}