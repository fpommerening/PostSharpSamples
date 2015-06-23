using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;
using PostSharp.Aspects;

namespace FP.Spartakiade2015.WebservicePersistence.Webservice
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Assembly)]
    
    public class PersistWebserviceCallAspect : OnMethodBoundaryAspect 
    {

        public override bool CompileTimeValidate(MethodBase method)
        {
            if (method == null || method.ReflectedType == null)
            {
                return false;
            }
            foreach (var interfaceType in method.ReflectedType.GetInterfaces())
            {
                var methodInInterface = interfaceType.GetMethod(method.Name);
                if (methodInInterface != null && methodInInterface.GetCustomAttributes(typeof (WebMethodAttribute)).Any())
                {
                    return true;
                }
            }
            return false;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            base.OnEntry(args);
            var sessionGuid = Guid.NewGuid();
            args.MethodExecutionTag = sessionGuid;
            SaveToFile(string.Format("{0}_Request.xml", sessionGuid.ToString("N")), args.Arguments.First());
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var sessionGuid = (Guid) args.MethodExecutionTag;
            if (args.Exception != null)
            {
                SaveToFile(string.Format("{0}_Response.xml", sessionGuid.ToString("N")), args.Exception);    
            }
            else
            {
                SaveToFile(string.Format("{0}_Response.xml", sessionGuid.ToString("N")), args.ReturnValue);    
            }
            base.OnExit(args);
        }

        private void SaveToFile(string fileName, object o)
        {
            try
            {
                string savePath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath,
                    "ServiceLog", fileName);
                if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                }
                var exception = o as Exception;
                var filecontent = exception != null ? exception.ToString() : Serialize(o);
                File.WriteAllText(savePath, filecontent);
            }
            catch
            {
            }
        }

        private string Serialize(object o)
        {
            Type valueType = o.GetType();
            XmlWriterSettings settings = new XmlWriterSettings { NewLineHandling = NewLineHandling.Entitize };
            StringWriter sWriter = new StringWriter();
            XmlSerializer ser = new XmlSerializer(valueType);
            using (XmlWriter writer = XmlWriter.Create(sWriter, settings))
            {
                ser.Serialize(writer, o);
            }
            return sWriter.ToString();
        }
    }
}