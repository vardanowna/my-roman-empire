namespace MyRomanEmpire.Models.ApiModels;

public class EditRequest
{
    public int Id { get; set; }
    public string TodoName { get; set; }

}

public class EditResponse
{
    public int Id { get; set; }
}