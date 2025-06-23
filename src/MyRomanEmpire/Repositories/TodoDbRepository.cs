using MyRomanEmpire.Models;

namespace MyRomanEmpire.Repositories;

public class TodoDbRepository : ITodoRepository
{
    public void Init()
    {
        throw new NotImplementedException();
    }

    public int Create(Todo todo)
    {
        throw new NotImplementedException();
    }

    public Todo? Get(int searchId)
    {
        throw new NotImplementedException();
    }

    public string Edit(int searchId, string newName)
    {
        throw new NotImplementedException();
    }

    public string Burn(int searchId)
    {
        throw new NotImplementedException();
    }

    public Todo? Search(string searchName)
    {
        throw new NotImplementedException();
    }

    public void Filter(State state)
    {
        throw new NotImplementedException();
    }

    public void ToInProgressFromNew(int searchId)
    {
        throw new NotImplementedException();
    }

    public void Done(int searchId)
    {
        throw new NotImplementedException();
    }

    public void ToInProgressFromDone(int searchId)
    {
        throw new NotImplementedException();
    }

    public void Reopen(int searchId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<Todo> All()
    {
        throw new NotImplementedException();
    }

    public Task Save()
    {
        throw new NotImplementedException();
    }

    public Task UpdateFile()
    {
        throw new NotImplementedException();
    }

    public Task Import(string path)
    {
        throw new NotImplementedException();
    }

    public Task Export()
    {
        throw new NotImplementedException();
    }
}