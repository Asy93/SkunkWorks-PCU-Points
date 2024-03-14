using ProtoBuf;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.IO;
using VRage.Utils;
using System.Linq;
using System.Text;

namespace Limits
{
    [ProtoContract]
    public class Config
    {
        public const string Filename = "pcu_config.txt";

        public Dictionary<string, int> PCUConfig { get; set; } = new Dictionary<string, int>();
		public bool pveZone = false;

		static Dictionary<string, int> DefaultConfig = new Dictionary<string, int>()
		{
	/* Large Grid Weapons */
		//Vanilla Weapons		
			{"MyObjectBuilder_LargeGatlingTurret/(null)", 350},									//
			{"MyObjectBuilder_LargeMissileTurret/AutoCannonTurret", 300},						//		
			{"MyObjectBuilder_LargeMissileTurret/(null)", 200},									//
			{"MyObjectBuilder_LargeMissileTurret/LargeCalibreTurret", 300},						//
			{"MyObjectBuilder_LargeMissileTurret/LargeBlockMediumCalibreTurret", 300},			//	
			{"MyObjectBuilder_InteriorTurret/LargeInteriorTurret", 175},						//
			{"MyObjectBuilder_SmallMissileLauncher/LargeMissileLauncher", 250},					//
			{"MyObjectBuilder_SmallMissileLauncher/LargeBlockLargeCalibreGun", 250},			//									
			{"MyObjectBuilder_ConveyorSorter/LargeRailgun", 400},								//
			{"MyObjectBuilder_Warhead/LargeWarhead", 1000},										//
			{"MyObjectBuilder_Warhead/LargeExplosiveBarrel", 1000},								//

		//AWE Weapons	
//Cannons					
			{"MyObjectBuilder_LargeMissileTurret/ARYXCycloneCannon", 1000}, 					// M240 Cyclone Strike Cannon
			{"MyObjectBuilder_LargeMissileTurret/ARYXHurricaneCannon", 1500},					// M480 Hurricane Strike Cannon
			{"MyObjectBuilder_LargeMissileTurret/ARYXTsunamiCannon", 900},					 	// M480 Tsunami Strike Cannon
			{"MyObjectBuilder_LargeMissileTurret/ARYXTyphoonCannon", 2500},						// M600 Typhoon Strike Cannon
			{"MyObjectBuilder_SmallMissileLauncher/ARYXTempestCannon", 1000},					// M600 Tempest Strike Cannon			
			{"MyObjectBuilder_LargeMissileTurret/ARYXBurstTurret", 500},						// BR-RT7 "Punisher" Burst Cannon
			{"MyObjectBuilder_ConveyorSorter/ARYXBurstTurretSlanted", 500},						// BR-RT7 "Punisher" Slanted Burst Cannon
			{"MyObjectBuilder_LargeMissileTurret/ARYX_ChordAutocannon", 300},					// AC54 Chord
			{"MyObjectBuilder_LargeMissileTurret/ARYX_EchoAutocannon", 600},					// AC85 Echo Autocannon
//Railguns
			{"MyObjectBuilder_ConveyorSorter/ARYXGaussCannon", 5000},							// ZS-1200-S Ares Heavy Railgun
			{"MyObjectBuilder_LargeMissileTurret/ARYXGaussTurret", 5000},						// ZS-1200 Ariadne Heavy Railgun Turret
			{"MyObjectBuilder_LargeMissileTurret/ARYXPicketRailgun", 1500},						// Athena-115 Picket Railgun Turret
//Plasma
			{"MyObjectBuilder_ConveyorSorter/ARYXPlasmaPulser", 750},							// M5D-4E Helios Plasma Pulser
			{"MyObjectBuilder_LargeMissileTurret/ARYXMagnetarCannon", 4000},					// K8A-3SC Magnetar Shock Cannon
			{"MyObjectBuilder_LargeMissileTurret/ARYXQuasarCannon", 2000},        				// K4A-2SC Quasar Shock Cannon
			{"MyObjectBuilder_LargeMissileTurret/ARYXPulsarCannon", 1000},						// K2A-1SC Pulsar Shock Cannon
			{"MyObjectBuilder_LargeMissileTurret/ARYXSpartanTurret", 1000},						// APL35-G Spartan Plasma Cannon			
//Laser
			{"MyObjectBuilder_LargeMissileTurret/ARYXVariableLaser", 2200},						// VL6 Modulus Variable-Laser
  			{"MyObjectBuilder_ConveyorSorter/ARYXFocusLance", 1250},        					// M-100V Prometheus Focus Beam Lance
			{"MyObjectBuilder_LargeMissileTurret/ARYXAuroraLaser", 1000},						// Aurora Combat Laser
//Point Defense		
			{"MyObjectBuilder_LargeGatlingTurret/ARYXAtlasPDC", 750},							// MG50 "ATLAS" Point Defence Cannon	
			{"MyObjectBuilder_ConveyorSorter/ARYXSlantedAtlasPDC", 1000},						// MG50 "ATLAS" Slanted Point Defence Cannon
//Siege
			{"MyObjectBuilder_ConveyorSorter/ARYXSiegeMortarCannon", 2000},						// M-1000 Avalanche Siege Mortar
			{"MyObjectBuilder_ConveyorSorter/ARYXHeavyCoilgun", 8000},							// EDR-0F Predator-850 Coilgun	
//Other		
			{"MyObjectBuilder_ConveyorSorter/ARYXLargeRadar", 0},								// "Doppler" Radar Unit		
			{"MyObjectBuilder_Beacon/JumpInhibitor", 1500},										// Jump Inhibitor
			{"MyObjectBuilder_Beacon/SmallJumpInhibitor", 3000},								// SG Jump Inhibitor							

////////////////////////////OLD
			{"MyObjectBuilder_ConveyorSorter/ARYXHydraTurret", 750},							// RL6 Hydra Rocket Battery
			{"MyObjectBuilder_ConveyorSorter/ARYXTacticalModule", 0},							// Aegis Tactical Module
			{"MyObjectBuilder_LargeMissileTurret/ARYXHeavyFlakTurret", 900}, 					// F4-GL Thrasher Heavy Flak Cannon
			{"MyObjectBuilder_ConveyorSorter/ARYXMissileBattery", 4000},						// M8G-LS4 Longsword Missile Battery
			{"MyObjectBuilder_LargeMissileTurret/ARYXPlasmaBeamCannon", 4000},					// NC7-5F Trident Plasma Beam Cannon
			{"MyObjectBuilder_ConveyorSorter/ARYXOculusLaserBase", 700},						// Oculus Orb-PD Laser
			{"MyObjectBuilder_ConveyorSorter/ARYXRailgun", 1500},								// Artemis-250 Railgun
			{"MyObjectBuilder_ConveyorSorter/ARYXInterceptorPDGun", 800},  						// R1-S Interceptor Rocket Pod         
			{"MyObjectBuilder_LargeMissileTurret/ARYXJuryCannon", 500},							// M120 Whirlwind Heavy Cannon
			{"MyObjectBuilder_LargeGatlingTurret/ARYXCodexPDC", 400},							// MG25 "Avalanche" Heavy Machine Gun
			{"MyObjectBuilder_ConveyorSorter/ARYXSlantedCodexPDC", 400},						// MG25 "Avalanche" Slanted Heavy Machine Gun
			{"MyObjectBuilder_ConveyorSorter/ARYXSlantedInvCodexPDC", 400},					 	// MG25 "Avalanche" Slanted Heavy Machine Gun		
			{"MyObjectBuilder_LargeMissileTurret/ARYXWarriorGatling", 1900},					// LS5-MG100 Warrior Heavy Gatling
			{"MyObjectBuilder_LargeMissileTurret/ARYXPulseTurret", 750},						// PL16 Gravastar Laser Turret
			{"MyObjectBuilder_LargeMissileTurret/ARYXCompactPulseTurret", 750},					// PL16-C Gravastar Laser Turret
			{"MyObjectBuilder_LargeMissileTurret/ARYXNucleonShotgun", 500},						// Nucleon Energy Shotgun
			{"MyObjectBuilder_ConveyorSorter/ARYXFlechetteLauncher", 500},						// Flechette Launcher
			{"MyObjectBuilder_LargeMissileTurret/ARYXFlakTurret", 500},							// Riptide Flak Turret
			{"MyObjectBuilder_ConveyorSorter/ARYXTorpLauncher", 1200},							// TL-150 Astraeus Torpedo Launcher
 			{"MyObjectBuilder_ConveyorSorter/ARYXInlineTorpLauncher", 1200},		    		// TL-150-B Astraeus Inline Torpedo Launcher       
			{"MyObjectBuilder_ConveyorSorter/ARYXLongbowLauncher", 500},						// ML-70 Longbow Missile Launcher
			{"MyObjectBuilder_ConveyorSorter/ARYXHeavyMissileSalvoLauncher", 2000},			 	// HA-4ML2 Poseidon Salvo Launcher
			{"MyObjectBuilder_ConveyorSorter/ARYXLightCoilgun", 4000},							// LC-C7 Hunter-405 Coilgun
			{"MyObjectBuilder_LargeMissileTurret/ARYXRailgunTurret", 2000},						// Apollo-250 Railgun Turret
			{"MyObjectBuilder_LargeMissileTurret/ARYXSentinel", 250},							// SR-75 Sentinel Smartgun
			{"MyObjectBuilder_LargeMissileTurret/ARYXReaperPulseCannon", 5000},					// VLX-5000 Reaper Pulse Cannon
			{"MyObjectBuilder_ConveyorSorter/ARYXMace", 500},									// L82 Mace Combat Shotgun
			{"MyObjectBuilder_ConveyorSorter/AWE_WL_SuperLaser_Large_CB", 2000},				// Mark-I Atlas Superlaser
			{"MyObjectBuilder_LargeMissileTurret/ARYX_FW_NovaBlaster", 500},					// EB-10 Nova Phase Blaster
			{"MyObjectBuilder_ConveyorSorter/AWE_MarkV_SuperLaser_Large_CB", 4000},				// CO-P3 Sunderer Heavy Lance
			{"MyObjectBuilder_ConveyorSorter/ARYXVariableLauncher", 7500},						// Variable Warhead Single-use Launcher
			{"MyObjectBuilder_LargeMissileTurret/ARYX_FocusBeam_CompactTurret", 500},			// M98-T Focus Beam Turret
			{"MyObjectBuilder_ConveyorSorter/ARYX_Small_Sidekick_Hangar", 3500},				// Small Hangar Bay				
			{"MyObjectBuilder_ConveyorSorter/ARYX_LargeFlareLauncher", 500},					// F9-B Flare Launcher
			{"MyObjectBuilder_ConveyorSorter/ARYXLargeIonCannon", 10000},						// CT500 Centurion Ion Cannon
			{"MyObjectBuilder_ConveyorSorter/ARYXWarriorGatlingGun", 1750},						// LS5-MG100 Warrior Heavy Gatling Gun	
			{"MyObjectBuilder_LargeMissileTurret/ARYXVulcanTurret", 1250},						// MG65-T Vulcan Gatling Cannon
			{"MyObjectBuilder_ConveyorSorter/ARYXGladiatorMissileLauncher", 4000},				// TS-L8 Gladiator Tactical Launcher
			{"MyObjectBuilder_ConveyorSorter/ARYXRocketArtillery", 9000},						// RA-5 Starfall Rocket Artillery
			{"MyObjectBuilder_LargeMissileTurret/ARYXPhaseRepeaterCannon", 3000},				// XM500 Medusa Phase Cannon

		//AWE Weapons CAPTURABLE	
			{"MyObjectBuilder_ConveyorSorter/ARYXKingswordSupercannon", 999000},				// S12A-3KS Kingsword Casaba Lance	
			{"MyObjectBuilder_ConveyorSorter/ARYXHeavyTorpedoLauncher", 8000},					// TL-350A Hyperion Heavy Torpedo Launcher		
		
	/* Small Grid Weapons */	
		//Vanilla Weapons	
			{"MyObjectBuilder_LargeGatlingTurret/SmallGatlingTurret", 250},						//				
			{"MyObjectBuilder_SmallGatlingGun/(null)", 250},									//
			{"MyObjectBuilder_LargeMissileTurret/SmallMissileTurret", 250},						//
			{"MyObjectBuilder_LargeMissileTurret/SmallBlockMediumCalibreTurret", 250},			//
			{"MyObjectBuilder_SmallMissileLauncher/(null)", 250},								//
			{"MyObjectBuilder_SmallMissileLauncher/SmallMissileLauncherWarfare2", 250},			//
			{"MyObjectBuilder_SmallMissileLauncherReload/SmallRocketLauncherReload", 250},		//
			{"MyObjectBuilder_SmallGatlingGun/SmallBlockAutocannon", 250},						//
			{"MyObjectBuilder_SmallMissileLauncherReload/SmallBlockMediumCalibreGun", 250},		//
			{"MyObjectBuilder_SmallGatlingGun/SmallGatlingGunWarfare2", 250},					//					
			{"MyObjectBuilder_SmallMissileLauncherReload/SmallRailgun", 400},					//
			{"MyObjectBuilder_ConveyorSorter/SmallRailgun", 400},								//
			{"MyObjectBuilder_Warhead/SmallWarhead", 500},										//
			{"MyObjectBuilder_Warhead/SmallExplosiveBarrel", 500},								//			

		//Modded AWE
//Cannon
			{"MyObjectBuilder_SmallMissileLauncher/ARYXWindfallCannon", 1000},					// M240 Windfall Strike Cannon
			{"MyObjectBuilder_SmallMissileLauncher/ARYXStormCannon", 1000},						// M120 Storm Light Cannon
			{"MyObjectBuilder_LargeMissileTurret/ARYXCycloneCannon_SG", 2000},					// M240 Cyclone Strike Cannon
			{"MyObjectBuilder_LargeMissileTurret/ARYX_ChordAutocannon_SG", 500},				// AC54 Chord
			{"MyObjectBuilder_LargeMissileTurret/ARYXBurstTurret_SG", 2000},					// BR-RT7 "Punisher" Burst Cannon
			{"MyObjectBuilder_SmallMissileLauncher/ARYX_Fixed_Chord_auto", 350}, 				// AC54 Chord Autocannon						
//Railgun
			{"MyObjectBuilder_ConveyorSorter/ARYXLightRailgun", 700},							// Antaeus-115 Railgun	
//Plasma
			{"MyObjectBuilder_ConveyorSorter/ARYX_SpartanCannonSG", 500},						// AL35-R Spartan Plasma Cannon
//Laser
			{"MyObjectBuilder_ConveyorSorter/ARYXSmallPulseLaser_Fixed", 1000},					// PL4-S Zarya Pulse Laser
			{"MyObjectBuilder_ConveyorSorter/ARYXArgusLaser", 1000},							// Argus Orb PD Laser				
//Point Defense
			{"MyObjectBuilder_SmallGatlingGun/ARYX_FixedAtlasGatling", 1000},					// MG50 Coaxial ATLAS Gatling Gun
//Siege
			{"MyObjectBuilder_ConveyorSorter/ARYXSmallBombBay", 1000},							// B2-M Shrike Bomb Bay
			{"MyObjectBuilder_ConveyorSorter/ARYX_SabreMissileHardpoint", 5000},				// Sabre Missile
			{"MyObjectBuilder_ConveyorSorter/ARYX_NyxMissileHardpoint", 5000},					// Nyx Missile		
//Other		
			{"MyObjectBuilder_ConveyorSorter/ARYXSmallRadar", 0},								// "Maxwell" Radar Unit
//OLD//			
			{"MyObjectBuilder_ConveyorSorter/ARYX_FocusBeam_CompactSG", 1000},					// M98-V Compact Focus Beam
			{"MyObjectBuilder_ConveyorSorter/ARYXLongbowLauncher_SG", 1500},					// ML-70 Longbow Missile Launcher
			{"MyObjectBuilder_SmallMissileLauncher/ARYXTempestCannon_SG", 2000},				// M600 Tempest Strike Cannon
			{"MyObjectBuilder_SmallGatlingGun/ARYX_SmallChaingun", 1000},						// MG22-S Prowler Chaingun
			{"MyObjectBuilder_ConveyorSorter/ARYX_SmallFlareLauncher", 350},					// F9-B Flare Launcher
			{"MyObjectBuilder_ConveyorSorter/ARYXSmallFlechetteLauncher", 1000},				// Small Flechette Launcher
			{"MyObjectBuilder_LargeGatlingTurret/ARYXCodexPDC_SG", 2000},						// MG25 "Avalanche" Heavy Machine Gun		

	/* Sudentican Weapons */
			{"MyObjectBuilder_ConveyorSorter/Aryx_Sudentican_Spinal_Gun", 99999},				// Sudentican Linear Plasma Accelerator
			{"MyObjectBuilder_ConveyorSorter/Aryx_Sudentican_Spectrum_Beam", 99999},			// Sudentican Spectrum Beam
			{"MyObjectBuilder_ConveyorSorter/Aryx_Sudentican_Shock_Blaster", 99999},			// Sudentican Shock Blaster
			{"MyObjectBuilder_ConveyorSorter/Aryx_Sudentican_Burst_Cannon", 99999},				//
			{"MyObjectBuilder_ConveyorSorter/Aryx_Sudentican_Super_Railgun", 99999},			// ZXV-A2000G "Oblivion's Calling" Enigmatic Gauss Cannon
			{"MyObjectBuilder_ConveyorSorter/Aryx_Sudentican_Concussion_Missiles", 99999},		// Sudentican Concussion Missile Launcher
			{"MyObjectBuilder_ConveyorSorter/Aryx_Sudentican_Launch_Bay", 99999},				// Sudentican Launch Bay
			{"MyObjectBuilder_Thrust/Aryx_Sudentican_Drive_Thruster",99999},					// Sudentican Impulse Drive
			{"MyObjectBuilder_Thrust/Aryx_Sudentican_Thruster", 99999},							// Sudentican Maneuvring Thruster
			{"MyObjectBuilder_Battery/Aryx_Sudentican_Reactor", 99999},							// Sudentican Reactor
			{"MyObjectBuilder_Gyro/Aryx_Sudentican_Gyroscope", 99999},							// Sudentican Reaction Wheel Core

	/* Large Grid Power */     
		//Vanilla Reactors
			{"MyObjectBuilder_Reactor/LargeBlockSmallGenerator", 150},
			{"MyObjectBuilder_Reactor/LargeBlockSmallGenerator4x", 450},
			{"MyObjectBuilder_Reactor/LargeBlockSmallGenerator8x", 900},
			{"MyObjectBuilder_Reactor/LargeBlockLargeGenerator", 3000},
			{"MyObjectBuilder_Reactor/LargeBlockLargeGenerator4x", 9000},
			{"MyObjectBuilder_Reactor/LargeBlockLargeGenerator8x", 18000},
		//Warfare Reactors	
			{"MyObjectBuilder_Reactor/LargeBlockSmallGeneratorWarfare2", 150},
			{"MyObjectBuilder_Reactor/LargeBlockSmallGeneratorWarfare24x", 450},
			{"MyObjectBuilder_Reactor/LargeBlockSmallGeneratorWarfare28x", 900},
			{"MyObjectBuilder_Reactor/LargeBlockLargeGeneratorWarfare2", 3000},
			{"MyObjectBuilder_Reactor/LargeBlockLargeGeneratorWarfare24x", 9000},	
			{"MyObjectBuilder_Reactor/LargeBlockLargeGeneratorWarfare28x", 18000},			
		//Wind Turbines
			{"MyObjectBuilder_WindTurbine/LargeBlockWindTurbine", 4},
			{"MyObjectBuilder_WindTurbine/LargeBlockWindTurbine2x", 16},
			{"MyObjectBuilder_WindTurbine/LargeBlockWindTurbine4x", 24},
			{"MyObjectBuilder_WindTurbine/LargeBlockWindTurbine8x", 32},
		//Wind Turbines
			{"MyObjectBuilder_WindTurbine/LargeBlockWindTurbineReskin", 4},
			{"MyObjectBuilder_WindTurbine/LargeBlockWindTurbineReskin2x", 16},
			{"MyObjectBuilder_WindTurbine/LargeBlockWindTurbineReskin4x", 24},
			{"MyObjectBuilder_WindTurbine/LargeBlockWindTurbineReskin8x", 32},
		//Solar Panels
			{"MyObjectBuilder_SolarPanel/LargeBlockSolarPanel", 2},
			{"MyObjectBuilder_SolarPanel/LargeBlockSolarPanel2x", 8},
			{"MyObjectBuilder_SolarPanel/LargeBlockSolarPanel4x", 12},
			{"MyObjectBuilder_SolarPanel/LargeBlockSolarPanel8x", 16},
		//Solar Panels Colorable
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanel", 2},
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanel2x", 8},
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanel4x", 12},
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanel8x", 16},
		//Solar Panels Colorable Corner
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanelCorner", 1},
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanelCorner2x", 4},
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanelCorner4x", 6},
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanelCorner8x", 8},
		//Solar Panels Colorable Corner Inverted
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanelCornerInverted", 1},
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanelCornerInverted2x", 4},
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanelCornerInverted4x", 6},
			{"MyObjectBuilder_SolarPanel/LargeBlockColorableSolarPanelCornerInverted8x", 8},			
		//Hydrogen Engines
			{"MyObjectBuilder_HydrogenEngine/LargeHydrogenEngine", 50},
			{"MyObjectBuilder_HydrogenEngine/LargeHydrogenEngine2x", 200},
			{"MyObjectBuilder_HydrogenEngine/LargeHydrogenEngine4x", 300},
			{"MyObjectBuilder_HydrogenEngine/LargeHydrogenEngine8x", 400},
		//Vanilla Batteries
			{"MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlock", 120},
			{"MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlock2x", 240},
			{"MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlock4x", 300},
			{"MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlock8x", 360},
		//Warfare Batteries	
			{"MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlockWarfare2", 120},
			{"MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlockWarfare22x", 240},
			{"MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlockWarfare24x", 300},
			{"MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlockWarfare28x", 360},
	/* Large Grid Tools */ 			
		// Welder	
			{"MyObjectBuilder_ShipWelder/LargeShipWelder", 1250},		

	/* Small Grid Power */
		//Vanilla Reactors
			{"MyObjectBuilder_Reactor/SmallBlockSmallGenerator", 25},
			{"MyObjectBuilder_Reactor/SmallBlockSmallGenerator4x", 75},
			{"MyObjectBuilder_Reactor/SmallBlockSmallGenerator8x", 150},
			{"MyObjectBuilder_Reactor/SmallBlockLargeGenerator", 738},
			{"MyObjectBuilder_Reactor/SmallBlockLargeGenerator4x", 2213},
			{"MyObjectBuilder_Reactor/SmallBlockLargeGenerator8x", 4425},
		//Warfare Reactors	
			{"MyObjectBuilder_Reactor/SmallBlockSmallGeneratorWarfare2", 25},
			{"MyObjectBuilder_Reactor/SmallBlockSmallGeneratorWarfare24x", 75},
			{"MyObjectBuilder_Reactor/SmallBlockSmallGeneratorWarfare28x", 150},
			{"MyObjectBuilder_Reactor/SmallBlockLargeGeneratorWarfare2", 738},
			{"MyObjectBuilder_Reactor/SmallBlockLargeGeneratorWarfare24x", 2213},			
			{"MyObjectBuilder_Reactor/SmallBlockLargeGeneratorWarfare28x", 4425},			
		//Solar Panels	
			{"MyObjectBuilder_SolarPanel/SmallBlockSolarPanel", 3},
			{"MyObjectBuilder_SolarPanel/SmallBlockSolarPanel2x", 12},
			{"MyObjectBuilder_SolarPanel/SmallBlockSolarPanel4x", 18},
			{"MyObjectBuilder_SolarPanel/SmallBlockSolarPanel8x", 24},
		//Solar Panels Colorable
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanel", 3},
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanel2x", 12},
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanel4x", 18},
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanel8x", 24},
		//Solar Panels Colorable Corner
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanelCorner", 1},
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanelCorner2x", 6},
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanelCorner4x", 9},
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanelCorner8x", 12},
		//Solar Panels Colorable Corner Inverted
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanelCornerInverted", 1},
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanelCornerInverted2x", 6},
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanelCornerInverted4x", 9},
			{"MyObjectBuilder_SolarPanel/SmallBlockColorableSolarPanelCornerInverted8x", 12},	
		//Hydrogen Engines
			{"MyObjectBuilder_HydrogenEngine/SmallHydrogenEngine", 25},
			{"MyObjectBuilder_HydrogenEngine/SmallHydrogenEngine2x", 100},
			{"MyObjectBuilder_HydrogenEngine/SmallHydrogenEngine4x", 150},
			{"MyObjectBuilder_HydrogenEngine/SmallHydrogenEngine8x", 200},
		//Vanilla Batteries
			{"MyObjectBuilder_BatteryBlock/SmallBlockSmallBatteryBlock", 10},
			{"MyObjectBuilder_BatteryBlock/SmallBlockSmallBatteryBlock2x", 20},
			{"MyObjectBuilder_BatteryBlock/SmallBlockSmallBatteryBlock4x", 40},
			{"MyObjectBuilder_BatteryBlock/SmallBlockSmallBatteryBlock8x", 80},
			{"MyObjectBuilder_BatteryBlock/SmallBlockBatteryBlock", 200},
			{"MyObjectBuilder_BatteryBlock/SmallBlockBatteryBlock2x", 400},
			{"MyObjectBuilder_BatteryBlock/SmallBlockBatteryBlock4x", 500},
			{"MyObjectBuilder_BatteryBlock/SmallBlockBatteryBlock8x", 600},
		//Warfare Batteries
			{"MyObjectBuilder_BatteryBlock/SmallBlockSmallBatteryBlockWarfare2", 10},
			{"MyObjectBuilder_BatteryBlock/SmallBlockSmallBatteryBlockWarfare22x", 20},
			{"MyObjectBuilder_BatteryBlock/SmallBlockSmallBatteryBlockWarfare24x", 40},
			{"MyObjectBuilder_BatteryBlock/SmallBlockSmallBatteryBlockWarfare28x", 80},
			{"MyObjectBuilder_BatteryBlock/SmallBlockBatteryBlockWarfare2", 200},
			{"MyObjectBuilder_BatteryBlock/SmallBlockBatteryBlockWarfare22x", 400},
			{"MyObjectBuilder_BatteryBlock/SmallBlockBatteryBlockWarfare24x", 500},
			{"MyObjectBuilder_BatteryBlock/SmallBlockBatteryBlockWarfare28x", 600},
	/* Small Grid Tools */ 			
		// Welder	
			{"MyObjectBuilder_ShipWelder/SmallShipWelder", 1250},	

/* Thruster Blocks*/
//Atmospheric Thrusters
	//Atmospheric Thrust (Vanilla)
		//Large Block Large
			{"MyObjectBuilder_Thrust/LargeBlockLargeAtmosphericThrust",  42},
			{"MyObjectBuilder_Thrust/LargeBlockLargeAtmosphericThrust2x", 168},
			{"MyObjectBuilder_Thrust/LargeBlockLargeAtmosphericThrust4x", 252},			
			{"MyObjectBuilder_Thrust/LargeBlockLargeAtmosphericThrust8x", 336},
		//Large Block Small
			{"MyObjectBuilder_Thrust/LargeBlockSmallAtmosphericThrust",  6},
			{"MyObjectBuilder_Thrust/LargeBlockSmallAtmosphericThrust2x", 24},
			{"MyObjectBuilder_Thrust/LargeBlockSmallAtmosphericThrust4x", 36},
			{"MyObjectBuilder_Thrust/LargeBlockSmallAtmosphericThrust8x", 48},
		//Small Block Large
			{"MyObjectBuilder_Thrust/SmallBlockLargeAtmosphericThrust",  42},
			{"MyObjectBuilder_Thrust/SmallBlockLargeAtmosphericThrust2x", 168},
			{"MyObjectBuilder_Thrust/SmallBlockLargeAtmosphericThrust4x", 252},
			{"MyObjectBuilder_Thrust/SmallBlockLargeAtmosphericThrust8x", 336},
		//Small Block Small
			{"MyObjectBuilder_Thrust/SmallBlockSmallAtmosphericThrust",  6},
			{"MyObjectBuilder_Thrust/SmallBlockSmallAtmosphericThrust2x", 24},
			{"MyObjectBuilder_Thrust/SmallBlockSmallAtmosphericThrust4x", 36},
			{"MyObjectBuilder_Thrust/SmallBlockSmallAtmosphericThrust8x", 48},

	//Atmospheric Thrust (SciFi)
		//Large Block Large
			{"MyObjectBuilder_Thrust/LargeBlockLargeAtmosphericThrustSciFi",  42},
			{"MyObjectBuilder_Thrust/LargeBlockLargeAtmosphericThrustSciFi2x", 168},
			{"MyObjectBuilder_Thrust/LargeBlockLargeAtmosphericThrustSciFi4x", 252},
			{"MyObjectBuilder_Thrust/LargeBlockLargeAtmosphericThrustSciFi8x", 336},
		//Large Block Small
			{"MyObjectBuilder_Thrust/LargeBlockSmallAtmosphericThrustSciFi",  6},
			{"MyObjectBuilder_Thrust/LargeBlockSmallAtmosphericThrustSciFi2x", 24},
			{"MyObjectBuilder_Thrust/LargeBlockSmallAtmosphericThrustSciFi4x", 36},
			{"MyObjectBuilder_Thrust/LargeBlockSmallAtmosphericThrustSciFi8x", 48},
		//Small Block Large
			{"MyObjectBuilder_Thrust/SmallBlockLargeAtmosphericThrustSciFi",  42},
			{"MyObjectBuilder_Thrust/SmallBlockLargeAtmosphericThrustSciFi2x", 168},
			{"MyObjectBuilder_Thrust/SmallBlockLargeAtmosphericThrustSciFi4x", 252},
			{"MyObjectBuilder_Thrust/SmallBlockLargeAtmosphericThrustSciFi8x", 336},
		//Small Block Small
			{"MyObjectBuilder_Thrust/SmallBlockSmallAtmosphericThrustSciFi",  6},
			{"MyObjectBuilder_Thrust/SmallBlockSmallAtmosphericThrustSciFi2x", 24},
			{"MyObjectBuilder_Thrust/SmallBlockSmallAtmosphericThrustSciFi4x", 36},
			{"MyObjectBuilder_Thrust/SmallBlockSmallAtmosphericThrustSciFi8x", 48},

	//Atmospheric Thrust (Flat)
		//Large Block Large
			{"MyObjectBuilder_Thrust/LargeBlockLargeFlatAtmosphericThrust",  14},
			{"MyObjectBuilder_Thrust/LargeBlockLargeFlatAtmosphericThrustDShape",  14},	
			{"MyObjectBuilder_Thrust/LargeBlockLargeFlatAtmosphericThrust2x",  56},
			{"MyObjectBuilder_Thrust/LargeBlockLargeFlatAtmosphericThrustDShape2x", 56},	
			{"MyObjectBuilder_Thrust/LargeBlockLargeFlatAtmosphericThrust4x",  84},
			{"MyObjectBuilder_Thrust/LargeBlockLargeFlatAtmosphericThrustDShape4x", 84},	
			{"MyObjectBuilder_Thrust/LargeBlockLargeFlatAtmosphericThrust8x",  112},
			{"MyObjectBuilder_Thrust/LargeBlockLargeFlatAtmosphericThrustDShape8x", 112},	
		//Large Block Small
			{"MyObjectBuilder_Thrust/LargeBlockSmallFlatAtmosphericThrust", 2},
			{"MyObjectBuilder_Thrust/LargeBlockSmallFlatAtmosphericThrustDShape", 2},	
			{"MyObjectBuilder_Thrust/LargeBlockSmallFlatAtmosphericThrust2x", 8},
			{"MyObjectBuilder_Thrust/LargeBlockSmallFlatAtmosphericThrustDShape2x", 8},	
			{"MyObjectBuilder_Thrust/LargeBlockSmallFlatAtmosphericThrust4x", 12},
			{"MyObjectBuilder_Thrust/LargeBlockSmallFlatAtmosphericThrustDShape4x", 12},	
			{"MyObjectBuilder_Thrust/LargeBlockSmallFlatAtmosphericThrust8x", 16},
			{"MyObjectBuilder_Thrust/LargeBlockSmallFlatAtmosphericThrustDShape8x", 16},	
		//Small Block Large
			{"MyObjectBuilder_Thrust/SmallBlockLargeFlatAtmosphericThrust", 14},
			{"MyObjectBuilder_Thrust/SmallBlockLargeFlatAtmosphericThrustDShape",	14},	
			{"MyObjectBuilder_Thrust/SmallBlockLargeFlatAtmosphericThrust2x", 56},
			{"MyObjectBuilder_Thrust/SmallBlockLargeFlatAtmosphericThrustDShape2x", 56},	
			{"MyObjectBuilder_Thrust/SmallBlockLargeFlatAtmosphericThrust4x",84},
			{"MyObjectBuilder_Thrust/SmallBlockLargeFlatAtmosphericThrustDShape4x", 84},	
			{"MyObjectBuilder_Thrust/SmallBlockLargeFlatAtmosphericThrust8x", 112},
			{"MyObjectBuilder_Thrust/SmallBlockLargeFlatAtmosphericThrustDShape8x", 112},	

		//Small Block Small
			{"MyObjectBuilder_Thrust/SmallBlockSmallFlatAtmosphericThrust", 2},
			{"MyObjectBuilder_Thrust/SmallBlockSmallFlatAtmosphericThrustDShape",   2},
			{"MyObjectBuilder_Thrust/SmallBlockSmallFlatAtmosphericThrust2x", 8},
			{"MyObjectBuilder_Thrust/SmallBlockSmallFlatAtmosphericThrustDShape2x", 8},
			{"MyObjectBuilder_Thrust/SmallBlockSmallFlatAtmosphericThrust4x", 12},
			{"MyObjectBuilder_Thrust/SmallBlockSmallFlatAtmosphericThrustDShape4x", 12},
			{"MyObjectBuilder_Thrust/SmallBlockSmallFlatAtmosphericThrust8x", 16},
			{"MyObjectBuilder_Thrust/SmallBlockSmallFlatAtmosphericThrustDShape8x", 16},

//Hydrogen Thrusters
	//Hydrogen Thrust (Vanilla)
		//Large Block Large
			{"MyObjectBuilder_Thrust/LargeBlockLargeHydrogenThrust", 42},
			{"MyObjectBuilder_Thrust/LargeBlockLargeHydrogenThrust2x", 168},
			{"MyObjectBuilder_Thrust/LargeBlockLargeHydrogenThrust4x", 252},
			{"MyObjectBuilder_Thrust/LargeBlockLargeHydrogenThrust8x", 336},

		//Large Block Small
			{"MyObjectBuilder_Thrust/LargeBlockSmallHydrogenThrust", 6},
			{"MyObjectBuilder_Thrust/LargeBlockSmallHydrogenThrust2x", 24},
			{"MyObjectBuilder_Thrust/LargeBlockSmallHydrogenThrust4x", 36},
			{"MyObjectBuilder_Thrust/LargeBlockSmallHydrogenThrust8x", 48},

		//Small Block Large
			{"MyObjectBuilder_Thrust/SmallBlockLargeHydrogenThrust", 42},
			{"MyObjectBuilder_Thrust/SmallBlockLargeHydrogenThrust2x", 168},
			{"MyObjectBuilder_Thrust/SmallBlockLargeHydrogenThrust4x", 252},
			{"MyObjectBuilder_Thrust/SmallBlockLargeHydrogenThrust8x", 336},

		//Small Block Small
			{"MyObjectBuilder_Thrust/SmallBlockSmallHydrogenThrust", 6},	
			{"MyObjectBuilder_Thrust/SmallBlockSmallHydrogenThrust2x", 24},
			{"MyObjectBuilder_Thrust/SmallBlockSmallHydrogenThrust4x", 36},
			{"MyObjectBuilder_Thrust/SmallBlockSmallHydrogenThrust8x", 48},

	//Hydrogen Thrust (Industrial)
		//Large Block Large
			{"MyObjectBuilder_Thrust/LargeBlockLargeHydrogenThrustIndustrial", 42},
			{"MyObjectBuilder_Thrust/LargeBlockLargeHydrogenThrustIndustrial2x", 168},
			{"MyObjectBuilder_Thrust/LargeBlockLargeHydrogenThrustIndustrial4x", 252},
			{"MyObjectBuilder_Thrust/LargeBlockLargeHydrogenThrustIndustrial8x", 336},			

		//Large Block Small
			{"MyObjectBuilder_Thrust/LargeBlockSmallHydrogenThrustIndustrial", 6},
			{"MyObjectBuilder_Thrust/LargeBlockSmallHydrogenThrustIndustrial2x", 24},
			{"MyObjectBuilder_Thrust/LargeBlockSmallHydrogenThrustIndustrial4x", 36},			
			{"MyObjectBuilder_Thrust/LargeBlockSmallHydrogenThrustIndustrial8x", 48},

		//Small Block Large
			{"MyObjectBuilder_Thrust/SmallBlockLargeHydrogenThrustIndustrial", 42},
			{"MyObjectBuilder_Thrust/SmallBlockLargeHydrogenThrustIndustrial2x", 168},
			{"MyObjectBuilder_Thrust/SmallBlockLargeHydrogenThrustIndustrial4x", 252},			
			{"MyObjectBuilder_Thrust/SmallBlockLargeHydrogenThrustIndustrial8x", 336},

		//Small Block Small
			{"MyObjectBuilder_Thrust/SmallBlockSmallHydrogenThrustIndustrial", 6},	
			{"MyObjectBuilder_Thrust/SmallBlockSmallHydrogenThrustIndustrial2x", 24},	
			{"MyObjectBuilder_Thrust/SmallBlockSmallHydrogenThrustIndustrial4x", 36},	
			{"MyObjectBuilder_Thrust/SmallBlockSmallHydrogenThrustIndustrial8x", 48},	

//Ion Thrusters
	//Ion Thrust (Vanilla)
		//Large Block Large
			{"MyObjectBuilder_Thrust/LargeBlockLargeThrust", 42},
			{"MyObjectBuilder_Thrust/LargeBlockLargeThrust2x", 168},
			{"MyObjectBuilder_Thrust/LargeBlockLargeThrust4x", 252},
			{"MyObjectBuilder_Thrust/LargeBlockLargeThrust8x", 336},

		//Large Block Small
			{"MyObjectBuilder_Thrust/LargeBlockSmallThrust", 6},
			{"MyObjectBuilder_Thrust/LargeBlockSmallThrust2x", 24},
			{"MyObjectBuilder_Thrust/LargeBlockSmallThrust4x", 36},
			{"MyObjectBuilder_Thrust/LargeBlockSmallThrust8x", 48},			

		//Small Block Large
			{"MyObjectBuilder_Thrust/SmallBlockLargeThrust", 42},
			{"MyObjectBuilder_Thrust/SmallBlockLargeThrust2x", 168},
			{"MyObjectBuilder_Thrust/SmallBlockLargeThrust4x", 252},
			{"MyObjectBuilder_Thrust/SmallBlockLargeThrust8x", 336},

		//Small Block Small
			{"MyObjectBuilder_Thrust/SmallBlockSmallThrust", 6},	
			{"MyObjectBuilder_Thrust/SmallBlockSmallThrust2x", 24},
			{"MyObjectBuilder_Thrust/SmallBlockSmallThrust4x", 36},			
			{"MyObjectBuilder_Thrust/SmallBlockSmallThrust8x", 48},

	//Ion Thrust (SciFi)
		//Large Block Large
			{"MyObjectBuilder_Thrust/LargeBlockLargeThrustSciFi", 42},
			{"MyObjectBuilder_Thrust/LargeBlockLargeThrustSciFi2x", 168},
			{"MyObjectBuilder_Thrust/LargeBlockLargeThrustSciFi4x", 252},
			{"MyObjectBuilder_Thrust/LargeBlockLargeThrustSciFi8x", 336},

		//Large Block Small
			{"MyObjectBuilder_Thrust/LargeBlockSmallThrustSciFi", 6},
			{"MyObjectBuilder_Thrust/LargeBlockSmallThrustSciFi2x", 24},
			{"MyObjectBuilder_Thrust/LargeBlockSmallThrustSciFi4x", 36},			
			{"MyObjectBuilder_Thrust/LargeBlockSmallThrustSciFi8x", 48},

		//Small Block Large
			{"MyObjectBuilder_Thrust/SmallBlockLargeThrustSciFi", 42},
			{"MyObjectBuilder_Thrust/SmallBlockLargeThrustSciFi2x", 168},
			{"MyObjectBuilder_Thrust/SmallBlockLargeThrustSciFi4x", 252},
			{"MyObjectBuilder_Thrust/SmallBlockLargeThrustSciFi8x", 336},			

		//Small Block Small
			{"MyObjectBuilder_Thrust/SmallBlockSmallThrustSciFi", 6},	
			{"MyObjectBuilder_Thrust/SmallBlockSmallThrustSciFi2x", 24},	
			{"MyObjectBuilder_Thrust/SmallBlockSmallThrustSciFi4x", 36},	
			{"MyObjectBuilder_Thrust/SmallBlockSmallThrustSciFi8x", 48},	

	//Ion Thrust (Warfare 2)
		//Large Block Large
			{"MyObjectBuilder_Thrust/LargeBlockLargeModularThruster", 42},
			{"MyObjectBuilder_Thrust/LargeBlockLargeModularThruster2x", 168},
			{"MyObjectBuilder_Thrust/LargeBlockLargeModularThruster4x", 252},
			{"MyObjectBuilder_Thrust/LargeBlockLargeModularThruster8x", 336},

		//Large Block Small
			{"MyObjectBuilder_Thrust/LargeBlockSmallModularThruster", 6},
			{"MyObjectBuilder_Thrust/LargeBlockSmallModularThruster2x", 24},
			{"MyObjectBuilder_Thrust/LargeBlockSmallModularThruster4x", 36},
			{"MyObjectBuilder_Thrust/LargeBlockSmallModularThruster8x", 48},			

		//Small Block Large
			{"MyObjectBuilder_Thrust/SmallBlockLargeModularThruster", 42},
			{"MyObjectBuilder_Thrust/SmallBlockLargeModularThruster2x", 168},
			{"MyObjectBuilder_Thrust/SmallBlockLargeModularThruster4x", 252},
			{"MyObjectBuilder_Thrust/SmallBlockLargeModularThruster8x", 336},			

		//Small Block Small
			{"MyObjectBuilder_Thrust/SmallBlockSmallModularThruster", 6},	
			{"MyObjectBuilder_Thrust/SmallBlockSmallModularThruster2x", 24},
			{"MyObjectBuilder_Thrust/SmallBlockSmallModularThruster4x", 36},
			{"MyObjectBuilder_Thrust/SmallBlockSmallModularThruster8x", 48},

		};

