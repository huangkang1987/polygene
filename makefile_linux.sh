echo 'Removing previous compiled executables'
rm bin/PolyGene.linux
rm bin/dre.so


echo 'Compiling dre.so'
cd dre
g++ -fPIC -shared dre.cpp -o dre.so -O3 -march=x86-64 -msse2
cd ..
mv dre/dre.so bin/dre.so

echo 'Compiling PolyGene.linux.exe'
cd src
xbuild /p:Configuration=Release "/p:Platform=Any CPU"  PolyGene.sln
mv bin/Release/PolyGene.exe ../bin/PolyGene.linux.exe

echo 'Making PolyGene.linux'
cd ../bin
mkbundle --deps --static -z -o PolyGene.linux PolyGene.linux.exe MathNet.Numerics.dll --simple --machine-config /etc/mono/4.5/machine.config --no-config


echo 'Finished, use the command ./PolyGene.linux to launch'