using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Main
{
    public class SaveSystem
    {
        public Gender Gender { get; set; }
        public string HairColour { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public float MaxHP { get; set; }
        public float Atk { get; set; }
        public float Defense { get; set; }
        public int Gold { get; set; }

        public List<Item> Items { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public Armor CurrentArmor { get; set; }
        private static string savePath = "save.json";
       public SaveSystem() { }
        public static void Save(Player player)
        {
            if (player == null) { Console.WriteLine("Player data is null"); return; }
            SaveSystem data = new SaveSystem
            {
                Gender = player.Gender,
                HairColour = player.HairColour,
                Age = player.Age,
                Name = player.Name,
                MaxHP = player.MaxHP,
                Atk = player.Atk,
                Defense = player.Defense,
                Gold = player.Gold,
                Items = player.Items,
                CurrentWeapon = player.CurrentWeapon,
                CurrentArmor = player.CurrentArmor
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(data, options);

            File.WriteAllText(savePath, json);
            Console.WriteLine("Game saved!");
        }

        public static Player Load(Player fallbackPlayer)
        {
            if (!File.Exists(savePath))
            {
                Console.Write("No save file found...");
                return fallbackPlayer;
            }

            string json = File.ReadAllText(savePath);
            SaveSystem data = JsonSerializer.Deserialize<SaveSystem>(json);

            Player player = new Player(
                data.Gender,
                data.HairColour,
                data.Age,
                data.Name,
                data.MaxHP,
                data.Atk,
                data.Defense,
                data.Gold
            );

            foreach (var item in data.Items)
            {
                player.AddItem(item);
            }

            player.CurrentWeapon = data.CurrentWeapon;
            player.CurrentArmor = data.CurrentArmor;


            return player;
        }
    }
}
