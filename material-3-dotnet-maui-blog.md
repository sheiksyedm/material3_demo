# Build Modern Android Apps with Material 3 in .NET MAUI 11 Preview 7

**Meta title:** Material 3 Support in .NET MAUI 11 Preview 7  
**Meta description:** Learn how to enable Material 3 in a .NET MAUI Android app and explore examples for every supported control in .NET 11 Preview 7.

Material 3, also known as Material You, is Google's latest design system for creating expressive, adaptive, and accessible Android experiences. It introduces updated component shapes, state layers, color roles, motion, and support for dynamic color.

The Syncfusion contribution team collaborated with the .NET MAUI team to bring opt-in Material 3 support to .NET MAUI on Android. This work covered the build infrastructure, Android handlers, Material widgets, Shell navigation, tests, documentation support, and follow-up fixes.

In this blog, we will:

- Enable Material 3 in a .NET MAUI 11 Preview 7 project.
- Review the controls that support Material 3 on Android.
- Explore a simple example for each control.
- Build a sample gallery that demonstrates the controls in one app.
- Discuss platform scope and migration considerations.

> **Preview note:** This article and sample use .NET 11 Preview 7. Preview APIs and behavior can change before the final .NET 11 release.

## Syncfusion's contribution to .NET MAUI Material 3

Material 3 was designed as an opt-in feature so existing .NET MAUI Android applications can continue to use Material 2 without unexpected visual changes. The foundation is the `UseMaterial3` MSBuild property.

