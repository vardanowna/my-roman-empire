namespace MyRomanEmpire.Models.ApiModels;

public class CreateRequest
{
    public string TodoName { get; set; }
}

public class CreateResponse
{
    public int Id { get; set; }
}