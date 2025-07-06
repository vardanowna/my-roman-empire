namespace MyRomanEmpire.Models.ApiModels;

public class GetAllResponse
{
    public List<GetAllItem> Items { get; set; }

}

public class GetAllItem
{
    public int Id { get; set; }
    public string Name { get; set; }

}