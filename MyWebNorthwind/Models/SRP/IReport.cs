namespace MyWebNorthwind.Models.SRP
{
    /// SRP Code Example 
    //Before
    /**
    //public interface  IReport
    //{
    //    void AddEntryAt(int index);
    //    void RemoveEntryAt(int index);
    //    void SaveToFile(string directoryPath, string fileName);
    //}
    */
    // After
    public interface IReport
    {
        void AddEntryAt(int index);
        void RemoveEntryAt(int index);
    }
    public interface IReportSaver
    {   
        void SaveToFile(string directoryPath, string fileName);
    }
}
