@echo off
title Compiling pi.exe
echo Compiling pi.exe
\Windows\Microsoft.NET\Framework\v4.0.30319\csc /nologo /out:pi.exe /t:winexe /win32icon:Art\p.ico /res:Art\p.ico /res:Art\Spritesheet.png /res:Sounds\Fart1.wav /res:Sounds\Fart2.wav /res:Sounds\Fart3.wav /res:Sounds\FartWithReverb.wav /res:Sounds\DiseasedFart.wav Code\*.cs
echo Completing Process...
pause