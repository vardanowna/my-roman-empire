namespace MyRomanEmpire.Repositories;

public class TodoRepositoryFactory
{
    public static ITodoRepository GetRepo(DayOfWeek myWishes)
    {
        return myWishes switch
        {
            DayOfWeek.Monday => new TodoRepository(),
            DayOfWeek.Tuesday => new TodoDbRepository(),
            _ => throw new ArgumentOutOfRangeException(nameof(myWishes), myWishes, null)
        };
    }
}