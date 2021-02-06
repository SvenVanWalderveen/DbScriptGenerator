using System;
using System.Collections.Generic;
using System.Text;

namespace DbScriptGeneratorDll.Enums
{
    public enum DatabaseOperation
    {
        CreateTable = 0,
        UpdateTable = 1,
        DropTable = 2,
        InsertRecord = 3,
        UpdateRecord = 4,
        DeleteRecord = 5
    }
}
