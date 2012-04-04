using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Sims3.CSHost;
using System.Windows.Forms;

namespace ChaosTools.GetShaders
{
    [XmlRoot("ShaderLibrary")]
    public class ShaderDbXml
    {
        public ShaderDbXml()
        {
            Shaders = new List<ShaderXml>();
        }
        [XmlArray("Shaders")]
        [XmlArrayItem("Shader")]
        public List<ShaderXml> Shaders;
    }

    public class ShaderXml
    {
        public ShaderXml()
        {
            Params = new List<ShaderParamXml>();
        }
        public ShaderXml(string name, string uiname)
        {
            Name = name;
            UIName = uiname;
            Params = new List<ShaderParamXml>();
            UIDescription = null;
        }
        public ShaderXml(string name, string uiname, string uidesc)
        {
            Name = name;
            UIName = uiname;
            Params = new List<ShaderParamXml>();
            UIDescription = uidesc;
        }
        [XmlAttribute]
        public string Name;
        [XmlAttribute]
        public string UIName;
        [XmlArray("Parameters")]
        [XmlArrayItem("Parameter")]
        public List<ShaderParamXml> Params;
        [XmlAttribute]
        public string UIDescription;
    }

    public class ShaderParamXml
    {
        [XmlAttribute]
        public String Name;
        [XmlAttribute]
        public String DefaultValue;
        [XmlAttribute]
        public Sims3.ShaderParamType Type;
        [XmlAttribute]
        public string Category;
        [XmlAttribute]
        public String Description;
        [XmlAttribute]
        public UInt32 EditorHash;
        [XmlAttribute]
        public Single MinValue;
        [XmlAttribute]
        public Single MaxValue;
        [XmlAttribute]
        public float StepValue;
    }

    public class ShaderEngine : ChaosTools.Sims3Engine.BasicEngine
    {
        protected override int Execute(string[] args)
        {
            ShaderLibrary sl = new ShaderLibrary();
            sl.Init();
            ShaderDbXml xmlob = new ShaderDbXml();
            foreach (ShaderSet shaderSet in sl.ShaderSets)
            {
                ShaderXml shaderXml = new ShaderXml(shaderSet.Name, shaderSet.UIName);
                foreach (ShaderSetParameter shaderSetParameter in shaderSet.Parameters)
                {
                    ShaderParamXml shaderParamXml = new ShaderParamXml();
                    shaderParamXml.DefaultValue = shaderSetParameter.DefaultValue != null ?
                        shaderSetParameter.DefaultValue.ToString() : null;
                    shaderParamXml.Category = shaderSetParameter.Category;
                    shaderParamXml.Description = shaderSetParameter.Description;
                    shaderParamXml.EditorHash = shaderSetParameter.EditorHash;
                    shaderParamXml.MaxValue = shaderSetParameter.MaxValue;
                    shaderParamXml.MinValue = shaderSetParameter.MinValue;
                    shaderParamXml.StepValue = shaderSetParameter.StepValue;
                    shaderParamXml.Name = shaderSetParameter.Name;
                    shaderParamXml.Type = shaderSetParameter.Type;
                    shaderXml.Params.Add(shaderParamXml);
                }
                xmlob.Shaders.Add(shaderXml);
            }
            XmlSerializer xs = new XmlSerializer(typeof(ShaderDbXml));
            string outputPath = Path.Combine(this.OverrideUserDataPath, "Shaders.xml");
            using (FileStream stream = File.Create(outputPath))
            {
                try
                {
                    xs.Serialize(stream, xmlob);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return 0;
        }
    }

    static class Program
    {
        static int Main(string[] args)
        {
            ShaderEngine engine = new ShaderEngine();
            return engine.Run(args);

            /*string overrideUserDataPath = null;
            string installedGameUserDataDir = App.GetInstalledGameUserDataDir();
            SharedInitialization.AddGimexSupport();
            Panel panel1 = new Panel();
            if (!string.IsNullOrEmpty(installedGameUserDataDir))
            {
                string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                overrideUserDataPath = Path.Combine(folderPath, installedGameUserDataDir);
            }
            if (!App.InitApp("", "", panel1.Width, panel1.Height, IntPtr.Zero, 0, panel1.Handle, true, null, overrideUserDataPath))
            {
                throw new Exception("Failed to initialize game engine");
            }

            App.StartProcessMessages();
            ShaderLibrary sl = new ShaderLibrary();
            sl.Init();
            ShaderDbXml xmlob = new ShaderDbXml();
            foreach (ShaderSet shaderSet in sl.ShaderSets)
            {
                ShaderXml shaderXml = new ShaderXml(shaderSet.Name, shaderSet.UIName);
                foreach (ShaderSetParameter shaderSetParameter in shaderSet.Parameters)
                {
                    ShaderParamXml shaderParamXml = new ShaderParamXml();
                    shaderParamXml.DefaultValue = shaderSetParameter.DefaultValue != null ? 
                        shaderSetParameter.DefaultValue.ToString() : null;
                    shaderParamXml.Category = shaderSetParameter.Category;
                    shaderParamXml.Description = shaderSetParameter.Description;
                    shaderParamXml.EditorHash = shaderSetParameter.EditorHash;
                    shaderParamXml.MaxValue = shaderSetParameter.MaxValue;
                    shaderParamXml.MinValue = shaderSetParameter.MinValue;
                    shaderParamXml.StepValue = shaderSetParameter.StepValue;
                    shaderParamXml.Name = shaderSetParameter.Name;
                    shaderParamXml.Type = shaderSetParameter.Type;
                    shaderXml.Params.Add(shaderParamXml);
                }
                xmlob.Shaders.Add(shaderXml);
            }
            XmlSerializer xs = new XmlSerializer(typeof(ShaderDbXml));
            using (FileStream stream = File.Create("Shaders.xml"))
            {
                try
                {
                    xs.Serialize(stream, xmlob);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            App.Shutdown();/**/
        }
    }
}
