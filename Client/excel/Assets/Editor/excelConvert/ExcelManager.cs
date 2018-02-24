﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace npoi
{
    class ExcelConfig
    {
        public static string XLSX_PATH = "/../../Table/";
        public static string PROTO_PATH = "/../../Proto/";
		public static string CMP_PROTO_PATH = "/../../orgTable/proto/";
		public static string TABLE_LIST_CS_PATH = "/Scripts/00Common/";
		public static string TXT_SAVE_PATH = "/Resources/Data/tmpTable/";
		public static string TXT_ASSET_PATH = "Assets/Resources/Data/Table/";
        public static string SHELL_CMD_PATH = "/../../shell_cmd/";
        public static string TABLE_SCRIPTS_PATH = "/Scripts/01TableScripts/";
    }

    enum FileExtensionType
    {
        FET_XLSX = 0,
        FET_PROTO,
    }

    class ExcelManager
    {
        static ExcelManager ms_handle = null;

        public static ExcelManager Instance()
        {
            if(null == ms_handle)
            {
                ms_handle = new ExcelManager();
            }
            return ms_handle;
        }

		public bool Convert(string applicationPath,string name,ExcelHelper.ConvertType eConvertType)
        {
            string purName = Path.GetFileNameWithoutExtension(name);
            var excelPath = CombinePath(applicationPath, purName, FileExtensionType.FET_XLSX);
            if(!string.IsNullOrEmpty(excelPath))
            {
                ExcelUnit unit = new ExcelUnit(excelPath);
                unit.Init();
				unit.LoadProtoBase ();
				if (unit.succeed) 
				{
					if (eConvertType == ExcelHelper.ConvertType.CT_PROTO) 
					{
						unit.CreateProto (Path.GetFullPath (applicationPath + ExcelConfig.PROTO_PATH));
					} 
					else 
					{
						unit.generateText (applicationPath);
					}
				}
                unit.Close();
                return unit.succeed;
            }
            return false;
        }

        string CombinePath(string applicationPath,string name, FileExtensionType eFileExtensionType)
        {
            switch(eFileExtensionType)
            {
                case FileExtensionType.FET_PROTO:
                    {
                        return Path.GetFullPath(applicationPath + ExcelConfig.PROTO_PATH + name + ".proto");
                    }
                case FileExtensionType.FET_XLSX:
                    {
                        return Path.GetFullPath(applicationPath + ExcelConfig.XLSX_PATH + name + ".xls");
                    }
            }
            return string.Empty;
        }
    }
}