using System;
using System.Reflection;

/// <summary>
/// Add this attribute to a class, and any static enum fields will have an enum value created with the name of the field.
/// You must call <see cref="EnumUtils.RegisterAllEnumHolders(Assembly)"/> on your assembly for that to happen.
/// </summary>
public class EnumHolderAttribute : Attribute { }