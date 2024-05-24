using Dapper;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using XuguClient;

namespace DapperExtensions.Tests.IntegrationTests.Xugu
{
    public class XuguBaseFixture
    {
        protected IDatabase Db;

        [SetUp]
        public virtual void Setup()
        {
            SqlMapper.AddTypeHandler(new GuidTypeHandler());
            SqlMapper.RemoveTypeMap(typeof(Guid));
            SqlMapper.RemoveTypeMap(typeof(Guid?));

            var connection = new XGConnection("IP=127.0.0.1;DB=DAPPERTEST;User=SYSDBA;PWD=SYSDBA;Port=5138;AUTO_COMMIT=on;CHAR_SET=UTF8");

            var config = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new XuguDialect());

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