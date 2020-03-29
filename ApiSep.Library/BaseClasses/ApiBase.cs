using System;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using ApiSep.Library.Extensions;
using ApiSep.Library.Helpers;

namespace ApiSep.Library.BaseClasses
{
    [Serializable]
    [DataContract]
    public class ApiBase 
    {
        [DataMember]
        public string ApiPath { get; set; }
        [DataMember]
        public string VirtualApiPath { get; set; }
        [DataMember] public string ApiContentPath { get; set; }
        [DataMember] public string ApiLogPath { get; set; }
        [DataMember] public string ApiItemPath { get; set; }
        [DataMember] public string VirtualItemPath { get; set; }

        private string NetworkLocation { get; } = ConfigurationManager.AppSettings["NetworkLocation"];

        public ApiBase(string virtualDirectory)
        {
            ApiPath = GetApiPath(virtualDirectory);
            ApiContentPath = GetContentPath();
            ApiLogPath = GetLogsPath();
            ApiItemPath = ApiContentPath;
            VirtualItemPath = MapPathReverse();
        }

        private string GetApiPath(string virtualDirectory)
        {
            return DirectoryHelper.CreateDirectory(Path.Combine(NetworkLocation, virtualDirectory));
        }

        private string GetContentPath()
        {
            return DirectoryHelper.CreateDirectory(Path.Combine(ApiPath, "Content"));
        }

        private string GetLogsPath()
        {
            return DirectoryHelper.CreateDirectory(Path.Combine(ApiPath, "Logs"));
        }

        private string GetItemPath(string path)
        {
            return DirectoryHelper.CreateDirectory(Path.Combine(ApiContentPath, path));
        }



        public string MapPathReverse()
        {
            var path = ApiItemPath.Replace(NetworkLocation, "~/");
            if (path.Contains(@"\"))
            {
                path = path.Replace(@"\", "/");
            }

            return path;
        }

    }
}
