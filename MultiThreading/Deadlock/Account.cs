using System;
using System.Threading;

namespace DeadlockDemos
{
    class Account
    {
        int m_Id;
        long m_Balance;

        public Account(int id, long balance)
        {
            m_Id = id;
            m_Balance = balance;
        }

        public int ID { get { return m_Id; } }
        public long Balance { get { return m_Balance; } }

        public void Deposit(long amount) { m_Balance += amount; }
        public void Withdraw(long amount) { m_Balance -= amount; }

        public override string ToString()
        {
            return ("account " + ID + " having balance " + Balance);
        }
    }

    class AccountManager
    {
        Account m_FromAccount;
        Account m_ToAccount;
        long m_lAmountToTransfer;

        public AccountManager(Account FromAccount, Account ToAccount, long AmountToTransfer)
        {
            m_FromAccount = FromAccount;
            m_ToAccount = ToAccount;
            m_lAmountToTransfer = AmountToTransfer;
        }

        public void Transfer_with_Deadlock()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " about to acquire lock on " + m_FromAccount.ToString());
            lock (m_FromAccount)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " locked " + m_FromAccount.ToString());
                Console.WriteLine(Thread.CurrentThread.Name + " about to sleep for 1 second");
                Thread.Sleep(1000);
                Console.WriteLine(Thread.CurrentThread.Name + " completed sleep of 1 second");

                Console.WriteLine(Thread.CurrentThread.Name + " about to acquire lock on " + m_ToAccount.ToString());
                lock (m_ToAccount)
                {
                    Console.WriteLine("This code is never executed");
                    m_FromAccount.Withdraw(m_lAmountToTransfer);
                    m_ToAccount.Deposit(m_lAmountToTransfer);
                }
            }
        }

        public void Transfer_without_Deadlock()
        {
            // soln1. Avoiding deadlock using smart ordering of locks
            Object lock1, lock2;
            if(m_FromAccount.ID < m_ToAccount.ID)
            {
                lock1 = m_FromAccount;
                lock2 = m_ToAccount;
            }
            else
            {
                lock1 = m_ToAccount;
                lock2 = m_FromAccount;
            }
            
            Console.WriteLine(Thread.CurrentThread.Name + " about to acquire lock on " + ((Account)lock1).ToString());
            lock (lock1)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " locked " + ((Account)lock1).ToString());
                Console.WriteLine(Thread.CurrentThread.Name + " about to sleep for 1 second");
                Thread.Sleep(1000);
                Console.WriteLine(Thread.CurrentThread.Name + " completed sleep of 1 second");

                Console.WriteLine(Thread.CurrentThread.Name + " about to acquire lock on " + ((Account)lock2).ToString());
                lock (lock2)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " locked " + ((Account)lock2).ToString());
                    m_FromAccount.Withdraw(m_lAmountToTransfer);
                    m_ToAccount.Deposit(m_lAmountToTransfer);
                    Console.WriteLine(Thread.CurrentThread.Name + " transfered " + m_lAmountToTransfer + " from account " + m_FromAccount.ID + 
                        " to account " + m_ToAccount.ID);
                    Console.WriteLine("Updated balance : " + m_FromAccount.ToString() + ", " + m_ToAccount.ToString());
                }
            }
        }
    }
}
