﻿namespace MyRomanEmpire.Models.ApiModels;

public class GetRequest
{
    public int Id { get; set; }

}

public class GetResponse
{
    public Todo Todo { get; set; }

}

public class GetResponseError : GetResponse
{
    public string acab = "FCK THE POLICE";

}