The Syncfusion contribution team implemented the foundation and a broad set of controls through contributions to the [`dotnet/maui`](https://github.com/dotnet/maui) repository.

| Area | Representative contribution |
|---|---|
| Opt-in build property and resources | [PR #33074](https://github.com/dotnet/maui/pull/33074) |
| Button | [PR #33173](https://github.com/dotnet/maui/pull/33173) |
| Switch | [PR #33132](https://github.com/dotnet/maui/pull/33132) |
| CheckBox | [PR #33339](https://github.com/dotnet/maui/pull/33339) |
| Shell | [PR #33427](https://github.com/dotnet/maui/pull/33427) |
| RadioButton | [PR #33468](https://github.com/dotnet/maui/pull/33468) |
| Editor | [PR #33478](https://github.com/dotnet/maui/pull/33478) |
| ActivityIndicator | [PR #33481](https://github.com/dotnet/maui/pull/33481) |
| Label | [PR #33599](https://github.com/dotnet/maui/pull/33599) |
| Slider | [PR #33603](https://github.com/dotnet/maui/pull/33603) |
| TimePicker | [PR #33646](https://github.com/dotnet/maui/pull/33646) |
| ImageButton | [PR #33649](https://github.com/dotnet/maui/pull/33649) |
| DatePicker | [PR #33651](https://github.com/dotnet/maui/pull/33651) |
| Image | [PR #33661](https://github.com/dotnet/maui/pull/33661) |
| Picker | [PR #33668](https://github.com/dotnet/maui/pull/33668) |
| Entry | [PR #33673](https://github.com/dotnet/maui/pull/33673) |
| ProgressBar | [PR #33926](https://github.com/dotnet/maui/pull/33926) |
| SearchBar | [PR #33948](https://github.com/dotnet/maui/pull/33948) |
| Public Material 3 helper types | [PR #35323](https://github.com/dotnet/maui/pull/35323) |
| Preview 7 Slider event improvements | [PR #36448](https://github.com/dotnet/maui/pull/36448) |

These contributions make it possible for .NET MAUI developers to opt in without replacing their cross-platform controls or writing Android handlers for each component.

## Material 3 availability in .NET 10 and .NET 11

Material 3 support began shipping for Android through .NET 10 servicing releases, with support added incrementally across the .NET MAUI controls. Applications using a supported .NET 10 service release can opt in by setting the `UseMaterial3` build property.

.NET 11 extends this work by making the Material 3 handler and platform helper types public. This enables developers to subclass the underlying Android Material 3 views and replace a handler's platform-view factory when deeper control customization is required.

| Version | Material 3 capability |
|---|---|
| .NET 10 servicing releases | Opt-in Material 3 rendering for supported Android controls |
| .NET 11 | Public Material 3 handlers and helper types for advanced customization |

## Enable Material 3 and target Android

Material 3 support is currently available only for the Android target. In the .NET MAUI project file, target `net11.0-android` and set the `UseMaterial3` build property to `true`:

```xml
<PropertyGroup>
  <TargetFrameworks>net11.0-android</TargetFrameworks>
  <UseMaui>true</UseMaui>
  <UseMaterial3>true</UseMaterial3>
</PropertyGroup>
```

No additional initialization is required in `MauiProgram.cs`. During the Android build, .NET MAUI selects the Material 3 theme resources and Material 3-aware handler implementations.

If `UseMaterial3` is missing or set to `false`, the Android app continues to use Material 2. This opt-in behavior protects the appearance of existing applications.

For a multi-targeted application, keep the other target frameworks as needed. The `UseMaterial3` property affects only Android; iOS, Mac Catalyst, and Windows continue to use their native platform controls and design systems.

## Material 3 controls in .NET MAUI

The following sections show concise XAML examples for the controls covered by the Material 3 work.

### Button

`Button` supports Material shape, color, state, and ripple behavior. The sample uses a rounded filled button:

```xml
<Button
    Text="Save profile"
    Clicked="OnSaveClicked" />
```

Use semantic colors in a shared style so buttons remain consistent in light and dark themes.

### ImageButton

On Android, `ImageButton` uses a Material 3 shapeable image platform view:

```xml
<ImageButton
    Source="dotnet_bot.png"
    HeightRequest="56"
    WidthRequest="56"
    Clicked="OnImageButtonClicked" />
```

It can adopt Material shape, ripple, and elevation behavior while retaining the cross-platform .NET MAUI API.

### Entry

`Entry` uses the Material 3 text input implementation. It can render as an outlined field rather than the older underline-only appearance:

```xml
<Entry
    Placeholder="Full name"
    Text="Alex Morgan" />
```

The Material platform view handles focus states and Material theme color roles.

### Editor

`Editor` uses the Material 3 multiline text field implementation:

```xml
<Editor
    Placeholder="Tell us about your Material 3 experience"
    AutoSize="TextChanges"
    MinimumHeightRequest="96" />
```

This is useful for comments, descriptions, notes, and other multiline input.

### SearchBar

`SearchBar` uses a Material 3-styled text input with a leading search icon and trailing clear action:

```xml
<SearchBar
    Placeholder="Search controls"
    TextChanged="OnSearchTextChanged" />
```

The clear action appears when the user enters text.

### CheckBox

`CheckBox` adopts Material 3 colors and state behavior:

```xml
<HorizontalStackLayout>
  <CheckBox IsChecked="True" />
  <Label Text="Receive product updates" />
</HorizontalStackLayout>
```

Keep the text in a separate `Label` so the layout and accessibility description can be customized.

### RadioButton

`RadioButton` uses Material 3 selection states on Android:

```xml
<HorizontalStackLayout Spacing="16">
  <RadioButton Content="Light"
               GroupName="ThemeMode"
               IsChecked="True" />
  <RadioButton Content="Dark"
               GroupName="ThemeMode" />
  <RadioButton Content="System"
               GroupName="ThemeMode" />
</HorizontalStackLayout>
```

Assign the same `GroupName` to make the choices mutually exclusive.

### Switch

When Material 3 is enabled, `Switch` uses Android's `MaterialSwitch` instead of the legacy switch platform view:

```xml
<Switch
    IsToggled="True"
    Toggled="OnNotificationToggled" />
```

The updated track, thumb, and state colors follow Material 3 behavior.

### Picker

`Picker` uses a Material 3 text input and selection dialog:

```xml
<Picker
    x:Name="FrameworkPicker"
    Title="Choose a target framework" />
```

Set its items in C#:

```csharp
FrameworkPicker.ItemsSource = new[]
{
    ".NET 11 Preview 7",
    ".NET 10",
    ".NET 9"
};
FrameworkPicker.SelectedIndex = 0;
```

### DatePicker

`DatePicker` opens the Material 3 date picker experience on Android:

```xml
<DatePicker
    x:Name="ReleaseDatePicker"
    MinimumDate="2026-01-01"
    MaximumDate="2026-12-31" />
```

The `MinimumDate` and `MaximumDate` constraints are applied when the dialog is created. They cannot be changed while the dialog is open.

### TimePicker

`TimePicker` opens the Material 3 time selection dialog:

```xml
<TimePicker Time="09:30:00" />
```

The control retains the same .NET MAUI `Time` API while using the Material Android presentation.

### ActivityIndicator

`ActivityIndicator` uses the Material progress indicator implementation:

```xml
<ActivityIndicator
    IsRunning="True"
    HorizontalOptions="Start" />
```

Use it for indeterminate operations when the completion percentage is unknown.

### ProgressBar

`ProgressBar` uses the Material 3 linear progress indicator:

```xml
<ProgressBar Progress="0.68" />
```

Its `Progress` value remains in the range from `0` to `1`.

### Slider

`Slider` adopts the Material 3 track and thumb. Preview 7 also includes improvements to its native event handling:

```xml
<Slider
    Maximum="100"
    Value="42"
    ValueChanged="OnVolumeChanged" />
```

Display the current value in a label:

```csharp
private void OnVolumeChanged(object? sender, ValueChangedEventArgs e)
{
    VolumeLabel.Text = $"{e.NewValue:F0}%";
}
```

### Label

`Label` participates in the Material 3 Android rendering and theme integration:

```xml
<Label
    Text=".NET MAUI Material 3"
    FontSize="28"
    FontAttributes="Bold" />
```

Typography remains controlled by your .NET MAUI styles, so define a clear type scale for display, title, body, and supporting text.

### Image

`Image` keeps the familiar .NET MAUI API while receiving the Android handler updates included in the Material 3 effort:

```xml
<Image
    Source="dotnet_bot.png"
    HeightRequest="120"
    Aspect="AspectFit" />
```

Use `ImageButton` instead when the image represents an action.

### Shell

Material 3 support also extends to Shell navigation on Android. Bottom tabs use Material 3 bottom navigation, top tabs use Material 3 tab layout, and badges use Material badge rendering.

```xml
<Shell
    x:Class="Material3Gallery.AppShell"
    FlyoutBehavior="Disabled">
  <TabBar>
    <ShellContent
        Title="Controls"
        Icon="controls.svg"
        ContentTemplate="{DataTemplate local:MainPage}" />
    <ShellContent
        Title="About"
        Icon="about.svg"
        ContentTemplate="{DataTemplate local:AboutPage}" />
  </TabBar>
</Shell>
```

Material bottom navigation supports up to five directly visible destinations. Design the navigation hierarchy accordingly.

## Assemble the control gallery

The accompanying sample groups the controls into five cards:

1. Text input: `Entry`, `Editor`, and `SearchBar`.
2. Selection: `CheckBox`, `RadioButton`, and `Switch`.
3. Pickers: `Picker`, `DatePicker`, and `TimePicker`.
4. Progress and value: `ActivityIndicator`, `ProgressBar`, and `Slider`.
5. Images and actions: `Image`, `ImageButton`, `Button`, and `Label`.

A second Shell tab demonstrates Material 3 bottom navigation.

> **Screenshot placeholder:** Add a portrait Android screenshot showing the text input and selection cards.

> **Screenshot placeholder:** Add a portrait Android screenshot showing the picker, progress, and action cards.

> **Screenshot placeholder:** Add a light-theme and dark-theme comparison of the completed app.

Run the Android app with:

```bash
dotnet build -t:Run -f net11.0-android
```

## Customize public Material 3 helper types

While .NET 10 servicing releases provide opt-in Material 3 rendering, the underlying customization surface was not public. In .NET MAUI 11, the Material 3 handlers and Android helper types are public, allowing advanced applications to subclass the platform views and provide a custom `PlatformViewFactory`.

Public helper types include:

- `MauiMaterialEditText`
- `MauiMaterialPicker`
- `MauiMaterialDatePicker`
- `MauiMaterialTimePicker`
- `MauiMaterialSearchBarTextInputLayout`
- `MauiMaterialTextView`
- `MaterialActivityIndicator`
- `MauiMaterialContextThemeWrapper`

Use this extension point only when app-level styles and handler mappings are not sufficient. A custom platform view factory replaces the handler's default platform-view creation, so it must preserve the required Material theme wrapper and control-specific initialization.

## Migration considerations

Before enabling Material 3 in an existing application, review the following points:

- **Android-only behavior:** Other platforms retain their native appearance.
- **Visual changes:** Shapes, spacing, dialogs, tracks, thumbs, and state layers can change.
- **Date constraints:** `DatePicker` constraints cannot change while its dialog is open.
- **Navigation limits:** Material bottom navigation should contain no more than five primary destinations.
- **Regression testing:** Compare important pages before and after enabling the property.
- **Preview status:** Revalidate package versions and behavior when upgrading to a newer preview or the final .NET 11 release.

Because Material 3 is opt-in, you can migrate one development branch at a time and compare it with the Material 2 version before release.

## Conclusion

Material 3 support modernizes .NET MAUI Android applications without requiring developers to abandon the cross-platform control model. By setting one build property and testing the resulting visual changes, an existing application can adopt Material 3 while iOS, Mac Catalyst, and Windows continue to use their native design systems.

The Syncfusion contribution team helped deliver this support across the build system, controls, Shell navigation, tests, and follow-up fixes. .NET 11 Preview 7 provides an excellent opportunity to evaluate the experience and prepare applications for the final .NET 11 release.

## References

- [Material 3 in .NET MAUI](https://learn.microsoft.com/dotnet/maui/user-interface/material-design?view=net-maui-11.0)
- [What's new in .NET MAUI for .NET 11](https://learn.microsoft.com/dotnet/maui/whats-new/dotnet-11?view=net-maui-11.0)
- [.NET MAUI 11 Preview 7 release notes](https://github.com/dotnet/core/blob/main/release-notes/11.0/preview/preview7/dotnetmaui.md)
- [Material 3 tracking issue](https://github.com/dotnet/maui/issues/33063)
- [.NET MAUI repository](https://github.com/dotnet/maui)
