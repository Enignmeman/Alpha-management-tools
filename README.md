# Alpha-management-tools
Paint.NET plugins to help manage the transparency of images that are textures dumped by PCSX2 or that are replacement textures for PCSX2-compatible texture packs.

## Table of contents
- [Table of contents](#table-of-contents)
- [What is this?](#what-is-this)
- [Installing](#installing)
- [Usage](#usage)
  - [Fixing transparency of dumped textures](#fixing-transparency-of-dumped-textures)
  - [Fixing transparency for texture packs](#fixing-transparency-for-texture-packs)
<!--
- [Building from source](#building-from-source)
-->
- [Notes](#notes)
- [Changelogs](#Changelogs)
  - [modern to PS2.cs](#modern-to-ps2-cs)
  - [PS2 to modern.cs](#ps2-to-modern-cs)

## What is this?
[PCSX2](https://pcsx2.net/) allows users to dump the textures present on screen, as well as use texture packs to change textures of the game (usually, this feature is used for HD or 4K texture packs).

However, when someone tries to open these files, they are around 50% transparent.  
This is because these textures likely use 7bits for the Alpha value of pixels, which means 128 different Alpha values, opposed to 256 (8bits) different values that nearly all modern image editing software uses.

## Installing
1. Download the latest `PCSX2AlphaFixer.zip` from the releases page
2. Unzip it
3. Run `Install_PSX2AlphaFixer.bat`
4. Start/restart Paint.NET to use the plugin

## Usage

### Fixing transparency of dumped textures
1. Open a texture dumped by PCSX2
2. Click on `Effects > Advanced > PCSX2 Dumped Texture Alpha Fixer`
3. Done

### Fixing transparency for texture packs
1. Open a texture you want to use for a texture pack (that isn't already at the right transparency)
2. Click on `Effects > Advanced > PCSX2 Texture Replacement Alpha Fixer`
3. Choose what kind of Alpha values you want (`0 to 127` or `0 or 128`)
4. Click on OK and it's done

<!--
## Building from source
> /!\ You will need [CodeLab](https://boltbait.com/pdn/CodeLab/) to build using the files in this repository.
-->

## Notes

Something like this maybe has been made already, or there are tutorials about this issue, but I prefer doing things this way rather than have to search I don't know where for good information.

I made this using [CodeLab](https://boltbait.com/pdn/CodeLab/).

## Changelogs
### PS2 to modern.cs
<details>
<summary>1.2 - Misc changes</summary>
Updated metadada
</details>
<details>
<summary>1.1 - Compatibility update</summary>
Added support to processing from pictures with two transparency values (Alpha being 0 or 128)
</details>
<details>
<summary>1.0 - Initial version</summary>
Supports processing from pictures with multiple transparency values (Alpha can be anything from 0 to 127)
</details>
 
 
### Fixing transparency for texture packs
<details>
<summary>2.1 - Misc changes</summary>
Updated metadada
Fixed a logic issue
</details>
<details>
<summary>2.0 - Compatibility update</summary>
Added support to processing to pictures with two transparency values (Alpha being 0 or 128)  
Added UI 
</details>
<details>
<summary>1.0 - Initial version</summary>
Supports processing to pictures with multiple transparency values (Alpha can be anything from 0 to 127)
</details>