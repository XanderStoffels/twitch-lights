using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace TwitchLights.API.Services
{
    public static class HexFinder
    {
        private static readonly IImmutableDictionary<string, string> _table =
           new Dictionary<string, string>() { { "almond", "EFDECD" }, { "antiquebrass", "CD9575" }, { "apricot", "FDD9B5" },
               { "aquamarine", "78DBE2" }, { "asparagus", "87A96B" }, { "atomictangerine", "FFA474" }, { "bananamania", "FAE7B5" }, 
               { "beaver", "9F8170" }, { "bittersweet", "FD7C6E" }, { "black", "000000" }, { "blizzardblue", "ACE5EE" }, { "blue", "1F75FE" }, 
               { "bluebell", "A2A2D0" }, { "bluegray", "6699CC" }, { "bluegreen", "0D98BA" }, { "blueviolet", "7366BD" }, { "blush", "DE5D83" }, 
               { "brickred", "CB4154" }, { "brown", "B4674D" }, { "burntorange", "FF7F49" }, { "burntsienna", "EA7E5D" }, { "cadetblue", "B0B7C6" },
               { "canary", "FFFF99" }, { "caribbeangreen", "1CD3A2" }, { "carnationpink", "FFAACC" }, { "cerise", "DD4492" }, { "cerulean", "1DACD6" },
               { "chestnut", "BC5D58" }, { "copper", "DD9475" }, { "cornflower", "9ACEEB" }, { "cottoncandy", "FFBCD9" }, { "dandelion", "FDDB6D" },
               { "denim", "2B6CC4" }, { "desertsand", "EFCDB8" }, { "eggplant", "6E5160" }, { "electriclime", "CEFF1D" }, { "fern", "71BC78" }, 
               { "forestgreen", "6DAE81" }, { "fuchsia", "C364C5" }, { "fuzzywuzzy", "CC6666" }, { "gold", "E7C697" }, { "goldenrod", "FCD975" },
               { "grannysmithapple", "A8E4A0" }, { "gray", "95918C" }, { "green", "1CAC78" }, { "greenblue", "1164B4" }, { "greenyellow", "F0E891" },
               { "hotmagenta", "FF1DCE" }, { "inchworm", "B2EC5D" }, { "indigo", "5D76CB" }, { "jazzberryjam", "CA3767" }, { "junglegreen", "3BB08F" },
               { "laserlemon", "FEFE22" }, { "lavender", "FCB4D5" }, { "lemonyellow", "FFF44F" }, { "macaroniandcheese", "FFBD88" }, { "magenta", "F664AF" }, 
               { "magicmint", "AAF0D1" }, { "mahogany", "CD4A4C" }, { "maize", "EDD19C" }, { "manatee", "979AAA" }, { "mangotango", "FF8243" }, 
               { "maroon", "C8385A" }, { "mauvelous", "EF98AA" }, { "melon", "FDBCB4" }, { "midnightblue", "1A4876" }, { "mountainmeadow", "30BA8F" }, 
               { "mulberry", "C54B8C" }, { "navyblue", "1974D2" }, { "neoncarrot", "FFA343" }, { "olivegreen", "BAB86C" }, { "orange", "FF7538" }, 
               { "orangered", "FF2B2B" }, { "orangeyellow", "F8D568" }, { "orchid", "E6A8D7" }, { "outerspace", "414A4C" }, { "outrageousorange", "FF6E4A" }, 
               { "pacificblue", "1CA9C9" }, { "peach", "FFCFAB" }, { "periwinkle", "C5D0E6" }, { "piggypink", "FDDDE6" }, { "pinegreen", "158078" }, 
               { "pinkflamingo", "FC74FD" }, { "pinksherbet", "F78FA7" }, { "plum", "8E4585" }, { "purpleheart", "7442C8" }, { "purplemountainsmajesty", "9D81BA" },
               { "purplepizzazz", "FE4EDA" }, { "radicalred", "FF496C" }, { "rawsienna", "D68A59" }, { "rawumber", "714B23" }, { "razzledazzlerose", "FF48D0" }, 
               { "razzmatazz", "E3256B" }, { "red", "EE204D" }, { "redorange", "FF5349" }, { "redviolet", "C0448F" }, { "robinseggblue", "1FCECB" }, 
               { "royalpurple", "7851A9" }, { "salmon", "FF9BAA" }, { "scarlet", "FC2847" }, { "screamingreen", "76FF7A" }, { "seagreen", "9FE2BF" }, 
               { "sepia", "A5694F" }, { "shadow", "8A795D" }, { "shamrock", "45CEA2" }, { "shockingpink", "FB7EFD" }, { "silver", "CDC5C2" }, 
               { "skyblue", "80DAEB" }, { "springgreen", "ECEABE" }, { "sunglow", "FFCF48" }, { "sunsetorange", "FD5E53" }, { "tan", "FAA76C" }, 
               { "tealblue", "18A7B5" }, { "thistle", "EBC7DF" }, { "ticklemepink", "FC89AC" }, { "timberwolf", "DBD7D2" }, { "tropicalrainforest", "17806D" },
               { "tumbleweed", "DEAA88" }, { "turquoiseblue", "77DDE7" }, { "unmellowyellow", "FFFF66" }, { "violetpurple", "926EAE" }, { "violetblue", "324AB2" },
               { "violetred", "F75394" }, { "vividtangerine", "FFA089" }, { "vividviolet", "8F509D" }, { "white", "FFFFFF" }, { "wildblueyonder", "A2ADD0" },
               { "wildstrawberry", "FF43A4" }, { "wildwatermelon", "FC6C85" }, { "wisteria", "CDA4DE" }, { "yellow", "FCE883" }, { "yellowgreen", "C5E384" }, 
               { "yelloworange", "FFAE42" } }.ToImmutableDictionary();

        public static string Lookup(string color)
        {
            if (_table.TryGetValue(color, out var hex))
                return hex;
            return null;
        }
    }
}
