using System;
namespace Lab13
{
    public class IndexErrorException : ApplicationException
    {
        public override string ToString()
        {
            return Message;
        }
        public IndexErrorException() : base() { }
        public IndexErrorException(string str) : base (str) { }
    }
}
