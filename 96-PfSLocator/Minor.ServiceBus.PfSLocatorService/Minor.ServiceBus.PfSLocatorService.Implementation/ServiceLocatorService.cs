using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Minor.ServiceBus.PfSLocatorService.Implementation
{
    public class ServiceLocatorService : IServiceLocatorService
    {
        private IServiceLocationDatamapper _datamapper;

        public ServiceLocatorService()
        {
            _datamapper = new ServiceLocationXmlDatamapper(@"App_data\locationData.xml");
        }

        public ServiceLocatorService(IServiceLocationDatamapper datamapper)
        {
            _datamapper = datamapper;
        }

        public string FindMetadataEndpointAddress(ServiceLocation serviceLocation)
        {
            FunctionalErrorList errorList = new FunctionalErrorList();
            if (serviceLocation != null)
            {
                if (String.IsNullOrEmpty(serviceLocation.Name) || String.IsNullOrEmpty(serviceLocation.Profile))
                {
                    errorList.Add(new FunctionalErrorDetail
                    {
                        Message = "Name or Profile is null"
                    });
                    throw new FaultException<FunctionalErrorList>(errorList);
                }


                try
                {
                    if (serviceLocation.Version == null)
                    {
                        return _datamapper.FindMetadataEndpointAddress(serviceLocation.Name, serviceLocation.Profile);
                    }
                    return _datamapper.FindMetadataEndpointAddress(serviceLocation.Name, serviceLocation.Profile, serviceLocation.Version);
                }
                catch (MultipleRecordsFoundException ex)
                {
                    errorList.Add(new FunctionalErrorDetail
                    {
                        Message = ex.Message,
                        Data = ex.Data
                    });
                }
                catch (NoRecordsFoundException ex)
                {
                    errorList.Add(new FunctionalErrorDetail
                    {
                        Message = ex.Message,
                        Data = ex.Data
                    });
                }
                catch (VersionedRecordFoundException ex)
                {
                    errorList.Add(new FunctionalErrorDetail
                    {
                        Message = ex.Message,
                        Data = ex.Data
                    });
                }
            }

            if (errorList.HasErrors)
            {
                throw new FaultException<FunctionalErrorList>(errorList);
            }

            return null;
        }
    }
}
