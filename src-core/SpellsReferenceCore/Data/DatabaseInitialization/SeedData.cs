using SpellsReferenceCore.Data.DatabaseInitialization;
using SpellsReferenceCore.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SpellsReferenceCore.Data
{
    public static class SeedData
    {

        public static DatabaseModel ReadDatabaseModel(string fileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine(@"Data\DatabaseInitialization", fileName));
            if (File.Exists(filePath))
            {
                string jsonString;
                try
                {
                    jsonString = File.ReadAllText(filePath);
                }
                catch
                {
                    Console.Error.WriteLine($"Unable to read from {filePath}");
                    return null;
                }
                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var jsonObject = JsonSerializer.Deserialize<DatabaseModel>(jsonString, options);
                return jsonObject;
                //var spells = jsonObject.Spells;
                //var spellbook = jsonObject.Spellbooks;
                //var spellbookSpells = jsonObject.SpellbookSpells;
            }
            else
            {
                Console.Error.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");
                Console.Error.WriteLine($"Attempted to read {Directory.GetCurrentDirectory()}\\{filePath}");
                Console.Error.WriteLine($"File does not exist");
                return null;
            }
        }
    }
}
