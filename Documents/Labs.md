# Information regarding the labs for 20483 (C#)

I've written a few notes here for you to help  when it comes to doing the labs. There are a few key things to keep in mind:

1. The lab environment runs on a Virtual Machine in the cloud. All of the labs have a timeout and when that  timeout expires everything on the Virtual Machine is destroyed. Consequently, if you want to keep any work you've done you need to store it elsewhere. I'll show you how to do that using github.
2. The labs are located here: https://ddls.learnondemand.net. From this location You'll launch a Virtual machine running Windows 10.
3. On the **desktop** of the Virtual Machine you'll find a folder called **LabFiles\AllFiles**. This folder has the starter and solution for every lab in the course.
4. To run Visual Studio on the lab virtual machines you will need to sign in to Visual Studio. You can either sign-in with an existing Microsoft account or create a new one for the course by visiting https://www.outlook.com.
5. Don't follow the lab instructions in the course notes, those are out-of-date. Be sure to follow the instructions in the lab environment.
6. **Every time** you launch a new lab environment I'd like you to run a script I've written to install additional software. The lab environments were created several years ago and it would be good to bring a few things up-to-date. The instructions for running the script are below:
 
## Do this every time you start a new lab environment (takes about 15 minutes)
1. run **cmd.exe** from the Windows  Start button.
2. Run the command **git clone https://github.com/Mark-AIICT/CAD-2.git C:\Users\Admin\Desktop\MarksFiles**
3. Navigate to **C:\Users\Admin\Desktop\MarksFiles\setups**, then right-mouse click **bootstrap.cmd** and **run as administrator**
4. After running the above you'll see that it reboots the Virtual Machine. That's necessary.
5. After it restarts, login and run **cmd.exe** as administrator. Type the following command and press enter **git credential-manager-core configure**

6. Change your default browser to google chrome by typing **default app settings** from the windows start button. (I would have liked to install the latest version of the Microsoft Edge browser but it isn't compatible the the version of Windows in the lab).