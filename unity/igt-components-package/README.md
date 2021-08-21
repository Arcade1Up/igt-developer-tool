# THE INFINITY GAME TABLE Developer Tools

## Infinity Game Table Components for Unity (package)

Install into Unity to quickly add Infinity Game Table components such as a Settings menu.

- Check out this repository to your local disk
- Open Unity project
- Open `Package Manager` (`Window` > `Package Manager`)
- Click `+` in the upper left corner of the `Package Manager` window
  - Select `Add package from disk...`
  - Navigate to the `igt-components-package` directory in your local copy of this repository
  - Select the `package.json` in this directory and click `open`
  - This will install the package into your project under `Packages` > `Infinity Game Table`
- To install a sample scene, expand the `Samples` section in the content pane of the `Package Manager`
  - Click `Import` next to the `Sample Scene` sample
  - This will install the sample into your project under `Assets` > `Samples` > `Infinity Game Table`

## Components

### Settings

The Settings component includes a settings button, which will launch a settings menu. This menu includes options
for displaying the "how to play" screen, a button to return home (the title screen) for the game, a button to
return to the Infinity Game Table dashboard, and audio buttons for enabling/disabling both the SFX and music within
a game.

To add the Settings component to your game, drag an instance of `Packages` > `Infinity Game Table` > `Runtime` >
`Settings` > `Settings` _(prefab)_ to your game hierarchy.

As a developer, you can wire up your own custom actions on the root settings prefab to integrate the system into
your game.

To edit the "how to play" instructions, add the Settings prefab to your scene and navigate to
`Settings` > `Settings Controller` > `How to Play Panel` > `Content` > `How to Play`. You can edit this container
if you need more or less space for your instructions, need to add more content, a scroller, etc. Edit the content
within `Edit Instructions Here` to change the actual text (or replace with your own content items).
