using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class Worksheet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Date { get; set; }
        public int Proid { get; set; }
        public int Siteid { get; set; }
        public string CompanyName { get; set; }
        public string SiteAddress { get; set; }
        public string FloorSide { get; set; }
        public string ProviderOrderNo { get; set; }
        public string AccoummodationNo { get; set; }
        public string EntranceNovi { get; set; }
        public string EntranceMod { get; set; }
        public string ClearenceNovi { get; set; }
        public string ClearenceModi { get; set; }
        public string BedNovi { get; set; }
        public string BedMod { get; set; }
        public string Room1Novi { get; set; }
        public string Room1Mod { get; set; }
        public string Room2Novi { get; set; }
        public string Room2Mod { get; set; }
        public string CellarNovi { get; set; }
        public string CellarMod { get; set; }
        public string CookNovi { get; set; }
        public string CookMod { get; set; }
        public string RoomBathNovi { get; set; }
        public string RoomBathMod { get; set; }
        public string FirmToiletNovi { get; set; }
        public string FirmToiletMod { get; set; }
        public string WCNovi { get; set; }
        public string WCMod { get; set; }
        public string WoodPlinth5 { get; set; }
        public string WoodPlinth10 { get; set; }
        public string LevelCompund { get; set; }
        public string SILICONE { get; set; }
        public string Deatil1 { get; set; }
        public string EDL { get; set; }
    }
}
