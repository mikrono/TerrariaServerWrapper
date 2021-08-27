using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TerrariaServerWrapper.Config
{
    public abstract class TemplateConfig<T> : IConfig where T : TemplateConfig<T>, new()
    {
        [JsonIgnore]
        public abstract string ConfigName { get; set; }

        public string Convert()
            => JsonConvert.SerializeObject(this, Formatting.Indented);

        public void Save()
        {
            string file = Path.Combine(EnvVar.AbsolutePath, ConfigName);
            File.WriteAllText(file, Convert());
        }

        public bool Exists()
        {
            string file = Path.Combine(EnvVar.AbsolutePath, ConfigName);

            return File.Exists(file);
        }
        public virtual IConfig GetConfig()
        {
            string file = Path.Combine(EnvVar.AbsolutePath, ConfigName);
            T config;

            if (File.Exists(file))
            {
                config = GetConfig(file);
            }
            else
            {
                config = CreateConfig(file);
            }

            return config;
        }

        private T GetConfig(string file)
        {
            var config = JsonConvert.DeserializeObject<T>(File.ReadAllText(file));

            return config;
        }
        public static T LoadConfig()
        {
            return new T().GetConfig() as T;
        }

        private T CreateConfig(string file)
        {
            if (!Directory.Exists(Path.GetDirectoryName(file)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(file));
            }

            Save();

            return this as T;
        }

    }
    public interface IConfig
    {
        string ConfigName { get; set; }
        string Convert();
        void Save();
        bool Exists();
        IConfig GetConfig();

    }
}
