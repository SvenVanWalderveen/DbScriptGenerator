using DbScriptGeneratorDll.Enums;
using DbScriptGeneratorDll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbScriptGeneratorDll.Factories.Script
{
    abstract class CommandGeneratorFactory
    {
        public abstract Dictionary<List<Type>, string> DataTypeMapping { get; }


        public abstract string GenerateCreateTableScript(CommandGeneratorParameters parameters);
        public abstract string GenerateDropTableScript(CommandGeneratorParameters parameters);
        public abstract string GenerateTableAddColumnScript(CommandGeneratorParameters parameters);
        public abstract string GenerateTableRemoveColumnScript(CommandGeneratorParameters parameters);
        public abstract string GenerateInsertRecordScript(CommandGeneratorParameters parameters);
        public abstract string GenerateUpdateRecordScript(CommandGeneratorParameters parameters);
        public abstract string GenerateDeleteRecordScript(CommandGeneratorParameters parameters);

        public abstract ResponseEnvelopeWithDataResult<GeneratedScriptModel> CreateScriptModel(DatabaseOperation databaseOperation, Type objectType);


    }
}
