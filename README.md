typescript-bug
==============

Reproducing an issue with typescript compiler
The solution contains 2 projects:

**ChildProccess** - a console application that references TypeScriptLanguageService.dll   
The reference to a TypeScriptLanguageService.dll has intentionally CopyLocal=false to 
prevent the dll to be copied in the wrong folder. But the probing path is set to TypeScript. 
For that to work you have to manually set OutputDir for this project to the folder 
C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\ _(adjust if you have another vs installation folder)_

This projects writes FileHelpers.GetSetupLocation() to the output.

**TypeScriptServicesHost** - a console application that creates new application domain which runs ChildProcess.exe and have shadow-copy 

So if you run ChildProcess you'll see C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\TypeScript in the output.

But if you run TypeScriptServicesHost you'll see something like C:\Users\v.makaev\AppData\Local\assembly\dl3\VTYCJYCB.51X\JT6B6H89.PM2\06a7bfe7\

_(Hint: to fix the bug you'll probably need to use Assembly.GetExecutingAssembly().CodeBase in the GetSetupLocation but I'm not sure)_
