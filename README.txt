Roco Url Shorten Service
Version: 1.0.0.0 Build 1
BuildNumber: Build1_20140106_x86_x64_winmain_linuxmain_userdebug_nokey
Build User: Roco@Roco-PC #1

tarball.tar.gz: Tarball of Source Code
tar: Source Code

============================================================================
                   LICENSE OF ROCO URL SHORTEN SERVICE
============================================================================
1. Roco URL Service is free and open source
2. Everyone can copy,rebuild,redistribute,repackage,modify the code to 
   make your own URL Shorten Service
3. This License is not compactible with LGPL,GPL,Apache Licenses.
----------------------------------------------------------------------------

============================================================================
                                INSTALL GUIDE
============================================================================
WEB SERVER : IIS 7.0 or above(Windows),Apache 2.0 or above(Linux)
Database: SQL SERVER 2008 or above(SQL Server 2012 recommended)
Runtime: .NET Framework 4.0 or above(Windows),Mono Framework 4.0 Mode(Linux)
Install Steps:
Windows Version:
Copy Source Code into D:\www\ or other place which is not in Drive C
Add a site point to the directory which one you placed the source
Linux Version:
Copy Source Code into /var/www or your Apache Web Root directory.
Install Mono via your linux package manager,and set it into 4.0 mode.
IMPORTANT: You must add your SQL SERVER connection into Resource.resx and 
           Build once before you install the source.
           After install the source,you must add Web.Config and Set * to 
           ShortUrlHandlerFactory without file detection
----------------------------------------------------------------------------
