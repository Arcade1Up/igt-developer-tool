# THE INFINITY GAME TABLE Developer Tools

## Welcome

<a href="https://infinitygametable.com/">The Infinity Game Table</a> ("IGT" for short) was designed and created by the gamers at <a href="https://arcade1up.com/">Arcade1Up™</a> — the #1 at-home arcade company, who partnered with Hasbro™ the — the #1 name in board games, to take board game entertainment to the next level.  

The page is intended to help developers to get started on games development on The Infinity Game Table. 

## Quick Links

[Technical Specification](#technicalspec)  
[Overview](#overview)  
[Game Life Cycle](#gamelifecycle)  
[In-Game Menu](#ingamemenu)  
[Control the Rumble Motor](#controlmotor)  
[Sample Game](#samplegame)  
[Multiplayer SDK](#multiplayer)  
[In-App Purchase](#iap)

## <a name="technicalspec"></a>Technical Specification
| Item        | Spec           |
| :------------- |:------------- |
| **CPU** | RockChip RK3368 Octa-core Cortex-A53 1.5GHz |
| **GPU** | PowerVR G6110 |
| **Memory** | 16GB + TF Card Slot |
| **RAM** | DDR3 2GB |
| **WiFi** | 2.4G |
| **Screen Sizes** | 24" and 32" |
| **Operating System** | Android 9 |
| **Screen Resolution** | 1920x1080 |
| **Aspect Ratio** | 16:9 |
| **Touch Support** | G+G capacitive Touch-10 Points |
| **Google Play Service** | Not available |

## <a name="overview"></a>Overview
IGT automatically boots into our Dashboard application which user will use it to browse our games store, download games and manage their downloaded games. Developing games on IGT is no difference than typical Android games development except Google Play Service is not supported on IGT.  
  
Refer to the below sections for more information.

## <a name="gamelifecycle"></a>Game Life Cycle
User can launch any downloaded games from their Dashboard. Games life cycle management is exactly the same as typical Android application except **there is no hardware or software back button on IGT**. Developers will have to provide a software button for users to quit the game and head back to the IGT Dashboard simply by calling
```
getActivity().finish();
System.exit(0);
```

## <a name="ingamemenu"></a>In-Game Menu
Coming soon.

## <a name="controlmotor"></a>Control the Rumble Motor
Coming soon.

## <a name="samplegame"></a>Sample Game
Coming soon.

## <a name="multiplayer"></a>Multiplayer SDK
Coming soon.

## <a name="iap"></a>In-App Purchase
Coming soon.