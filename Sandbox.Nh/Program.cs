// See https://aka.ms/new-console-template for more information

using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Dialect;using Sandbox.Nh;

NHibernateProfiler.Initialize();

const string connectionString = "User ID=sys;Password=123;Host=127.0.0.1;Port=5432;Database=sandbox_db";

using var sessionFactory =
    Fluently.Configure()
        .Database(PostgreSQLConfiguration.Standard.Dialect<PostgreSQLDialect>().ConnectionString(connectionString))
        .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.Load("Sandbox.Nh")))
        .BuildSessionFactory();

using var nhSession = sessionFactory.OpenSession();
using var dbTransaction = nhSession.BeginTransaction();

// var user = new User
// {
//     Name = "Петя",
//     Surname = "Петров",
//     MiddleName = "Петрович",
// };
//
// user.AddAccount("KGS");
//
// nhSession.Save(user);

//var user = nhSession.Get<User>(4L);

var user = nhSession.Query<User>().First(x => x.Name == "Петя");

//user.RemoveAccount("KGS");

//nhSession.Save(user);

Console.WriteLine(user.Id);
Console.WriteLine(user.Name);
Console.WriteLine(user.MiddleName);
Console.WriteLine(user.Accounts.Any(x => x.Currency == "KZT"));

dbTransaction.Commit();

Console.WriteLine("Press Enter to exit...");
Console.ReadLine();
