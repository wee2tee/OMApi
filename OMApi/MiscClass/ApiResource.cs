using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace OMApi.MiscClass
{
    public class ApiResource
    {
        public static string GetValueOf(string app_data_key)
        {
            string appDataPath = HttpContext.Current.Server.MapPath("~/App_Data");
            string appDataFile = Path.Combine(appDataPath, "API_CONFIG.xml");
            //XElement xelem = XElement.Load(appDataFile);
            //var retValue = (string)((from data in xelem.Elements(app_data_key) select data).First().Value);

            XDocument xdoc = XDocument.Load(appDataFile);
            var targetElem = xdoc.Descendants(XName.Get(app_data_key)).First();


            if (targetElem != null)
            {
                return (string)targetElem.Value;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetAttrOf(string app_data_key, string attr_name)
        {
            string appDataPath = HttpContext.Current.Server.MapPath("~/App_Data");
            string appDataFile = Path.Combine(appDataPath, "API_CONFIG.xml");
            //XElement xelem = XElement.Load(appDataFile);
            //var retValue = (string)((from data in xelem.Elements(app_data_key) select data).First().Value);

            XDocument xdoc = XDocument.Load(appDataFile);
            var targetElem = xdoc.Descendants(XName.Get(app_data_key)).First();


            if (targetElem != null)
            {
                return (string)targetElem.Attribute(attr_name);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
