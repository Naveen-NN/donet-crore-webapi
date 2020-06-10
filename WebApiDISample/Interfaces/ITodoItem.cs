namespace WebApiDISample.Interfaces
{
    public interface ITodoItem
    {
        int Id {get;set;}
        string Description {get;set;}

        bool IsComplete {get;set;}
    }
}