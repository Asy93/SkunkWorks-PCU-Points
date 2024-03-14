using Sandbox.Definitions;
using Sandbox.ModAPI;
using VRage.Game.Components;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Sandbox.Game.AI.Pathfinding.Obsolete;
using Sandbox.Game.Entities;
using VRage.Game;
using VRage.Game.ObjectBuilders.ComponentSystem;
using VRage.Utils;
using VRageMath;

namespace Limits
{
	[MySessionComponentDescriptor(MyUpdateOrder.BeforeSimulation)]
    public class PCULimits : MySessionComponentBase
    {
        private bool isInit = false;

        private void SetLimits()
        {
			var config = Config.Load();
            var PCUConfig = config.PCUConfig;
			var PCUModLookupByType = new Dictionary<MyDefinitionId, int>();
            foreach (var id in PCUConfig.Keys)
            {
                MyDefinitionId typeId;
                if ( MyDefinitionId.TryParse(id, out typeId) )
                {
                    PCUModLookupByType.Add(typeId, PCUConfig[id]);
                }
                else
                {
                    throw new Exception("Bad Entry in PCU Mod Table. Entry=" + id);
                }
            }

			MyLog.Default.WriteLineAndConsole("Setting custom PCU values");
            foreach (MyDefinitionBase def in MyDefinitionManager.Static.GetAllDefinitions())
            {
                MyCubeBlockDefinition blockDef = def as MyCubeBlockDefinition;
				string name = def.Id.ToString();
				int PCUMod = 0;
				
				bool isAWE = name.Contains("ARYX") || name.Contains("AWE");
				bool isVanillaWeapon = name.Contains("MyObjectBuilder_LargeGatlingTurret")
				             || name.Contains("MyObjectBuilder_LargeMissileTurret")
							 || name.Contains("MyObjectBuilder_InteriorTurret")
							 || name.Contains("MyObjectBuilder_SmallMissileLauncher")
							 || name.Contains("MyObjectBuilder_ConveyorSorter/LargeRailgun")
							 || name.Contains("MyObjectBuilder_ConveyorSorter/SmallRailgun")
							 || name.Contains("MyObjectBuilder_Warhead");
				bool isWCWeapon = name.Contains("Sorter") || name.Contains("Turret");
				
				if (!PCUModLookupByType.TryGetValue(def.Id, out PCUMod)) {
					if(name.Contains("TurretControlBlock")) {
						//ignore
					}
					else if (isVanillaWeapon && !isAWE) {
						MyLog.Default.WriteLineAndConsole($"Vanilla Weapon missing config. Setting default value for {def.Id}");
						PCUMod = 100000;
					} else if (isAWE && isWCWeapon) {
						MyLog.Default.WriteLineAndConsole($"AWE Weapon missing config. Setting default value for {def.Id}");
						PCUMod = 100000;
					} else {
						PCUMod = 0;
					}
				}

				if (blockDef != null) {
					blockDef.PCU = config.pveZone ? PCUMod / 2 : PCUMod;
				}
            }
        }

        public override void Init(MyObjectBuilder_SessionComponent sessionComponent)
        {
            SetLimits();
        }
        
        public override void SaveData()
        {
            if (MyAPIGateway.Multiplayer == null) return;
            MyAPIGateway.Multiplayer.SendMessageToServer(45834, new byte[0]);
        }

        public override void UpdateBeforeSimulation()
        {
            if (!isInit && MyAPIGateway.Session == null)
            {
                SetLimits();
                isInit = true;
            }
        }
    }
}
