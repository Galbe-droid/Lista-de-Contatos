using Agenda_de_Contatos.Classe;
using Agenda_de_Contatos.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Repository
{
    internal class IContatosRepository
    {
        //caminho e nome do arquivo json para salvar
        private string _path = @"../../../SaveInfo/ContatosSalvos.json";
        //Salvar a lista no json 
        public void Save(List<Contato> lista)
        {
            using (StreamWriter file = File.CreateText(_path))
            {
                JsonSerializer serializer = new();
                serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.TypeNameHandling = TypeNameHandling.Auto;
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, lista);
                file.Close();
            }
        }
        //Checa para saber se existe ou não um arquivo para salvar, caso não tenha, será criado um 
        public void CrateFile()
        {
            if (!File.Exists(_path))
            {
                using var steam = File.Create(_path);
                steam.Close();
            }
        }
        //Carrega o json dentro de uma lista inicial e global quando o programa se abre
        public List<Contato> Loading()
        {
            string jsonString = File.ReadAllText(_path);
            List<Contato> loadingList = [];

            if(jsonString.Length != 0)
            {
                loadingList = JsonConvert.DeserializeObject<List<Contato>>(jsonString, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,
                })!;
            }

            return loadingList;
        }
    }
}
