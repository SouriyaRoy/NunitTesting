using System;
using System.Runtime.Serialization;

namespace Day1
{
    [Serializable]
    public class InvalidCreditScore : Exception
    {
        public InvalidCreditScore()
        {
        }

        public InvalidCreditScore(string message) : base(message)
        {
        }

        public InvalidCreditScore(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCreditScore(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}