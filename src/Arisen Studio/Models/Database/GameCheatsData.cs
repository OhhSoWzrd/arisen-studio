﻿using ArisenStudio.Database;
using ArisenStudio.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ArisenStudio.Models.Database
{
    public class GameCheatsDatasds
    {
        /// <summary>
        /// Get the mods from the database.
        /// </summary>
        public List<GameCheatsData> Games { get; set; } = [];

        /// <summary>
        /// Get all of the mods matching the specified filters.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="region"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public List<ArisenStudio.Database.GameCheatsData> GetGameCheatsItems(string game, string region, string version)
        {
            return Games.Where(x => (game.IsNullOrEmpty() ? x.Game.ContainsIgnoreCase(game) : x.Game.EqualsIgnoreCase(game))
                                    && x.Region.ContainsIgnoreCase(region)
                                    && x.Version.ContainsIgnoreCase(version)).ToList();
        }

        /// <summary>
        /// Get the <see cref="ArisenStudio.Database.GameCheatsData" /> matching the specified <see cref="ArisenStudio.Database.GameCheatsData.Id" />.
        /// </summary>
        /// <param name="game"> <see cref="ArisenStudio.Database.GameCheatsData.Game"/> </param>
        /// <param name="region"> <see cref="ArisenStudio.Database.GameCheatsData.Region" /> </param>
        /// <param name="version"> <see cref="ArisenStudio.Database.GameCheatsData.Version"/> </param>
        /// <returns> Mod details for the <see cref="ArisenStudio.Database.GameCheatsData.Region" /> and <see cref="ArisenStudio.Database.GameCheatsData.Game"/> </returns>
        public ArisenStudio.Database.GameCheatsData GetGameCheatById(string game, string region, string version)
        {
            return Games.FirstOrDefault(x => x.Region.Equals(region) && x.Game.Equals(game) && x.Version.Equals(version));
        }

        /// <summary>
        /// Get all the <see cref="ArisenStudio.Database.GameCheatsData" /> matching the specified <see cref="ArisenStudio.Database.GameCheatsData.Game" />.
        /// </summary>
        /// <returns> </returns>
        public List<ArisenStudio.Database.GameCheatsData> GetGameCheatsByCategoryId(string game)
        {
            return Games.Where(x => x.Game.EqualsIgnoreCase(game)).ToList();
        }

        /// <summary>
        /// Get all of the mods matching the specified filters.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="region"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public int GetTotalCheats()
        {
            HashSet<string> set = [];

            foreach (ArisenStudio.Database.GameCheatsData list in Games)
            {
                foreach (Cheats item in list.Cheats)
                {
                    _ = set.Add(item.Name);
                }
            }
            return set.Count;
        }
    }
}