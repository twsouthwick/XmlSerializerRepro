# XmlSerializer for WinForms

Using XmlSerializer with Windorms in .NET 8 fails with the following:

```
1>.NET Xml Serialization Generation Utility, Version 8.0.0]
1>SGEN : warning SGEN1: Could not load file or assembly 'System.Windows.Forms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'. Reference assemblies cannot be loaded for execution. (0x80131058)
1>SGEN : warning SGEN1: Cannot load a reference assembly for execution.
1>Assembly '...\XmlSerializerRepro.dll' does not contain any types that can be serialized using XmlSerializer.
```

In order to fix that, this workaround adds a custom runtime config for the tool that is ran behind the scenes.

To incorporate in a project:

1. Add the `sgen_workaround` folder to your solution
2. Add the following to a `Directory.Build.targets` in the hierarchy of where the project to be serialized is (adapting the path here as necessary):
    ```xml
    <Import Project="$(MSBuildThisFileDirectory)sgen_workaround/sgen_workaround.targets" /> 
    ```
    
3. Set `<UseXmlSerializerGenerator>true</UseXmlSerializerGenerator>` in the project file that you want to enable it for. This will ensure the package is referenced correctly (if you're using CPM, you'll need to update accordingly)