﻿namespace MyRomanEmpire.Models;

public class Todo
{
    public int Id { get; set; }
    public string Name { get; set; }

    public State Status { get; set; }

    // public void Get()
    // {
    //     
    // }

    public Todo(int id, string name)
    {
        Id = id;
        Name = name;
        Status = State.New;
    }
    
    public Todo(string name)
    {
        Id = 0;
        Name = name;
        Status = State.New;
    }

    public override string ToString()
    {
        return $"{Id} - {Name} - {Status}";
    }
}

public enum State
{
    New = 0,
    InProgress = 1,
    Completed = 2,
}