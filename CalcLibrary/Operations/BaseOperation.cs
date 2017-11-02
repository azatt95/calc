namespace CalcLibrary.Operations
{
    public abstract class BaseOperation : IOperation
    {
        // заполняется в наследнике
        public abstract string Name { get; }

        // заполняется в наследнике
        public abstract double Execute(double[] args);

        // может быть изменено в наследнике
        public virtual int MinArgsCount => 1;
    }
}
