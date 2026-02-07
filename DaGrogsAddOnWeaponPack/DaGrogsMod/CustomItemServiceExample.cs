using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Services.Mod;

namespace _DaGrogsAddOnWeaponPack;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.sp-tarkov.examples.DaGrogsAddOnWeaponPack";
    public override string Name { get; init; } = "DaGrogsAddOnWeaponPack";
    public override string Author { get; init; } = "CarbonBased";
    public override List<string>? Contributors { get; init; }
    public override SemanticVersioning.Version Version { get; init; } = new("1.0.0");
    public override SemanticVersioning.Range SptVersion { get; init; } = new("~4.0.0");
    
    
    public override List<string>? Incompatibilities { get; init; }
    public override Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; }
    public override string? Url { get; init; }
    public override bool? IsBundleMod { get; init; }
    public override string? License { get; init; } = "MIT";
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemServiceAutoDeagle(
    ISptLogger<CustomItemService> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.PISTOL_MAGNUM_RESEARCH_DESERT_EAGLE_L6_50_AE_PISTOL_WTS,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5447b5cf4bdc2d65278b4567",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "69350c4f124113667535f7bc",
            // Flea price of item
            FleaPriceRoubles = 40000,
            // Price of item in handbook
            HandbookPriceRoubles = 40000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f792486f77447ed5636b3",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "(Modified) Magnum Research Desert Eagle L6 .50 AE pistol (WTS)",
                        ShortName = "Auto D50",
                        Description =
                            "A WTS L6 Desert Eagle modified to fire .50 AE cartridges in fully automatic. Stylish and high recoil."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                WeapFireType = ["single", "fullauto"],
                BFirerate = 600
            }
        };
            
            
            customItemService.CreateItemFromClone(exampleCloneItem
            ); // Send our data to the function that creates our item

            return Task.CompletedTask;
        }
    }

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemServiceDeagleExtMag(
    ISptLogger<CustomItemService> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MAGAZINE_127X33_DE_7RND,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5448bc234bdc2d3c308b4569",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "69350ec2124113667535f7bd",
            // Flea price of item
            FleaPriceRoubles = 8000,
            // Price of item in handbook
            HandbookPriceRoubles = 8000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f754a86f774094242f19b",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "Extended 15 Round .50 AE Desert Eagle Magazine",
                        ShortName = "D50 15 Mag",
                        Description =
                            "A modified Desert Eagle magazine that can hold 15 cartridges of .50 AE."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                Cartridges = [ 
                    new Slot
                    {
                        Name = "cartridges",
                        Id = "668fe5c5f35310705d02b698",
                        Parent = "668fe5c5f35310705d02b696",
                        MaxCount = 15,
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                        "668fe62ac62660a5d8071446",
                        "66a0d1e0ed648d72fe064d06",
                        "66a0d1c87d0d369e270bb9de",
                        "66a0d1f88486c69fce00fdf6"
                                    ]
                                }
                            ]
                        },
                        Prototype = "5748538b2459770af276a261",
                    }
                ],
                Height = 2
            }
        };
            
            
            customItemService.CreateItemFromClone(exampleCloneItem
            ); // Send our data to the function that creates our item

            return Task.CompletedTask;
        }
    }

    [Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService50AESR25(
    ISptLogger<CustomItemService> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MARKSMANRIFLE_KNIGHTS_ARMAMENT_COMPANY_SR25_762X51_MARKSMAN_RIFLE,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5447b6194bdc2d67278b4567",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "69351696124113667535f7be",
            // Flea price of item
            FleaPriceRoubles = 50000,
            // Price of item in handbook
            HandbookPriceRoubles = 50000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f791486f774093f2ed3be",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "Knights Armaments Company SR-50 .50 AE Combat Rifle",
                        ShortName = "SR-50",
                        Description =
                            "A KAC SR-50 Combat Rifle with a 3 position fire selector module designed to provide a rifle platform for the .50AE cartridge."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                Chambers = [ 
                    new Slot
                    {
                        Name = "patron_in_weapon",
                        Id = "668fe5c5f35310705d02b698",
                        Parent = "668fe5c5f35310705d02b696",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                        "668fe62ac62660a5d8071446",
                        "66a0d1e0ed648d72fe064d06",
                        "66a0d1c87d0d369e270bb9de",
                        "66a0d1f88486c69fce00fdf6"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d4af244bdc2d962f8b4571",
                    }
                ],
                WeapFireType = ["single",
                "fullauto"],
                BFirerate = 700,
                RecoilForceBack = 370,
                RecoilForceUp = 200,
                Ergonomics = 60,
                HeatFactorByShot = 1.4,
                CoolFactorGun = 1.5,
                DefAmmo = "668fe62ac62660a5d8071446",
                AmmoCaliber = "Caliber127x33"
            }
        };
            
            
            customItemService.CreateItemFromClone(exampleCloneItem
            ); // Send our data to the function that creates our item

            return Task.CompletedTask;
        }
    }
    
    [Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService50AESR25Mag(
    ISptLogger<CustomItemService> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MAGAZINE_762X51_KAC_762_20RND,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5448bc234bdc2d3c308b4569",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "69351a47124113667535f7bf",
            // Flea price of item
            FleaPriceRoubles = 6000,
            // Price of item in handbook
            HandbookPriceRoubles = 6000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f754a86f774094242f19b",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "KAC 30 Round .50 AE SR-50 Magazine",
                        ShortName = "SR50 30",
                        Description =
                            "A KAC SR-50 Combat Rifle 30 round magazine for the .50AE cartridge."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                Cartridges = [ 
                    new Slot
                    {
                        Name = "cartridges",
                        Id = "5df8f541c41b2312ea3335e5",
                        Parent = "5df8f541c41b2312ea3335e3",
                        MaxCount = 30,
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                        "668fe62ac62660a5d8071446",
                        "66a0d1e0ed648d72fe064d06",
                        "66a0d1c87d0d369e270bb9de",
                        "66a0d1f88486c69fce00fdf6"
                                    ]
                                }
                            ]
                        },
                        Prototype = "5748538b2459770af276a261",
                    }
                ],
                LoadUnloadModifier = -15,
                CheckTimeModifier = -15,
                Ergonomics = -2,
                Weight = 0.32
            }
        };
            
            
            customItemService.CreateItemFromClone(exampleCloneItem
            ); // Send our data to the function that creates our item

            return Task.CompletedTask;
        }
    }
