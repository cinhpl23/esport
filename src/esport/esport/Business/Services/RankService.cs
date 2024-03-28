using esport.Business.Entites;
using RankFinder.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace esport.Business.Services
{
    internal class RankService
    {
        public async Task<List<Entites.Rank>> GetRanks()
        {
            List<Entites.Rank> rankList = null;
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");
                using var reader = new StreamReader(stream);
                var contents = await reader.ReadToEndAsync();
                rankList = JsonSerializer.Deserialize<List<Entites.Rank>>(contents);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite lors de la récupération des rangs : {ex.Message}");
            }
            return rankList;
        }

        public async Task AddRank(Entites.Rank newRank)
        {
            try
            {
                List<Entites.Rank> rankList = await GetRanks();
                if (rankList == null)
                {
                    rankList = new List<Entites.Rank>();
                }
                rankList.Add(newRank);

                var json = JsonSerializer.Serialize(rankList);
                using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");
                using var writer = new StreamWriter(stream);
                await writer.WriteAsync(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite lors de l'ajout du rang : {ex.Message}");
            }
        }


    }
}
