namespace SpecflowApiMayBatch.Support
{
    [Binding]
    public class dataTransformation
    {
        [StepArgumentTransformation]
        public TableModel TableData(Table table)
        {
            return table.CreateInstance<TableModel>();
        }

        [StepArgumentTransformation]
        public IEnumerable<TableModel> TableDataList(Table table)
        {
            return table.CreateSet<TableModel>().ToList();
        }

        [StepArgumentTransformation]
        public CreatNewRequestUserTableModel NewUser(Table table)
        {
            return table.CreateInstance<CreatNewRequestUserTableModel>();
        }
    }
}
