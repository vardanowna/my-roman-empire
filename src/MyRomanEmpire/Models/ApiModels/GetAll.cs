namespace MyRomanEmpire.Models.ApiModels;

public class GetAllResponse
{
    public List<GetAllItem> Items { get; set; }
}

public class GetAllItem
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название тудуса
    /// </summary>
    public string Name { get; set; }
}