namespace WordCounter.Services.Printer
{
    /// <summary>
    /// Contract of printer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IPrinter<T>
    {
        public void Print();
    }
}
