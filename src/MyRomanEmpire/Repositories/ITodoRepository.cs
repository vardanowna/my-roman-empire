using MyRomanEmpire.Models;

namespace MyRomanEmpire.Repositories;

public interface ITodoRepository
{
    public void Init();

    public int Create(Todo todo);

    public Todo? Get(int searchId);

    public string Edit(int searchId, string newName);

    public string Burn(int searchId);

    public Todo? Search(string searchName);

    public void Filter(State state);

    public void ToInProgressFromNew(int searchId);

    public void Done(int searchId);

    public void ToInProgressFromDone(int searchId);

    public void Reopen(int searchId);

    public IReadOnlyCollection<Todo> All();

    public Task Save();

    public Task UpdateFile();

    public Task Import(string path);

    public Task Export();
}