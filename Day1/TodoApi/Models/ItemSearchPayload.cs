namespace TodoApi.Models
{
    public class ItemSearchPayload
    {
        public long Id {get; set;}
        public string? ItemNameTerm {get; set;}
        public string? AddressTerm {get; set;}
    }
}