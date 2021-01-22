# MorePrecisePlayerHeight
A very small Beat Saber mod that's let you view your own height with higher precision... at least one more decimal.

## Installation
Installation is fairly simple.
1. Grab the latest plugin release from the [releases page](https://github.com/ErisApps/MorePrecisePlayerHeight/releases)
2. Drop the .dll file in the Plugins folder of your Beat Saber installation.
3. Boot it up (or reboot)

## Developers
To build this project you will need to create a `MorePrecisePlayerHeight/MorePrecisePlayerHeight.csproj.user` file specifying where the game is located:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <!-- Change this path if necessary. Make sure it doesn't end with a backslash. -->
    <BeatSaberDir>D:\Program Files (x86)\Steam\steamapps\common\Beat Saber</BeatSaberDir>
  </PropertyGroup>
</Project>
```
