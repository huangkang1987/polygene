echo 'For Mac OS X before 10.14, compile 32bits executables'

echo 'Removing previous compiled executables'
rm bin/PolyGene.mac
rm bin/PolyGene.mac.exe
rm bin/dre.dylib

echo 'Compiling dre.dylib'
cd dre
g++ -dynamiclib dre.cpp -o dre.dylib -O3 -m32 -msse2 -mavx2
cd ..
mv dre/dre.dylib bin/dre.dylib

echo 'Compiling PolyGene.mac.exe'
cd src
xbuild /p:Configuration=Release "/p:Platform=Any CPU" PolyGene.sln
mv bin/Release/PolyGene.exe ../bin/PolyGene.mac.exe

echo 'Making PolyGene.mac'
cd ../bin
# mkbundle --fetch-target mono-6.6.0-osx-10.9-i386
mkbundle --cross mono-6.6.0-osx-10.9-i386 -o PolyGene.mac --deps --static -z PolyGene.mac.exe MathNet.Numerics.dll -L /Library/Frameworks/Mono.framework/Versions/Current/lib/mono/4.5


echo 'Finished, use the command ./PolyGene.mac to launch'

