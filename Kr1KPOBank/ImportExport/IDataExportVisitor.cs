namespace Kr1kpo.ImportExport
{
    public interface IDataExportVisitor
    {
        void Export(Domain.BankAccount account);
        void Export(Domain.Category category);
        void Export(Domain.Operation operation);
    }
}