        public static Config Load()
        {
            Config config = new Config();
			config.PCUConfig = DefaultConfig;

            try
            {
                if (MyAPIGateway.Utilities.FileExistsInWorldStorage(Filename, typeof(Config)))
                {
                    MyLog.Default.WriteLineAndConsole("Loading saved pcu config");
                    TextReader reader = MyAPIGateway.Utilities.ReadFileInWorldStorage(Filename, typeof(Config));
                    string text = reader.ReadToEnd();
                    reader.Close();

                    config.pveZone = bool.Parse(Deser(text)["pveZone"]);
                }
                else
                {
                   MyLog.Default.WriteLineAndConsole("PCU config file not found. Loading default config");
                   Save(config);
                }
            }
            catch (Exception e)
            {
                MyLog.Default.WriteLineAndConsole($"Failed to load saved pcu configuration. Loading defaults\n {e.ToString()}");
                Save(config);
            }

            return config;
        }

        public static void Save(Config config)
        {
            try
            {
                MyLog.Default.WriteLineAndConsole("Saving pcu config");
                TextWriter writer = MyAPIGateway.Utilities.WriteFileInWorldStorage(Filename, typeof(Config));
                writer.Write($"pveZone={config.pveZone}");
                writer.Close();
            }
            catch (Exception e)
            {
                MyLog.Default.WriteLineAndConsole($"Failed to save pcu config\n{e.ToString()}");
            }
        }
		
/* 		public static string Ser(Dictionary<string, int> config) {
			var sb = new StringBuilder();
			foreach (var entry in config) {
				sb.AppendLine($"{entry.Key}={entry.Value}");
			}
			
			return sb.ToString();
		} */
		
		public static Dictionary<string, string> Deser(string configString) {
			var config = new Dictionary<string, string>();
			
			foreach (string line in configString.Split(new[] {"\n", "\r\n"}, StringSplitOptions.None)) {
				string[] parts = line.Split('=');
				if (parts.Count() < 2) {
					continue;
				}
				config[parts[0]] = parts[1];
			}
			
			return config;
		}
    }
}
