using BasicClicker.API.APICore;
using BasicClicker.Core;
using System;

namespace BasicClicker.BCMod
{
    public class BasicClickerMod : Mod
    {
        public override string DisplayName => "Basic Clicker";

        public override Version ModVersion => Main.BCVersion;
    }
}