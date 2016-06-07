﻿namespace GameEditor.Wcf.Harness.Models
{
    public interface IArmyDefinition
    {
        int ArmyId { get; set; }
        string ArmyName { get; set; }
        int ArmyBook { get; set; } 
        int ArmyList { get; set; }
        int MinYear { get; set; }
        int MaxYear { get; set; }
    }
}