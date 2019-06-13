using System;
namespace Lab12
{
    public class DidntExistElementException : ApplicationException
    {
        public DidntExistElementException() : base() { }
        public DidntExistElementException(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
}
