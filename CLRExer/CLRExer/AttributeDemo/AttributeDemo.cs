using System;
using System.Collections.Generic;
using System.Text;

namespace CLRExer.AttributeDemo
{
    [Flags]
    internal enum Accounts
    {
        Savings = 0x0001,
        Checking = 0x0002,
        Brokerage = 0x0004
    }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class AccountsAttribute : Attribute
    {
        private Accounts m_accounts;

        public AccountsAttribute(Accounts accounts)
        {
            m_accounts = accounts;
        }

        public override Boolean Match(object obj)
        {

            //
            if (obj == null)
            {
                return false;
            }

            //如果对象属于不同的类型，肯定不匹配
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            //先将obj转型为相同的类型
            AccountsAttribute other = (AccountsAttribute) obj;

            //比较字段，判断是否有相同的值
            if ((other.m_accounts & m_accounts) != m_accounts)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Boolean Equals(object obj)
        {
            //
            if (obj == null)
            {
                return false;
            }

            //如果对象属于不同的类型，肯定不匹配
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            //先将obj转型为相同的类型
            AccountsAttribute other = (AccountsAttribute) obj;

            //比较字段，判断是否有相同的值
            if (other.m_accounts != m_accounts)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return (int) m_accounts;

        }


    }

    [Accounts(Accounts.Savings)]
    internal sealed class ChildAccount
    {
    }

    [Accounts(Accounts.Savings | Accounts.Brokerage | Accounts.Checking)]
    internal sealed class AdultAccount
    {
    }


    public class AttributeDemo
    {

        public void AttributeExcute()
        {
            CanWriteCheck(new ChildAccount());

            CanWriteCheck(new AdultAccount());

        }


        private static void CanWriteCheck(object obj)
        {
            //构造实例
            Attribute checking = new AccountsAttribute(Accounts.Checking);

            //构造应用于类型的特性实例
            Attribute validAccounts = Attribute.GetCustomAttribute(obj.GetType(), typeof(AccountsAttribute), false);


            if ((validAccounts != null) && checking.Match(validAccounts))
            {
                Console.WriteLine("{0} types can write checks.", obj.GetType());
            }
            else
            {
                Console.WriteLine("{0} types can not write checks.", obj.GetType());
            }
        }
    }

}
