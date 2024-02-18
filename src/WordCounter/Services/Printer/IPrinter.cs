namespace WordCounter.Services.Printer
{
    /// <summary>
    /// Contract of printer
    /// </summary>
    internal interface IPrinter<T>
    {
        public void Print();
    }
}
