namespace SpecflowApiMayBatch.Modules
{
    public class CreatNewRequestUserTableModel
    {
        public string name { get; set; }
        public string job { get; set; }
    }

    public class CreatNewResponseUserModel
    {
        public string name { get; set; }
        public string job { get; set; }
        public string id { get; set; }
        public DateTime createdAt { get; set; }
    }
}
