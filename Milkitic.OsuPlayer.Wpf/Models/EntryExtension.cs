﻿using Milkitic.OsuPlayer.Wpf.Data;
using osu_database_reader.Components.Beatmaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milkitic.OsuPlayer.Wpf.Models
{
    public static class EntryExtension
    {
        public static MapIdentity GetIdentity(this BeatmapEntry entry) =>
            new MapIdentity(entry.FolderName, entry.Version);
        public static MapIdentity GetIdentity(this BeatmapViewModel viewModel) =>
            new MapIdentity(viewModel.FolderName, viewModel.Version);
        public static MapIdentity GetIdentity(this MapInfo viewModel) =>
            new MapIdentity(viewModel.FolderName, viewModel.Version);
    }
}
