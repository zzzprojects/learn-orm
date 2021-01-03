---
PermaID: 100003
Name: Installation on Linux
---

# Installation on Linux

Microsoft did the unexpected by releasing Visual Studio Code for all major desktop platforms that include Linux as well. Visual Studio Code is officially distributed as a Snap package in the [Snap Store]().

You can install it by running the following command.

```csharp
sudo snap install --classic code # or code-insiders
```

Once installed, the Snap daemon will take care of automatically updating Visual Studio Code in the background. You will get an in-product update notification whenever a new update is available.

## Debian and Ubuntu-based Distributions

The easiest way to install Visual Studio Code for Debian/Ubuntu-based distributions by using the `apt manager`. Download the `.deb` package (64-bit) from the [Visual Studio Code's official website](https://code.visualstudio.com/Download) and run the following command.

```csharp
sudo apt install ./<file>.deb

# If you're on an older Linux distribution, you will need to run this instead:
# sudo dpkg -i <file>.deb
# sudo apt-get install -f # Install dependencies
```

Installing the `.deb` package will automatically install the apt repository and signing key to enable auto-updating using the system's package manager. 

You can also install the repository and key manually using the following script.

```csharp
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > packages.microsoft.gpg
sudo install -o root -g root -m 644 packages.microsoft.gpg /etc/apt/trusted.gpg.d/
sudo sh -c 'echo "deb [arch=amd64,arm64,armhf signed-by=/etc/apt/trusted.gpg.d/packages.microsoft.gpg] 
https://packages.microsoft.com/repos/code stable main" > /etc/apt/sources.list.d/vscode.list'
```

Then update the package cache and install the package using the following command.

```csharp
sudo apt install apt-transport-https
sudo apt update
sudo apt install code # or code-insiders
```

Once installed, use the application manager to search Visual Code Studio and launch it as shown.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-linux-1.png">

## openSUSE and SLE-based distributions#

Currently, the stable 64-bit Visual Studio Code is shipped in a yum repository, you can install the key and repository using the following script.

```csharp
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo sh -c 'echo -e "[code]\nname=Visual Studio Code\nbaseurl=https://packages.microsoft.com/yumrepos/vscode\nenabled=1\ntype=rpm-md\ngpgcheck=1\ngpgkey=https://packages.microsoft.com/keys/microsoft.asc" > /etc/zypp/repos.d/vscode.repo'
```

Then update the package cache and install the package using the following command.

```csharp
sudo zypper refresh
sudo zypper install code
```

## RHEL, Fedora, and CentOS-based Distributions

You can install the key and repository using the following script.

```csharp
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo sh -c 'echo -e "[code]\nname=Visual Studio Code\nbaseurl=https://packages.microsoft.com/yumrepos/vscode\nenabled=1\ngpgcheck=1\ngpgkey=https://packages.microsoft.com/keys/microsoft.asc" > /etc/yum.repos.d/vscode.repo'
```
Then update the package cache and install the package using `dnf` (Fedora 22 and above).

```csharp
sudo dnf check-update
sudo dnf install code
```

On older versions using yum, run the following commands.

```csharp
yum check-update
sudo yum install code
```

Due to the manual signing process and the system we use to publish, the yum repo may lag behind and not get the latest version of Visual Studio Code immediately.
