using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Web.Hosting;

namespace Minor.ServiceBus.PfSLocatorService
{
    public class ServiceLocationXmlDatamapper : IServiceLocationDatamapper
    {
        private string _filePath;

        public ServiceLocationXmlDatamapper(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                _filePath = filePath;
            }
            else
            {
                throw new FilePathNotDefinedException("File path is not defined.");
            }
        }

        public string FindMetadataEndpointAddress(string name, string profile)
        {
            return GetMetadataEndPointAdress(name, profile);
        }

        public string FindMetadataEndpointAddress(string name, string profile, decimal? version)
        {
            return GetMetadataEndPointAdress(name, profile, version);
        }

        public string GetMetadataEndPointAdress(string name, string profile, decimal? version = null)
        {
            var data = LoadXmlFile<locationData>();
            var serviceLocationList = new List<string>();
            foreach (var servicelocation in data.serviceLocation)
            {
                if (version != null)
                {
                    if (servicelocation.name == name && 
                        servicelocation.profile == profile &&
                        servicelocation.version == version)
                    {
                        serviceLocationList.Add(servicelocation.metadataAddress);
                    }
                } else if (servicelocation.name == name && servicelocation.profile == profile)
                {
                    if (servicelocation.version != null)
                    {
                        throw new VersionedRecordFoundException("The location service found has a version, so specify the version");
                }
                    serviceLocationList.Add(servicelocation.metadataAddress);
                }
            }
            switch (serviceLocationList.Count())
                {
                case 0:
                    throw new NoRecordsFoundException("No location services found");
                case 1:
                    return serviceLocationList.First();
                default:
                    throw new MultipleRecordsFoundException("Multiple location services found instead of one");
            }
        }

        public T LoadXmlFile<T>()
        {
            string path = MakeAbsolutePath(_filePath);
            XmlSerializer serializer = new XmlSerializer(typeof(locationData));
            using (StreamReader reader = new StreamReader(path))
            {
                var data = serializer.Deserialize(reader);
                return (T)data;
            }
        }

        private static string MakeAbsolutePath(string relativePath)
        {
            string path = null;
            if(HostingEnvironment.IsHosted)
            {
                path = HostingEnvironment.MapPath(@"~\" + relativePath);
            }
            else
            {
                string executionFolder = new DirectoryInfo(Directory.GetCurrentDirectory()).Name;
                if (executionFolder == "Debug" || executionFolder == "Release")
                {
                    path = Directory.GetCurrentDirectory() + @"\..\..\" + relativePath;
                } else
                {
                    path = Directory.GetCurrentDirectory() + @"\" + relativePath;
                }
            }
            return path;
        }
    }
}
