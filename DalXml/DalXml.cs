﻿
using DalApi;
using DO;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Xml.Linq;

namespace Dal;
sealed internal class DalXml : IDal
{
    public static IDal Instance { get; } = new DalXml();
    private DalXml() { }
    public IEngineer Engineer => new EngineerImplementation();

    public ITask Task => new TaskImplementation();

    public IDependency Dependency => new DependencyImplementation();

    public DateTime StartProjectDate { get; set; }
    public DateTime EndProjectDate { get; set;}

    public void Reset()
    {
        Engineer.Reset();
        Task.Reset();
        Dependency.Reset();
    }
}
