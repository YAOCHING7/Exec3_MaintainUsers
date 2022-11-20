using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSpan.Utility;

namespace Exec3_MaintainUsers
{
    internal class Program
    {
        static void  Main(string[] args)
        {
            string insertSql = @"INSERT into Users(Name, Account, Password, DateOfBirthd, Height) 
Values(@Name, @Account,@password,@DateOfBirthd,@Height) ";

            string updateSql = @"UPDATE Users SET Name=@Name, Account=@Account ,
Password=@password , DateOfBirthd=@DateOfBirthd , Height =@Height where id = @id";

            string deleteSql = @"DELETE FROM Users WHERE id = @id ";

            string selectSql = @"SELECT Id, Name, Account, Password, DateOfBirthd, Height FROM Users";

            SqlParameter[] parameters = new SqlParameterBuilder()
            //.AddNvarchar("Name",50,"123")
            //.AddNvarchar("Account", 50,"123")
            //.AddInt("Password", 123)
            .AddDateTime("DateOfBirthd", Convert.ToDateTime("2022/1/1"))
            //.AddInt("Height",123)
            //.AddInt("id",1)
            .Build();
            var dbHelper = new SqlDbHelper("default");
            //dbHelper.Update(updateSql, parameters);

            try
            {
                var parameters = new SqlParameterBuilder().AddInt("id", 0).Build();
                DataTable news = dbHelper.Select(selectSql, parameters);
                foreach (DataRow row in news.Rows)
                {
                    int id = row.Field<int>("Id");
                    string name = row.Field<string>("name");
                    Console.WriteLine($"Id={id}, Name={name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"連線失敗, 原因 :{ex.Message}");
            }
        }
        static void selectSql()
        {
            string selectSql = @"SELECT Id, Name, Account, Password, DateOfBirthd, Height FROM Users";

            SqlParameter[] parameters = new SqlParameterBuilder()
            //.AddNvarchar("Name",50,"123")
            //.AddNvarchar("Account", 50,"123")
            //.AddInt("Password", 123)
            .AddDateTime("DateOfBirthd", Convert.ToDateTime("2022/1/1"))
            //.AddInt("Height",123)
            //.AddInt("id",1)
            .Build();
            var dbHelper = new SqlDbHelper("default");
            //dbHelper.Update(updateSql, parameters);

            try
            {
                var parameters = new SqlParameterBuilder().AddInt("id", 0).Build();
                DataTable news = dbHelper.Select(selectSql, parameters);
                foreach (DataRow row in news.Rows)
                {
                    int id = row.Field<int>("Id");
                    string name = row.Field<string>("name");
                    Console.WriteLine($"Id={id}, Name={name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"連線失敗, 原因 :{ex.Message}");
            }
        }
    }
}
