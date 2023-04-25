using Dapper;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Dm;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace DapperExtensions.Tests.IntegrationTests.Dameng
{
    public class DamengBaseFixture
    {
        protected IDatabase Db;

        [SetUp]
        public virtual void Setup()
        {
            SqlMapper.AddTypeHandler(new GuidTypeHandler());
            SqlMapper.RemoveTypeMap(typeof(Guid));
            SqlMapper.RemoveTypeMap(typeof(Guid?));

            var connection = new DmConnection("Server=localhost;UserId=DAPPERTEST;PWD=123456;Database=DAPPERTEST");
            connection.Open();

            var config = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new DamengDialect());
            var sqlGenerator = new SqlGeneratorImpl(config);
            Db = new Database(connection, sqlGenerator);

            var files = new List<string>
                                {
                                    ReadScriptFile("DropFooTable"),
                                    ReadScriptFile("DropMultikeyTable"),
                                    ReadScriptFile("DropPersonTable"),
                                    ReadScriptFile("DropCarTable"),
                                    ReadScriptFile("DropAnimalTable"),
                                    ReadScriptFile("CreateFooTable"),
                                    ReadScriptFile("CreateMultikeyTable"),
                                    ReadScriptFile("CreatePersonTable"),
                                    ReadScriptFile("CreateCarTable"),
                                    ReadScriptFile("CreateAnimalTable")
                                };

            foreach (var setupFile in files)
            {
                connection.Execute(setupFile);
            }
        }

        public string ReadScriptFile(string name)
        {
            string fileName = GetType().Namespace + ".Sql." + name + ".sql";
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName))
            using (StreamReader sr = new StreamReader(s))
            {
                return sr.ReadToEnd();
            }
        }
    }

    public class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
    {
        public override void SetValue(IDbDataParameter parameter, Guid guid)
        {
            parameter.Value = guid.ToString();
        }
        public override Guid Parse(object value)
        {
            return new Guid((string)value);
        }
    }
}