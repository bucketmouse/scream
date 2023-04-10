# ScreamReader
is a C# (.Net/WindowsForms) tray-application that can receive and play back Wave-streams as broadcasted by `scream`.  It uses `NAudio` to play back sound.

ScreamReader indicates its status via a red X on its tray icon and can be toggled on and off via the right-click menu. 

It also has an option to automatically attempt reconnection if disconnected which can be toggled on and off in the settings dialog next to the volume control.

## Building
Make sure to restore all *NuGet*-packages prior to building to avoid any errors.
