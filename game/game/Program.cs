using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace game
{
    class GetJsonFields
    {
        public string? TeamName { get; set; }
        public List<Unit>? UnitDiscriptions { get; set; }
        public List<int>? Units { get; set; }
        public void createJsonFile(GetJsonFields jsonString)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
            string json = JsonSerializer.Serialize(jsonString, options);
            File.WriteAllText("WhyNot.json", json);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var user = Army.CreateUserArmy();
            var computer = Army.CreateRandomArmy();
            var winner = new War(user, computer).Winner;

            List<int> id = new();
            for (int i = 0; i < winner.InitialList.Count; i++)
            {
                id.Add(winner.InitialList[i].UnitDescriptionId);
            }

            var jsonFile = new GetJsonFields
            {
                TeamName = "WhyNot?",
                UnitDiscriptions = winner.InitialList,
                Units = id
            };
            jsonFile.createJsonFile(jsonFile);
        }
    }
}