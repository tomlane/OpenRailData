using System;
using System.Xml.Linq;
using OpenRailData.Domain.DarwinReferenceData;
using System.Linq;

namespace OpenRailData.Darwin.ReferenceData
{
    public class XmlDarwinReferenceDataParser : IDarwinReferenceDataParser
    {
        public DarwinReferenceDataSet ParseDarwinReferenceDataSet(string rawData)
        {
            if (string.IsNullOrWhiteSpace(rawData))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(rawData));

            XNamespace referenceDataNamespace = "http://www.thalesgroup.com/rtti/XmlRefData/v3";

            var referenceDataDocument = XDocument.Parse(rawData);

            var locationData =
            (from location in referenceDataDocument.Root.Elements(referenceDataNamespace + "LocationRef")
             select new DarwinLocationReference
             {
                 CrsCode = (string)location.Attribute("crs") ?? string.Empty,
                 LocationName = (string)location.Attribute("locname") ?? string.Empty,
                 TiplocCode = (string)location.Attribute("tpl") ?? string.Empty,
                 Toc = (string)location.Attribute("toc") ?? string.Empty
             }).ToList();

            var tocData = (from toc in referenceDataDocument.Root.Elements(referenceDataNamespace + "TocRef")
                           select new DarwinTocReference
                           {
                               Toc = (string)toc.Attribute("toc") ?? string.Empty,
                               TocName = (string)toc.Attribute("tocname") ?? string.Empty,
                               Url = (string)toc.Attribute("url") ?? string.Empty
                           }).ToList();

            var lateRunningReasons =
            (from reason in
                referenceDataDocument.Root.Element(referenceDataNamespace + "LateRunningReasons").Descendants()
             select new DarwinLateRunningReason
             {
                 Code = (string)reason.Attribute("code") ?? string.Empty,
                 ReasonText = (string)reason.Attribute("reasontext") ?? string.Empty
             }).ToList();

            var cancellationReasons =
            (from reason in
                referenceDataDocument.Root.Element(referenceDataNamespace + "CancellationReasons").Descendants()
             select new DarwinCancellationReason
             {
                 Code = (string)reason.Attribute("code") ?? string.Empty,
                 ReasonText = (string)reason.Attribute("reasontext") ?? string.Empty
             }).ToList();

            var viaData = (from via in referenceDataDocument.Root.Descendants(referenceDataNamespace + "Via")
                           select new DarwinViaRecord
                           {
                               At = (string)via.Attribute("at") ?? string.Empty,
                               Destination = (string)via.Attribute("dest") ?? string.Empty,
                               FirstLocation = (string)via.Attribute("loc1") ?? string.Empty,
                               SecondLocation = (string)via.Attribute("loc2") ?? string.Empty,
                               ViaText = (string)via.Attribute("viatext") ?? string.Empty
                           }).ToList();

            var cisSources =
            (from cisSource in referenceDataDocument.Root.Descendants(referenceDataNamespace + "CISSource")
             select new DarwinCisSource
             {
                 Code = (string)cisSource.Attribute("code") ?? string.Empty,
                 Name = (string)cisSource.Attribute("name") ?? string.Empty
             }).ToList();

            return new DarwinReferenceDataSet
            {
                CisSources = cisSources,
                LocationData = locationData,
                LateRunningReasons = lateRunningReasons,
                CancellationReasons = cancellationReasons,
                TocData = tocData,
                ViaData = viaData
            };
        }
    }
}