[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService50NitroRifle(
	ISptLogger<CustomItemService> logger,
	CustomItemService customItemService) : IOnLoad
{

	public Task OnLoad()
	{
		//Example of adding new item by cloning an existing item using `createCloneDetails`
		var exampleCloneItem = new NewItemFromCloneDetails
		{
			ItemTplToClone = ItemTpl.SHOTGUN_MP431C_12GA_DOUBLEBARREL,
			// ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
			ParentId = "5447b6194bdc2d67278b4567",
			// The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
			NewId = "693dbae73d12cdff77867933",
			// Flea price of item
			FleaPriceRoubles = 100000,
			// Price of item in handbook
			HandbookPriceRoubles = 100000,
			// Handbook Parent Id refers to the category the gun will be under
			HandbookParentId = "5b5f791486f774093f2ed3be",
			//you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
			Locales = new Dictionary<string, LocaleDetails>
			{
				{
					"en", new LocaleDetails
					{
						Name = "MP-50BMG Nitro Double Rifle",
						ShortName = "Nitro",
						Description =
							"A Double Barrel Rifle built on the MP-43 Platform. Rebuilt and reinforced to handle .50 BMG cartridges, similar to Hunting Nitro Express Rifles. For taking down the biggest trophy monsters Tarkov has to offer."
					}
				}
			},
			OverrideProperties = new TemplateItemProperties
			{
                Weight = 4,
                CanSellOnRagfair = true,
                Ergonomics = 40,
                RecoilForceBack = 1200,
                RecoilForceUp = 700,
                SingleFireRate = 500,
                AmmoCaliber = "Caliber127x99",
                DefAmmo = "67dc255ee3028a8b120efc48",
                BEffDist = 1000,
                BHearDist = 200,
                Slots =  [ new Slot
	                {
		                Name = "mod_stock",
		                Id = "611a35095b7ffe001b4649d3",
		                Parent = "5580223e4bdc2d1c128b457f",
		                Properties = new SlotProperties
		                {
			                Filters = 
			                [
				                new SlotFilter
				                {
					                Filter = 
					                [
						                "611a31ce5b7ffe001b4649d1"
					                ]
				                }
			                ]
		                },
		                Required = false,
		                MergeSlotWithChildren = false,
		                Prototype = "55d30c4c4bdc2db4468b457e",
	                },
	                new Slot {
	                Name = "mod_barrel",
	                Id = "55d5a27c4bdc2d8c2f8b456f",
	                Parent = "5580223e4bdc2d1c128b457f",
	                Properties = new SlotProperties
	                {
		                Filters = 
		                [
			                new SlotFilter
			                {
				                Filter = 
				                [
					                "693db97f3d12cdff77867931"
				                ]
			                }
		                ]
	                },
	                Required = true,
	                MergeSlotWithChildren = false,
	                Prototype = "55d30c4c4bdc2db4468b457e",
	                }
                ],
                Chambers = [ new Slot
	                {
		                Name = "patron_in_weapon_000",
		                Id = "56eaa954d2720b7c698b4571",
		                Parent = "5580223e4bdc2d1c128b457f",
		                Properties = new SlotProperties
		                {
			                Filters = 
			                [
				                new SlotFilter
				                {
					                Filter = 
					                [
						                "67d41936f378a36c4706eeb9",
						                "67dc212493ce32834b0fa446",
						                "67dc255ee3028a8b120efc48",
						                "67dc2648ba5b79876906a166"
					                ]
				                }
			                ]
		                },
		                Required = false,
		                MergeSlotWithChildren = false,
		                Prototype = "55d4af244bdc2d962f8b4571",
	                },
	                new Slot
	                {
		                Name = "patron_in_weapon_001",
		                Id = "56eaa95ed2720b69698b456e",
		                Parent = "5580223e4bdc2d1c128b457f",
		                Properties = new SlotProperties
		                {
			                Filters = 
			                [
				                new SlotFilter
				                {
					                Filter = 
					                [
						                "67d41936f378a36c4706eeb9",
						                "67dc212493ce32834b0fa446",
						                "67dc255ee3028a8b120efc48",
						                "67dc2648ba5b79876906a166"
					                ]
				                }
			                ]
		                },
		                Required = false,
		                MergeSlotWithChildren = false,
		                Prototype = "55d4af244bdc2d962f8b4571",
	                }
                ]
			},
		
		};

		customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item

		return Task.CompletedTask;
	}
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService50NitroBarrel(
	ISptLogger<CustomItemService> logger,
	CustomItemService customItemService) : IOnLoad
{

	public Task OnLoad()
	{
		//Example of adding new item by cloning an existing item using `createCloneDetails`
		var exampleCloneItem = new NewItemFromCloneDetails
		{
			ItemTplToClone = ItemTpl.BARREL_MP43_12GA_750MM,
			// ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
			ParentId = "555ef6e44bdc2de9068b457e",
			// The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
			NewId = "693db97f3d12cdff77867931",
			// Flea price of item
			FleaPriceRoubles = 50000,
			// Price of item in handbook
			HandbookPriceRoubles = 50000,
			// Handbook Parent Id refers to the category the gun will be under
			HandbookParentId = "5b5f75c686f774094242f19f",
			//you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
			Locales = new Dictionary<string, LocaleDetails>
			{
				{
					"en", new LocaleDetails
					{
						Name = "MP-50BMG Nitro Double Rifle Barrel Assembly",
						ShortName = "50NitroBarrel",
						Description =
							"A reworked barrel for the MP-50BMG Nitro Double Rifle, intended to provide accurate and reliable fire of .50 BMG cartridges for hunting purposes."
					}
				}
			},
			OverrideProperties = new TemplateItemProperties
			{
                Weight = 6,
                Ergonomics = -25,
                CanSellOnRagfair = true,
                Recoil = 0,
                Velocity = 10,
                CenterOfImpact = 0.02,
                DurabilityBurnModificator = 0.5,
                shotgunDispersion = 0
			},
		};

		customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item

		return Task.CompletedTask;
	}
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemServiceAA20(
    ISptLogger<CustomItemServiceAA20> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.SHOTGUN_MPS_AUTO_ASSAULT12_GEN_2_12GA_AUTOMATIC,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5447b6094bdc2dc3278b4567",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "691a1a18d8de5e14a7771d93",
            // Flea price of item
            FleaPriceRoubles = 10000,
            // Price of item in handbook
            HandbookPriceRoubles = 10000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f794b86f77409407a7f92",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "MPS Auto Assault-20 Gen 2 20ga Automatic Shotgun",
                        ShortName = "AA-20 Gen2",
                        Description = "The AA-20 (Auto Assault-20) is a reliable full-auto 20-gauge shotgun. The second generation features a mount for installing optics. This shotgun is distinguished by its recoil pulse accumulation, which makes the recoil feel smooth without sacrificing fire rate and stopping power. The AA-20 is designed for military and police units. Manufactured by Military Police Systems. The use of 20 gauge shells reduces recoil and weight compared to the 12 gauge version, improving handling."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
             Ergonomics   = 58,
             Weight = 1.9,
             Width = 3,
             RecoilForceBack = 190,
             RecoilForceUp = 130,
             BFirerate = 450,
             AmmoCaliber = "Caliber20g"
             
            }
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemServiceAA20Mag(
    ISptLogger<CustomItemServiceAA20Mag> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MAGAZINE_12G_AA12_20RND,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5448bc234bdc2d3c308b4569",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "691a220ad8de5e14a7771d94",
            // Flea price of item
            FleaPriceRoubles = 10000,
            // Price of item in handbook
            HandbookPriceRoubles = 10000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f754a86f774094242f19b",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "MPS Auto Assault-20 20 Round Drum",
                        ShortName = "AA-20 Drum",
                        Description = "A 20 Round Drum Magazine for the MPS AA-20 (Auto Assault-20) full-auto 20-gauge shotgun. "
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                Width = 1,
                Weight = 1,
                Ergonomics = -10,
                LoadUnloadModifier = -5,
                CheckTimeModifier = -50,
                MalfunctionChance = 0.03,
                Cartridges = 
                [
                    new Slot
                    {
                        Name = "cartridges",
                        Id = "6709133fa532466d5403fb7e",
                        Parent = "AA-20 Gen2",
                        MaxCount = 20,
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5a38ebd9c4a282000d722a5b",
                                        "5d6e695fa4b936359b35d852",
                                        "5d6e69b9a4b9361bc8618958",
                                        "5d6e69c7a4b9360b6c0d54e4",
                                        "5d6e6a5fa4b93614ec501745",
                                        "5d6e6a53a4b9361bd473feec",
                                        "5d6e6a42a4b9364f07165f52",
                                        "5d6e6a05a4b93618084f58d0",
                                        "6601380580e77cfd080e3418",
                                        "660137d8481cc6907a0c5cda",
                                        "660137ef76c1b56143052be8"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "5748538b2459770af276a261"
                    }
                ]
            } 
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemServiceSaiga20(
    ISptLogger<CustomItemServiceSaiga20> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {

        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.SHOTGUN_SAIGA12K_VER10_12GA_SEMIAUTOMATIC,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5447b6094bdc2dc3278b4567",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "69191fe6f7555679b84d980a",
            // Flea price of item
            FleaPriceRoubles = 10000,
            // Price of item in handbook
            HandbookPriceRoubles = 10000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f794b86f77409407a7f92",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "Saiga-20 20 Gauge Shotgun (Semi-Automatic)",
                        ShortName = "Saiga20G",
                        Description =
                            "A 20 Gauge Saiga platform self loading shotgun. Lighter and easier to handle compared to the 12 gauge versions."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                AmmoCaliber = "Caliber20g",
                Ergonomics = 47,
                RecoilForceBack = 390,
                RecoilForceUp = 215,
                HeatFactorByShot = 3.7,
                Width = 3,
                Weight = 1.9,
                Slots =
                [
                    new Slot
                    {
                        Name = "mod_mount_000",
                        Id = "576166c92459773ccd7031c7",
                        Parent = "69191fe6f7555679b84d980a",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5947db3f86f77447880cf76f",
                                        "6113d6c3290d254f5e6b27db",
                                        "57486e672459770abd687134",
                                        "618a5d5852ecee1505530b2a",
                                        "5c82342f2e221644f31c060e",
                                        "576fd4ec2459777f0b518431",
                                        "5c82343a2e221644f31c0611",
                                        "5cf638cbd7f00c06595bc936",
                                        "5a7c74b3e899ef0014332c29",
                                        "591ee00d86f774592f7b841e",
                                        "5d0a29ead7ad1a0026013f27",
                                        "618a75c9a3884f56c957ca1b",
                                        "57acb6222459771ec34b5cb0",
                                        "5c61a40d2e2216001403158d",
                                        "5c90c3622e221601da359851",
                                        "638db77630c4240f9e06f8b6",
                                        "63d114019e35b334d82302f7",
                                        "6544d4187c5457729210d277",
                                        "65f1b1176dbd6c5ba2082eed"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_handguard",
                        Id = "57616d962459773c7a400235",
                        Parent = "69191fe6f7555679b84d980a",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5f63418ef5750b524b45f116",
                                        "6086b5731246154cad35d6c7",
                                        "576169e62459773c69055191",
                                        "5827272a24597748c74bdeea",
                                        "58272b392459774b4c7b3ccd",
                                        "674fe57721a9aa6be6045b96",
                                        "5cf4e3f3d7f00c06595bc7f0",
                                        "5648ae314bdc2d3d1c8b457f",
                                        "5d2c829448f0353a5c7d6674",
                                        "5b800e9286f7747a8b04f3ff",
                                        "5b80242286f77429445e0b47",
                                        "5cbda392ae92155f3c17c39f",
                                        "5cbda9f4ae9215000e5b9bfc",
                                        "5648b0744bdc2d363b8b4578",
                                        "5648b1504bdc2d9d488b4584",
                                        "59d64f2f86f77417193ef8b3",
                                        "57cff947245977638e6f2a19",
                                        "57cffd8224597763b03fc609",
                                        "57cffddc24597763133760c6",
                                        "57cffe0024597763b03fc60b",
                                        "57cffe20245977632f391a9d",
                                        "5c9a07572e221644f31c4b32",
                                        "5c9a1c3a2e2216000e69fb6a",
                                        "5c9a1c422e221600106f69f0",
                                        "59e6284f86f77440d569536f",
                                        "59e898ee86f77427614bd225",
                                        "5a9d56c8a2750c0032157146",
                                        "5d1b198cd7ad1a604869ad72",
                                        "5d4aaa73a4b9365392071175",
                                        "5d4aaa54a4b9365392071170",
                                        "5f6331e097199b7db2128dc2",
                                        "5c17664f2e2216398b5a7e3c",
                                        "5c617a5f2e2216000f1e81b3",
                                        "5648b4534bdc2d3d1c8b4580",
                                        "5efaf417aeb21837e749c7f2",
                                        "6389f1dfc879ce63f72fc43e",
                                        "647dba3142c479dde701b654"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_muzzle",
                        Id = "57616dbd2459773c7a400236",
                        Parent = "69191fe6f7555679b84d980a",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "58272d7f2459774f6311ddfd",
                                        "59fb137a86f7740adb646af1",
                                        "576167ab2459773cad038c43",
                                        "5b363e1b5acfc4771e1c5e80",
                                        "59c0ec5b86f77435b128bfca",
                                        "670fd1cc95c92bfc8e0bea39",
                                        "619d36da53b4d42ee724fae4"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_pistol_grip",
                        Id = "57616dcf2459773ccd7031ca",
                        Parent = "69191fe6f7555679b84d980a",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5f6341043ada5942720e2dc5",
                                        "6087e663132d4d12c81fd96b",
                                        "5beec8ea0db834001a6f9dbf",
                                        "5649ad3f4bdc2df8348b4585",
                                        "5649ade84bdc2d1b2b8b4587",
                                        "59e62cc886f77440d40b52a1",
                                        "5a0071d486f77404e23a12b2",
                                        "57e3dba62459770f0c32322b",
                                        "5cf54404d7f00c108840b2ef",
                                        "5e2192a498a36665e8337386",
                                        "5b30ac585acfc433000eb79c",
                                        "59e6318286f77444dd62c4cc",
                                        "5cf50850d7f00c056e24104c",
                                        "5cf508bfd7f00c056e24104e",
                                        "5947f92f86f77427344a76b1",
                                        "5947fa2486f77425b47c1a9b",
                                        "5c6bf4aa2e2216001219b0ae",
                                        "5649ae4a4bdc2d1b2b8b4588",
                                        "5998517986f7746017232f7e",
                                        "623c3be0484b5003161840dc",
                                        "628c9ab845c59e5b80768a81",
                                        "628a664bccaab13006640e47",
                                        "63f4da90f31d4a33b87bd054",
                                        "648ae3e356c6310a830fc291",
                                        "651580dc71a4f10aec4b6056"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_reciever",
                        Id = "57616ddc2459773c687dcdc3",
                        Parent = "69191fe6f7555679b84d980a",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "57616c112459773cce774d66",
                                        "676017fe8cfeeba9f707c8d6"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_sight_rear",
                        Id = "57616ded2459773cce774d67",
                        Parent = "69191fe6f7555679b84d980a",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "58272b842459774abc128d50",
                                        "57a9b9ce2459770ee926038d",
                                        "5649d9a14bdc2d79388b4580",
                                        "5bfebc530db834001d23eb65",
                                        "57ffb0062459777a045af529"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_stock",
                        Id = "57616e062459773c7a400237",
                        Parent = "69191fe6f7555679b84d980a",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5cf50fc5d7f00c056c53f83c",
                                        "5ac78eaf5acfc4001926317a",
                                        "5beec8b20db834001961942a",
                                        "57616ca52459773c69055192",
                                        "5649b1c04bdc2d16268b457c",
                                        "59d6514b86f774171a068a08",
                                        "59e6227d86f77440d64f5dc2",
                                        "59e89d0986f77427600d226e",
                                        "66ac9d9740e27931602042d4",
                                        "57dc347d245977596754e7a1",
                                        "5e217ba4c1434648c13568cd",
                                        "5cbdb1b0ae9215000d50e105",
                                        "5b04473a5acfc40018632f70"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_magazine",
                        Id = "57616e1f2459773cae04eae5",
                        Parent = "69191fe6f7555679b84d980a",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "6919280af7555679b84d980b"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c394bdc2dae468b4577",
                    },
                    new Slot
                    {
                        Name = "mod_charge",
                        Id = "57616f1e2459775d4d100241",
                        Parent = "69191fe6f7555679b84d980a",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "6130ca3fd92c473c77020dbd",
                                        "5648ac824bdc2ded0b8b457d"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_mount_001",
                        Id = "67162f402a35d090a30f6c2d",
                        Parent = "69191fe6f7555679b84d980a",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "6710cea62bb09af72f0e6bf8",
                                        "55d48ebc4bdc2d8c2f8b456c"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    }
                ],
                Chambers =
                [
                    new Slot
                    {
                        Name = "patron_in_weapon",
                        Id = "57616e2e2459773c362ab462",
                        Parent = "Saiga20G",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5a38ebd9c4a282000d722a5b",
                                        "5d6e695fa4b936359b35d852",
                                        "5d6e69b9a4b9361bc8618958",
                                        "5d6e69c7a4b9360b6c0d54e4",
                                        "5d6e6a5fa4b93614ec501745",
                                        "5d6e6a53a4b9361bd473feec",
                                        "5d6e6a42a4b9364f07165f52",
                                        "5d6e6a05a4b93618084f58d0",
                                        "6601380580e77cfd080e3418",
                                        "660137d8481cc6907a0c5cda",
                                        "660137ef76c1b56143052be8"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d4af244bdc2d962f8b4571"
                    }
                ]
            },
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item

        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemServiceSaiga20Mag(
    ISptLogger<CustomItemServiceSaiga20Mag> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MAGAZINE_12G_SAI02_10RND,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5448bc234bdc2d3c308b4569",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "6919280af7555679b84d980b",
            // Flea price of item
            FleaPriceRoubles = 3000,
            // Price of item in handbook
            HandbookPriceRoubles = 3000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f754a86f774094242f19b",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "SOK-20 20ga SAI-03 8-Round Magazine",
                        ShortName = "SOK20",
                        Description = "The SAI-03 is a 8-round polymer magazine for the Saiga 20 gauge platform weapons, intended for use with 20/76 or 20/70 shells. Manufactured by ProMag."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                Height = 2,
                ExtraSizeDown = 1,
                Weight = 0.14,
                Ergonomics = -2,
                LoadUnloadModifier = -17.5,
                MalfunctionChance = 0.02,
                CheckTimeModifier = -25,
                Cartridges = 
                [
                    new Slot
                    {
                        Name = "cartridges",
                        Id = "5a966f51a2750c00156aacf8",
                        Parent = "69191fe6f7555679b84d980a",
                        MaxCount = 8,
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5a38ebd9c4a282000d722a5b",
                                        "5d6e695fa4b936359b35d852",
                                        "5d6e69b9a4b9361bc8618958",
                                        "5d6e69c7a4b9360b6c0d54e4",
                                        "5d6e6a5fa4b93614ec501745",
                                        "5d6e6a53a4b9361bd473feec",
                                        "5d6e6a42a4b9364f07165f52",
                                        "5d6e6a05a4b93618084f58d0",
                                        "6601380580e77cfd080e3418",
                                        "660137d8481cc6907a0c5cda",
                                        "660137ef76c1b56143052be8"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "5748538b2459770af276a261"
                    }
                ]
            },
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService918ASVAL(
    ISptLogger<CustomItemService918ASVAL> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.ASSAULTCARBINE_AS_VAL_9X39_SPECIAL_ASSAULT_RIFLE,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5447b5fc4bdc2d87278b4567",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "68fee98c924d1a1be07759a4",
            // Flea price of item
            FleaPriceRoubles = 2000,
            // Price of item in handbook
            HandbookPriceRoubles = 1500,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f78e986f77447ed5636b1",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "9x18mm Converted AS VAL Special Assault Carbine",
                        ShortName = "VAL PCC",
                        Description = "An AS VAL carbine converted to fire 9x18mm cartridges. Improves rate of fire, recoil, ergonomics, durability, and weight."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                BFirerate = 950,
                Weight = 0.5,
                Width = 1,
                Ergonomics = 63,
                HeatFactorByShot = 1.1,
                HeatFactorGun = 1,
                CoolFactorGun = 3.2,
                MaxRepairDegradation = 0.02,
                MaxRepairKitDegradation = 0.015,
                RecoilForceBack = 190,
                RecoilForceUp = 60,
                AmmoCaliber = "Caliber9x18",
                Chambers =
                [
                    new Slot
                    {
                        Name = "patron_in_weapon",
                        Id = "57c44c7c2459772d28133240",
                        Parent = "68fee98c924d1a1be07759a4",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "573718ba2459775a75491131",
                                        "573719df2459775a626ccbc2",
                                        "57371aab2459775a77142f22",
                                        "57371b192459775a9f58a5e0",
                                        "57371e4124597760ff7b25f1",
                                        "57371eb62459776125652ac1",
                                        "57371f8d24597761006c6a81",
                                        "5737201124597760fc4431f1",
                                        "5737207f24597760ff7b25f2",
                                        "57371f2b24597761224311f1",
                                        "573719762459775a626ccbc1",
                                        "573720e02459776143012541",
                                        "57372140245977611f70ee91",
                                        "5737218f245977612125ba51"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d4af244bdc2d962f8b4571"
                    },
                    ],
                Slots = [
                    new Slot
                    {
                        Name = "mod_muzzle",
                        Id = "57c44cb62459772d2d75e37f",
                        Parent = "68fee98c924d1a1be07759a4",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "57c44dd02459772d2e0ae249",
                                        "57838c962459774a1651ec63",
                                        "56e05b06d2720bb2668b4586",
                                        "5a9fb739a2750c003215717f"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_reciever",
                        Id = "57c44ce02459772d2b39b8d4",
                        Parent = "68fee98c924d1a1be07759a4",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "57c44f4f2459772d2c627113",
                                        "578395402459774a256959b5"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_magazine",
                        Id = "57c44cec2459772d303d899c",
                        Parent = "68fee98c924d1a1be07759a4",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "68fef34a924d1a1be07759a5"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c394bdc2dae468b4577",
                    },
                    new Slot
                    {
                        Name = "mod_pistol_grip",
                        Id = "57c44cf92459772d2b39b8d5",
                        Parent = "68fee98c924d1a1be07759a4",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "5a69a2ed8dc32e000d46d1f1",
                                        "57c44fa82459772d2d75e415",
                                        "6565b91666492762f5029c0b"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_stock",
                        Id = "57c44d062459772d28133242",
                        Parent = "68fee98c924d1a1be07759a4",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "57c450252459772d28133253",
                                        "668672b8c99550c6fd0f0b29",
                                        "66881008f23233ee9a0742e7"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                                            {
                                            Name = "mod_charge",
                                            Id = "57c44d162459772d2f482f38",
                                            Parent = "68fee98c924d1a1be07759a4",
                                            Properties = new SlotProperties
                                            {
                                                Filters = 
                                                    [
                                                        new SlotFilter
                                                        {
                                                            Filter = 
                                                                [
                                                                    "6130ca3fd92c473c77020dbd",
                                                                    "5648ac824bdc2ded0b8b457d"
                                                                ]
                                                        }
                                                    ]
                                            },
                                            Required = false,
                                            MergeSlotWithChildren = false,
                                            Prototype = "55d30c4c4bdc2db4468b457e",
                                            },
                    new Slot
                    {
                        Name = "mod_mount_004",
                        Id = "57c452612459772d2d75e495",
                        Parent = "68fee98c924d1a1be07759a4",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "5947db3f86f77447880cf76f",
                                        "6113d6c3290d254f5e6b27db",
                                        "57486e672459770abd687134",
                                        "618a5d5852ecee1505530b2a",
                                        "5cf638cbd7f00c06595bc936",
                                        "5a7c74b3e899ef0014332c29",
                                        "591ee00d86f774592f7b841e",
                                        "5e569a2e56edd02abe09f280",
                                        "5d0a29ead7ad1a0026013f27",
                                        "618a75c9a3884f56c957ca1b",
                                        "57acb6222459771ec34b5cb0",
                                        "5c61a40d2e2216001403158d",
                                        "5c90c3622e221601da359851",
                                        "638db77630c4240f9e06f8b6",
                                        "6544d4187c5457729210d277",
                                        "65f1b1176dbd6c5ba2082eed"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_mount_000",
                        Id = "57c4526f2459772d291a83e9",
                        Parent = "68fee98c924d1a1be07759a4",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "5c82342f2e221644f31c060e",
                                        "576fd4ec2459777f0b518431",
                                        "5c82343a2e221644f31c0611",
                                        "5dff8db859400025ea5150d4",
                                        "67069c8cee8138ed2f05ad34",
                                        "67069cbbb29a2cd33803338c"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_handguard",
                        Id = "6511786c1b90b4fc77015073",
                        Parent = "68fee98c924d1a1be07759a4",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "651178336cad06c37c049eb4",
                                        "6565bb7eb4b12a56eb04b084"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "",
                    }
                ]
            }
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService918ASVALMag(
    ISptLogger<CustomItemService918ASVALMag> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MAGAZINE_9X39_6L25_20RND,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5448bc234bdc2d3c308b4569",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "68fef34a924d1a1be07759a5",
            // Flea price of item
            FleaPriceRoubles = 3000,
            // Price of item in handbook
            HandbookPriceRoubles = 3000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f754a86f774094242f19b",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "Modified 6L25 35 Round Magazine",
                        ShortName = "Mod 6L25",
                        Description = "A 6L25 Magazine modified to hold and feed 35 9x18mm cartridges."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                ExtraSizeDown = 0,
                Ergonomics = 0,
                Weight = 0.1,
                LoadUnloadModifier = -25,
                MalfunctionChance = 0.05,
                DurabilityBurnModificator = 0.8,
                Cartridges = 
                [
                    new Slot
                    {
                        Name = "cartridges",
                        Id = "57838fae2459774a0d5f2fed",
                        Parent = "68fef34a924d1a1be07759a5",
                        MaxCount = 35,
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "573718ba2459775a75491131",
                                        "573719df2459775a626ccbc2",
                                        "57371aab2459775a77142f22",
                                        "57371b192459775a9f58a5e0",
                                        "57371e4124597760ff7b25f1",
                                        "57371eb62459776125652ac1",
                                        "57371f8d24597761006c6a81",
                                        "5737201124597760fc4431f1",
                                        "5737207f24597760ff7b25f2",
                                        "57371f2b24597761224311f1",
                                        "573719762459775a626ccbc1",
                                        "573720e02459776143012541",
                                        "57372140245977611f70ee91",
                                        "5737218f245977612125ba51"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d4af244bdc2d962f8b4571"
                    }
                ]
            },
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService9MMM60(
    ISptLogger<CustomItemService9MMM60> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MACHINEGUN_US_ORDNANCE_M60E6_762X51_LIGHT_MACHINE_GUN,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5447bed64bdc2d97278b4568",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "69213e442258063167bddbef",
            // Flea price of item
            FleaPriceRoubles = 10000,
            // Price of item in handbook
            HandbookPriceRoubles = 10000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f79a486f77409407a7f94",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "M60E6 9x19mm Machine Gun",
                        ShortName = "9mm M60",
                        Description = "A M60E6 Light Machine Gun converted to fire 9x19mm Parabellum cartridges. Lighter and handier than the platform the weapon is based upon."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                Width = 2,
                Weight = 3,
                BaseMalfunctionChance = 0.1,
                Ergonomics = 56,
                RecoilForceBack = 300,
                RecoilForceUp = 100,
                BFirerate = 790
            },
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService9MMM60Box(
    ISptLogger<CustomItemService9MMM60Box> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MAGAZINE_762X51_ASSAULT_BOX_100RND,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5448bc234bdc2d3c308b4569",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "692142cb2258063167bddbf0",
            // Flea price of item
            FleaPriceRoubles = 20000,
            // Price of item in handbook
            HandbookPriceRoubles = 20000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f754a86f774094242f19b",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "9x19mm 200 Round M60 Platform Belt Box",
                        ShortName = "9mm Box",
                        Description = "A M60 Platform Belt Box redesigned to hold 200 9x19mm cartridges. Lighter and easier to carry than the original 7.62x51mm equipment."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
               Weight = 0.25,
               Ergonomics = -10,
               LoadUnloadModifier = -15,
               Cartridges = 
               [ 
                   new Slot
                   {
                       Name = "cartridges",
                       Id = "660ea4453786cc0af808a1bf",
                       Parent = "660ea4453786cc0af808a1be",
                       MaxCount = 200,
                       Properties = new SlotProperties
                           
                       { Filters =
                       [
                       new SlotFilter
                       {
                       Filter =
                       [
                           "5efb0da7a29a85116f6ea05f",
                           "5c3df7d588a4501f290594e5",
                           "58864a4f2459770fcc257101",
                           "56d59d3ad2720bdb418b4577",
                           "5c925fa22e221601da359b7b",
                           "5a3c16fe86f77452b62de32a",
                           "5efb0e16aeb21837e749c7ff",
                           "5c0d56a986f774449d5de529",
                           "64b7bbb74b75259c590fa897"
                           ]
                   }
                   ]
                   },
                   Required = false,
                   MergeSlotWithChildren = false,
                   Prototype = "5748538b2459770af276a261"
                   }
               ]
            },
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService46OPSKS(
    ISptLogger<CustomItemService46OPSKS> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.ASSAULTCARBINE_MOLOT_ARMS_SIMONOV_OPSKS_762X39_CARBINE,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5447b5fc4bdc2d87278b4567",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "68ffbb67ba52633ba0e4f4a5",
            // Flea price of item
            FleaPriceRoubles = 2000,
            // Price of item in handbook
            HandbookPriceRoubles = 2000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f78e986f77447ed5636b1",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "4.6x30mm Converted OP-SKS Assault Carbine",
                        ShortName = "4.6 SKS",
                        Description = "A Simonov OP-SKS Assault Carbine converted to fire in select full auto and utilize modified magazines holding 4.6x30mm cartridges. Low recoil, high rate of fire and can still be top loaded with the magazine still engaged with the weapon. Lighter than base."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                WeapFireType = ["single", "fullauto"],
                AmmoCaliber = "Caliber46x30",
                BFirerate = 825,
                Ergonomics = 55,
                Weight = 0.4,
                CoolFactorGun = 3.75,
                BaseMalfunctionChance = 0.15,
                Width = 1,
                RecoilForceBack = 250,
                RecoilForceUp = 100,
                Slots = 
                [ new Slot
                    {
                        Name = "mod_stock",
                        Id = "587e02ff24597743df3deaec",
                        Parent = "68ffbb67ba52633ba0e4f4a5",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "5d0236dad7ad1a0940739d29",
                                        "587e0531245977466077a0f7",
                                        "5afd7ded5acfc40017541f5e",
                                        "574dad8024597745964bf05c",
                                        "653ecef836fae5a82f02b869"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_barrel",
                        Id = "587e02ff24597743df3deaed",
                        Parent = "68ffbb67ba52633ba0e4f4a5",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "634eff66517ccc8a960fc735",
                                        "634f02331f9f536910079b51",
                                        "603372d154072b51b239f9e1"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_magazine",
                        Id = "587e02ff24597743df3deaee",
                        Parent = "68ffbb67ba52633ba0e4f4a5",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "68ffbfe8ba52633ba0e4f4a6"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c394bdc2dae468b4577",
                    },
                    new Slot
                    {
                        Name = "mod_mount",
                        Id = "587e09d924597743df3deb26",
                        Parent = "68ffbb67ba52633ba0e4f4a5",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "587e08ee245977446b4410cf",
                                        "6415d33eda439c6a97048b5b"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_reciever",
                        Id = "593d4a0586f7745e5838a153",
                        Parent = "68ffbb67ba52633ba0e4f4a5",
                        Properties = new SlotProperties
                        {
                            Filters = 
                            [
                                new SlotFilter
                                {
                                    Filter = 
                                    [
                                        "634f06262e5def262d0b30ca",
                                        "634f05ca517ccc8a960fc748",
                                        "6415c694da439c6a97048b56"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    }
                ],
                Chambers =
                [
                    new Slot
                    {
                        Name = "patron_in_weapon",
                        Id = "587e030024597743df3deaef",
                        Parent = "68ffbb67ba52633ba0e4f4a5",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5ba26812d4351e003201fef1",
                                        "5ba26835d4351e0035628ff5",
                                        "5ba2678ad4351e44f824b344",
                                        "5ba26844d4351e00334c9475",
                                        "64b6979341772715af0f9c39"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d4af244bdc2d962f8b4571"
                    }
                ]
            },
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService46OPSKSMag(
    ISptLogger<CustomItemService46OPSKSMag> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MAGAZINE_366TKM_6610_20RND,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5448bc234bdc2d3c308b4569",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "68ffbfe8ba52633ba0e4f4a6",
            // Flea price of item
            FleaPriceRoubles = 5000,
            // Price of item in handbook
            HandbookPriceRoubles = 5000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f78e986f77447ed5636b1",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "Modified 6610 50 Round SKS Magazine",
                        ShortName = "46 6610",
                        Description = "A SKS 6610 Magazine modified to hold and feed 50 4.6x30mm Cartridges."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                Ergonomics = -1,
                CheckTimeModifier = -10,
                LoadUnloadModifier = -10,
                MalfunctionChance = 0.03,
                Weight = 0.1,
                Cartridges = 
                [
                    new Slot
                    {
                        Name = "cartridges",
                        Id = "587df583245977373c4f112a",
                        Parent = "68ffbfe8ba52633ba0e4f4a6",
                        MaxCount = 50,
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5ba26812d4351e003201fef1",
                                        "5ba26835d4351e0035628ff5",
                                        "5ba2678ad4351e44f824b344",
                                        "5ba26844d4351e00334c9475",
                                        "64b6979341772715af0f9c39"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d4af244bdc2d962f8b4571"
                    }
                ]
            },
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService921PKP(
    ISptLogger<CustomItemService921PKP> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MACHINEGUN_KALASHNIKOV_PKP_762X54R_INFANTRY_MACHINE_GUN,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5447bed64bdc2d97278b4568",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "68fea4af924d1a1be07759a2",
            // Flea price of item
            FleaPriceRoubles = 5000,
            // Price of item in handbook
            HandbookPriceRoubles = 5000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f79a486f77409407a7f94",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "9x21mm Converted PKP Machine Gun",
                        ShortName = "PKP PCMG",
                        Description =
                            "A PKP Machine Gun converted to use custom 200 round belt boxes with 9x21mm cartridges. The conversion is intended to reduce recoil and weight whilst improving fire rate, ergonomics, and durability."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                AmmoCaliber = "Caliber9x21",
                BFirerate = 850,
                RecoilForceBack = 280,
                RecoilForceUp = 100,
                AllowJam = false,
                BaseMalfunctionChance = 0.05,
                Weight = 1,
                Width = 2,
                CanSellOnRagfair = true,
                Ergonomics = 65,
                HeatFactorByShot = 1,
                CoolFactorGun = 4,
                Chambers =
                [
                    new Slot
                    {
                        Name = "patron_in_weapon",
                        Id = "64ca3d3954fc657e230529cd",
                        Parent = "68fea4af924d1a1be07759a2",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5a269f97c4a282000b151807",
                                        "5a26abfac4a28232980eabff",
                                        "5a26ac06c4a282000c5a90a8",
                                        "5a26ac0ec4a28200741e1e18",
                                        "6576f93989f0062e741ba952",
                                        "6576f4708ca9c4381d16cd9d"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d4af244bdc2d962f8b4571"
                    }
                ],
                Slots =
                [
                    new Slot
                    {
                        Name = "mod_pistolgrip",
                        Id = "64ca3d3954fc657e230529ce",
                        Parent = "68fea4af924d1a1be07759a2",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "646371779f5f0ea59a04c204",
                                        "64cbad529f7cf7f75c077fd5",
                                        "5f6341043ada5942720e2dc5",
                                        "6087e663132d4d12c81fd96b",
                                        "623c3be0484b5003161840dc",
                                        "5649ad3f4bdc2df8348b4585",
                                        "5649ade84bdc2d1b2b8b4587",
                                        "59e62cc886f77440d40b52a1",
                                        "5a0071d486f77404e23a12b2",
                                        "5e2192a498a36665e8337386",
                                        "5cf54404d7f00c108840b2ef",
                                        "57e3dba62459770f0c32322b",
                                        "63f4da90f31d4a33b87bd054",
                                        "5b30ac585acfc433000eb79c",
                                        "59e6318286f77444dd62c4cc",
                                        "5cf50850d7f00c056e24104c",
                                        "5cf508bfd7f00c056e24104e",
                                        "628a664bccaab13006640e47",
                                        "628c9ab845c59e5b80768a81",
                                        "5947f92f86f77427344a76b1",
                                        "5947fa2486f77425b47c1a9b",
                                        "5649ae4a4bdc2d1b2b8b4588",
                                        "5c6bf4aa2e2216001219b0ae",
                                        "648ae3e356c6310a830fc291",
                                        "651580dc71a4f10aec4b6056"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_magazine",
                        Id = "64ca3d3954fc657e230529cf",
                        Parent = "68fea4af924d1a1be07759a2",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "68feac9f924d1a1be07759a3"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "646372518610c40fc20204e8",
                    },
                    new Slot
                    {
                        Name = "mod_stock",
                        Id = "64ca3d3954fc657e230529d0",
                        Parent = "68fea4af924d1a1be07759a2",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "646371a9f2404ab67905c8e6",
                                        "6492d7847363b8a52206bc52",
                                        "6492e3a97df7d749100e29ee",
                                        "668672b8c99550c6fd0f0b29"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_barrel",
                        Id = "64ca3d3954fc657e230529d1",
                        Parent = "68fea4af924d1a1be07759a2",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "64639a9aab86f8fd4300146c",
                                        "646371faf2404ab67905c8e9",
                                        "603372f153a60014f970616d"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_bipod",
                        Id = "64ca3d3954fc657e230529d2",
                        Parent = "68fea4af924d1a1be07759a2",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "6464d870bb2c580352070cc4",
                                        "55d48ebc4bdc2d8c2f8b456c"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_handguard",
                        Id = "64ca3d3954fc657e230529d3",
                        Parent = "68fea4af924d1a1be07759a2",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "6491c6f6ef312a876705191b",
                                        "5d123102d7ad1a004e475fe5"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_sight_rear",
                        Id = "64ca3d3954fc657e230529d4",
                        Parent = "68fea4af924d1a1be07759a2",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "6492fb8253acae0af00a29b6",
                                        "59d650cf86f7741b846413a4",
                                        "5a0eb980fcdbcb001a3b00a6",
                                        "5649d9a14bdc2d79388b4580",
                                        "628a7b23b0f75035732dd565"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_scope",
                        Id = "64ca3dd78f30beca2606cd07",
                        Parent = "68fea4af924d1a1be07759a2",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5947db3f86f77447880cf76f",
                                        "6113d6c3290d254f5e6b27db",
                                        "57486e672459770abd687134",
                                        "618a5d5852ecee1505530b2a",
                                        "5c82342f2e221644f31c060e",
                                        "576fd4ec2459777f0b518431",
                                        "5c82343a2e221644f31c0611",
                                        "5cf638cbd7f00c06595bc936",
                                        "5a7c74b3e899ef0014332c29",
                                        "591ee00d86f774592f7b841e",
                                        "5d0a29ead7ad1a0026013f27",
                                        "618a75c9a3884f56c957ca1b",
                                        "57acb6222459771ec34b5cb0",
                                        "638db77630c4240f9e06f8b6",
                                        "6544d4187c5457729210d277"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                ]
            }
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item

        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService921PKPBox(
    ISptLogger<CustomItemService921PKPBox> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MAGAZINE_762X54R_PK_100RND,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5448bc234bdc2d3c308b4569",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "68feac9f924d1a1be07759a3",
            // Flea price of item
            FleaPriceRoubles = 25000,
            // Price of item in handbook
            HandbookPriceRoubles = 25000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f754a86f774094242f19b",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "9x21mm 200 Round Modified PK Belt Box",
                        ShortName = "PK Belt",
                        Description = "A PK Machine Gun Belt Box holding a modified 200 round linked belt for 9x21mm cartridges. Lighter than standard with less effect on overall size."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                ExtraSizeDown = 1,
                LoadUnloadModifier = -30,
                Ergonomics = -10,
                DurabilityBurnModificator = 0.8,
                Weight = 0.75,
                Cartridges = 
                [
                    new Slot
                    {
                        Name = "cartridges",
                        Id = "646372518610c40fc20204e9",
                        Parent = "68feac9f924d1a1be07759a3",
                        MaxCount = 200,
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5a269f97c4a282000b151807",
                                        "5a26abfac4a28232980eabff",
                                        "5a26ac06c4a282000c5a90a8",
                                        "5a26ac0ec4a28200741e1e18",
                                        "6576f93989f0062e741ba952",
                                        "6576f4708ca9c4381d16cd9d"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d4af244bdc2d962f8b4571"
                    }
                ]
            },
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService762TTRPDN(
    ISptLogger<CustomItemService762TTRPDN> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MACHINEGUN_DEGTYAREV_RPDN_762X39_MACHINE_GUN,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5447bed64bdc2d97278b4568",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "68fe7c92924d1a1be07759a0",
            // Flea price of item
            FleaPriceRoubles = 3000,
            // Price of item in handbook
            HandbookPriceRoubles = 3000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f79a486f77409407a7f94",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "7.62TT Converted RPDN Machine Gun",
                        ShortName = "PCMG RPDN",
                        Description =
                            "A RPDN Machine Gun converted to use custom Buben belt holders and fire 7.62x25mm Tokarev Cartridges. Lighter, higher rate of fire, and better ergonomics alongside durability and recoil improvements are the underlying reasons for the conversion."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                BFirerate = 850,
                Ergonomics = 66,
                Weight = 1,
                Width = 2,
                CanSellOnRagfair = true,
                RecoilForceUp = 75,
                RecoilForceBack = 300,
                AmmoCaliber = "Caliber762x25TT",
                Slots =
                [
                    new Slot
                    {
                        Name = "mod_magazine",
                        Id = "65268d8ecb944ff1e90ea387",
                        Parent = "68fe7c92924d1a1be07759a0",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "68fe8c81924d1a1be07759a1"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c394bdc2dae468b4577",
                    },
                    new Slot
                    {
                        Name = "mod_stock",
                        Id = "65268d8ecb944ff1e90ea388",
                        Parent = "68fe7c92924d1a1be07759a0",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "6513f1798cb24472490ee331"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    },
                    new Slot
                    {
                        Name = "mod_barrel",
                        Id = "65268d8ecb944ff1e90ea389",
                        Parent = "68fe7c92924d1a1be07759a0",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "6513eff1e06849f06c0957d4",
                                        "65266fd43341ed9aa903dd56",
                                        "603372d154072b51b239f9e1"
                                    ]
                                }
                            ]
                        },
                        Required = true,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    }, new Slot
                    {
                        Name = "mod_handguard",
                        Id = "65268d8ecb944ff1e90ea38a",
                        Parent = "68fe7c92924d1a1be07759a0",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "6513f05a94c72326990a3866",
                                        "5cf4e3f3d7f00c06595bc7f0",
                                        "5648ae314bdc2d3d1c8b457f",
                                        "5d2c829448f0353a5c7d6674",
                                        "5b800e9286f7747a8b04f3ff",
                                        "5b80242286f77429445e0b47",
                                        "5cbda392ae92155f3c17c39f",
                                        "5cbda9f4ae9215000e5b9bfc",
                                        "5648b0744bdc2d363b8b4578",
                                        "5648b1504bdc2d9d488b4584",
                                        "59d64f2f86f77417193ef8b3",
                                        "57cff947245977638e6f2a19",
                                        "57cffd8224597763b03fc609",
                                        "57cffddc24597763133760c6",
                                        "57cffe0024597763b03fc60b",
                                        "57cffe20245977632f391a9d",
                                        "5c9a07572e221644f31c4b32",
                                        "5c9a1c3a2e2216000e69fb6a",
                                        "5c9a1c422e221600106f69f0",
                                        "59e6284f86f77440d569536f",
                                        "59e898ee86f77427614bd225",
                                        "5a9d56c8a2750c0032157146",
                                        "5d1b198cd7ad1a604869ad72",
                                        "5d4aaa73a4b9365392071175",
                                        "5d4aaa54a4b9365392071170",
                                        "5f6331e097199b7db2128dc2",
                                        "5c17664f2e2216398b5a7e3c",
                                        "5c617a5f2e2216000f1e81b3",
                                        "5648b4534bdc2d3d1c8b4580",
                                        "5efaf417aeb21837e749c7f2",
                                        "6389f1dfc879ce63f72fc43e",
                                        "647dba3142c479dde701b654",
                                        "647dd2b8a12ebf96c3031655",
                                        "5d123102d7ad1a004e475fe5"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    }, new Slot
                    {
                        Name = "mod_sight_rear",
                        Id = "65268d8ecb944ff1e90ea38b",
                        Parent = "68fe7c92924d1a1be07759a0",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "6513f153e63f29908d0ffaba",
                                        "5ac733a45acfc400192630e2",
                                        "5649b0544bdc2d1b2b8b458a",
                                        "5ac72e475acfc400180ae6fe",
                                        "5bf3f59f0db834001a6fa060",
                                        "649ec2cec93611967b03495e",
                                        "628a7b23b0f75035732dd565",
                                        "5649d9a14bdc2d79388b4580"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    }, new Slot
                    {
                        Name = "mod_scope",
                        Id = "65268dc17bdd1243830efbd6",
                        Parent = "68fe7c92924d1a1be07759a0",
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5947db3f86f77447880cf76f",
                                        "6113d6c3290d254f5e6b27db",
                                        "57486e672459770abd687134",
                                        "618a5d5852ecee1505530b2a",
                                        "5c82342f2e221644f31c060e",
                                        "576fd4ec2459777f0b518431",
                                        "5c82343a2e221644f31c0611",
                                        "5cf638cbd7f00c06595bc936",
                                        "5a7c74b3e899ef0014332c29",
                                        "591ee00d86f774592f7b841e",
                                        "5d0a29ead7ad1a0026013f27",
                                        "618a75c9a3884f56c957ca1b",
                                        "57acb6222459771ec34b5cb0",
                                        "638db77630c4240f9e06f8b6",
                                        "6544d4187c5457729210d277",
                                        "65f1b1176dbd6c5ba2082eed"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                    }
                    
                ],
            }
    };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class CustomItemService762TTRPDNBox(
    ISptLogger<CustomItemService762TTRPDNBox> logger,
    CustomItemService customItemService) : IOnLoad
{

    public Task OnLoad()
    {
        //Example of adding new item by cloning an existing item using `createCloneDetails`
        var exampleCloneItem = new NewItemFromCloneDetails
        {
            ItemTplToClone = ItemTpl.MAGAZINE_762X39_BUBEN_100RND,
            // ParentId refers to the Node item the gun will be under, you can check it in https://db.sp-tarkov.com/search
            ParentId = "5448bc234bdc2d3c308b4569",
            // The new id of our cloned item - MUST be a valid mongo id, search online for mongo id generators
            NewId = "68fe8c81924d1a1be07759a1",
            // Flea price of item
            FleaPriceRoubles = 23000,
            // Price of item in handbook
            HandbookPriceRoubles = 23000,
            // Handbook Parent Id refers to the category the gun will be under
            HandbookParentId = "5b5f754a86f774094242f19b",
            //you see those side box tab thing that only select gun under specific icon? Handbook parent can be found in Spt_Data\Server\database\templates.
            Locales = new Dictionary<string, LocaleDetails>
            {
                {
                    "en", new LocaleDetails
                    {
                        Name = "Buben 7.62x25mm TT 200 Round Belt",
                        ShortName = "Buben TT",
                        Description = "A Buben belt box converted to hold a modified 200 round belt of 7.62x25mm TT Cartridges for use in similar converted RPD style machine guns. Lighter and more ergonomic with less effect on overall size."
                    }
                }
            },
            OverrideProperties = new TemplateItemProperties
            {
                ExtraSizeDown = 0,
                Ergonomics = -10,
                MalfunctionChance = 0,
                Weight = 0.4,
                LoadUnloadModifier = -35,
                Cartridges = 
                [
                    new Slot
                    {
                        Name = "cartridges",
                        Id = "6513f0a194c72326990a3869",
                        Parent = "68fe8c81924d1a1be07759a1",
                        MaxCount = 200,
                        Properties = new SlotProperties
                        {
                            Filters =
                            [
                                new SlotFilter
                                {
                                    Filter =
                                    [
                                        "5735ff5c245977640e39ba7e",
                                        "573601b42459776410737435",
                                        "573602322459776445391df1",
                                        "5736026a245977644601dc61",
                                        "573603562459776430731618",
                                        "573603c924597764442bd9cb",
                                        "5735fdcd2459776445391d61"
                                    ]
                                }
                            ]
                        },
                        Required = false,
                        MergeSlotWithChildren = false,
                        Prototype = "55d4af244bdc2d962f8b4571"
                    }
                ]
            },
        };

        customItemService.CreateItemFromClone(exampleCloneItem); // Send our data to the function that creates our item
        
        return Task.CompletedTask;
    }
}

public class EditDatabaseValues(
	ISptLogger<EditDatabaseValues>
		logger, // We are injecting a logger similar to example 1, but notice the class inside <> is different
	DatabaseService databaseService)
	: IOnLoad // Implement the `IOnLoad` interface so that this mod can do something
{
	// Our constructor

	/// <summary>
	/// This is called when this class is loaded, the order in which its loaded is set according to the type priority
	/// on the [Injectable] attribute on this class. Each class can then be used as an entry point to do
	/// things at varying times according to type priority
	/// </summary>
	public Task OnLoad()
	{
		AutoD50Kit();

		SR50Kit();

		AddnameofitemtoPmc();
		
		AA20GKit();

		logger.Success("Finished Editing Database! DaGrog's Add On Weapon Pack Added!");

		return Task.CompletedTask;

	}

	private void AutoD50Kit()
	{
		var items = databaseService.GetItems();

		foreach (var (id, item) in items)
		{
			if (id != "69350c4f124113667535f7bc" && id != "668fe5a998b5ad715703ddd6" && id != "669fa39b48fc9f8db6035a0c"
			    && id != "669fa3d876116c89840b1217" && id != "669fa3f88abd2662d80eee77")
			{
				continue;
			}

			foreach (var slot in item.Properties?.Slots ?? [])
			{
				if (slot.Name != "mod_magazine")
				{
					continue;
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("69350ec2124113667535f7bd");
				}
			}
		}

		foreach (var (id, item) in items)
		{
			if (id != "69350c4f124113667535f7bc")
			{
				continue;
			}

			foreach (var slot in item.Properties?.Slots ?? [])
			{
				if (slot.Name != "mod_tactical")
				{
					continue;
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5a800961159bd4315e3a1657");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5cc9c20cd7f00c001336c65d");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5d2369418abbc306c62e0c80");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5b07dd285acfc4001754240d");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("56def37dd2720bec348b456a");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5a7b483fe899ef0016170d15");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5a5f1ce64f39f90b401987bc");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("560d657b4bdc2da74d8b4572");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5b3a337e5acfc4704b4a19a0");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("6272370ee4013c5d7e31f418");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("6272379924e29f06af4d5ecb");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("6644920d49817dc7d505ca71");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("67112695fe5c8bf33f02476d");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("671126a210d67adb5b08e925");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("671126b049e181972e0681fa");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("676175bb48fa5c377e06fc36");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c7fc87d2e221644f31c0298");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5cda9bcfd7f00c0c0b53e900");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("59f8a37386f7747af3328f06");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5a7dbfc1159bd40016548fde");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("619386379fb0c665d5490dbe");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c87ca002e221600114cb150");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("588226d124597767ad33f787");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("588226dd24597767ad33f789");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("588226e62459776e3e094af7");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("588226ef24597767af46e39c");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("59fc48e086f77463b1118392");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5fce0cf655375d18a253eff0");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5cf4fb76d7f00c065703d3ac");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5b057b4f5acfc4771e1bd3e9");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c791e872e2216001219c40a");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("558032614bdc2de7118b4585");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("58c157be86f77403c74b2bb6");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("661e52b5b099f32c28003586");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("58c157c886f774032749fb06");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5f6340d3ca442212f4047eb2");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("591af28e86f77414a27a9e1d");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c1cd46f2e22164bef5cfedb");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c1bc4812e22164bef5cfde7");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c1bc5612e221602b5429350");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c1bc5af2e221602b412949b");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c1bc7752e221602b1779b34");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c1bc5fb2e221602b1779b32");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c1bc7432e221602b412949d");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("64806bdd26c80811d408d37a");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("64807a29e5ffe165600abc97");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("648067db042be0705c0b3009");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("65169d5b30425317755f8e25");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("655df24fdf80b12750626d0a");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("655dccfdbdcc6b5df71382b6");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("661e53149c8b4dadef008579");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("661e52e29c8b4dadef008577");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("661e52415be02310ed07a07a");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("57fd23e32459772d0805bcf1");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("544909bb4bdc2d6f028b4577");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c06595c0db834001a66af6c");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("61605d88ffa6e502ac5e7eeb");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5c5952732e2216398b5abda2");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5b3a337e5acfc4704b4a19a0");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("57d17e212459775a1179a0f5");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("6267c6396b642f77f56f5c1c");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("646f6322f43d0c5d62063715");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("626becf9582c3e319310b837");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("644a3df63b0b6f03e101e065");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5d2369418abbc306c62e0c80");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5d10b49bd7ad1a1a560708b0");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("62444cb99f47004c781903eb");
				}

			}
		}
	}

	private void SR50Kit()
	{
		var items = databaseService.GetItems();

		foreach (var (id, item) in items)
		{
			if (id != "69351696124113667535f7be")
			{
				continue;
			}

			foreach (var slot in item.Properties?.Slots ?? [])
			{
				if (slot.Name != "mod_magazine")
				{
					continue;
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("69351a47124113667535f7bf");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Remove("5df8f535bb49d91fb446d6b0");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Remove("5df8f541c41b2312ea3335e3");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Remove("5a3501acc4a282000d72293a");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Remove("65293c38fc460e50a509cb25");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Remove("65293c7a17e14363030ad308");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Remove("6761770e48fa5c377e06fc3c");
				}
			}
		}

	}

	private void AA20GKit()
	{
		var items = databaseService.GetItems();

		foreach (var (id, item) in items)
		{
			if (id != "691a1a18d8de5e14a7771d93")
			{
				continue;
			}

			foreach (var slot in item.Properties?.Slots ?? [])
			{
				if (slot.Name != "mod_magazine")
				{
					continue;
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("691a220ad8de5e14a7771d94");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Remove("66ffaab91f7492c901027bb8");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Remove("6709133fa532466d5403fb7c");
				}
			} 
			foreach (var slot in item.Properties?.Slots ?? [])
			{
				if (slot.Name != "mod_scope")
				{
					continue;
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("5bfebc530db834001d23eb65");
				}
			}
		}
	}
	private void AddnameofitemtoPmc()
	{
		var items = databaseService.GetItems();

		foreach (var (id, item) in items)
		{
			if (id != "55d7217a4bdc2d86028b456d")
			{
				continue;
			}

			foreach (var slot in item.Properties?.Slots ?? [])
			{
				if (slot.Name != "FirstPrimaryWeapon")
				{
					continue;
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("69350c4f124113667535f7bc");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("69351696124113667535f7be");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("693dbae73d12cdff77867933");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("691a1a18d8de5e14a7771d93");
				}
				
				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("69191fe6f7555679b84d980a");
				}
				
				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("68fee98c924d1a1be07759a4");
				}

                foreach (var filter in slot.Properties?.Filters ?? [])
                {
                    filter.Filter!.Add("69213e442258063167bddbef");
                }

                foreach (var filter in slot.Properties?.Filters ?? [])
                {
                    filter.Filter!.Add("68ffbb67ba52633ba0e4f4a5");
                }

                foreach (var filter in slot.Properties?.Filters ?? [])
                {
                    filter.Filter!.Add("68fea4af924d1a1be07759a2");
                }
                
                foreach (var filter in slot.Properties?.Filters ?? [])
                {
                    filter.Filter!.Add("68fe7c92924d1a1be07759a0");
                }
			}

			foreach (var slot in item.Properties?.Slots ?? [])
			{
				if (slot.Name != "SecondPrimaryWeapon")
				{
					continue;
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("69350c4f124113667535f7bc");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("69351696124113667535f7be");
				}
				
				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("693dbae73d12cdff77867933");
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("691a1a18d8de5e14a7771d93");
				}
				
				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("69191fe6f7555679b84d980a");
				}
				
				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("68fee98c924d1a1be07759a4");
				}

                foreach (var filter in slot.Properties?.Filters ?? [])
                {
                    filter.Filter!.Add("69213e442258063167bddbef");
                }

                foreach (var filter in slot.Properties?.Filters ?? [])
                {
                    filter.Filter!.Add("68ffbb67ba52633ba0e4f4a5");
                }

                foreach (var filter in slot.Properties?.Filters ?? [])
                {
                    filter.Filter!.Add("68fea4af924d1a1be07759a2");
                }

                foreach (var filter in slot.Properties?.Filters ?? [])
                {
                    filter.Filter!.Add("68fe7c92924d1a1be07759a0");
                }
			}

			foreach (var slot in item.Properties?.Slots ?? [])
			{
				if (slot.Name != "Holster")
				{
					continue;
				}

				foreach (var filter in slot.Properties?.Filters ?? [])
				{
					filter.Filter!.Add("69350c4f124113667535f7bc");
				}
			}
		}
	}
}
