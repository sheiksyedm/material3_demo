# .NET MAUI Material 3 Gallery

This sample demonstrates the Android Material 3 support available with .NET MAUI 11 Preview 7.

## Included controls

- ActivityIndicator
- Button
- CheckBox
- DatePicker
- Editor
- Entry
- Image
- ImageButton
- Label
- Picker
- ProgressBar
- RadioButton
- SearchBar
- Shell
- Slider
- Switch
- TimePicker

## Requirements

- .NET SDK `11.0.100-preview.7.26381.103`
- .NET MAUI workload compatible with the installed .NET 11 SDK
- Android SDK and an emulator or physical device

The SDK is pinned in `global.json`. The project uses the workload-provided `$(MauiVersion)` so the MAUI NuGet packages and Android workload packs always stay compatible.

## Run

```bash
dotnet workload install maui
dotnet build material3_demo/material3_demo.csproj -f net11.0-android
dotnet build material3_demo/material3_demo.csproj -t:Run -f net11.0-android
```

To use the complete Preview 7 workload set, install it with:

```bash
dotnet workload install maui --version 11.0.100-preview.7.26410.2
```

Material 3 is enabled by this project property:

```xml
<UseMaterial3>true</UseMaterial3>
```

The property affects Android only. Other targets use their native platform controls.

The publication-ready article is available in [`material-3-dotnet-maui-blog.md`](material-3-dotnet-maui-blog.md).
