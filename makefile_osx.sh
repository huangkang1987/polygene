rm bin/PolyGene.mac
rm bin/dre.dylib

cd dre
g++ -dynamiclib dre.cpp -o dre.dylib -O3 -m32 -msse2
cd ..
mv dre/dre.dylib bin/dre.dylib

xbuild /p:Configuration=Release_x86 /p:Platform=x86 PolyGene.sln
mv PolyGene/bin/Release_x86/PolyGene.exe bin/PolyGene.exe

cd bin
mkbundle --fetch-target mono-6.6.0-osx-10.9-i386  --target-server http://192.168.214.1/
mkbundle --cross mono-6.6.0-osx-10.9-i386 -o PolyGene.mac --deps --static -z PolyGene.exe MathNet.Numerics.dll -L /Library/Frameworks/Mono.framework/Versions/Current/lib/mono/4.5
rm PolyGene.exe
cd ..
