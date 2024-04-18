[![Thunderstore](https://img.shields.io/thunderstore/v/MegaPiggy/EnumUtils?logo=thunderstore&logoColor=white)](https://thunderstore.io/c/content-warning/p/MegaPiggy/EnumUtils)

# Content Warning Enum Utils
A library with utilities for dynamically creating and getting Enums.

Originally for Lethal Company, but ported to Content Warning for a request. Everything is identical except the dll relies on CW files instead.

For feature requests or issues, go to my [repo](https://github.com/MegaPiggy/LethalCompanyEnumUtils/issues).

## General Users
This mod is just a dependency for other mods, it doesn't add content by itself.

### Recommended Install
Please use a mod manager. I recommend [r2modman](https://github.com/ebkr/r2modmanPlus) as the mod manager to use.
 
## Developer Quick-Start
Download the latest release from either the [Thunderstore](https://thunderstore.io/c/content-warning/p/MegaPiggy/EnumUtils/).

Extract the zip and add a reference to the dll file of the mod in the IDE (Visual Studio, Rider, or etc) you use.

## Enum Utilities

### Getting Enums
Shortcuts for getting enums. There is various functions you can use.
Here are some of the examples.

```csharp
[BepInPlugin(modGUID, modName, modVersion)]
public class ExampleModClass : BaseUnityPlugin
{
    private void Start()
    {
        RARITY mythic = EnumUtils.Parse<RARITY>("mythic");

        if (EnumUtils.TryParse("example", out RARITY example))
        {

        }

        int numOfRarities = EnumUtils.Count<RARITY>();
        RARITY minRarity = EnumUtils.GetMinValue<RARITY>();
        RARITY maxRarity = EnumUtils.GetMaxValue<RARITY>();
        RARITY randomRarity = EnumUtils.GetRandom<RARITY>();
        RARITY unusedRarityValue = EnumUtils.GetFirstFreeValue<RARITY>();
        string[] allRarityNames = EnumUtils.GetNames<RARITY>();
        RARITY[] allRarityValues = EnumUtils.GetValues<RARITY>();
        bool doesExampleRarityExist = EnumUtils.IsDefined<RARITY>("example");
        Type valueType = EnumUtils.GetUnderlyingType<RARITY>();
        bool hasFlags = EnumUtils.IsPowerOfTwoEnum<RARITY>();
    }
}
```

### Creating Enums
You can use the EnumUtils class to create enums just like this.

```csharp
[BepInPlugin(modGUID, modName, modVersion)]
public class ExampleModClass : BaseUnityPlugin
{
    // Associate an unused enum value with a name of your choosing.
    private static readonly RARITY example = EnumUtils.Create<RARITY>("example");
    // Associate a specific enum value with a name of your choosing.
    private static readonly RARITY example2 = EnumUtils.Create<RARITY>("example2", -1);

    private void Awake()
    {
    }
}
```

### Enum Holders

Another way to create enums.

Add the `[EnumHolder]` attribute to a class, run the `RegisterAllEnumHolders` function, and any static enum fields will have an enum value created with the name of the field. It'll select any unused enum value to be associated with that name (or if you specify a value it'll use that one).

```csharp
using System.Reflection;

[BepInPlugin(modGUID, modName, modVersion)]
public class ExampleModClass : BaseUnityPlugin
{
    private void Awake()
    {
        EnumUtils.RegisterAllEnumHolders(Assembly.GetExecutingAssembly());
    }
}
```

```csharp
[EnumHolder]
public static class ExampleEnumHolderClass 
{
    public static readonly RARITY example;
    public static readonly RARITY example2 = (RARITY)-1;
}
```
