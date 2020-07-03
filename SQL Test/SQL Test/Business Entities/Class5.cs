using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Test
{
    class Class5
    {
        public string CoreIron { get; set; }
        public string Ic { get; set; }
        public string CoreMaking1 { get; set; }
        public string CoreMaking2 { get; set; }
        public string CoreMaking3 { get; set; }
        public string CoreMaking4 { get; set; }
        public string CoreMaking5 { get; set; }
        public string CoreMaking6 { get; set; }
        public string CoreMaking7 { get; set; }
        public string CoreMaking8 { get; set; }
        public string CastMassKg { get; set; }
        public string CastTemperatureDeg { get; set; }
        public string CastTimeSeconds { get; set; }
        public string CastingInstruction { get; set; }
        public string HotTopping { get; set; }
        public string KOInstruction1 { get; set; }
        public string KOInstruction2 { get; set; }
        public string KOInstruction3 { get; set; }
        public string KOInstruction4 { get; set; }
        public string KOInstruction5 { get; set; }
        public string KOInstruction6 { get; set; }
        public string ChromiteInstructio { get; set; }
        public string FoundryNotes { get; set; }
        public string PaintInstructions { get; set; }
        public string ChillsYesNo { get; set; }
        public string FettledMassKg { get; set; }
        public string MouldingBoxBottom { get; set; }
        public string MouldingBoxTop { get; set; }
        public string PouringBasin { get; set; }
        public string Downgate { get; set; }
        public string RunnerBar { get; set; }
        public string Ingates { get; set; }
        public string Vents { get; set; }
        public string MouldInstruct1 { get; set; }
        public string MouldInstruct2 { get; set; }
        public string MouldInstruct3 { get; set; }
        public string MouldInstruct4 { get; set; }
        public string MouldInstruct5 { get; set; }
        public string MouldInstruct6 { get; set; }
        public string MouldInstruct7 { get; set; }
        public string MouldInstruct8 { get; set; }
        public string CloseInstruct1 { get; set; }
        public string CloseInstruct2 { get; set; }
        public string CloseInstruct3 { get; set; }
        public string CloseInstruct4 { get; set; }
        public string CloseInstruct5 { get; set; }
        public string CloseInstruct6 { get; set; }
        public string CloseInstruct7 { get; set; }
        public string CloseInstruct8 { get; set; }
        public string SimulationFileNo { get; set; }
        public string MethodRevisionBy { get; set; }
        public string MethodApprovedBy { get; set; }
        public string MethodRevisionDate { get; set; }
        public string MethodApprovedDate { get; set; }
        public string MethodApprovedYes { get; set; }



        public Class5(string CoreIron, string Ic, string CoreMaking1, string CoreMaking2, string CoreMaking3, string CoreMaking4, string CoreMaking5, string CoreMaking6, string CoreMaking7, string CoreMaking8, string CastMassKg, string CastTemperatureDeg, string CastTimeSeconds, string CastingInstruction, string HotTopping, string KOInstruction1, string KOInstruction2, string KOInstruction3, string KOInstruction4, string KOInstruction5, string KOInstruction6, string ChromiteInstructio, string FoundryNotes, string PaintInstructions, string ChillsYesNo, string FettledMassKg, string MouldingBoxBottom, string MouldingBoxTop, string PouringBasin, string Downgate, string RunnerBar, string Ingates, string Vents, string MouldInstruct1, string MouldInstruct2, string MouldInstruct3, string MouldInstruct4, string MouldInstruct5, string MouldInstruct6, string MouldInstruct7, string MouldInstruct8, string CloseInstruct1, string CloseInstruct2, string CloseInstruct3, string CloseInstruct4, string CloseInstruct5, string CloseInstruct6, string CloseInstruct7, string CloseInstruct8, string SimulationFileNo, string MethodRevisionBy, string MethodApprovedBy, string MethodRevisionDate, string MethodApprovedDate, string MethodApprovedYes)
        {
            this.CoreIron = CoreIron;
            this.Ic = Ic;
            this.CoreMaking1 = CoreMaking1;
            this.CoreMaking2 = CoreMaking2;
            this.CoreMaking3 = CoreMaking3;
            this.CoreMaking4 = CoreMaking4;
            this.CoreMaking5 = CoreMaking5;
            this.CoreMaking6 = CoreMaking6;
            this.CoreMaking7 = CoreMaking7;
            this.CoreMaking8 = CoreMaking8;
            this.CastMassKg = CastMassKg;
            this.CastTemperatureDeg = CastTemperatureDeg;
            this.CastTimeSeconds = CastTimeSeconds;
            this.CastingInstruction = CastingInstruction;
            this.HotTopping = HotTopping;
            this.KOInstruction1 = KOInstruction1;
            this.KOInstruction2 = KOInstruction2;
            this.KOInstruction3 = KOInstruction3;
            this.KOInstruction4 = KOInstruction4;
            this.KOInstruction5 = KOInstruction5;
            this.KOInstruction6 = KOInstruction6;
            this.ChromiteInstructio = ChromiteInstructio;
            this.FoundryNotes = FoundryNotes;
            this.PaintInstructions = PaintInstructions;
            this.ChillsYesNo = ChillsYesNo;
            this.FettledMassKg = FettledMassKg;
            this.MouldingBoxBottom = MouldingBoxBottom;
            this.MouldingBoxTop = MouldingBoxTop;
            this.PouringBasin = PouringBasin;
            this.Downgate = Downgate;
            this.RunnerBar = RunnerBar;
            this.Ingates = Ingates;
            this.Vents = Vents;
            this.MouldInstruct1 = MouldInstruct1;
            this.MouldInstruct2 = MouldInstruct2;
            this.MouldInstruct3 = MouldInstruct3;
            this.MouldInstruct4 = MouldInstruct4;
            this.MouldInstruct5 = MouldInstruct5;
            this.MouldInstruct6 = MouldInstruct6;
            this.MouldInstruct7 = MouldInstruct7;
            this.MouldInstruct8 = MouldInstruct8;
            this.CloseInstruct1 = CloseInstruct1;
            this.CloseInstruct2 = CloseInstruct2;
            this.CloseInstruct3 = CloseInstruct3;
            this.CloseInstruct4 = CloseInstruct4;
            this.CloseInstruct5 = CloseInstruct5;
            this.CloseInstruct6 = CloseInstruct6;
            this.CloseInstruct7 = CloseInstruct7;
            this.CloseInstruct8 = CloseInstruct8;
            this.SimulationFileNo = SimulationFileNo;
            this.MethodRevisionBy = MethodRevisionBy;
            this.MethodApprovedBy = MethodApprovedBy;
            this.MethodRevisionDate = MethodRevisionDate;
            this.MethodApprovedDate = MethodApprovedDate;
            this.MethodApprovedYes = MethodApprovedYes;
        }

    }
}