using System;
using System.Windows.Forms;
using System.Threading;

namespace ThreadingDemos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLongTask_Click(object sender, EventArgs e)
        {
            btnLongTask.Enabled = false;
            btnPrintNumbers.Enabled = false;

            Thread workerThread = new Thread(DoWait);
            // Another way of initializing above Thread
            // Any thread you will need an explicitly defined entry point i.e. pointer to a function where they should begin execution.
            // Hence thread will always need delegate.
            Thread workerThread1 = new Thread(delegate () { DoWait(); });
            Thread workerThread2 = new Thread(new ThreadStart(DoWait));
            Thread workerThread3 = new Thread(() => DoWait());

            workerThread.Start();

            btnLongTask.Enabled = true;
            btnPrintNumbers.Enabled = true;
        }

        public void DoWait()
        {
            Thread.Sleep(5000);
        }

        private void btnPrintNumbers_Click(object sender, EventArgs e)
        {
            lstNumbers.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                lstNumbers.Items.Add(i.ToString());
            }
        }

        private void btnParamThread_Click(object sender, EventArgs e)
        {
            Number n = new Number();
            ParameterizedThreadStart param = new ParameterizedThreadStart(n.PrintRange);
            Thread t = new Thread(param);
            // The above 2 lines can be clubbed to,
            // Thread t = new Thread(n.PrintRange);
            // Using ParameterizedThreadStart delegate is not type safe as it is expecting object as a parameter
            t.Start(6);

            // To pass a data to the thread fn in a type safe manner, encapsulate a thread function and the data it needs in a
            // helper class and use the ThreadStart delegate to invoke that fn.
            TypesafeNumber tn = new TypesafeNumber(8);
            Thread t1 = new Thread(tn.PrintRange);
            t1.Start();
        }

        private void btnThreadCallback_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(txtEnterNo.Text);

            CheckPrimeCallback callback = new CheckPrimeCallback(PrintIsPrimeMessageBox);

            PrimeNoCallbackDemo primeCallbackDemo = new PrimeNoCallbackDemo(no, callback);

            Thread t = new Thread(primeCallbackDemo.ComputePrimeCheckOperation);
            t.Start();
            t.Join(15000);      // Waits for 15 sec before showing below message
            MessageBox.Show("Event finished");
        }

        private void PrintIsPrimeMessageBox(bool bIsPrime)
        {            
            if (bIsPrime)
                MessageBox.Show("No is Prime");
            else
                MessageBox.Show("No is Not Prime");
        }
    }

    public delegate void CheckPrimeCallback(bool bIsPrimeNo);

    class PrimeNoCallbackDemo
    {
        int m_iNumber = 0;
        CheckPrimeCallback m_delCheckPrimeCallback;

        public PrimeNoCallbackDemo(int iNumber, CheckPrimeCallback callback)
        {
            m_iNumber = iNumber;
            m_delCheckPrimeCallback = callback;
        }

        public void ComputePrimeCheckOperation()
        {
            bool bIsPrime = true;
            for (int i = 2; i <= m_iNumber/2; i++)
            {
                if(m_iNumber % i == 0)
                {
                    bIsPrime = false;
                    break;
                }
            }

            if (m_delCheckPrimeCallback != null)
                m_delCheckPrimeCallback(bIsPrime);
        }

    }

    class Number : Form1
    {
        public void PrintRange(object endNo)
        {            
            int no;
            if (int.TryParse(endNo.ToString(), out no))
            {                
                lstNumbers.Items.Clear();
                for (int i = 1; i < no; i++)
                {
                    lstNumbers.Items.Add(i.ToString());
                }
                // TODO list is not displaying data..
            }
        }
    }

    class TypesafeNumber
    {
        int m_count;
        public TypesafeNumber(int count) { m_count = count; }
        public void PrintRange()
        {
            string sMessage = "";
            for (int i = 1; i < m_count; i++)
                sMessage += i.ToString();
            MessageBox.Show(sMessage);
        }
    }
}
