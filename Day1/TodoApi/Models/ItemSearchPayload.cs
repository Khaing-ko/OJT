namespace TodoApi.Models
{
    public class ItemSearchPayload
    {
        public int Id {get; set;}
        public string? ItemNameTerm {get; set;}
        public string? AddressTerm {get; set;}
    }
}