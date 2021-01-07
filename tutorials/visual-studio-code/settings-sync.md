---
PermaID: 100017
Name: Settings Sync
---

# Settings Sync

Settings Sync lets you share your Visual Studio Code configurations such as settings, keybindings, and installed extensions across your machines so you are always working with your favorite setup.

You can turn on **Settings Sync** using the **Turn On Settings Sync...** entry in the **Manage** gear menu at the bottom of the **Activity Bar**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/settings-sync-1.png">

You will be asked to sign in and what preferences you would like to sync; currently Settings, Keyboard Shortcuts, Extensions, User Snippets, and UI State are supported.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/settings-sync-2.png">

Selecting the **Sign in & Turn on** button will ask you to choose between signing in with your **Microsoft** or **GitHub** account.

After signing in to the **GitHub** account, **Settings Sync** will be turned on and continue to synchronize your preferences automatically in the background.

## Check the Sync Details

You can check the status of your latest syncs by opening the **Command Palette** and run the **Settings Sync: Show Synced Data** command.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/settings-sync-3.png">

## Real-Time Sync

If you get this set up on two different instances of VS Code you can see that changing settings on one will update the settings on another in real-time.

## Conflicts

When synchronizing settings between multiple machines, there may occasionally be conflicts. Conflicts can happen when first setting up sync between machines or when settings change while a machine is offline. When conflicts occur, you will be presented with the following options.

 - **Accept Local:** Selecting this option will overwrite remote settings in the cloud with your local settings.
 - **Accept Remote:** Selecting this option will overwrite local settings with remote settings from the cloud.
 - **Show Conflicts:** Selecting this will display a diff editor similar to the Source Control diff editor, where you can preview the local and remote settings and choose to either accept local or remote or manually resolve the changes in your local settings file and then accept the local file.

## Switching Accounts

If at any time you want to sync your data to a different account, you can turn it off and turn on **Settings Sync** again with a different account.