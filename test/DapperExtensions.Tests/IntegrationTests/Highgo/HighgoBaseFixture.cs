using Dapper;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Nhgdb;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace DapperExtensions.Tests.IntegrationTests.Highgo
{
    public class HighgoBaseFixture
    {
        protected IDatabase Db;

        [SetUp]
        public virtual void Setup()
        {
            SqlMapper.AddTypeHandler(new GuidTypeHandler());
            SqlMapper.RemoveTypeMap(typeof(Guid));
            SqlMapper.RemoveTypeMap(typeof(Guid?));

            AppContext.SetSwitch("Nhgdb.EnableLegacyTimestampBehavior", true);

            var connection = new NhgdbConnection("Server=127.0.0.1;Port=5866;User Id=sysdba;Password=Hello@1234;Database=dapperTest;");

            var config = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new HighgoDialect());

            var sqlGenerator = new SqlGeneratorImpl(config);
            Db = new Database(connection, sqlGenerator);

            var files = new List<string>
                                {
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
            using (Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName))
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