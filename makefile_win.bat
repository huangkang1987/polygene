call vcvars.bat amd64
del bin\dre.dll
cd dre
del dre.dll
cl.exe /c /nologo /O2 /Ot /Oy- /w /EHsc /MT /GS- /Gy- /fp:precise /D_USE_MATH_DEFINES /openmp /MP4 dre.cpp
link.exe /dll dre.obj
del dre.exp
del dre.lib
del dre.obj
cd ..
move dre\dre.dll bin\dre.dll

%WinDir%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe /p:Configuration=Release_x64 /p:Platform=x64 PolyGene.sln
move PolyGene\bin\Release_x64\PolyGene.exe bin\PolyGene.exe
pause