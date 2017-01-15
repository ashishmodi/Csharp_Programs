using System;
using System.IO;

namespace BasicStuff
{
    class ExceptionHandling
    {
        public static void exceptionHandlingDemo()
        {
            StreamReader sr = null;
            try
            {                
                string path = "F:\\abc.txt.txt";
                sr = new StreamReader(path);
                Console.WriteLine(sr.ReadToEnd());
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("FileNotFoundException " + ex.Message + "\n" + ex.StackTrace + "\n" + ex.FileName);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception " + ex.GetType().Name);
            }
            finally
            {
                if(sr != null)
                    sr.Close();
            }
        }
    }

    public class InnerException
    {
        public static void innerExceptionDemo()
        {
            try
            {
                try
                {
                    Console.WriteLine("Enter 1st no ");
                    int firstNo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter 2nd no ");
                    int secondNo = Convert.ToInt32(Console.ReadLine());

                    int iResult = firstNo / secondNo;
                    Console.WriteLine("Result = {0}", iResult);
                }
                catch (Exception ex)
                {
                    string path = "F:\\abc.txt.txt";
                    if (File.Exists(path))
                    {
                        StreamWriter sw = new StreamWriter(path);
                        sw.WriteLine(ex.GetType().Name);
                        sw.WriteLine(ex.Message);
                        sw.Close();
                    }
                    else
                    {
                        throw new FileNotFoundException(path + " Is not present", ex);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Current excetion = {0}", exception.GetType().FullName);
                if(exception.InnerException != null)
                    Console.WriteLine("Inner excetion = {0}", exception.InnerException.GetType().FullName);
            }
        }
    }
}
