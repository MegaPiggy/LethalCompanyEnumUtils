# LethalCompanyEnumUtils
A library with utilities for dynamically creating and getting Enums.

For feature requests or issues, go to my [repo](https://github.com/MegaPiggy/LethalCompanyEnumUtils/issues).

## General Users
This mod is just a dependency for other mods, it doesn't add content by itself.

### Recommended Install
Please use a mod manager. I recommend [r2modman](https://github.com/ebkr/r2modmanPlus) as the mod manager to use for Lethal Company.
 
## Developer Quick-Start
Download the latest release from either the [Thunderstore](https://thunderstore.io/c/lethal-company/p/MegaPiggy/EnumUtils/) or the [Releases](https://github.com/MegaPiggy/LethalCompanyEnumUtils/releases).

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
        CauseOfDeath bludgeoning = EnumUtils.Parse<CauseOfDeath>("Bludgeoning");

        if (EnumUtils.TryParse("Example", out CauseOfDeath example))
        {

        }

        int numOfDeathCauses = EnumUtils.Count<CauseOfDeath>();
        CauseOfDeath minDeathCause = EnumUtils.GetMinValue<CauseOfDeath>();
        CauseOfDeath maxDeathCause = EnumUtils.GetMaxValue<CauseOfDeath>();
        CauseOfDeath randomDeathCause = EnumUtils.GetRandom<CauseOfDeath>();
        CauseOfDeath unusedDeathCauseValue = EnumUtils.GetFirstFreeValue<CauseOfDeath>();
        string[] allDeathNames = EnumUtils.GetNames<CauseOfDeath>();
        CauseOfDeath[] allDeathValues = EnumUtils.GetValues<CauseOfDeath>();
        bool doesExampleDeathExist = EnumUtils.IsDefined<CauseOfDeath>("Example");
        Type valueType = EnumUtils.GetUnderlyingType<CauseOfDeath>();
        bool hasFlags = EnumUtils.IsPowerOfTwoEnum<CauseOfDeath>();
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
    private static readonly CauseOfDeath Example = EnumUtils.Create<CauseOfDeath>("Example");
    // Associate a specific enum value with a name of your choosing.
    private static readonly CauseOfDeath Example2 = EnumUtils.Create<CauseOfDeath>("Example2", -1);

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
    public static readonly CauseOfDeath Example;
    public static readonly CauseOfDeath Example2 = (CauseOfDeath)-1;
}
```