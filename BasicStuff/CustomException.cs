using System;
using System.Runtime.Serialization;

namespace BasicStuff
{
    public class CustomExceptionDemo
    {
        public static void customExceptionTest()
        {
            try
            {
                throw new UserAlreadyLoggedInException("2 Sessions not allowed");
            }
            catch(UserAlreadyLoggedInException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    [Serializable] //To move object from one application domain to another
    public class UserAlreadyLoggedInException : Exception
    {
        public UserAlreadyLoggedInException() : base()
        {
            //Default implementation
        }
        public UserAlreadyLoggedInException(string msg) : base(msg)
        {

        }
        public UserAlreadyLoggedInException(string msg, Exception innerException) : base(msg, innerException)
        {

        }
        public UserAlreadyLoggedInException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
