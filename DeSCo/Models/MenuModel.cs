namespace DeSCo.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int SortOrder { get; set; }

        public string Text { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool Selected { get; set; }

    }
}

